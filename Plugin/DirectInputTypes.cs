using System;
using System.Runtime.InteropServices;

namespace DirectInputManager {
  /// <summary>
  /// Enum of possible FFB Effects<br/>
  /// </summary>
  public enum FFBEffects {
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
  }

  /// <summary>
  /// Types of OnDeviceChange DBTEvents<br/>
  /// More info: https://docs.microsoft.com/en-us/windows/win32/devio/wm-devicechange
  /// </summary>
  public enum DBTEvents {
    DBT_DEVNODES_CHANGED        = 0x0007,
    DBT_QUERYCHANGECONFIG       = 0x0017,
    DBT_CONFIGCHANGED           = 0x0018,
    DBT_CONFIGCHANGECANCELED    = 0x0019,
    DBT_DEVICEARRIVAL           = 0x8000,
    DBT_DEVICEQUERYREMOVE       = 0x8001,
    DBT_DEVICEQUERYREMOVEFAILED = 0x8002,
    DBT_DEVICEREMOVEPENDING     = 0x8003,
    DBT_DEVICEREMOVECOMPLETE    = 0x8004,
    DBT_DEVICETYPESPECIFIC      = 0x8005,
    DBT_CUSTOMEVENT             = 0x8006,
    DBT_USERDEFINED             = 0xFFFF
  }

  /// <summary>
  /// Struct to hold device specific info<br/>
  /// </summary>
  [Serializable]
  [StructLayout(LayoutKind.Sequential)]
  public struct DeviceInfo {
    public uint deviceType;
    [MarshalAs(UnmanagedType.LPStr)] public string guidInstance;
    [MarshalAs(UnmanagedType.LPStr)] public string guidProduct;
    [MarshalAs(UnmanagedType.LPStr)] public string instanceName;
    [MarshalAs(UnmanagedType.LPStr)] public string productName;
    public bool FFBCapable;
  }

  public delegate void deviceInfoEvent(DeviceInfo device); // delegate for handling events that pass DeviceInfo
  public delegate void deviceStateEvent(DeviceInfo device, FlatJoyState2 state); // delegate for handling events that pass DeviceInfo & FlatJoyState2
  /// <summary>
  /// Like DeviceInfo but allows for events per device<br/>
  /// </summary>
  public class ActiveDeviceInfo{
    public DeviceInfo deviceInfo;                     // Hold the info about the device
    public Int32 stateHash;                           // Hold the hash of the last known state
    public event deviceInfoEvent OnDeviceRemoved;     // Event to add listners too
    public event deviceStateEvent OnDeviceStateChange; // Event to add listners too
    public void DeviceRemoved(DeviceInfo device){ OnDeviceRemoved?.Invoke(device); }         // Function to invoke event listeners
    public void DeviceStateChange(DeviceInfo device, FlatJoyState2 state){ OnDeviceStateChange?.Invoke(device, state); } // Function to invoke event listeners
  }

  /// <summary>
  /// DirectInput DIConditon Struct <br/>
  /// Offset: -10,000 - 10,000 <br/>
  /// positiveCoefficient: -10,000 - 10,000 <br/>
  /// negativeCoefficient: -10,000 - 10,000 <br/>
  /// positiveSaturation: 0 - 10,000 <br/>
  /// negativeSaturation: 0 - 10,000 <br/>
  /// deadband: 0 - 10,000 <br/>
  /// More info: https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ee416601(v=vs.85)
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct DICondition {
    /// <summary>
    /// Offset for the condition, in the range from - 10,000 through 10,000.
    /// </summary>
    public int offset;
    /// <summary>
    /// Coefficient constant on the positive side of the offset, in the range 
    /// from - 10,000 through 10,000.
    /// </summary>
    public int positiveCoefficient;
    /// <summary>
    /// Coefficient constant on the negative side of the offset, in the range 
    /// from - 10,000 through 10,000. If the device does not support separate
    /// positive and negative coefficients, the value of lNegativeCoefficient 
    /// is ignored, and the value of lPositiveCoefficient is used as both the 
    /// positive and negative coefficients.
    /// </summary>
    public int negativeCoefficient;
    /// <summary>
    /// Maximum force output on the positive side of the offset, in the range
    /// from 0 through 10,000.
    /// 
    /// If the device does not support force saturation, the value of this
    /// member is ignored.
    /// </summary>
    public uint positiveSaturation;
    /// <summary>
    /// Maximum force output on the negative side of the offset, in the range
    /// from 0 through 10,000.
    ///
    /// If the device does not support force saturation, the value of this member
    /// is ignored.
    /// 
    /// If the device does not support separate positive and negative saturation,
    /// the value of dwNegativeSaturation is ignored, and the value of dwPositiveSaturation
    /// is used as both the positive and negative saturation.
    /// </summary>
    public uint negativeSaturation;
    /// <summary>
    /// Region around lOffset in which the condition is not active, in the range
    /// from 0 through 10,000. In other words, the condition is not active between
    /// lOffset minus lDeadBand and lOffset plus lDeadBand.
    /// </summary>
    public uint deadband; // Should be uint? (LONG in DICONDITION though not like dwPositiveSaturation )
  }

