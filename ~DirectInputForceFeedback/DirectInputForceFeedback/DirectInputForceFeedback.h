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

	DIRECTINPUTFORCEFEEDBACK_API HRESULT StartDirectInput();
	DIRECTINPUTFORCEFEEDBACK_API DeviceInfo* EnumerateDevices(int& deviceCount);
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