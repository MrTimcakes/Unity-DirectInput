using System;
using System.Runtime.InteropServices;

namespace DirectInputManager {
  class Native {
    const string DLLFile = @"..\..\..\..\..\~DirectInputForceFeedback\x64\Release\DirectInputForceFeedback.dll";
    [DllImport(DLLFile)] public static extern int StartDirectInput();
    [DllImport(DLLFile)] public static extern IntPtr EnumerateDevices(out int deviceCount);
    [DllImport(DLLFile)] public static extern int CreateDevice(string guidInstance);
    [DllImport(DLLFile)] public static extern int GetDeviceState(string guidInstance, out FlatJoyState2 DeviceState);
    [DllImport(DLLFile)] public static extern int GetDeviceStateRaw(string guidInstance, out DIJOYSTATE2 DeviceState);
    [DllImport(DLLFile)] public static extern int GetDeviceCapabilities(string guidInstance, out DIDEVCAPS DeviceCapabilitiesOut);
  }
  class DIManager {
    //////////////////////////////////////////////////////////////
    // Private Variables
    //////////////////////////////////////////////////////////////

    private static bool           _isInitialized = false;
    private static DeviceInfo[]   _devices = new DeviceInfo[0];

    //////////////////////////////////////////////////////////////
    // Public Variables
    //////////////////////////////////////////////////////////////
    public static bool isInitialized {
      get => _isInitialized;
      //set { Debug.Log("[DirectInputManager]Can't set isInitialized!"); }
    }
    public static DeviceInfo[] devices {
      get => _devices;
      //set { Debug.Log("[DirectInputManager]Can't set devices!"); }
    }

    //////////////////////////////////////////////////////////////
    // Methods
    //////////////////////////////////////////////////////////////
    public static bool Initialize() {
      if (_isInitialized) { return _isInitialized; }
      if (Native.StartDirectInput() != 0) { _isInitialized = false; }
      return _isInitialized = true;
    }

    // Fill _devices with DeviceInfo
    public static void EnumerateDevices() {
      int deviceCount = 0;
      IntPtr ptrDevices = Native.EnumerateDevices(out deviceCount); // Returns pointer to list of devices and how many are available

      if (deviceCount > 0) {
        _devices = new DeviceInfo[deviceCount];

        int deviceSize = Marshal.SizeOf(typeof(DeviceInfo)); // Size of each Device entry
        for (int i = 0; i < deviceCount; i++) {
          IntPtr pCurrent = ptrDevices + i * deviceSize; // Ptr to the current device
          _devices[i] = Marshal.PtrToStructure<DeviceInfo>(pCurrent); // Transform the Ptr into a C# instance of DeviceInfo
        }
      }
      return;
    }

    // Attach to Device, ready to get state/ForceFeedback
    // E.g. DIManager.Attach( DIManager.devices[0] );
    public static bool Attach(DeviceInfo device) {
      int hresult = Native.CreateDevice(device.guidInstance);
      //if (hresult != 0) { Debug.LogError($"[DirectInputManager] CreateDevice Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); return false; }
      if (hresult != 0) { System.Diagnostics.Debug.WriteLine($"[DirectInputManager] CreateDevice Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); return false; }
      return true;
    }

    // Retrieve state of the Device, Flattened for easier comparrison. (JoyState2)
    public static FlatJoyState2 GetDeviceState(DeviceInfo device) {
      FlatJoyState2 DeviceState = new();
      int hresult = Native.GetDeviceState(device.guidInstance, out DeviceState);
      //if (hresult != 0) { Debug.LogError($"[DirectInputManager] GetDeviceState Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); /*return false;*/ }
      if (hresult != 0) { System.Diagnostics.Debug.WriteLine($"[DirectInputManager] GetDeviceState Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); /*return false;*/ }
      return DeviceState;
    }

    // Retrieve the state of the device, not flattened raw DIJOYSTATE2. 
    public static DIJOYSTATE2 GetDeviceStateRaw(DeviceInfo device) {
      DIJOYSTATE2 DeviceState = new();
      int hresult = Native.GetDeviceStateRaw(device.guidInstance, out DeviceState);
      //if (hresult != 0) { Debug.LogError($"[DirectInputManager] GetDeviceState Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); /*return false;*/ }
      if (hresult != 0) { System.Diagnostics.Debug.WriteLine($"[DirectInputManager] GetDeviceState Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); /*return false;*/ }
      return DeviceState;
    }

  }

  /// <summary>
  /// Helper class to print out user friendly system error codes.
  /// Taken from: https://stackoverflow.com/a/21174331/9053848
  /// </summary>
  public static class WinErrors {
    #region definitions
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr LocalFree(IntPtr hMem);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern int FormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer, uint nSize, IntPtr Arguments);

    [Flags]
    private enum FormatMessageFlags : uint {
      FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100,
      FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200,
      FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000,
      FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x00002000,
      FORMAT_MESSAGE_FROM_HMODULE = 0x00000800,
      FORMAT_MESSAGE_FROM_STRING = 0x00000400,
    }
    #endregion

    /// <summary>
    /// Gets a user friendly string message for a system error code
    /// </summary>
    /// <param name="errorCode">System error code</param>
    /// <returns>Error string</returns>
    public static string GetSystemMessage(int errorCode) {
      try {
        IntPtr lpMsgBuf = IntPtr.Zero;

        int dwChars = FormatMessage(
            FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER | FormatMessageFlags.FORMAT_MESSAGE_FROM_SYSTEM | FormatMessageFlags.FORMAT_MESSAGE_IGNORE_INSERTS,
            IntPtr.Zero,
            (uint)errorCode,
            0, // Default language
            ref lpMsgBuf,
            0,
            IntPtr.Zero);
        if (dwChars == 0) {
          // Handle the error.
          int le = Marshal.GetLastWin32Error();
          return "Unable to get error code string from System - Error " + le.ToString();
        }

        string sRet = Marshal.PtrToStringAnsi(lpMsgBuf);

        // Free the buffer.
        lpMsgBuf = LocalFree(lpMsgBuf);
        return sRet;
      } catch (Exception e) {
        return "Unable to get error code string from System -> " + e.ToString();
      }
    }
  }

}