  /// <summary>
  /// Describes the state of a joystick device with extended capabilities. <br/>
  /// See https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ee416628(v=vs.85)
  /// </summary>
  [Serializable]
  [StructLayout(LayoutKind.Sequential)]
  public struct DIJOYSTATE2 {
    public int lX;
    public int lY;
    public int lZ;
    public int lRx;
    public int lRy;
    public int lRz;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public int[] rglSlider;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public int[] rgdwPOV;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
    public byte[] rgbButtons;
    public int lVX;
    public int lVY;
    public int lVZ;
    public int lVRx;
    public int lVRy;
    public int lVRz;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public int[] rglVSlider;
    public int lAX;
    public int lAY;
    public int lAZ;
    public int lARx;
    public int lARy;
    public int lARz;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public int[] rglASlider;
    public int lFX;
    public int lFY;
    public int lFZ;
    public int lFRx;
    public int lFRy;
    public int lFRz;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public int[] rglFSlider;
  }

  /// <summary>
  /// A flattend version of DIJOYSTATE2 without nested arrays<br/>
  /// See https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ee416628(v=vs.85)
  /// </summary>
  [Serializable]
  public struct FlatJoyState2 { // Axis trimmed from "LONG" UInt32 to UInt16 as values range 0-65535?
    public UInt64 buttonsA; // Buttons seperated into banks of 64-Bits to fit into Unsigned 64-bit integer
    public UInt64 buttonsB; // Buttons seperated into banks of 64-Bits to fit into Unsigned 64-bit integer
    public UInt16 lX;       // X-axis
    public UInt16 lY;       // Y-axis
    public UInt16 lZ;       // Z-axis
    public UInt16 lU;       // U-axis
    public UInt16 lV;       // V-axis
    public UInt16 lRx;      // X-axis rotation
    public UInt16 lRy;      // Y-axis rotation
    public UInt16 lRz;      // Z-axis rotation
    public UInt16 lVX;      // X-axis velocity
    public UInt16 lVY;      // Y-axis velocity
    public UInt16 lVZ;      // Z-axis velocity
    public UInt16 lVU;      // U-axis velocity
    public UInt16 lVV;      // V-axis velocity
    public UInt16 lVRx;     // X-axis angular velocity
    public UInt16 lVRy;     // Y-axis angular velocity
    public UInt16 lVRz;     // Z-axis angular velocity
    public UInt16 lAX;      // X-axis acceleration
    public UInt16 lAY;      // Y-axis acceleration
    public UInt16 lAZ;      // Z-axis acceleration
    public UInt16 lAU;      // U-axis acceleration
    public UInt16 lAV;      // V-axis acceleration
    public UInt16 lARx;     // X-axis angular acceleration
    public UInt16 lARy;     // Y-axis angular acceleration
    public UInt16 lARz;     // Z-axis angular acceleration
    public UInt16 lFX;      // X-axis force
    public UInt16 lFY;      // Y-axis force
    public UInt16 lFZ;      // Z-axis force
    public UInt16 lFU;      // U-axis force
    public UInt16 lFV;      // V-axis force
    public UInt16 lFRx;     // X-axis torque
    public UInt16 lFRy;     // Y-axis torque
    public UInt16 lFRz;     // Z-axis torque
    public UInt16 rgdwPOV;  // Store each DPAD in chunks of 4 bits inside 16-bit UInt
    public override int GetHashCode() {
      return BitConverter.ToInt32(DIManager.FlatStateMD5(this), 0);
    }
  }

