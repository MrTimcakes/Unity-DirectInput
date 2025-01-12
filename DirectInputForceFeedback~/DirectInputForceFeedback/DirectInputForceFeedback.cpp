// DirectInputForceFeedback.cpp : Defines the exported functions for the DLL.
#include "pch.h"
#include <algorithm>  // for std::clamp
#include <limits>    // for UINT16_MAX
#include "DirectInputForceFeedback.h"

typedef std::string DeviceGUID; // Alias to make it clearer what maps below use as key

std::vector< DeviceInfo >                                               _DeviceInstances;         // Store devices available for connection
std::map   < DeviceGUID, LPDIRECTINPUTDEVICE8 >                         _ActiveDevices;           // Store all of the connected devices
std::map   < DeviceGUID, std::vector<DIEFFECTINFO> >                    _DeviceEnumeratedEffects; // Store the available FFB Effects for devices
std::map   < DeviceGUID, std::vector<DIDEVICEOBJECTINSTANCE> >          _DeviceFFBAxes;           // Store the Axes available for FFB
std::map   < DeviceGUID, std::map<Effects::Type, DIEFFECT> >            _DeviceFFBEffectConfig;   // Effect Configuration
std::map   < DeviceGUID, std::map<Effects::Type, LPDIRECTINPUTEFFECT> > _DeviceFFBEffectControl;  // Handle to Start/Stop Effect

DeviceChangeCallback _DeviceChangeCallback; // External function to invoke on device change

std::vector<std::wstring> DEBUGDATA; // Used for Debugging during development

//////////////////////////////////////////////////////////////
// DLL Exported Functions
//////////////////////////////////////////////////////////////

// Create the _DirectInput global
HRESULT StartDirectInput() {
	if (_DirectInput != NULL) { return S_OK; } // Already initialised

	// Setup Device Change Detection (Add/Remove Device Events)
	SetWindowsHookExW(WH_CALLWNDPROC, (HOOKPROC)&_WindowsHookCallback, GetModuleHandleW(NULL), GetCurrentThreadId());

	return DirectInput8Create( // Create DirectInput
		GetModuleHandle(NULL),
		DIRECTINPUT_VERSION,
		IID_IDirectInput8,
		(void**)&_DirectInput, // Place our DirectInput instance in _DirectInput
		NULL
	);
}

// Stop _DirectInput
HRESULT StopDirectInput() {
	HRESULT hr = E_FAIL;
	if (_DirectInput == NULL) { return hr = S_OK; } // No DirectInput Instance

	for (const auto& [GUIDString, Device] : _ActiveDevices) { // For each device
		// TODO: Stop Effects?
		if (FAILED(hr = Device->Unacquire())) { return hr; }
	}

	_DeviceInstances.clear();
	_ActiveDevices.clear();
	_DeviceEnumeratedEffects.clear();
	_DeviceFFBAxes.clear();
	_DeviceFFBEffectConfig.clear();
	_DeviceFFBEffectControl.clear();

	_DirectInput = NULL;

	return hr;
}

// Return a vector of all attached devices
DeviceInfo* EnumerateDevices(/*[out]*/ int& deviceCount) {
	HRESULT hr = E_FAIL;
	if (_DirectInput == NULL) { return NULL; } // If DI not ready, return nothing
	_DeviceInstances.clear();                  // Clear devices

	// First fetch all devices
	hr = _DirectInput->EnumDevices(    // Invoke device enumeration to the _EnumDevicesCallback callback
		DI8DEVCLASS_GAMECTRL,                    // List devices of type GameController
		_EnumDevicesCallback,                    // Callback executed for each device found
		NULL,                                    // Passed to callback as optional arg
		DIEDFL_ATTACHEDONLY //| DIEDFL_FORCEFEEDBACK
	);

	// Next update FFB devices (Important this happens after as it modifies existing entries)
	hr = _DirectInput->EnumDevices(    // Invoke device enumeration to the _EnumDevicesCallback callback
		DI8DEVCLASS_GAMECTRL,                    // List devices of type GameController
		_EnumDevicesCallbackFFB,                 // Callback executed for each device found
		NULL,                                    // Passed to callback as optional arg
		DIEDFL_ATTACHEDONLY | DIEDFL_FORCEFEEDBACK
	);

	if (_DeviceInstances.size() > 0) {
		deviceCount = (int)_DeviceInstances.size();
		return &_DeviceInstances[0]; // Return 1st element, structure size & deviceCount are used to find next elements
	}
	else {
		deviceCount = 0;
	}
	return NULL;
}

// Create the DirectInput Device and Acquire ready for State retreval & FFB Effects (Requires Cooperation level Exclusive)
// Pass the GUID (as a string) of the Device you'd like to attach to, GUID obtained from the Enumerated Devices 
HRESULT CreateDevice(LPCSTR guidInstance) {
	HRESULT hr;
	DestroyDeviceIfExists(guidInstance); // If device exists, clear it first

	LPDIRECTINPUTDEVICE8 DIDevice;
	if (FAILED(hr = _DirectInput->CreateDevice(LPCSTRGUIDtoGUID(guidInstance), &DIDevice, NULL))) { return hr; }
	if (FAILED(hr = DIDevice->SetDataFormat(&c_dfDIJoystick2))) { return hr; }
	if (FAILED(hr = DIDevice->SetCooperativeLevel(FindMainWindow(GetCurrentProcessId()), DISCL_EXCLUSIVE | DISCL_BACKGROUND))) { return hr; }
	if (FAILED(hr = DIDevice->Acquire())) { return hr; }

	std::string GUIDString((LPCSTR)guidInstance); // Convert the LPCSTR to a STL String for use as key in map (String as GUID has no operater<)
	_ActiveDevices[GUIDString] = DIDevice; // Store Device in _ActiveDevices Map to be referenced later

	return hr;
}

// Remove the DirectInput Device, Unacquire and remove from ActiveDevices
HRESULT DestroyDevice(LPCSTR guidInstance) {
	HRESULT hr = E_FAIL;
	std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail

	StopAllFFBEffects(guidInstance);
	if (SUCCEEDED(hr = _ActiveDevices[GUIDString]->Unacquire())) {
		_ActiveDevices.erase(GUIDString);
	}

	return hr;
}

