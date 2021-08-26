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
    bool FFBCapable;
	};

  struct FlatJoyState2 {
    uint64_t buttonsA; // Buttons seperated into banks of 64-Bits to fit into 64-bit integer
    uint64_t buttonsB; // Buttons seperated into banks of 64-Bits to fit into 64-bit integer
    uint16_t lX;       // X-axis
    uint16_t lY;       // Y-axis
    uint16_t lZ;       // Z-axis
    uint16_t lU;       // U-axis
    uint16_t lV;       // V-axis
    uint16_t lRx;      // X-axis rotation
    uint16_t lRy;      // Y-axis rotation
    uint16_t lRz;      // Z-axis rotation
    uint16_t lVX;      // X-axis velocity
    uint16_t lVY;      // Y-axis velocity
    uint16_t lVZ;      // Z-axis velocity
    uint16_t lVU;      // U-axis velocity
    uint16_t lVV;      // V-axis velocity
    uint16_t lVRx;     // X-axis angular velocity
    uint16_t lVRy;     // Y-axis angular velocity
    uint16_t lVRz;     // Z-axis angular velocity
    uint16_t lAX;      // X-axis acceleration
    uint16_t lAY;      // Y-axis acceleration
    uint16_t lAZ;      // Z-axis acceleration
    uint16_t lAU;      // U-axis acceleration
    uint16_t lAV;      // V-axis acceleration
    uint16_t lARx;     // X-axis angular acceleration
    uint16_t lARy;     // Y-axis angular acceleration
    uint16_t lARz;     // Z-axis angular acceleration
    uint16_t lFX;      // X-axis force
    uint16_t lFY;      // Y-axis force
    uint16_t lFZ;      // Z-axis force
    uint16_t lFU;      // U-axis force
    uint16_t lFV;      // V-axis force
    uint16_t lFRx;     // X-axis torque
    uint16_t lFRy;     // Y-axis torque
    uint16_t lFRz;     // Z-axis torque
    uint16_t rgdwPOV; // Store each DPAD in chunks of 4 bits inside 16-bit short     
  };

  struct DIDEVCAPS; // Transfer device capabilities across the interop boundary

  struct Effects {
    enum class Type {
      ConstantForce = 0,
      RampForce = 1,
      Square = 2,
      Sine = 3,
      Triangle = 4,
      SawtoothUp = 5,
      SawtoothDown = 6,
      Spring = 7,
      Damper = 8,
      Inertia = 9,
      Friction = 10,
      CustomForce = 11
    };
  };

  //////////////////////////////////////////////////////////////
  // DLL Functions
  //////////////////////////////////////////////////////////////
	DIRECTINPUTFORCEFEEDBACK_API HRESULT              StartDirectInput();
	DIRECTINPUTFORCEFEEDBACK_API HRESULT              StopDirectInput();
	DIRECTINPUTFORCEFEEDBACK_API DeviceInfo*          EnumerateDevices(/*[out]*/ int& deviceCount);
	DIRECTINPUTFORCEFEEDBACK_API HRESULT              CreateDevice(LPCSTR guidInstance);
	DIRECTINPUTFORCEFEEDBACK_API HRESULT              DestroyDevice(LPCSTR guidInstance);
	DIRECTINPUTFORCEFEEDBACK_API HRESULT              GetDeviceState(LPCSTR guidInstance, /*[out]*/ FlatJoyState2& deviceState);
	DIRECTINPUTFORCEFEEDBACK_API HRESULT              GetDeviceStateRaw(LPCSTR guidInstance, /*[out]*/ DIJOYSTATE2& deviceState);
	DIRECTINPUTFORCEFEEDBACK_API HRESULT              GetDeviceCapabilities(LPCSTR guidInstance, /*[out]*/ DIDEVCAPS& deviceCapabilitiesOut);
  DIRECTINPUTFORCEFEEDBACK_API HRESULT              GetActiveDevices(/*[out]*/ SAFEARRAY** activeGUIDs);
  DIRECTINPUTFORCEFEEDBACK_API HRESULT              SetAutocenter(LPCSTR guidInstance, bool AutocenterState);
  DIRECTINPUTFORCEFEEDBACK_API HRESULT              EnumerateFFBEffects(LPCSTR guidInstance, /*[out]*/ SAFEARRAY** FFBEffects);
  DIRECTINPUTFORCEFEEDBACK_API HRESULT              EnumerateFFBAxes(LPCSTR guidInstance, /*[out]*/ SAFEARRAY** FFBAxis);
  DIRECTINPUTFORCEFEEDBACK_API HRESULT              CreateFFBEffect(LPCSTR guidInstance, Effects::Type effectType);
  DIRECTINPUTFORCEFEEDBACK_API HRESULT              DestroyFFBEffect(LPCSTR guidInstance, Effects::Type effectType);
  DIRECTINPUTFORCEFEEDBACK_API HRESULT              UpdateFFBEffect(LPCSTR guidInstance, Effects::Type effectType, DICONDITION* conditions);
  DIRECTINPUTFORCEFEEDBACK_API HRESULT              StopAllFFBEffects(LPCSTR guidInstance);

  typedef void(__stdcall* DeviceChangeCallback)(int);
  DIRECTINPUTFORCEFEEDBACK_API void                 SetDeviceChangeCallback(DeviceChangeCallback CB);


  DIRECTINPUTFORCEFEEDBACK_API HRESULT              DEBUG1(LPCSTR guidInstance, /*[out]*/ SAFEARRAY** DebugData);
}


//////////////////////////////////////////////////////////////
// Internal Callbacks
//////////////////////////////////////////////////////////////
BOOL CALLBACK _EnumWindowsCallback(HWND handle, LPARAM lParam);
BOOL CALLBACK _EnumDevicesCallback(const DIDEVICEINSTANCE* pInst, void* pContext);
BOOL CALLBACK _EnumDevicesCallbackFFB(const DIDEVICEINSTANCE* DIDI, void* pContext);
BOOL CALLBACK _EnumFFBEffectsCallback(LPCDIEFFECTINFO pdei, LPVOID pvRef);
BOOL CALLBACK _EnumFFBAxisCallback(const DIDEVICEOBJECTINSTANCE* pdidoi, LPVOID pvRef);
LRESULT _WindowsHookCallback(int code, WPARAM wParam, LPARAM lParam);

//////////////////////////////////////////////////////////////
// Helper Functions
//////////////////////////////////////////////////////////////

struct WindowData { // Used in FindMainWindow
	unsigned long process_id;
	HWND window_handle;
};

std::wstring string_to_wstring(const std::string& str);
std::string wstring_to_string(const std::wstring& str);
std::string GUID_to_string(GUID guidInstance);
HWND FindMainWindow(unsigned long process_id);
BOOL IsMainWindow(HWND handle);
GUID LPCSTRGUIDtoGUID(LPCSTR guidInstance);
FlatJoyState2 FlattenDIJOYSTATE2(DIJOYSTATE2 DeviceState);
bool GUIDMatch(LPCSTR guidInstance, LPDIRECTINPUTDEVICE8 Device);
GUID Device2GUID(LPDIRECTINPUTDEVICE8 Device);
inline CComBSTR ToBstr(const std::wstring& s);
void DestroyDeviceIfExists(LPCSTR guidInstance);
HRESULT BuildSafeArray(std::vector<std::wstring> sourceData, /*[out]*/ SAFEARRAY** SafeArrayData);
DWORD AxisTypeToDIJOFS(GUID axisType);
GUID EffectTypeToGUID(Effects::Type effectType);