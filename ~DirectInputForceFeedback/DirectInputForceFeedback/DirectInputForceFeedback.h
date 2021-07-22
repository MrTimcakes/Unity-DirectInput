#pragma once

#ifdef DIRECTINPUTFORCEFEEDBACK_EXPORTS
	#define DIRECTINPUTFORCEFEEDBACK_API __declspec(dllexport)
#else
	#define DIRECTINPUTFORCEFEEDBACK_API __declspec(dllimport)
#endif

LPDIRECTINPUT8 _DirectInput = NULL; // Global DirectInput Instance

extern "C" { // Everything to be made available by the DLL

	struct DeviceInfo {
		DWORD deviceType;
		LPSTR guidInstance;
		LPSTR guidProduct;
		LPSTR instanceName;
		LPSTR productName;
	};

  struct FlatJoyState2 {
    long long buttonsA; // Buttons seperated into banks of 64-Bits to fit into 64-bit integer
    long long buttonsB; // Buttons seperated into banks of 64-Bits to fit into 64-bit integer
    long lX;       // X-axis
    long lY;       // Y-axis
    long lZ;       // Z-axis
    long lU;       // U-axis
    long lV;       // V-axis
    long lRx;      // X-axis rotation
    long lRy;      // Y-axis rotation
    long lRz;      // Z-axis rotation
    long lVX;      // X-axis velocity
    long lVY;      // Y-axis velocity
    long lVZ;      // Z-axis velocity
    long lVU;      // U-axis velocity
    long lVV;      // V-axis velocity
    long lVRx;     // X-axis angular velocity
    long lVRy;     // Y-axis angular velocity
    long lVRz;     // Z-axis angular velocity
    long lAX;      // X-axis acceleration
    long lAY;      // Y-axis acceleration
    long lAZ;      // Z-axis acceleration
    long lAU;      // U-axis acceleration
    long lAV;      // V-axis acceleration
    long lARx;     // X-axis angular acceleration
    long lARy;     // Y-axis angular acceleration
    long lARz;     // Z-axis angular acceleration
    long lFX;      // X-axis force
    long lFY;      // Y-axis force
    long lFZ;      // Z-axis force
    long lFU;      // U-axis force
    long lFV;      // V-axis force
    long lFRx;     // X-axis torque
    long lFRy;     // Y-axis torque
    long lFRz;     // Z-axis torque
    short rgdwPOV; // Store each DPAD in chunks of 4 bits inside 16-bit short     
  };

  struct DIDEVCAPS; // Transfer device capabilities across the interop boundary

  //////////////////////////////////////////////////////////////
  // DLL Functions
  //////////////////////////////////////////////////////////////
	DIRECTINPUTFORCEFEEDBACK_API HRESULT              StartDirectInput();
	DIRECTINPUTFORCEFEEDBACK_API DeviceInfo*          EnumerateDevices(int& deviceCount);
	DIRECTINPUTFORCEFEEDBACK_API HRESULT              CreateDevice(LPCSTR guidInstance);
	DIRECTINPUTFORCEFEEDBACK_API HRESULT              DestroyDevice(LPCSTR guidInstance);
	DIRECTINPUTFORCEFEEDBACK_API HRESULT              GetDeviceState(LPCSTR guidInstance, /*[out]*/ FlatJoyState2& deviceState);
	DIRECTINPUTFORCEFEEDBACK_API HRESULT              GetDeviceStateRaw(LPCSTR guidInstance, /*[out]*/ DIJOYSTATE2& deviceState);
	DIRECTINPUTFORCEFEEDBACK_API HRESULT              GetDeviceCapabilities(LPCSTR guidInstance, /*[out]*/ DIDEVCAPS& deviceCapabilitiesOut);
  DIRECTINPUTFORCEFEEDBACK_API HRESULT __stdcall    GetActiveDevices( /*[out]*/ SAFEARRAY** activeGUIDs);

}


//////////////////////////////////////////////////////////////
// Internal Callbacks
//////////////////////////////////////////////////////////////
BOOL CALLBACK _EnumDevicesCallback(const DIDEVICEINSTANCE* pInst, void* pContext);

//////////////////////////////////////////////////////////////
// Helper Functions
//////////////////////////////////////////////////////////////
std::string utf16ToUTF8(const std::wstring& s);

struct WindowData {
	unsigned long process_id;
	HWND window_handle;
};

HWND FindMainWindow(unsigned long process_id);
BOOL CALLBACK _EnumWindowsCallback(HWND handle, LPARAM lParam);
BOOL IsMainWindow(HWND handle);
GUID LPCSTRGUIDtoGUID(LPCSTR guidInstance);
FlatJoyState2 FlattenDIJOYSTATE2(DIJOYSTATE2 DeviceState);
bool GUIDMatch(LPCSTR guidInstance, LPDIRECTINPUTDEVICE8 Device);
GUID Device2GUID(LPDIRECTINPUTDEVICE8 Device);
inline CComBSTR ToBstr(const std::wstring& s);
void DestroyDeviceIfExists(LPCSTR guidInstance);