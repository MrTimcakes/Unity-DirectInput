using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DirectInputManager {
  class Native {
    const string DLLFile = @"..\..\..\..\..\~DirectInputForceFeedback\x64\Release\DirectInputForceFeedback.dll";
    [DllImport(DLLFile)] public static extern int StartDirectInput();
    [DllImport(DLLFile)] public static extern IntPtr EnumerateDevices(ref int deviceCount);
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

    public static void EnumerateDevices() {
      int deviceCount = 0;
      IntPtr ptrDevices = Native.EnumerateDevices(ref deviceCount);

      if (deviceCount > 0) {
        _devices = new DeviceInfo[deviceCount];

        int deviceSize = Marshal.SizeOf(typeof(DeviceInfo));
        for (int i = 0; i < deviceCount; i++) {
          IntPtr pCurrent = ptrDevices + i * deviceSize;
          _devices[i] = Marshal.PtrToStructure<DeviceInfo>(pCurrent);
        }
      }
      return;
    }


  }
}