  /// <summary>
  /// Describes a DirectInput device's capabilities. <br/>
  /// More info: https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ee416607(v=vs.85)
  /// </summary>
  [Serializable]
  public struct DIDEVCAPS {
    public UInt32  dwSize;                // Size of this structure, in bytes.
    public dwFlags dwFlags;               // Flags associated with the device.
    public UInt32  dwDevType;             // Device type specifier. The least-significant byte of the device type description code specifies the device type. The next-significant byte specifies the device subtype. This value can also be combined with DIDEVTYPE_HID, which specifies a Human Interface Device (human interface device).
    public UInt32  dwAxes;                // Number of axes available on the device.
    public UInt32  dwButtons;             // Number of buttons available on the device.
    public UInt32  dwPOVs;                // Number of point-of-view controllers available on the device.
    public UInt32  dwFFSamplePeriod;      // Minimum time between playback of consecutive raw force commands, in microseconds.
    public UInt32  dwFFMinTimeResolution; // Minimum time, in microseconds, that the device can resolve. The device rounds any times to the nearest supported increment. For example, if the value of dwFFMinTimeResolution is 1000, the device would round any times to the nearest millisecond.
    public UInt32  dwFirmwareRevision;    // Firmware revision of the device.
    public UInt32  dwHardwareRevision;    // Hardware revision of the device.
    public UInt32  dwFFDriverVersion;     // Version number of the device driver.
  }

  /// <summary>
  /// Describes the Flags associated with a DirectInput device's capabilities. <br/>
  /// More info: https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ee416607(v=vs.85)#:~:text=IDirectInputDevice8%3A%3AGetCapabilities%20method.-,dwFlags,-Flags%20associated%20with
  /// </summary>
  [Flags]
  public enum dwFlags {
    DIDC_ALIAS              = 0x00010000, // The device is a duplicate of another DirectInput device.
    DIDC_ATTACHED           = 0x00000001, // The device is physically attached to the user's computer.
    DIDC_DEADBAND           = 0x00004000, // The device supports deadband for at least one force-feedback condition.
    DIDC_EMULATED           = 0x00000004, // If this flag is set, the data is coming from a user mode device interface, such as a Human Interface Device (human interface device), or by some other ring 3 means. If it is not set, the data is coming directly from a kernel mode driver.
    DIDC_FORCEFEEDBACK      = 0x00000100, // The device supports force feedback.
    DIDC_FFFADE             = 0x00000400, // The force-feedback system supports the fade parameter for at least one effect.
    DIDC_FFATTACK           = 0x00000200, // The force-feedback system supports the attack parameter for at least one effect.
    DIDC_HIDDEN             = 0x00040000, // Fictitious device created by a device driver so that it can generate keyboard and mouse events.
    DIDC_PHANTOM            = 0x00020000, // Placeholder. Phantom devices are by default not enumerated.
    DIDC_POLLEDDATAFORMAT   = 0x00000008, // At least one object in the current data format is polled, rather than interrupt-driven.
    DIDC_POLLEDDEVICE       = 0x00000002, // At least one object on the device is polled, rather than interrupt-driven. HID devices can contain a mixture of polled and nonpolled objects.
    DIDC_POSNEGCOEFFICIENTS = 0x00001000, // The force-feedback system supports two coefficient values for conditions (one for the positive displacement of the axis and one for the negative displacement of the axis) for at least one condition. If the device does not support both coefficients, the negative coefficient in the DICONDITION structure is ignored.
    DIDC_POSNEGSATURATION   = 0x00002000, // The force-feedback system supports a maximum saturation for both positive and negative force output for at least one condition. If the device does not support both saturation values, the negative saturation in the DICONDITION structure is ignored.
    DIDC_SATURATION         = 0x00000800, // The force-feedback system supports the saturation of condition effects for at least one condition. If the device does not support saturation, the force generated by a condition is limited only by the maximum force that the device can generate.
    DIDC_STARTDELAY         = 0x00008000, // The force-feedback system supports the start delay parameter for at least one effect. If the device does not support start delays, the dwStartDelay member of the DIEFFECT structure is ignored.
  }
}