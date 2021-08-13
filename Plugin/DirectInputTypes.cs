using System;
using System.Runtime.InteropServices;

namespace DirectInputManager {
  public enum EffectsType {
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

  [Serializable]
  [StructLayout(LayoutKind.Sequential)]
  public struct DeviceInfo {
    public uint deviceType;
    [MarshalAs(UnmanagedType.LPStr)]
    public string guidInstance;
    [MarshalAs(UnmanagedType.LPStr)]
    public string guidProduct;
    [MarshalAs(UnmanagedType.LPStr)]
    public string instanceName;
    [MarshalAs(UnmanagedType.LPStr)]
    public string productName;
  }

  /// <summary>
  /// See https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ee416601(v=vs.85)
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
  /// Describes the state of a joystick device with extended capabilities.
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

  [Serializable]
  public struct FlatJoyState2 {
    public UInt64 buttonsA; // Buttons seperated into banks of 64-Bits to fit into Unsigned 64-bit integer
    public UInt64 buttonsB; // Buttons seperated into banks of 64-Bits to fit into Unsigned 64-bit integer
    public UInt32 lX;       // X-axis
    public UInt32 lY;       // Y-axis
    public UInt32 lZ;       // Z-axis
    public UInt32 lU;       // U-axis
    public UInt32 lV;       // V-axis
    public UInt32 lRx;      // X-axis rotation
    public UInt32 lRy;      // Y-axis rotation
    public UInt32 lRz;      // Z-axis rotation
    public UInt32 lVX;      // X-axis velocity
    public UInt32 lVY;      // Y-axis velocity
    public UInt32 lVZ;      // Z-axis velocity
    public UInt32 lVU;      // U-axis velocity
    public UInt32 lVV;      // V-axis velocity
    public UInt32 lVRx;     // X-axis angular velocity
    public UInt32 lVRy;     // Y-axis angular velocity
    public UInt32 lVRz;     // Z-axis angular velocity
    public UInt32 lAX;      // X-axis acceleration
    public UInt32 lAY;      // Y-axis acceleration
    public UInt32 lAZ;      // Z-axis acceleration
    public UInt32 lAU;      // U-axis acceleration
    public UInt32 lAV;      // V-axis acceleration
    public UInt32 lARx;     // X-axis angular acceleration
    public UInt32 lARy;     // Y-axis angular acceleration
    public UInt32 lARz;     // Z-axis angular acceleration
    public UInt32 lFX;      // X-axis force
    public UInt32 lFY;      // Y-axis force
    public UInt32 lFZ;      // Z-axis force
    public UInt32 lFU;      // U-axis force
    public UInt32 lFV;      // V-axis force
    public UInt32 lFRx;     // X-axis torque
    public UInt32 lFRy;     // Y-axis torque
    public UInt32 lFRz;     // Z-axis torque
    public UInt16 rgdwPOV;  // Store each DPAD in chunks of 4 bits inside 16-bit UInt   
  }

  [Flags]
  public enum dwFlags {
    DIDC_ALIAS = 0x00010000,
    DIDC_ATTACHED = 0x00000001,
    DIDC_DEADBAND = 0x00004000,
    DIDC_EMULATED = 0x00000004,
    DIDC_FORCEFEEDBACK = 0x00000100,
    DIDC_FFFADE = 0x00000400,
    DIDC_FFATTACK = 0x00000200,
    DIDC_HIDDEN = 0x00040000,
    DIDC_PHANTOM = 0x00020000,
    DIDC_POLLEDDATAFORMAT = 0x00000008,
    DIDC_POLLEDDEVICE = 0x00000002,
    DIDC_POSNEGCOEFFICIENTS = 0x00001000,
    DIDC_POSNEGSATURATION = 0x00002000,
    DIDC_SATURATION = 0x00000800,
    DIDC_STARTDELAY = 0x00008000,
  }

  [Serializable]
  public struct DIDEVCAPS {
    public UInt32 dwSize; // Size of this structure, in bytes.
    public dwFlags dwFlags; // Flags associated with the device.
    public UInt32 dwDevType; // Device type specifier. The least-significant byte of the device type description code specifies the device type. The next-significant byte specifies the device subtype. This value can also be combined with DIDEVTYPE_HID, which specifies a Human Interface Device (human interface device).
    public UInt32 dwAxes; // Number of axes available on the device.
    public UInt32 dwButtons; // Number of buttons available on the device.
    public UInt32 dwPOVs; // Number of point-of-view controllers available on the device.
    public UInt32 dwFFSamplePeriod; // Minimum time between playback of consecutive raw force commands, in microseconds.
    public UInt32 dwFFMinTimeResolution; // Minimum time, in microseconds, that the device can resolve. The device rounds any times to the nearest supported increment. For example, if the value of dwFFMinTimeResolution is 1000, the device would round any times to the nearest millisecond.
    public UInt32 dwFirmwareRevision; // Firmware revision of the device.
    public UInt32 dwHardwareRevision; // Hardware revision of the device.
    public UInt32 dwFFDriverVersion; // Version number of the device driver.
  }
}