#pragma once

#define WIN32_LEAN_AND_MEAN
// Windows Header Files
#include <windows.h>

// C++ Includes
#include <vector>
#include <string>
#include <map>

// DirectInput
#define DIRECTINPUT_VERSION 0x0800
#include <dinput.h>
#pragma comment(lib, "dinput8.lib")
#pragma comment(lib, "dxguid.lib")

// ATL Includes
#include <atlbase.h>    // For ATL::CComBSTR
#include <atlsafe.h>    // For ATL::CComSafeArray


//#include <dbt.h> // Device Change Events
