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

  [Serializable]
  [StructLayout(LayoutKind.Sequential)]
  public struct DeviceAxisInfo {
    public uint offset;
    public uint type;
    public uint flags;
    public uint ffMaxForce;
    public uint ffForceResolution;
    public uint collectionNumber;
    public uint designatorIndex;
    public uint usagePage;
    public uint usage;
    public uint dimension;
    public uint exponent;
    public uint reportId;
    [MarshalAs(UnmanagedType.LPStr)]
    public string guidType;
    [MarshalAs(UnmanagedType.LPStr)]
    public string name;
  };

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
    public int deadband;
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
    public ulong buttonsA; // Buttons seperated into banks of 64-Bits to fit into Unsigned 64-bit integer
    public ulong buttonsB; // Buttons seperated into banks of 64-Bits to fit into Unsigned 64-bit integer
    public ushort lX; // X-axis
    public ushort lY; // Y-axis
    public ushort lZ; // Z-axis
    public ushort lU; // U-axis
    public ushort lV; // V-axis
    public ushort lRx; // X-axis rotation
    public ushort lRy; // Y-axis rotation
    public ushort lRz; // Z-axis rotation
    public ushort lVX; // X-axis velocity
    public ushort lVY; // Y-axis velocity
    public ushort lVZ; // Z-axis velocity
    public ushort lVU; // U-axis velocity
    public ushort lVV; // V-axis velocity
    public ushort lVRx; // X-axis angular velocity
    public ushort lVRy; // Y-axis angular velocity
    public ushort lVRz; // Z-axis angular velocity
    public ushort lAX; // X-axis acceleration
    public ushort lAY; // Y-axis acceleration
    public ushort lAZ; // Z-axis acceleration
    public ushort lAU; // U-axis acceleration
    public ushort lAV; // V-axis acceleration
    public ushort lARx; // X-axis angular acceleration
    public ushort lARy; // Y-axis angular acceleration
    public ushort lARz; // Z-axis angular acceleration
    public ushort lFX; // X-axis force
    public ushort lFY; // Y-axis force
    public ushort lFZ; // Z-axis force
    public ushort lFU; // U-axis force
    public ushort lFV; // V-axis force
    public ushort lFRx; // X-axis torque
    public ushort lFRy; // Y-axis torque
    public ushort lFRz; // Z-axis torque
    public short rgdwPOV; // Store each DPAD in chunks of 4 bits inside 16-bit short     
  }
}