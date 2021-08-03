// DirectInputForceFeedback.cpp : Defines the exported functions for the DLL.
#include "pch.h"
#include "DirectInputForceFeedback.h"


std::vector<DeviceInfo> _DeviceInstances;

std::map<std::string, LPDIRECTINPUTDEVICE8> _ActiveDevices; // Store all of the connected devices
std::map<std::string, std::vector<DIEFFECTINFO>> _DeviceEnumeratedEffects;

//////////////////////////////////////////////////////////////
// DLL Exported Functions
//////////////////////////////////////////////////////////////

// Create the _DirectInput global
HRESULT StartDirectInput() {
  if (_DirectInput != NULL) { return S_OK; } // Already initialised
  return DirectInput8Create(
    GetModuleHandle(NULL),
    DIRECTINPUT_VERSION,
    IID_IDirectInput8,
    (void**)&_DirectInput, // Place our DirectInput instance in _DirectInput
    NULL
  );
}

// Return a vector of all attached devices
DeviceInfo* EnumerateDevices(int& deviceCount) {
  if (_DirectInput == NULL) { return NULL; } // If DI not ready, return nothing
  _DeviceInstances.clear(); // Clear devices
  HRESULT hr = _DirectInput->EnumDevices( // Invoke device enumeration to the _EnumDevicesCallback callback
    DI8DEVCLASS_GAMECTRL, // List devices of type GameController
    _EnumDevicesCallback,
    NULL, // Passed to callback as optional arg
    DIEDFL_ATTACHEDONLY //| DIEDFL_FORCEFEEDBACK
  );

  if (_DeviceInstances.size() > 0) {
    deviceCount = (int)_DeviceInstances.size();
    return &_DeviceInstances[0];
  } else {
    deviceCount = 0;
  }
  return NULL;
}

// Create the DirectInput Device and Acquire ready for State retreval & FFB Effects (Requires Cooperation level Exclusive)
// Pass the GUID (as a string) of the Device you'd like to attach to, GUID obtained from the Enumerated Devices 
HRESULT CreateDevice(LPCSTR guidInstance) {
  DestroyDeviceIfExists(guidInstance); // If device exists, clear it first


  LPDIRECTINPUTDEVICE8 DIDevice;

  HRESULT hr;
  HWND hWnd = FindMainWindow(GetCurrentProcessId());

  if (FAILED(hr = _DirectInput->CreateDevice(LPCSTRGUIDtoGUID(guidInstance), &DIDevice, NULL))) { return hr; }
  if (FAILED(hr = DIDevice->SetDataFormat(&c_dfDIJoystick2))) { return hr; }
  if (FAILED(hr = DIDevice->SetCooperativeLevel(hWnd, DISCL_EXCLUSIVE | DISCL_BACKGROUND))) { return hr; }
  if (FAILED(hr = DIDevice->Acquire())) { return hr; }

  std::string GUIDString((LPCSTR)guidInstance); // Convert the LPCSTR to a STL String for use as key in map (String as GUID has no operater<)
  _ActiveDevices[GUIDString] = DIDevice;

  return S_OK;
}

// Remove the DirectInput Device, Unacquire and remove from ActiveDevices
HRESULT DestroyDevice(LPCSTR guidInstance) {
  HRESULT hr = E_FAIL;
  std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail

  // TODO: Stop FFB Effects First?
  if (SUCCEEDED(hr = _ActiveDevices[GUIDString]->Unacquire())) {
    _ActiveDevices.erase(GUIDString);
  }

  return hr;
}