// Fetch the Device State, give GUID of the Device (Must already be created by CreateDevice) and out FlatJoyState2
HRESULT GetDeviceState(LPCSTR guidInstance, /*[out]*/ FlatJoyState2& deviceState) {
	HRESULT hr = E_FAIL;
	std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail

	DIJOYSTATE2 DeviceStateRaw = {};
	hr = _ActiveDevices[GUIDString]->GetDeviceState(sizeof(DIJOYSTATE2), &DeviceStateRaw); // Fetch the device State
	deviceState = FlattenDIJOYSTATE2(DeviceStateRaw); // Convert to a friendlier format (Nested arrays are more difficult to check for change)

	return hr;
}

// Fetch the Device State, give GUID of the Device (Must already be created by CreateDevice) and out DIJOYSTATE2
HRESULT GetDeviceStateRaw(LPCSTR guidInstance, /*[out]*/ DIJOYSTATE2& deviceState) {
	HRESULT hr = E_FAIL;
	std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail

	hr = _ActiveDevices[GUIDString]->GetDeviceState(sizeof(DIJOYSTATE2), &deviceState); // Fetch the device State

	return hr;
}

// Fetch the capabilities of the device, returns DIDEVCAPS see https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ee416607(v=vs.85)
HRESULT GetDeviceCapabilities(LPCSTR guidInstance, /*[out]*/ DIDEVCAPS& deviceCapabilitiesOut) {
	HRESULT hr = E_FAIL;
	std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail

	DIDEVCAPS DeviceCapabilities;
	DeviceCapabilities.dwSize = sizeof(DIDEVCAPS);
	hr = _ActiveDevices[GUIDString]->GetCapabilities(&DeviceCapabilities);
	deviceCapabilitiesOut = DeviceCapabilities;

	return hr;
}

// Generate SAFEARRAY of ActiveDevice GUIDs
HRESULT GetActiveDevices(/*[out]*/ SAFEARRAY** activeGUIDs) {
	HRESULT hr = E_FAIL;

	std::vector<std::wstring> SAData;
	for (const auto& [GUIDString, Device] : _ActiveDevices) {
		SAData.push_back(string_to_wstring(GUIDString));
	}

	hr = BuildSafeArray(SAData, activeGUIDs);
	return hr;
}

// Set the Autocenter property for a DI device, pass device GUID and bool to enable or disable
HRESULT SetAutocenter(LPCSTR guidInstance, bool AutocenterState) {
	HRESULT hr = E_FAIL;
	std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail
	DIPROPDWORD DIPropAutoCenter = {};

	DIPropAutoCenter.diph.dwSize = sizeof(DIPropAutoCenter);
	DIPropAutoCenter.diph.dwHeaderSize = sizeof(DIPROPHEADER);
	DIPropAutoCenter.diph.dwObj = 0;
	DIPropAutoCenter.diph.dwHow = DIPH_DEVICE;
	DIPropAutoCenter.dwData = AutocenterState ? DIPROPAUTOCENTER_ON : DIPROPAUTOCENTER_OFF;

	hr = _ActiveDevices[GUIDString]->SetProperty(DIPROP_AUTOCENTER, &DIPropAutoCenter.diph);

	return hr;
}

// Generate SAFEARRAY of possible FFB Effects for this Device
HRESULT EnumerateFFBEffects(LPCSTR guidInstance, /*[out]*/ SAFEARRAY** FFBEffects) {
	HRESULT hr = E_FAIL;
	std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail

	_DeviceEnumeratedEffects[GUIDString].clear(); // Clear effects for this device
	hr = _ActiveDevices[GUIDString]->EnumEffects(&_EnumFFBEffectsCallback, &GUIDString, DIEFT_ALL); // Callback adds each effect to _DeviceEnumeratedEffects with key as device's GUID

	// Generate SafeArray of supported effects
	std::vector<std::wstring> SAData; // Store what will be in the SafeArray
	for (const auto& Effect : _DeviceEnumeratedEffects[GUIDString]) {
		SAData.push_back(Effect.tszName); // Add each effect name
	}
	hr = BuildSafeArray(SAData, FFBEffects);

	return hr;
}

// Generate SAFEARRAY of possible FFB Effects for this Device
HRESULT EnumerateFFBAxes(LPCSTR guidInstance, /*[out]*/ SAFEARRAY** FFBAxes) {
	HRESULT hr = E_FAIL;
	std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail

	_DeviceFFBAxes[GUIDString].clear(); // Clear Axes info for this device
	hr = _ActiveDevices[GUIDString]->EnumObjects(&_EnumFFBAxisCallback, &GUIDString, DIEFT_ALL); // Callback adds each effect to _DeviceFFBAxes with key as device's GUID

	// Generate SafeArray of FFB Axes
	std::vector<std::wstring> SAData; // Store what will be in the SafeArray
	SAData.push_back(L"FFB Axes: " + std::to_wstring(_DeviceFFBAxes.size()));
	for (const auto& ObjectInst : _DeviceFFBAxes[GUIDString]) {

		wchar_t szGUID[64] = { 0 };
		(void)StringFromGUID2(ObjectInst.guidType, szGUID, 64); // Void cast ignores [[nodiscard]] warning
		std::wstring guidType(szGUID);

		SAData.push_back(ObjectInst.tszName); // Add each effect name
		SAData.push_back(L"dwSize: " + std::to_wstring(ObjectInst.dwSize));
		SAData.push_back(L"guidType: " + guidType);
		SAData.push_back(L"dwOfs: " + std::to_wstring(ObjectInst.dwOfs));
		SAData.push_back(L"dwType: " + std::to_wstring(ObjectInst.dwType));
		SAData.push_back(L"dwFlags: " + std::to_wstring(ObjectInst.dwFlags));
		SAData.push_back(L"dwFFMaxForce: " + std::to_wstring(ObjectInst.dwFFMaxForce));
		SAData.push_back(L"dwFFForceResolution: " + std::to_wstring(ObjectInst.dwFFForceResolution));
		SAData.push_back(L"wCollectionNumber: " + std::to_wstring(ObjectInst.wCollectionNumber));
		SAData.push_back(L"wDesignatorIndex: " + std::to_wstring(ObjectInst.wDesignatorIndex));
		SAData.push_back(L"wUsagePage: " + std::to_wstring(ObjectInst.wUsagePage));
		SAData.push_back(L"wUsage: " + std::to_wstring(ObjectInst.wUsage));
		SAData.push_back(L"dwDimension: " + std::to_wstring(ObjectInst.dwDimension));
		SAData.push_back(L"wExponent: " + std::to_wstring(ObjectInst.wExponent));
		SAData.push_back(L"wReportId: " + std::to_wstring(ObjectInst.wReportId));
	}
	hr = BuildSafeArray(SAData, FFBAxes);

	return hr;
}

