// DirectInputForceFeedback.cpp : Defines the exported functions for the DLL.
#include "pch.h"
#include "DirectInputForceFeedback.h"


std::vector<DeviceInfo> _DeviceInstances;
std::vector<LPDIRECTINPUTDEVICE8> ActiveDevices; // Store all of the connected devices


/// Create the _DirectInput global
HRESULT StartDirectInput() {
  if (_DirectInput != NULL) { return S_OK; } // Already initialised
  return DirectInput8Create(
    GetModuleHandle(NULL),
    DIRECTINPUT_VERSION,
    IID_IDirectInput8,
    (void**)&_DirectInput,
    NULL
  );
}

// Return a vector of all attached devices
DeviceInfo* EnumerateDevices(int& deviceCount) {
  if (_DirectInput == NULL) { return NULL; } // If DI not ready, return nothing
  _DeviceInstances.clear(); // Clear devices
  HRESULT hr = _DirectInput->EnumDevices( // Invoke device enumeration to the _EnumDevicesCallback callback
    DI8DEVCLASS_GAMECTRL,
    _EnumDevicesCallback,
    NULL,
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

// Callback for each device enumerated, each device is added to the _DeviceInstances vector
BOOL CALLBACK _EnumDevicesCallback(const DIDEVICEINSTANCE* pInst, void* pContext) {
  DeviceInfo di = { 0 };

  OLECHAR* guidInstance;
  StringFromCLSID(pInst->guidInstance, &guidInstance);
  OLECHAR* guidProduct;
  StringFromCLSID(pInst->guidProduct, &guidProduct);

  std::string strGuidInstance = utf16ToUTF8(guidInstance);
  std::string strGuidProduct = utf16ToUTF8(guidProduct);
  std::string strInstanceName = utf16ToUTF8(pInst->tszInstanceName);
  std::string strProductName = utf16ToUTF8(pInst->tszProductName);

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

// Create the DirectInput Device and Acquire ready for State retreval & FFB Effects (Requires Cooperation level Exclusive)
// Pass the GUID (as a string) of the Device you'd like to attach to, GUID obtained from the Enumerated Devices 
HRESULT CreateDevice(LPCSTR guidInstance) {
  // If device with GUID already exists, destroy ir
  //if (g_pDevice) { FreeFFBDevice(); }
  LPDIRECTINPUTDEVICE8 DIDevice;

  HRESULT hr;
  HWND hWnd = FindMainWindow(GetCurrentProcessId());

  if (FAILED(hr = _DirectInput->CreateDevice(LPCSTRGUIDtoGUID(guidInstance), &DIDevice, NULL))) { return hr; }
  if (FAILED(hr = DIDevice->SetDataFormat(&c_dfDIJoystick2))) { return hr; }
  if (FAILED(hr = DIDevice->SetCooperativeLevel(hWnd, DISCL_EXCLUSIVE | DISCL_BACKGROUND))) { return hr; }
  if (FAILED(hr = DIDevice->Acquire())) { return hr; }
  ActiveDevices.push_back( DIDevice ); // Add this device to the Vector of active devices

  return S_OK;
}

// Remove the DirectInput Device, Unacquire and remove from ActiveDevices
HRESULT RemoveDevice(LPCSTR guidInstance) {
  HRESULT hr = E_FAIL;
  int idx = 0;
  for (LPDIRECTINPUTDEVICE8 Device : ActiveDevices) {
    if (GUIDMatch(guidInstance, Device)) {
      if (SUCCEEDED(hr = Device->Unacquire())) { // DirectInput Unacquire
        //ActiveDevices.erase(ActiveDevices.begin() + idx); // Remove the device from our ActiveDevices vector     // Performance issues as vector grows? Swap to last element then remove?
        if (idx != ActiveDevices.size() - 1) { ActiveDevices[idx] = std::move(ActiveDevices.back()); } // Swap to back (Avoiding self assignment)
        ActiveDevices.pop_back();
      }
    }
    idx++;
  }
  return hr;
}

// Fetch the Device State, give GUID of the Device (Must already be created by CreateDevice) and out FlatJoyState2
HRESULT GetDeviceState(LPCSTR guidInstance, FlatJoyState2& deviceState) {
  HRESULT hr = E_FAIL;

  for (LPDIRECTINPUTDEVICE8 Device : ActiveDevices) {
    if (GUIDMatch(guidInstance, Device)) {
      DIJOYSTATE2 DeviceStateRaw;
      hr = Device->GetDeviceState(sizeof(DIJOYSTATE2), &DeviceStateRaw); // Fetch the device State
      deviceState = FlattenDIJOYSTATE2(DeviceStateRaw); // Convert to a friendlier format (Nested arrays are more difficult to check for change)
    }
  }
  return hr;
}

// Fetch the Device State, give GUID of the Device (Must already be created by CreateDevice) and out DIJOYSTATE2
HRESULT GetDeviceStateRaw(LPCSTR guidInstance, DIJOYSTATE2& deviceState) {
  HRESULT hr = E_FAIL;

  for (LPDIRECTINPUTDEVICE8 Device : ActiveDevices) {
    if (GUIDMatch(guidInstance, Device)) {
      hr = Device->GetDeviceState(sizeof(DIJOYSTATE2), &deviceState); // Fetch the device State
    }
  }
  return hr;
}

// Fetch the capabilities of the device, returns DIDEVCAPS see https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ee416607(v=vs.85)
HRESULT GetDeviceCapabilities(LPCSTR guidInstance, DIDEVCAPS& DeviceCapabilitiesOut) {
  HRESULT hr = E_FAIL;

  for (LPDIRECTINPUTDEVICE8 Device : ActiveDevices) {
    if (GUIDMatch(guidInstance, Device)) {
      DIDEVCAPS DeviceCapabilities;
      DeviceCapabilities.dwSize = sizeof(DIDEVCAPS);
      Device->GetCapabilities(&DeviceCapabilities);
      DeviceCapabilitiesOut = DeviceCapabilities;
    }
  }

  return hr;
}

//////////////////////////////////////////////////////////////
// Helper Functions
//////////////////////////////////////////////////////////////


//Helper function for converting wide strings to regular strings
std::string utf16ToUTF8(const std::wstring& s) {
  const int size = ::WideCharToMultiByte(CP_UTF8, 0, s.c_str(), -1, NULL, 0, 0, NULL);

  std::vector<char> buf(size);
  ::WideCharToMultiByte(CP_UTF8, 0, s.c_str(), -1, &buf[0], size, 0, NULL);

  return std::string(&buf[0]);
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
  //state.buttonsA = 0;

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