// Fetch the Device State, give GUID of the Device (Must already be created by CreateDevice) and out FlatJoyState2
HRESULT GetDeviceState(LPCSTR guidInstance, /*[out]*/ FlatJoyState2& deviceState) {
  HRESULT hr = E_FAIL;
  std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail

  DIJOYSTATE2 DeviceStateRaw;
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
HRESULT GetActiveDevices(/*[out]*/ SAFEARRAY** activeGUIDs){
  HRESULT hr = E_FAIL;

  std::vector<std::wstring> SAData;
  for (const auto& [GUIDString, Device] : _ActiveDevices) {
    SAData.push_back( string_to_wstring(GUIDString) );
  }

  hr = BuildSafeArray(SAData, activeGUIDs);
  return hr;
}

// 
HRESULT CreateFFBEffect(LPCSTR guidInstance, Effects::Type effectType) {
  HRESULT hr = E_FAIL;
  std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail

  // Create that FFB Effect

  // Set Cooperation level to exclusive
  //HWND hWnd = FindMainWindow(GetCurrentProcessId());
  //if (FAILED(hr = Device->SetCooperativeLevel(hWnd, DISCL_EXCLUSIVE | DISCL_BACKGROUND))) { return hr; } // DISCL_EXCLUSIVE is required for FFB

  // Check for existing events
  // Enumerate Axis?


  //An array of axes that will be involved in the effect.For a joystick, this array normally consists of the identifiers for the x - axis and the y - axis.
  //An array of values for setting the direction.The values differ according to both the number of axesand whether you want to use polar, spherical, or Cartesian coordinates.For a full explanation, see Effect Direction.
  //A structure of type - specific parameters.In the example, because you are creating a periodic effect, this is of type DIPERIODIC.
  //A DIENVELOPE structure for defining an envelope to be applied to the effect.
  //A DIEFFECT structure to contain the basic parameters for the effect.
      


  return hr;
}

HRESULT DestroyFFBEffect(LPCSTR guidInstance, Effects::Type effectType) {
  HRESULT hr = E_FAIL;
  std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail

  // Destroy Effect

  return hr;
}

// Set the Autocenter property for a DI device, pass device GUID and bool to enable or disable
HRESULT SetAutocenter(LPCSTR guidInstance, bool AutocenterState) {
  HRESULT hr = E_FAIL;
  std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail

  hr = SetAutocenter(_ActiveDevices[GUIDString], AutocenterState);

  return hr;
}

// Generate SAFEARRAY of possible FFB Effects for this Device
HRESULT EnumerateFFBEffects(LPCSTR guidInstance, /*[out]*/ SAFEARRAY** FFBEffects) {
  HRESULT hr = E_FAIL;
  std::string GUIDString((LPCSTR)guidInstance); if (!_ActiveDevices.contains(GUIDString)) return hr; // Device not attached, fail

  _DeviceEnumeratedEffects[GUIDString].clear(); // Clear effects for this device
  hr = _ActiveDevices[GUIDString]->EnumEffects(&_EnumFFBEffectsCallbackMap, &GUIDString, DIEFT_ALL); // Callback adds each effect to _DeviceEnumeratedEffects with key as device's GUID

  // Generate SafeArray of supported effects
  std::vector<std::wstring> SAData; // Store what will be in the SafeArray
  for (const auto& Effect : _DeviceEnumeratedEffects[GUIDString]) {
    SAData.push_back(Effect.tszName); // Add each effect name
  }
  hr = BuildSafeArray(SAData, FFBEffects);

  return hr;
}

// Generate SAFEARRAY of DEBUG data
HRESULT DEBUG1(LPCSTR guidInstance, /*[out]*/ SAFEARRAY** DebugData) {
  HRESULT hr = E_FAIL;

  std::string GUIDString((LPCSTR)guidInstance);

  std::wstring wGUIDString = string_to_wstring(GUIDString);

  std::vector<std::wstring> sourceData;
  //sourceData.push_back(L"WideStr");
  sourceData.push_back(wGUIDString);
  sourceData.push_back( std::to_wstring(_DeviceEnumeratedEffects.size()) );
  sourceData.push_back( std::to_wstring(_DeviceEnumeratedEffects[GUIDString].size()) );

  for (const auto& Effect : _DeviceEnumeratedEffects[GUIDString]) {
    sourceData.push_back(Effect.tszName); // Add each effect name
  }

  hr = BuildSafeArray(sourceData, DebugData);

  return hr;
}


//////////////////////////////////////////////////////////////
// Callback Functions
//////////////////////////////////////////////////////////////

// Callback for each device enumerated, each device is added to the _DeviceInstances vector
BOOL CALLBACK _EnumDevicesCallback(const DIDEVICEINSTANCE* pInst, void* pContext) {
  DeviceInfo di = { 0 };

  OLECHAR* guidInstance;
  StringFromCLSID(pInst->guidInstance, &guidInstance);
  OLECHAR* guidProduct;
  StringFromCLSID(pInst->guidProduct, &guidProduct);

  std::string strGuidInstance = wstring_to_string(guidInstance);
  std::string strGuidProduct = wstring_to_string(guidProduct);
  std::string strInstanceName = wstring_to_string(pInst->tszInstanceName);
  std::string strProductName = wstring_to_string(pInst->tszProductName);

  di.guidInstance = new char[strGuidInstance.length() + 1];
  di.guidProduct = new char[strGuidProduct.length() + 1];
  di.instanceName = new char[strInstanceName.length() + 1];
  di.productName = new char[strProductName.length() + 1];

  di.deviceType = pInst->dwDevType;
  strcpy_s(di.guidInstance, strGuidInstance.length() + 1, strGuidInstance.c_str());
  strcpy_s(di.guidProduct, strGuidProduct.length() + 1, strGuidProduct.c_str());
  strcpy_s(di.instanceName, strInstanceName.length() + 1, strInstanceName.c_str());
  strcpy_s(di.productName, strProductName.length() + 1, strProductName.c_str());

  _DeviceInstances.push_back(di);

  return true;
}

BOOL CALLBACK _EnumFFBEffectsCallbackMap(LPCDIEFFECTINFO pdei, LPVOID pvRef) {
  std::string GUIDString = *reinterpret_cast<std::string*>(pvRef); // Device GUID passed in as 2nd arg
  _DeviceEnumeratedEffects[GUIDString].push_back(*pdei); // Add the DIEffectInfo to the entry for this Device
  return DIENUM_CONTINUE; // Continue to next effect
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
  } catch (const CAtlException& e) {
    hr = e;
  } catch (const std::exception&) {
    hr = E_FAIL;
  }

  return hr;
}