// Creates/Enables the Effect on the device 
HRESULT CreateFFBEffect(LPCSTR guidInstance, Effects::Type effectType) {
	HRESULT hr = E_FAIL;
	std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail

	if (_DeviceFFBEffectControl[GUIDString].contains(effectType)) { return E_ABORT; } // Effect Already Exists on Device

	//Enumerate FFBAxes if not already
	if (!_DeviceFFBAxes.contains(GUIDString)) {
		_DeviceFFBAxes[GUIDString].clear(); // Clear Axes info for this device
		hr = _ActiveDevices[GUIDString]->EnumObjects(&_EnumFFBAxisCallback, &GUIDString, DIEFT_ALL); // Callback adds each effect to _DeviceFFBAxes with key as device's GUID
	}



	int FFBAxesCount = (int)_DeviceFFBAxes[GUIDString].size();
	DWORD* FFBAxes = new DWORD[FFBAxesCount];
	LONG* FFBDirections = new LONG[FFBAxesCount];

	for (int idx = 0; idx < FFBAxesCount; idx++) {
		FFBAxes[idx] = AxisTypeToDIJOFS(_DeviceFFBAxes[GUIDString][idx].guidType); // FFB Axis GUID to DirectInput representation
		FFBDirections[idx] = 0; // Init this axis
	}

	// Create the Effect

	DICONSTANTFORCE* constantForce = NULL;
	DICONDITION* conditions = NULL;
	DIRAMPFORCE* rampForce = new DIRAMPFORCE();
	DIPERIODIC* periodicForce = new DIPERIODIC();
	DICUSTOMFORCE* customForce = new DICUSTOMFORCE();
	LPDIRECTINPUTEFFECT effectControl;
	DIEFFECT effect = {}; // https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ee416616(v=vs.85)
	effect.dwSize = sizeof(DIEFFECT);
	effect.dwFlags = DIEFF_CARTESIAN | DIEFF_OBJECTOFFSETS;
	effect.dwDuration = INFINITE;
	effect.dwSamplePeriod = 0;
	effect.dwGain = DI_FFNOMINALMAX;
	effect.dwTriggerButton = DIEB_NOTRIGGER;     // Start effect without requiring a button press
	effect.dwTriggerRepeatInterval = 0;
	effect.cAxes = FFBAxesCount;       // How many Axes will the effect be on (cannot be changed once it has been set)
	effect.rgdwAxes = FFBAxes;            // Identifies the axes to which the effects will be applied (cannot be changed once it has been set)
	effect.rglDirection = FFBDirections;      // Distribution of effect strength between Axes?
	effect.lpEnvelope = 0;
	effect.dwStartDelay = 0;



	switch (effectType) {
	case Effects::Type::ConstantForce:
		constantForce = new DICONSTANTFORCE();
		constantForce->lMagnitude = 0;
		effect.cbTypeSpecificParams = sizeof(DICONSTANTFORCE);
		effect.lpvTypeSpecificParams = constantForce;
		break;

	case Effects::Type::Spring:
		conditions = new DICONDITION[FFBAxesCount];
		ZeroMemory(conditions, sizeof(DICONDITION) * FFBAxesCount);
		effect.cbTypeSpecificParams = sizeof(DICONDITION) * FFBAxesCount;
		effect.lpvTypeSpecificParams = conditions;
		break;

	case Effects::Type::Damper:
		conditions = new DICONDITION[FFBAxesCount];
		ZeroMemory(conditions, sizeof(DICONDITION) * FFBAxesCount);
		effect.cbTypeSpecificParams = sizeof(DICONDITION) * FFBAxesCount;
		effect.lpvTypeSpecificParams = conditions;
		break;

	case Effects::Type::Friction:
		conditions = new DICONDITION[FFBAxesCount];
		ZeroMemory(conditions, sizeof(DICONDITION) * FFBAxesCount);
		effect.cbTypeSpecificParams = sizeof(DICONDITION) * FFBAxesCount;
		effect.lpvTypeSpecificParams = conditions;
		break;

	case Effects::Type::Inertia:
		conditions = new DICONDITION[FFBAxesCount];
		ZeroMemory(conditions, sizeof(DICONDITION) * FFBAxesCount);
		effect.cbTypeSpecificParams = sizeof(DICONDITION) * FFBAxesCount;
		effect.lpvTypeSpecificParams = conditions;
		break;
	case Effects::Type::Sine:
	case Effects::Type::Square:
	case Effects::Type::Triangle:
	case Effects::Type::SawtoothUp:
	case Effects::Type::SawtoothDown:
		ZeroMemory(periodicForce, sizeof(DIPERIODIC));
		periodicForce->dwMagnitude = 0;
		periodicForce->lOffset = 0;
		periodicForce->dwPhase = 0;
		periodicForce->dwPeriod = 30000;
		effect.cbTypeSpecificParams = sizeof(DIPERIODIC);
		effect.lpvTypeSpecificParams = periodicForce;
		break;
	case Effects::Type::RampForce:
		ZeroMemory(rampForce, sizeof(DIRAMPFORCE));
		rampForce->lStart = 0;
		rampForce->lEnd = 0;
		effect.cbTypeSpecificParams = sizeof(DIRAMPFORCE);
		effect.lpvTypeSpecificParams = rampForce;
		break;
	case Effects::Type::CustomForce: {
		FILE* debugFile;
		fopen_s(&debugFile, "ffb_custom_debug.txt", "a");
		fprintf(debugFile, "\n=== Custom Force Creation Debug ===\n");
		fprintf(debugFile, "Time: %s\n", __TIMESTAMP__);

		// Get device capabilities
		DIDEVCAPS deviceCaps = {};
		deviceCaps.dwSize = sizeof(DIDEVCAPS);
		if (FAILED(_ActiveDevices[GUIDString]->GetCapabilities(&deviceCaps))) {
			fprintf(debugFile, "Failed to get device capabilities\n");
			fclose(debugFile);
			return E_FAIL;
		}

		fprintf(debugFile, "Device Capabilities:\n");
		fprintf(debugFile, "- FFSamplePeriod: %lu microseconds\n", deviceCaps.dwFFSamplePeriod);
		fprintf(debugFile, "- FFMinTimeResolution: %lu\n", deviceCaps.dwFFMinTimeResolution);

		// Initialize custom force with proper parameters
		ZeroMemory(customForce, sizeof(DICUSTOMFORCE));
		customForce->cChannels = FFBAxesCount;  // Match actual axes count
		customForce->dwSamplePeriod = deviceCaps.dwFFSamplePeriod;
		customForce->cSamples = 2;  // At least two samples for interpolation

		// Allocate and initialize force data array
		LONG* forceData = new LONG[customForce->cSamples];
		forceData[0] = 0;    // Initial force
		forceData[1] = 5000; // Final force

		customForce->rglForceData = forceData;

		// Initialize effect structure
		ZeroMemory(&effect, sizeof(DIEFFECT));
		effect.dwSize = sizeof(DIEFFECT);
		effect.dwFlags = DIEFF_CARTESIAN | DIEFF_OBJECTOFFSETS;
		effect.dwDuration = INFINITE;
		effect.dwSamplePeriod = customForce->dwSamplePeriod;
		effect.dwGain = DI_FFNOMINALMAX;
		effect.dwTriggerButton = DIEB_NOTRIGGER;
		effect.dwTriggerRepeatInterval = 0;
		effect.cAxes = FFBAxesCount;
		effect.rgdwAxes = FFBAxes;
		effect.rglDirection = FFBDirections;
		effect.lpEnvelope = NULL;
		effect.cbTypeSpecificParams = sizeof(DICUSTOMFORCE);
		effect.lpvTypeSpecificParams = customForce;

		fprintf(debugFile, "\nCustom Force Parameters:\n");
		fprintf(debugFile, "- Channels: %lu\n", customForce->cChannels);
		fprintf(debugFile, "- Sample Period: %lu microseconds\n", customForce->dwSamplePeriod);
		fprintf(debugFile, "- Samples Count: %lu\n", customForce->cSamples);
		fprintf(debugFile, "- Force Data[0]: %ld\n", customForce->rglForceData[0]);
		fprintf(debugFile, "- Force Data[1]: %ld\n", customForce->rglForceData[1]);

		fprintf(debugFile, "\nEffect Configuration:\n");
		fprintf(debugFile, "- Effect Size: %lu\n", effect.dwSize);
		fprintf(debugFile, "- Type Specific Params Size: %lu\n", effect.cbTypeSpecificParams);
		fprintf(debugFile, "- Sample Period: %lu microseconds\n", effect.dwSamplePeriod);
		fprintf(debugFile, "- Duration: %lu\n", effect.dwDuration);
		fprintf(debugFile, "- Gain: %lu\n", effect.dwGain);
		fprintf(debugFile, "- Flags: 0x%08X\n", effect.dwFlags);

		HRESULT createResult = _ActiveDevices[GUIDString]->CreateEffect(
			EffectTypeToGUID(effectType),
			&effect,
			&effectControl,
			nullptr
		);

		fprintf(debugFile, "\nEffect Creation Result: 0x%08X\n", createResult);
		if (FAILED(createResult)) {
			fprintf(debugFile, "Failed to create custom force effect\n");
		}

		fclose(debugFile);
		return createResult;
		break;
	}

	default:
		return E_FAIL; // Unsupported Effect
	}

	
	if (FAILED(hr = _ActiveDevices[GUIDString]->CreateEffect(EffectTypeToGUID(effectType), &effect, &effectControl, nullptr))) { return hr; }
	if (FAILED(hr = effectControl->Start(1, 0))) { return hr; }
	_DeviceFFBEffectConfig[GUIDString][effectType] = effect;
	_DeviceFFBEffectControl[GUIDString][effectType] = effectControl;

	return hr;
}

