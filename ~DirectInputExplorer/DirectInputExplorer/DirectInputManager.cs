using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DirectInputManager {
  class Native {
    const string DLLFile = @"..\..\..\..\..\~DirectInputForceFeedback\x64\Release\DirectInputForceFeedback.dll";
    [DllImport(DLLFile)] public static extern int StartDirectInput();
    [DllImport(DLLFile)] public static extern IntPtr EnumerateDevices(out int deviceCount);
    [DllImport(DLLFile)] public static extern int CreateDevice(string guidInstance);
    [DllImport(DLLFile)] public static extern int DestroyDevice(string guidInstance);
    [DllImport(DLLFile)] public static extern int GetDeviceState(string guidInstance, out FlatJoyState2 DeviceState);
    [DllImport(DLLFile)] public static extern int GetDeviceStateRaw(string guidInstance, out DIJOYSTATE2 DeviceState);
    [DllImport(DLLFile)] public static extern int GetDeviceCapabilities(string guidInstance, out DIDEVCAPS DeviceCapabilitiesOut);
    [DllImport(DLLFile)] public static extern int GetActiveDevices([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out string[] ActiveGUIDs);
    [DllImport(DLLFile)] public static extern int CreateFFBEffect(string guidInstance, EffectsType effectsType);
    [DllImport(DLLFile)] public static extern int EnumerateFFBEffects(string guidInstance, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out string[] SupportedFFBEffects);
    [DllImport(DLLFile)] public static extern int DEBUG1(string guidInstance, [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out string[] DEBUGDATA);
  }
  class DIManager {
    //////////////////////////////////////////////////////////////
    // Private Variables - For Internal use
    //////////////////////////////////////////////////////////////

    private static bool _isInitialized = false; // is DIManager ready
    private static DeviceInfo[] _devices = new DeviceInfo[0]; // Hold data for devices plugged in
    private static Dictionary<string, DeviceInfo> _activeDevices = new(); // Hold data for devices actively attached

    //////////////////////////////////////////////////////////////
    // Public Variables
    //////////////////////////////////////////////////////////////
    public static bool isInitialized { get => _isInitialized; }
    public static DeviceInfo[] devices { get => _devices; }
    public static Dictionary<string, DeviceInfo> activeDevices { get => _activeDevices; }

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
      if (_activeDevices.ContainsKey(device.guidInstance)) { return true; } // We're already attached to that device
      int hresult = Native.CreateDevice(device.guidInstance);
      //if (hresult != 0) { Debug.LogError($"[DirectInputManager] CreateDevice Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); return false; }
      if (hresult != 0) { System.Diagnostics.Debug.WriteLine($"[DirectInputManager] CreateDevice Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); return false; }

      _activeDevices.Add(device.guidInstance, device); // Add device to our C# active device tracker (Dictionary allows us to easily check if GUID already exists)
      return true;
    }

    // Remove a specified Device, Stops all ForceFeedback & GetState capabilities
    // E.g. DIManager.Destroy( DIManager.devices[0] );
    public static bool Destroy(DeviceInfo device) {
      if (!_activeDevices.ContainsKey(device.guidInstance)) { return false; } // We don't think we're attached to that device
      int hresult = Native.DestroyDevice(device.guidInstance);
      //if (hresult != 0) { Debug.LogError($"[DirectInputManager] CreateDevice Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); return false; }
      if (hresult != 0) { System.Diagnostics.Debug.WriteLine($"[DirectInputManager] CreateDevice Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); return false; }

      _activeDevices.Remove(device.guidInstance); // remove from our C# active device tracker
      return true;
    }

    // Retrieve state of the Device, Flattened for easier comparison. (JoyState2)
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

    public static string[] GetActiveDevices() {
      string[] ActiveGUIDs = null;
      int hresult = Native.GetActiveDevices(out ActiveGUIDs);
      //if (hresult != 0) { Debug.LogError($"[DirectInputManager] GetActiveDevices Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); /*return false;*/ }
      if (hresult != 0) { System.Diagnostics.Debug.WriteLine($"[DirectInputManager] GetActiveDevices Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); /*return false;*/ }

      if (ActiveGUIDs.Length != _activeDevices.Count) { System.Diagnostics.Debug.WriteLine($"[DirectInputManager] Active Device mismatch! DLL:{ActiveGUIDs.Length}, DIManager:{_activeDevices.Count}"); }

      return ActiveGUIDs;
    }

    // Retrieve the capabilities of the device, Device must be attached first, returns DIDEVCAPS https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ee416607(v=vs.85)
    public static DIDEVCAPS GetDeviceCapabilities(DeviceInfo device) {
      DIDEVCAPS DeviceCapabilities = new();
      int hresult = Native.GetDeviceCapabilities(device.guidInstance, out DeviceCapabilities);
      if (hresult != 0) { System.Diagnostics.Debug.WriteLine($"[DirectInputManager] GetDeviceCapabilities Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); /*return false;*/ }

      return DeviceCapabilities;
    }

    public static bool FFBCapable(DeviceInfo device) {
      return GetDeviceCapabilities(device).dwFlags.HasFlag(dwFlags.DIDC_FORCEFEEDBACK);
    }
    
    public static bool isDeviceActive(DeviceInfo device) {
      return _activeDevices.ContainsKey(device.guidInstance);
    }

    // Enables an FFB Effect 
    public static bool EnableFFBEffect(DeviceInfo device, EffectsType effectsType) {
      int hresult = Native.CreateFFBEffect(device.guidInstance, effectsType);
      if (hresult != 0) { System.Diagnostics.Debug.WriteLine($"[DirectInputManager] CreateFFBEffect Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); return false; }
      return true;
    }

    // Enables an FFB Effect 
    public static string[] GetDeviceFFBCapabilities(DeviceInfo device) {
      string[] SupportedFFBEffects = null;
      int hresult = Native.EnumerateFFBEffects(device.guidInstance, out SupportedFFBEffects);
      if (hresult != 0) { System.Diagnostics.Debug.WriteLine($"[DirectInputManager] GetDeviceFFBCapabilities Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); /*return false;*/ }
      return SupportedFFBEffects;
    }

    public static string[] DEBUG1(DeviceInfo device) {
      string[] DEBUGDATA = null;
      int hresult = Native.DEBUG1(device.guidInstance, out DEBUGDATA);
      if (hresult != 0) { System.Diagnostics.Debug.WriteLine($"[DirectInputManager] DEBUG1 Failed: 0x{hresult.ToString("x")} {WinErrors.GetSystemMessage(hresult)}"); /*return false;*/ }

      return DEBUGDATA;
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