// Utilities for converting string types ( https://stackoverflow.com/a/3999597/3055031 )
// Convert a wide Unicode string to an UTF8 string
std::string wstring_to_string(const std::wstring& wstr){
  if (wstr.empty()) return std::string();
  int size_needed = WideCharToMultiByte(CP_UTF8, 0, &wstr[0], (int)wstr.size(), NULL, 0, NULL, NULL);
  std::string strTo(size_needed, 0);
  WideCharToMultiByte(CP_UTF8, 0, &wstr[0], (int)wstr.size(), &strTo[0], size_needed, NULL, NULL);
  return strTo;
}

// Convert an UTF8 string to a wide Unicode String
std::wstring string_to_wstring(const std::string& str){
  if (str.empty()) return std::wstring();
  int size_needed = MultiByteToWideChar(CP_UTF8, 0, &str[0], (int)str.size(), NULL, 0);
  std::wstring wstrTo(size_needed, 0);
  MultiByteToWideChar(CP_UTF8, 0, &str[0], (int)str.size(), &wstrTo[0], size_needed);
  return wstrTo;
}

// Return window handle for specified PID
HWND FindMainWindow(unsigned long process_id) {
  WindowData data;
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
  CLSIDFromString(wstrGuidInstance, &deviceGuid);
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

  state.lX = DeviceState.lX; // X-axis
  state.lY = DeviceState.lY; // Y-axis
  state.lZ = DeviceState.lZ; // Z-axis
  // rglSlider
  state.lU = DeviceState.rglSlider[0]; // U-axis
  state.lV = DeviceState.rglSlider[1]; // V-axis

  state.lRx = DeviceState.lRx; // X-axis rotation
  state.lRy = DeviceState.lRy; // Y-axis rotation
  state.lRz = DeviceState.lRz; // Z-axis rotation

  state.lVX = DeviceState.lVX; // X-axis velocity
  state.lVY = DeviceState.lVY; // Y-axis velocity
  state.lVZ = DeviceState.lVZ; // Z-axis velocity
  // rglVSlider
  state.lVU = DeviceState.rglVSlider[0]; // U-axis velocity
  state.lVV = DeviceState.rglVSlider[1]; // V-axis velocity

  state.lVRx = DeviceState.lVRx; // X-axis angular velocity
  state.lVRy = DeviceState.lVRy; // Y-axis angular velocity
  state.lVRz = DeviceState.lVRz; // Z-axis angular velocity

  state.lAX = DeviceState.lAX; // X-axis acceleration
  state.lAY = DeviceState.lAY; // Y-axis acceleration
  state.lAZ = DeviceState.lAZ; // Z-axis acceleration
  // rglASlider
  state.lAU = DeviceState.rglASlider[0]; // U-axis acceleration
  state.lAV = DeviceState.rglASlider[1]; // V-axis acceleration

  state.lARx = DeviceState.lARx; // X-axis angular acceleration
  state.lARy = DeviceState.lARy; // Y-axis angular acceleration
  state.lARz = DeviceState.lARz; // Z-axis angular acceleration

  state.lFX = DeviceState.lFX; // X-axis force
  state.lFY = DeviceState.lFY; // Y-axis force
  state.lFZ = DeviceState.lFZ; // Z-axis force
  // rglFSlider
  state.lFU = DeviceState.rglFSlider[0]; // U-axis force
  state.lFV = DeviceState.rglFSlider[1]; // V-axis force

  state.lFRx = DeviceState.lFRx; // X-axis torque
  state.lFRy = DeviceState.lFRy; // Y-axis torque
  state.lFRz = DeviceState.lFRz; // Z-axis torque

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

HRESULT SetAutocenter(LPDIRECTINPUTDEVICE8 Device, bool AutocenterState) {
  HRESULT hr = E_FAIL;
  DIPROPDWORD DIPropAutoCenter;

  DIPropAutoCenter.diph.dwSize = sizeof(DIPropAutoCenter);
  DIPropAutoCenter.diph.dwHeaderSize = sizeof(DIPROPHEADER);
  DIPropAutoCenter.diph.dwObj = 0;
  DIPropAutoCenter.diph.dwHow = DIPH_DEVICE;
  DIPropAutoCenter.dwData = AutocenterState ? DIPROPAUTOCENTER_ON : DIPROPAUTOCENTER_OFF;

  hr = Device->SetProperty(DIPROP_AUTOCENTER, &DIPropAutoCenter.diph);

  return hr;
}