HRESULT DestroyFFBEffect(LPCSTR guidInstance, Effects::Type effectType) {
	if (!guidInstance) return E_INVALIDARG;

	HRESULT hr = E_FAIL;
	std::string GUIDString((LPCSTR)guidInstance);

	// Validate device exists
	if (!_ActiveDevices.contains(GUIDString)) {
		return E_HANDLE;
	}

	// Validate effect control exists
	if (!_DeviceFFBEffectControl[GUIDString].contains(effectType)) {
		return S_OK; // Already destroyed
	}

	// Get effect pointer
	LPDIRECTINPUTEFFECT diEffect = _DeviceFFBEffectControl[GUIDString][effectType];
	if (!diEffect) {
		// Cleanup invalid state
		_DeviceFFBEffectControl[GUIDString].erase(effectType);
		_DeviceFFBEffectConfig[GUIDString].erase(effectType);
		return E_POINTER;
	}

	try {
		// Stop effect first
		hr = diEffect->Stop();
		if (FAILED(hr)) {
			// Log error but continue cleanup
			char buffer[256];
			sprintf_s(buffer, "Failed to stop effect: 0x%08X\n", hr);
			OutputDebugStringA(buffer);
		}

		// Unload effect resources
		hr = diEffect->Unload();
		if (FAILED(hr)) {
			char buffer[256];
			sprintf_s(buffer, "Failed to unload effect: 0x%08X\n", hr);
			OutputDebugStringA(buffer);
		}

		// Release the effect interface
		ULONG refCount = diEffect->Release();
		if (refCount > 0) {
			char buffer[256];
			sprintf_s(buffer, "Warning: Effect released but refCount = %lu\n", refCount);
			OutputDebugStringA(buffer);
		}

		// Clean up maps
		_DeviceFFBEffectControl[GUIDString].erase(effectType);
		_DeviceFFBEffectConfig[GUIDString].erase(effectType);

		return S_OK;
	}
	catch (...) {
		// Ensure maps are cleaned even on error
		_DeviceFFBEffectControl[GUIDString].erase(effectType);
		_DeviceFFBEffectConfig[GUIDString].erase(effectType);
		return E_FAIL;
	}
}

