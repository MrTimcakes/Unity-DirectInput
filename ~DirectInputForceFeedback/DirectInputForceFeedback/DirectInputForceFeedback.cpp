// DirectInputForceFeedback.cpp : Defines the exported functions for the DLL.
#include "pch.h"
#include "DirectInputForceFeedback.h"



std::vector<DeviceInfo> _DeviceInstances;



/// Create the _DirectInput global
HRESULT StartDirectInput() {
  if (_DirectInput != NULL) {
    return S_OK;
  }
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
  }
  else {
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

  strcpy_s(di.guidInstance, strGuidInstance.length() + 1, strGuidInstance.c_str());
  strcpy_s(di.guidProduct, strGuidProduct.length() + 1, strGuidProduct.c_str());
  di.deviceType = pInst->dwDevType;
  strcpy_s(di.instanceName, strInstanceName.length() + 1, strInstanceName.c_str());
  strcpy_s(di.productName, strProductName.length() + 1, strProductName.c_str());

  _DeviceInstances.push_back(di);

  return true;
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