HRESULT UpdateFFBEffect(LPCSTR guidInstance, Effects::Type effectType, DICONDITION* conditions) {
	if (!guidInstance || !conditions) return E_INVALIDARG;

	HRESULT hr = E_FAIL;
	std::string GUIDString(guidInstance);

	// Validate device and effect existence
	if (!_ActiveDevices.contains(GUIDString)) return E_FAIL;
	if (!_DeviceFFBEffectControl[GUIDString].contains(effectType)) return E_ABORT;

	// Get effect configuration
	auto& effectConfig = _DeviceFFBEffectConfig[GUIDString][effectType];

	for (DWORD idx = 0; idx < effectConfig.cAxes; idx++) {
		switch (effectType) {
		case Effects::Type::ConstantForce: {
			auto* cf = static_cast<DICONSTANTFORCE*>(effectConfig.lpvTypeSpecificParams);
			if (!cf) return E_POINTER;
			cf->lMagnitude = conditions[idx].lPositiveCoefficient;
			break;
		}

		case Effects::Type::Sine:
		case Effects::Type::Square:
		case Effects::Type::Triangle:
		case Effects::Type::SawtoothUp:
		case Effects::Type::SawtoothDown: {
			auto* pe = static_cast<DIPERIODIC*>(effectConfig.lpvTypeSpecificParams);
			if (!pe) return E_POINTER;
			pe->dwMagnitude = conditions[idx].lPositiveCoefficient;
			pe->lOffset = conditions[idx].lOffset;
			pe->dwPeriod = conditions[idx].dwPositiveSaturation;
			// Maintain existing phase values
			break;
		}
		case Effects::Type::RampForce: {
			auto* rf = static_cast<DIRAMPFORCE*>(effectConfig.lpvTypeSpecificParams);
			if (!rf) return E_POINTER;
			rf->lStart = conditions[idx].lPositiveCoefficient;
			rf->lEnd = conditions[idx].lNegativeCoefficient;
			break;
		}
		default: {
			auto* cond = static_cast<DICONDITION*>(effectConfig.lpvTypeSpecificParams);
			if (!cond) return E_POINTER;
			cond[idx].lOffset = conditions[idx].lOffset;
			cond[idx].lPositiveCoefficient = conditions[idx].lPositiveCoefficient;
			cond[idx].lNegativeCoefficient = conditions[idx].lNegativeCoefficient;
			cond[idx].dwPositiveSaturation = conditions[idx].dwPositiveSaturation;
			cond[idx].dwNegativeSaturation = conditions[idx].dwNegativeSaturation;
			cond[idx].lDeadBand = conditions[idx].lDeadBand;
			break;
		}
		}
	}

	// Update effect parameters
	return _DeviceFFBEffectControl[GUIDString][effectType]->SetParameters(
		&effectConfig,
		DIEP_TYPESPECIFICPARAMS
	);
}

HRESULT StopAllFFBEffects(LPCSTR guidInstance) {
	HRESULT hr = E_FAIL;
	std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail
	hr = S_OK; // Incase there are no active effects, act like we stopped them all

	//for (auto& [effectType, effectControl] : _DeviceFFBEffectControl[GUIDString]) { // For each effect
	//  if (FAILED(hr = effectControl->Stop())) { return hr; } // Stop Effect
	//  //_DeviceFFBEffectControl[GUIDString].erase(effectType);        // Remove Effect Control        // effectType isn't behaving like Effects::Type, "An unhandled exception of type 'System.AccessViolationException' occurred in DirectInputExplorer.dll" "Attempted to read or write protected memory. This is often an indication that other memory is corrupt."
	//  //_DeviceFFBEffectConfig[GUIDString].erase(effectType);         // Remove Effect Config
	//}

	hr = DestroyFFBEffect(guidInstance, Effects::Type::ConstantForce);
	hr = DestroyFFBEffect(guidInstance, Effects::Type::RampForce);
	hr = DestroyFFBEffect(guidInstance, Effects::Type::Square);
	hr = DestroyFFBEffect(guidInstance, Effects::Type::Sine);
	hr = DestroyFFBEffect(guidInstance, Effects::Type::Triangle);
	hr = DestroyFFBEffect(guidInstance, Effects::Type::SawtoothUp);
	hr = DestroyFFBEffect(guidInstance, Effects::Type::SawtoothDown);
	hr = DestroyFFBEffect(guidInstance, Effects::Type::Spring);
	hr = DestroyFFBEffect(guidInstance, Effects::Type::Damper);
	hr = DestroyFFBEffect(guidInstance, Effects::Type::Inertia);
	hr = DestroyFFBEffect(guidInstance, Effects::Type::Friction);
	hr = DestroyFFBEffect(guidInstance, Effects::Type::CustomForce);

	return hr;
}

void SetDeviceChangeCallback(DeviceChangeCallback CB) {
	_DeviceChangeCallback = CB;
}

// Generate SAFEARRAY of DEBUG data
HRESULT DEBUG1(LPCSTR guidInstance, /*[out]*/ SAFEARRAY** DebugData) {
	HRESULT hr = E_FAIL;
	std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail

	//std::vector<std::wstring> SAData;

	//SAData.push_back(L"Modifying Constant Force!");
	//DICONSTANTFORCE CF = { 1000 };
	//_DeviceFFBEffectConfig[GUIDString][Effects::ConstantForce].lpvTypeSpecificParams = &CF;
	//_DeviceFFBEffectControl[GUIDString][Effects::ConstantForce]->SetParameters(&_DeviceFFBEffectConfig[GUIDString][Effects::ConstantForce], DIEP_TYPESPECIFICPARAMS);
	//hr = BuildSafeArray(SAData, DebugData);



	// Testing Fanatec Fix
	LPDIRECTINPUTDEVICE8 DIDevice = nullptr;
	if (FAILED(hr = _DirectInput->CreateDevice(LPCSTRGUIDtoGUID(guidInstance), &DIDevice, NULL))) {
		return hr;
	} // L"CreateDevice failed! 0x%08x", hr

	DIPROPGUIDANDPATH GUIDPath = {};
	GUIDPath.diph.dwSize = sizeof(DIPROPGUIDANDPATH);
	GUIDPath.diph.dwHeaderSize = sizeof(DIPROPHEADER);
	GUIDPath.diph.dwObj = 0;
	GUIDPath.diph.dwHow = static_cast<DWORD>(DIPH_DEVICE); // Explicit cast to DWORD
	if (FAILED(hr = DIDevice->GetProperty(DIPROP_GUIDANDPATH, &GUIDPath.diph))) {
		DIDevice->Release();
		return hr;
	} // L"GetProperty failed! Failed to get symbolic path for device 0x%08x", hr
	DIDevice->Release();

	//if (wcsstr(GUIDPath.wszPath, L"&col01") != 0) { // This is our primary device (HID Path contains "&col01")
	//  return false;
	//}
	//else {
	//  return true; // This is a duplicate device
	//}
	DEBUGDATA.push_back(GUIDPath.wszPath);


	hr = BuildSafeArray(DEBUGDATA, DebugData);
	return hr;
}


//////////////////////////////////////////////////////////////
// Callback Functions
//////////////////////////////////////////////////////////////

// Callback for each device enumerated, each device is added to the _DeviceInstances vector
BOOL CALLBACK _EnumDevicesCallback(const DIDEVICEINSTANCE* DIDI, void* pContext) {
	DeviceInfo di = { 0 }; // Store DeviceInfo
	di.deviceType = DIDI->dwDevType;
	std::string GIStr = (GUID_to_string(DIDI->guidInstance).c_str());
	std::string GPStr = (GUID_to_string(DIDI->guidProduct).c_str());
	std::string INStr = (wstring_to_string(DIDI->tszInstanceName).c_str());
	std::string PNStr = (wstring_to_string(DIDI->tszProductName).c_str());
	di.guidInstance = new char[GIStr.length() + 1];
	di.guidProduct = new char[GPStr.length() + 1];
	di.instanceName = new char[INStr.length() + 1];
	di.productName = new char[PNStr.length() + 1];
	strcpy_s(di.guidInstance, GIStr.length() + 1, GIStr.c_str());
	strcpy_s(di.guidProduct, GPStr.length() + 1, GPStr.c_str());
	strcpy_s(di.instanceName, INStr.length() + 1, INStr.c_str());
	strcpy_s(di.productName, PNStr.length() + 1, PNStr.c_str());
	di.FFBCapable = false; // Default all devices to false, FFB devices are updated later

	// Fanatec Fix (Fanatec devices enumerate as 2)
	if (LOWORD(DIDI->guidProduct.Data1) == 0x0EB7) // Fanatec manufacturer ID
		if (IsDuplicateHID(DIDI)) { return DIENUM_CONTINUE; } // Skip if duplicate

	_DeviceInstances.push_back(di);
	return DIENUM_CONTINUE;
}

// Callback for each device enumerated, each device is added to the _DeviceInstances vector
BOOL CALLBACK _EnumDevicesCallbackFFB(const DIDEVICEINSTANCE* DIDI, void* pContext) {
	std::string GUIDStr = (GUID_to_string(DIDI->guidInstance).c_str()); // Convert GUID to str to compare against
	for (auto& di : _DeviceInstances) {
		if (di.guidInstance == GUIDStr) { // Update existing entry
			di.FFBCapable = true;
		}
	}
	return DIENUM_CONTINUE;
}

BOOL CALLBACK _EnumFFBEffectsCallback(LPCDIEFFECTINFO EffectInfo, LPVOID pvRef) {
	std::string GUIDString = *reinterpret_cast<std::string*>(pvRef); // Device GUID passed in as 2nd arg
	_DeviceEnumeratedEffects[GUIDString].push_back(*EffectInfo); // Add the DIEffectInfo to the entry for this Device
	return DIENUM_CONTINUE; // Continue to next effect
}

BOOL CALLBACK _EnumFFBAxisCallback(const DIDEVICEOBJECTINSTANCE* ObjectInst, LPVOID pvRef) {
	std::string GUIDString = *reinterpret_cast<std::string*>(pvRef); // Device GUID passed in as 2nd arg

	if ((ObjectInst->dwFlags & DIDOI_FFACTUATOR) != 0) { // FFB Axis
		_DeviceFFBAxes[GUIDString].push_back(*ObjectInst); // Add this ObjectIntance to the vector for this Device
	}

	return DIENUM_CONTINUE;
}

LRESULT _WindowsHookCallback(int code, WPARAM wParam, LPARAM lParam) {
	if (code < 0) return CallNextHookEx(NULL, code, wParam, lParam); // invalid code skip

	// check if device was added/removed
	PCWPSTRUCT pMsg = PCWPSTRUCT(lParam);
	if (pMsg->message == WM_DEVICECHANGE) {
		if (_DeviceChangeCallback) { _DeviceChangeCallback((int)pMsg->wParam); } // If callback assigned, invoke it
		//switch (pMsg->wParam) {
		//  case DBT_DEVNODES_CHANGED:
		//    DEBUGDATA.push_back(L"Changed!");
		//    // TODO: Invoke Callback
		//    //if (_DeviceChangeCallback) { _DeviceChangeCallback(1); }
		//    break;
		//  case DBT_DEVICEARRIVAL:
		//    DEBUGDATA.push_back(L"Arrival!");
		//    // TODO: Invoke Callback
		//    break;
		//  case DBT_DEVICEREMOVECOMPLETE:
		//    DEBUGDATA.push_back(L"Remove!");
		//    // TODO: Invoke Callback
		//    break;
		//  default:
		//    DEBUGDATA.push_back(L"Other!");
		//    break;
		//}
	}
	return CallNextHookEx(NULL, code, wParam, lParam); // Continue to next hook
}

//////////////////////////////////////////////////////////////
// Helper Functions
//////////////////////////////////////////////////////////////

// Generate SAFEARRAY from vector of wstrings, useful for exporing data across interop boundary
HRESULT BuildSafeArray(std::vector<std::wstring> sourceData, /*[out]*/ SAFEARRAY** SafeArrayData) {
	HRESULT hr = E_FAIL;
	try {
		// Build the destination SAFEARRAY from the source data
		const LONG dataEntries = static_cast<LONG>(sourceData.size());
		CComSafeArray<BSTR> SAFEARRAY(dataEntries);
		for (LONG i = 0; i < dataEntries; i++) {
			CComBSTR bstr = ToBstr(sourceData[i]); // Create a BSTR from the std::wstring
			if (FAILED(hr = SAFEARRAY.SetAt(i, bstr.Detach(), FALSE))) { AtlThrow(hr); } // Move the BSTR into the safe array
		}

		// Return the safe array to the caller (transfer ownership)
		*SafeArrayData = SAFEARRAY.Detach();
	}
	catch (const CAtlException& e) {
		hr = e;
	}
	catch (const std::exception&) {
		hr = E_FAIL;
	}

	return hr;
}

// Utilities for converting string types ( https://stackoverflow.com/a/3999597/3055031 )
// Convert a wide Unicode string to an UTF8 string

// Convert an UTF8 string to a wide Unicode String
std::wstring string_to_wstring(const std::string& str) {
	if (str.empty()) return std::wstring();
	int size_needed = MultiByteToWideChar(CP_UTF8, 0, &str[0], (int)str.size(), NULL, 0);
	std::wstring wstrTo(size_needed, 0);
	MultiByteToWideChar(CP_UTF8, 0, &str[0], (int)str.size(), &wstrTo[0], size_needed);
	return wstrTo;
}

std::string wstring_to_string(const std::wstring& wstr) {
	if (wstr.empty()) return std::string();
	int size_needed = WideCharToMultiByte(CP_UTF8, 0, &wstr[0], (int)wstr.size(), NULL, 0, NULL, NULL);
	std::string strTo(size_needed, 0);
	WideCharToMultiByte(CP_UTF8, 0, &wstr[0], (int)wstr.size(), &strTo[0], size_needed, NULL, NULL);
	return strTo;
}

// Convert a GUID to a String
std::string GUID_to_string(GUID guidInstance) {
	OLECHAR* guidSTR;
	(void)StringFromCLSID(guidInstance, &guidSTR);
	return wstring_to_string(guidSTR);
}

// Return window handle for specified PID
HWND FindMainWindow(unsigned long process_id) {
	WindowData data = {};
	data.process_id = process_id;
	data.window_handle = 0;
	EnumWindows(_EnumWindowsCallback, (LPARAM)&data);
	return data.window_handle;
}

// Callback to find the main window when Enumerating windows of PID
BOOL CALLBACK _EnumWindowsCallback(HWND handle, LPARAM lParam) {
	WindowData& data = *(WindowData*)lParam; // Pointer to our original WindowData data object
	unsigned long process_id = 0; // Store PID
	GetWindowThreadProcessId(handle, &process_id); // Get PID of our handle (Window in callback)
	if (data.process_id != process_id || !IsMainWindow(handle))
		return TRUE;
	data.window_handle = handle; // This is the main window, set the WindowData handle
	return FALSE;
}

// True if the handle is for the main window
BOOL IsMainWindow(HWND handle) {
	return GetWindow(handle, GW_OWNER) == (HWND)0 && IsWindowVisible(handle);
}

GUID LPCSTRGUIDtoGUID(LPCSTR guidInstance) {
	GUID deviceGuid;
	int wcharCount = MultiByteToWideChar(CP_UTF8, 0, guidInstance, -1, NULL, 0);
	WCHAR* wstrGuidInstance = new WCHAR[wcharCount];
	MultiByteToWideChar(CP_UTF8, 0, guidInstance, -1, wstrGuidInstance, wcharCount);
	(void)CLSIDFromString(wstrGuidInstance, &deviceGuid);
	delete[] wstrGuidInstance;
	return deviceGuid;
}

FlatJoyState2 FlattenDIJOYSTATE2(DIJOYSTATE2 DeviceState) {
	FlatJoyState2 state = FlatJoyState2(); // Hold the flattend state

	// ButtonA
	for (int i = 0; i < 64; i++) { // In banks of 64, shift in the sate of each button BankA 0-63
		if (DeviceState.rgbButtons[i] == 128) // 128 = Button pressed
			state.buttonsA |= (unsigned long long)1 << i; // Shift in a 1 to the button at index i
	}
	// ButtonB
	for (int i = 64; i < 128; i++) { // 2nd bank of buttons from 64-128
		if (DeviceState.rgbButtons[i] == 128) // 128 = Button pressed
			state.buttonsB |= (unsigned long long)1 << i; // Shift in a 1 to the button at index i
	}

	// Properly cast and clamp values to uint16_t range
	auto ClampToUInt16 = [](LONG value) -> uint16_t {
		return static_cast<uint16_t>(std::clamp(value, 0L, static_cast<LONG>(UINT16_MAX)));
		};

	// Axis assignments with proper ClampToUInt16
	state.lX = ClampToUInt16(DeviceState.lX);
	state.lY = ClampToUInt16(DeviceState.lY);
	state.lZ = ClampToUInt16(DeviceState.lZ);
	state.lU = ClampToUInt16(DeviceState.rglSlider[0]);
	state.lV = ClampToUInt16(DeviceState.rglSlider[1]);

	// Rotation assignments
	state.lRx = ClampToUInt16(DeviceState.lRx);
	state.lRy = ClampToUInt16(DeviceState.lRy);
	state.lRz = ClampToUInt16(DeviceState.lRz);

	// Velocity assignments
	state.lVX = ClampToUInt16(DeviceState.lVX);
	state.lVY = ClampToUInt16(DeviceState.lVY);
	state.lVZ = ClampToUInt16(DeviceState.lVZ);
	state.lVU = ClampToUInt16(DeviceState.rglVSlider[0]);
	state.lVV = ClampToUInt16(DeviceState.rglVSlider[1]);

	// Angular velocity assignments
	state.lVRx = ClampToUInt16(DeviceState.lVRx);
	state.lVRy = ClampToUInt16(DeviceState.lVRy);
	state.lVRz = ClampToUInt16(DeviceState.lVRz);

	// Acceleration assignments
	state.lAX = ClampToUInt16(DeviceState.lAX);
	state.lAY = ClampToUInt16(DeviceState.lAY);
	state.lAZ = ClampToUInt16(DeviceState.lAZ);
	state.lAU = ClampToUInt16(DeviceState.rglASlider[0]);
	state.lAV = ClampToUInt16(DeviceState.rglASlider[1]);

	// Angular acceleration assignments
	state.lARx = ClampToUInt16(DeviceState.lARx);
	state.lARy = ClampToUInt16(DeviceState.lARy);
	state.lARz = ClampToUInt16(DeviceState.lARz);

	// Force assignments
	state.lFX = ClampToUInt16(DeviceState.lFX);
	state.lFY = ClampToUInt16(DeviceState.lFY);
	state.lFZ = ClampToUInt16(DeviceState.lFZ);
	state.lFU = ClampToUInt16(DeviceState.rglFSlider[0]);
	state.lFV = ClampToUInt16(DeviceState.rglFSlider[1]);

	// Torque assignments
	state.lFRx = ClampToUInt16(DeviceState.lFRx);
	state.lFRy = ClampToUInt16(DeviceState.lFRy);
	state.lFRz = ClampToUInt16(DeviceState.lFRz);

	for (int i = 0; i < 4; i++) { // In banks of 4, shift in the sate of each DPAD 0-16 bits 
		switch (DeviceState.rgdwPOV[i]) {
		case 0:     state.rgdwPOV |= (byte)(1 << ((i + 1) * 0)); break; // dpad[i]/up, bit = 0     shift into value at stride (i+1) * DPADButton
		case 18000: state.rgdwPOV |= (byte)(1 << ((i + 1) * 1)); break; // dpad[i]/down, bit = 1
		case 27000: state.rgdwPOV |= (byte)(1 << ((i + 1) * 2)); break; // dpad[i]/left, bit = 2
		case 9000:  state.rgdwPOV |= (byte)(1 << ((i + 1) * 3)); break; // dpad[i]/right, bit = 3
		}
	}

	return state;
}

bool GUIDMatch(LPCSTR guidInstance, LPDIRECTINPUTDEVICE8 Device) {
	DIDEVICEINSTANCE deviceInfo = { sizeof(DIDEVICEINSTANCE) };
	if (FAILED(Device->GetDeviceInfo(&deviceInfo))) { return false; } // Fetch device info
	if (deviceInfo.guidInstance == LPCSTRGUIDtoGUID(guidInstance)) { // Check if GUID matches the device we want
		return true;
	}
	return false;
}

GUID Device2GUID(LPDIRECTINPUTDEVICE8 Device) {
	DIDEVICEINSTANCE deviceInfo = { sizeof(DIDEVICEINSTANCE) };
	if (FAILED(Device->GetDeviceInfo(&deviceInfo))) { /*return false;*/ } // Fetch device info
	return deviceInfo.guidInstance;
}

// Helper function to convert a std::wstring to the ATL CComBSTR wrapper (Handy because it can be sized at runtime)
inline CComBSTR ToBstr(const std::wstring& s) {
	if (s.empty()) { return CComBSTR(); }// Special case of empty string
	return CComBSTR(static_cast<int>(s.size()), s.data());
}

void DestroyDeviceIfExists(LPCSTR guidInstance) {
	std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return; // Device not attached, fail
	DestroyDevice(guidInstance);
}

DWORD AxisTypeToDIJOFS(GUID axisType) {
	if (axisType == GUID_XAxis) {
		return DIJOFS_X;
	}
	else if (axisType == GUID_YAxis) {
		return DIJOFS_Y;
	}
	else if (axisType == GUID_ZAxis) {
		return DIJOFS_Z;
	}
	else if (axisType == GUID_RxAxis) {
		return DIJOFS_RX;
	}
	else if (axisType == GUID_RyAxis) {
		return DIJOFS_RY;
	}
	else if (axisType == GUID_RzAxis) {
		return DIJOFS_RZ;
	} /*else if (axisType == GUID_Slider) {
	  return DIJOFS_SLIDER;
	} else if (axisType == GUID_Button) {
	  return DIJOFS_BUTTON1;
	} else if (axisType == GUID_Key) {
	  return DIJOFS_;
	} else if (axisType == GUID_POV) {
	  return DIJOFS_POV;
	} else if (AxesType == GUID_Unknown) {
	  return DIJOFS_;
	}*/

	return 0; // GUID Type not found, likely POV Hat, Slider or Button
}

GUID EffectTypeToGUID(Effects::Type effectType) {
	switch (effectType) {
	case Effects::Type::ConstantForce:
		return GUID_ConstantForce;
		break;
	case Effects::Type::RampForce:
		return GUID_RampForce;
		break;
	case Effects::Type::Square:
		return GUID_Square;
		break;
	case Effects::Type::Sine:
		return GUID_Sine;
		break;
	case Effects::Type::Triangle:
		return GUID_Triangle;
		break;
	case Effects::Type::SawtoothUp:
		return GUID_SawtoothUp;
		break;
	case Effects::Type::SawtoothDown:
		return GUID_SawtoothDown;
		break;
	case Effects::Type::Spring:
		return GUID_Spring;
		break;
	case Effects::Type::Damper:
		return GUID_Damper;
		break;
	case Effects::Type::Inertia:
		return GUID_Inertia;
		break;
	case Effects::Type::Friction:
		return GUID_Friction;
		break;
	case Effects::Type::CustomForce:
		return GUID_CustomForce;
		break;
	default:
		return GUID_Unknown;
	}
}

bool IsDuplicateHID(const DIDEVICEINSTANCE* DIDI) {
	HRESULT hr;
	LPDIRECTINPUTDEVICE8 DIDevice = nullptr;
	if (FAILED(hr = _DirectInput->CreateDevice(DIDI->guidInstance, &DIDevice, NULL))) { return true; } // L"CreateDevice failed! 0x%08x", hr

	DIPROPGUIDANDPATH GUIDPath = {};
	GUIDPath.diph.dwSize = sizeof(DIPROPGUIDANDPATH);
	GUIDPath.diph.dwHeaderSize = sizeof(DIPROPHEADER);
	GUIDPath.diph.dwObj = 0;
	GUIDPath.diph.dwHow = DIPH_DEVICE;
	if (FAILED(hr = DIDevice->GetProperty(DIPROP_GUIDANDPATH, &GUIDPath.diph))) { DIDevice->Release(); return true; } // L"GetProperty failed! Failed to get symbolic path for device 0x%08x", hr
	DIDevice->Release();

	if (wcsstr(GUIDPath.wszPath, L"&col02") != 0) { // This is a duplicate device (HID Path contains "&col02")
		return true;
	}
	else {
		return false; // This is our primary device
	}
}