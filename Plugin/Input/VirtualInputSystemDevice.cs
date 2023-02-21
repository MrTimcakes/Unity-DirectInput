using System.Linq;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
// using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
#if UNITY_EDITOR
using UnityEditor;
#endif
using DirectInputManager;

//////////////////////////////////////////////////////////////
// FlatJoyState2State Struct - InputSystem Bindings
//////////////////////////////////////////////////////////////

/// <summary>
/// Describes a (Flattened)DIJOYSTATE2 in the Unity Input System form <br/>
/// Breaks out RGLSlider-s into U and V axis <br/>
/// See https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ee416628(v=vs.85)
/// </summary>
public struct FlatJoyState2State : IInputStateTypeInfo {
  public FourCC format => new FourCC('D', 'F', 'F', 'B'); // FourCC Code used for type checking? D-F-F-B -> DirectInput FFB

  [InputControl(name="Button000", layout="Button", bit=0,  displayName="000")]
  [InputControl(name="Button001", layout="Button", bit=1,  displayName="001")]
  [InputControl(name="Button002", layout="Button", bit=2,  displayName="002")]
  [InputControl(name="Button003", layout="Button", bit=3,  displayName="003")]
  [InputControl(name="Button004", layout="Button", bit=4,  displayName="004")]
  [InputControl(name="Button005", layout="Button", bit=5,  displayName="005")]
  [InputControl(name="Button006", layout="Button", bit=6,  displayName="006")]
  [InputControl(name="Button007", layout="Button", bit=7,  displayName="007")]
  [InputControl(name="Button008", layout="Button", bit=8,  displayName="008")]
  [InputControl(name="Button009", layout="Button", bit=9,  displayName="009")]
  [InputControl(name="Button010", layout="Button", bit=10, displayName="010")]
  [InputControl(name="Button011", layout="Button", bit=11, displayName="011")]
  [InputControl(name="Button012", layout="Button", bit=12, displayName="012")]
  [InputControl(name="Button013", layout="Button", bit=13, displayName="013")]
  [InputControl(name="Button014", layout="Button", bit=14, displayName="014")]
  [InputControl(name="Button015", layout="Button", bit=15, displayName="015")]
  [InputControl(name="Button016", layout="Button", bit=16, displayName="016")]
  [InputControl(name="Button017", layout="Button", bit=17, displayName="017")]
  [InputControl(name="Button018", layout="Button", bit=18, displayName="018")]
  [InputControl(name="Button019", layout="Button", bit=19, displayName="019")]
  [InputControl(name="Button020", layout="Button", bit=20, displayName="020")]
  [InputControl(name="Button021", layout="Button", bit=21, displayName="021")]
  [InputControl(name="Button022", layout="Button", bit=22, displayName="022")]
  [InputControl(name="Button023", layout="Button", bit=23, displayName="023")]
  [InputControl(name="Button024", layout="Button", bit=24, displayName="024")]
  [InputControl(name="Button025", layout="Button", bit=25, displayName="025")]
  [InputControl(name="Button026", layout="Button", bit=26, displayName="026")]
  [InputControl(name="Button027", layout="Button", bit=27, displayName="027")]
  [InputControl(name="Button028", layout="Button", bit=28, displayName="028")]
  [InputControl(name="Button029", layout="Button", bit=29, displayName="029")]
  [InputControl(name="Button030", layout="Button", bit=30, displayName="030")]
  [InputControl(name="Button031", layout="Button", bit=31, displayName="031")]
  [InputControl(name="Button032", layout="Button", bit=32, displayName="032")]
  [InputControl(name="Button033", layout="Button", bit=33, displayName="033")]
  [InputControl(name="Button034", layout="Button", bit=34, displayName="034")]
  [InputControl(name="Button035", layout="Button", bit=35, displayName="035")]
  [InputControl(name="Button036", layout="Button", bit=36, displayName="036")]
  [InputControl(name="Button037", layout="Button", bit=37, displayName="037")]
  [InputControl(name="Button038", layout="Button", bit=38, displayName="038")]
  [InputControl(name="Button039", layout="Button", bit=39, displayName="039")]
  [InputControl(name="Button040", layout="Button", bit=40, displayName="040")]
  [InputControl(name="Button041", layout="Button", bit=41, displayName="041")]
  [InputControl(name="Button042", layout="Button", bit=42, displayName="042")]
  [InputControl(name="Button043", layout="Button", bit=43, displayName="043")]
  [InputControl(name="Button044", layout="Button", bit=44, displayName="044")]
  [InputControl(name="Button045", layout="Button", bit=45, displayName="045")]
  [InputControl(name="Button046", layout="Button", bit=46, displayName="046")]
  [InputControl(name="Button047", layout="Button", bit=47, displayName="047")]
  [InputControl(name="Button048", layout="Button", bit=48, displayName="048")]
  [InputControl(name="Button049", layout="Button", bit=49, displayName="049")]
  [InputControl(name="Button050", layout="Button", bit=50, displayName="050")]
  [InputControl(name="Button051", layout="Button", bit=51, displayName="051")]
  [InputControl(name="Button052", layout="Button", bit=52, displayName="052")]
  [InputControl(name="Button053", layout="Button", bit=53, displayName="053")]
  [InputControl(name="Button054", layout="Button", bit=54, displayName="054")]
  [InputControl(name="Button055", layout="Button", bit=55, displayName="055")]
  [InputControl(name="Button056", layout="Button", bit=56, displayName="056")]
  [InputControl(name="Button057", layout="Button", bit=57, displayName="057")]
  [InputControl(name="Button058", layout="Button", bit=58, displayName="058")]
  [InputControl(name="Button059", layout="Button", bit=59, displayName="059")]
  [InputControl(name="Button060", layout="Button", bit=60, displayName="060")]
  [InputControl(name="Button061", layout="Button", bit=61, displayName="061")]
  [InputControl(name="Button062", layout="Button", bit=62, displayName="062")]
  [InputControl(name="Button063", layout="Button", bit=63, displayName="063")]
  public UInt64 buttonsA; // Buttons seperated into banks of 64-Bits to fit into Unsigned 64-bit integer

  [InputControl(name="Button064", layout="Button", bit=0,  displayName="064")]
  [InputControl(name="Button065", layout="Button", bit=1,  displayName="065")]
  [InputControl(name="Button066", layout="Button", bit=2,  displayName="066")]
  [InputControl(name="Button067", layout="Button", bit=3,  displayName="067")]
  [InputControl(name="Button068", layout="Button", bit=4,  displayName="068")]
  [InputControl(name="Button069", layout="Button", bit=5,  displayName="069")]
  [InputControl(name="Button070", layout="Button", bit=6,  displayName="070")]
  [InputControl(name="Button071", layout="Button", bit=7,  displayName="071")]
  [InputControl(name="Button072", layout="Button", bit=8,  displayName="072")]
  [InputControl(name="Button073", layout="Button", bit=9,  displayName="073")]
  [InputControl(name="Button074", layout="Button", bit=10, displayName="074")]
  [InputControl(name="Button075", layout="Button", bit=11, displayName="075")]
  [InputControl(name="Button076", layout="Button", bit=12, displayName="076")]
  [InputControl(name="Button077", layout="Button", bit=13, displayName="077")]
  [InputControl(name="Button078", layout="Button", bit=14, displayName="078")]
  [InputControl(name="Button079", layout="Button", bit=15, displayName="079")]
  [InputControl(name="Button080", layout="Button", bit=16, displayName="080")]
  [InputControl(name="Button081", layout="Button", bit=17, displayName="081")]
  [InputControl(name="Button082", layout="Button", bit=18, displayName="082")]
  [InputControl(name="Button083", layout="Button", bit=19, displayName="083")]
  [InputControl(name="Button084", layout="Button", bit=20, displayName="084")]
  [InputControl(name="Button085", layout="Button", bit=21, displayName="085")]
  [InputControl(name="Button086", layout="Button", bit=22, displayName="086")]
  [InputControl(name="Button087", layout="Button", bit=23, displayName="087")]
  [InputControl(name="Button088", layout="Button", bit=24, displayName="088")]
  [InputControl(name="Button089", layout="Button", bit=25, displayName="089")]
  [InputControl(name="Button090", layout="Button", bit=26, displayName="090")]
  [InputControl(name="Button091", layout="Button", bit=27, displayName="091")]
  [InputControl(name="Button092", layout="Button", bit=28, displayName="092")]
  [InputControl(name="Button093", layout="Button", bit=29, displayName="093")]
  [InputControl(name="Button094", layout="Button", bit=30, displayName="094")]
  [InputControl(name="Button095", layout="Button", bit=31, displayName="095")]
  [InputControl(name="Button096", layout="Button", bit=32, displayName="096")]
  [InputControl(name="Button097", layout="Button", bit=33, displayName="097")]
  [InputControl(name="Button098", layout="Button", bit=34, displayName="098")]
  [InputControl(name="Button099", layout="Button", bit=35, displayName="099")]
  [InputControl(name="Button100", layout="Button", bit=36, displayName="100")]
  [InputControl(name="Button101", layout="Button", bit=37, displayName="101")]
  [InputControl(name="Button102", layout="Button", bit=38, displayName="102")]
  [InputControl(name="Button103", layout="Button", bit=39, displayName="103")]
  [InputControl(name="Button104", layout="Button", bit=40, displayName="104")]
  [InputControl(name="Button105", layout="Button", bit=41, displayName="105")]
  [InputControl(name="Button106", layout="Button", bit=42, displayName="106")]
  [InputControl(name="Button107", layout="Button", bit=43, displayName="107")]
  [InputControl(name="Button108", layout="Button", bit=44, displayName="108")]
  [InputControl(name="Button109", layout="Button", bit=45, displayName="109")]
  [InputControl(name="Button110", layout="Button", bit=46, displayName="110")]
  [InputControl(name="Button111", layout="Button", bit=47, displayName="111")]
  [InputControl(name="Button112", layout="Button", bit=48, displayName="112")]
  [InputControl(name="Button113", layout="Button", bit=49, displayName="113")]
  [InputControl(name="Button114", layout="Button", bit=50, displayName="114")]
  [InputControl(name="Button115", layout="Button", bit=51, displayName="115")]
  [InputControl(name="Button116", layout="Button", bit=52, displayName="116")]
  [InputControl(name="Button117", layout="Button", bit=53, displayName="117")]
  [InputControl(name="Button118", layout="Button", bit=54, displayName="118")]
  [InputControl(name="Button119", layout="Button", bit=55, displayName="119")]
  [InputControl(name="Button120", layout="Button", bit=56, displayName="120")]
  [InputControl(name="Button121", layout="Button", bit=57, displayName="121")]
  [InputControl(name="Button122", layout="Button", bit=58, displayName="122")]
  [InputControl(name="Button123", layout="Button", bit=59, displayName="123")]
  [InputControl(name="Button124", layout="Button", bit=60, displayName="124")]
  [InputControl(name="Button125", layout="Button", bit=61, displayName="125")]
  [InputControl(name="Button126", layout="Button", bit=62, displayName="126")]
  [InputControl(name="Button127", layout="Button", bit=63, displayName="127")]
  public UInt64 buttonsB; // Buttons seperated into banks of 64-Bits to fit into Unsigned 64-bit integer

  // Axes listed as "LONG" in C++ (Uint32) but values are 0-65535, so UInt16? No issues so far
  [InputControl(name="X",   layout="Axis", displayName="X")]                        public UInt16 lX;     // X-axis
  [InputControl(name="Y",   layout="Axis", displayName="Y")]                        public UInt16 lY;     // Y-axis
  [InputControl(name="Z",   layout="Axis", displayName="Z")]                        public UInt16 lZ;     // Z-axis
  [InputControl(name="U",   layout="Axis", displayName="U")]                        public UInt16 lU;     // U-axis (rglSlider[0])
  [InputControl(name="V",   layout="Axis", displayName="V")]                        public UInt16 lV;     // V-axis (rglSlider[1])
  [InputControl(name="RX",  layout="Axis", displayName="X Rotation")]               public UInt16 lRx;    // X-axis rotation
  [InputControl(name="RY",  layout="Axis", displayName="Y Rotation")]               public UInt16 lRy;    // Y-axis rotation
  [InputControl(name="RZ",  layout="Axis", displayName="Z Rotation")]               public UInt16 lRz;    // Z-axis rotation
  [InputControl(name="VX",  layout="Axis", displayName="X Velocity")]               public UInt16 lVX;    // X-axis velocity
  [InputControl(name="VY",  layout="Axis", displayName="Y Velocity")]               public UInt16 lVY;    // Y-axis velocity
  [InputControl(name="VZ",  layout="Axis", displayName="Z Velocity")]               public UInt16 lVZ;    // Z-axis velocity
  [InputControl(name="VU",  layout="Axis", displayName="U Velocity")]               public UInt16 lVU;    // U-axis velocity (rglVSlider[0])
  [InputControl(name="VV",  layout="Axis", displayName="V Velocity")]               public UInt16 lVV;    // V-axis velocity (rglVSlider[1])
  [InputControl(name="VRX", layout="Axis", displayName="X Angular Velocity")]       public UInt16 lVRx;   // X-axis angular velocity
  [InputControl(name="VRY", layout="Axis", displayName="Y Angular Velocity")]       public UInt16 lVRy;   // Y-axis angular velocity
  [InputControl(name="VRZ", layout="Axis", displayName="Z Angular Velocity")]       public UInt16 lVRz;   // Z-axis angular velocity
  [InputControl(name="AX",  layout="Axis", displayName="X Acceleration")]           public UInt16 lAX;    // X-axis acceleration
  [InputControl(name="AY",  layout="Axis", displayName="Y Acceleration")]           public UInt16 lAY;    // Y-axis acceleration
  [InputControl(name="AZ",  layout="Axis", displayName="Z Acceleration")]           public UInt16 lAZ;    // Z-axis acceleration
  [InputControl(name="AU",  layout="Axis", displayName="U Acceleration")]           public UInt16 lAU;    // U-axis acceleration (rglASlider[0])
  [InputControl(name="AV",  layout="Axis", displayName="V Acceleration")]           public UInt16 lAV;    // V-axis acceleration (rglASlider[1])
  [InputControl(name="ARX", layout="Axis", displayName="X Angular Acceleration")]   public UInt16 lARx;   // X-axis angular acceleration
  [InputControl(name="ARY", layout="Axis", displayName="Y Angular Acceleration")]   public UInt16 lARy;   // Y-axis angular acceleration
  [InputControl(name="ARZ", layout="Axis", displayName="Z Angular Acceleration")]   public UInt16 lARz;   // Z-axis angular acceleration
  [InputControl(name="AFX", layout="Axis", displayName="X Force")]                  public UInt16 lFX;    // X-axis force
  [InputControl(name="AFY", layout="Axis", displayName="Y Force")]                  public UInt16 lFY;    // Y-axis force
  [InputControl(name="AFZ", layout="Axis", displayName="Z Force")]                  public UInt16 lFZ;    // Z-axis force
  [InputControl(name="AFU", layout="Axis", displayName="U Force")]                  public UInt16 lFU;    // U-axis force (rglFSlider[0])
  [InputControl(name="AFV", layout="Axis", displayName="V Force")]                  public UInt16 lFV;    // V-axis force (rglFSlider[1])
  [InputControl(name="FRX", layout="Axis", displayName="X Torque")]                 public UInt16 lFRx;   // X-axis torque
  [InputControl(name="FRY", layout="Axis", displayName="Y Torque")]                 public UInt16 lFRy;   // Y-axis torque
  [InputControl(name="FRZ", layout="Axis", displayName="Z Torque")]                 public UInt16 lFRz;   // Z-axis torque

  [InputControl(name="dpad0", layout="Dpad",  bit=0, sizeInBits=4, displayName="Dpad0")]
    [InputControl(name="dpad0/up",    bit=0,  displayName="Up"   )]
    [InputControl(name="dpad0/down",  bit=1,  displayName="Down" )]
    [InputControl(name="dpad0/left",  bit=2,  displayName="Left" )]
    [InputControl(name="dpad0/right", bit=3,  displayName="Right")]
  [InputControl(name="dpad1", layout="Dpad",  bit=4, sizeInBits=4, displayName="Dpad1")]
    [InputControl(name="dpad1/up",    bit=4,  displayName="Up"   )]
    [InputControl(name="dpad1/down",  bit=5,  displayName="Down" )]
    [InputControl(name="dpad1/left",  bit=6,  displayName="Left" )]
    [InputControl(name="dpad1/right", bit=7,  displayName="Right")]
  [InputControl(name="dpad2", layout="Dpad",  bit=8, sizeInBits=4, displayName="Dpad2")]
    [InputControl(name="dpad2/up",    bit=8,  displayName="Up"   )]
    [InputControl(name="dpad2/down",  bit=9,  displayName="Down" )]
    [InputControl(name="dpad2/left",  bit=10, displayName="Left" )]
    [InputControl(name="dpad2/right", bit=11, displayName="Right")]
  [InputControl(name="dpad3", layout="Dpad",  bit=12, sizeInBits=4, displayName="Dpad3")]
    [InputControl(name="dpad3/up",    bit=12, displayName="Up"   )]
    [InputControl(name="dpad3/down",  bit=13, displayName="Down" )]
    [InputControl(name="dpad3/left",  bit=14, displayName="Left" )]
    [InputControl(name="dpad3/right", bit=15, displayName="Right")]
  public UInt16 rgdwPOV; // Store each DPAD in chunks of 4 bits inside a 16-bit Unsigned integer   
}

//////////////////////////////////////////////////////////////
// DirectInputDevice - InputSystem Logic
//////////////////////////////////////////////////////////////

#if UNITY_EDITOR
[InitializeOnLoad]
#endif
[InputControlLayout(displayName="DirectInput Device",stateType=typeof(FlatJoyState2State))]
public class DirectInputDevice : InputDevice, IInputUpdateCallbackReceiver{

  public static DirectInputDevice current { get; private set; }

#if UNITY_EDITOR
  static DirectInputDevice(){
    Initialize();                                                                                         // Make sure layouts are ready even when just in the editor
  }
#endif

  [RuntimeInitializeOnLoadMethod]
  private static void Initialize(){
    DIManager.Initialize();                                                                               // Start DirectInput if it's not already
    DIManager.EnumerateDevices();                                                                         // Scan for available devices 
    // await DIManager.EnumerateDevicesAsync();                                                           // Async allows to detect enumeration issues but causes issues with domain reloads as await yields and processes devices before layouts can be built
    DIManager.OnDeviceAdded += DIDeviceAdded;                                                             // Register handler for when a device is attached
    GenerateISLayouts();                                                                                  // Create InputSystem Layouts for the DI Devices
    AddAllDIDevicesToIS();                                                                                // Create InputSystem Devices for the DI Devices
  }
  
  public static void GenerateISLayouts(){
    foreach (DeviceInfo device in DIManager.devices){
      InputSystem.RegisterLayout<DirectInputDevice>($"DI_{device.productName}", matches:                  // Create a layout so we can uniquely address this device
        new InputDeviceMatcher().WithProduct($"DID_{device.productName}")                                 // Interface name to match our device against
      );
    }
  }

  protected override void FinishSetup(){
    if (DIManager.Attach(this.description.serial)){                                                       // Doing this in FinishSetup allows events to be re-created on Domain reloads
      DIManager.activeDevices[this.description.serial].OnDeviceRemoved     += this.DIDeviceRemoved;       // Register a handler for when the device is removed
      DIManager.activeDevices[this.description.serial].OnDeviceStateChange += this.DeviceStateChanged;    // Register a handler for when the device state changes
    }
    base.FinishSetup();
  }

  public override void MakeCurrent(){
    base.MakeCurrent();
    current = this;
  }

  protected override void OnRemoved(){
    base.OnRemoved();
    if (current == this){ current = null; }
  }

  public void OnUpdate(){
    DIManager.Poll(this.description.serial); // TODO: Make ASYNC 
  }

  public static bool AddDIDeviceToIS(DeviceInfo device){
    if (InputSystem.devices.OfType<DirectInputDevice>().Where(d => d.description.serial == device.guidInstance).Any()){ return true; } // Device already exists
    if (DIManager.Attach(device)){                                                                        // Attach to DirectInput device, proceed if successfully connected
      InputDevice ISDevice = InputSystem.AddDevice(new InputDeviceDescription {
        interfaceName = $"Unity-DirectInput",
        product       = $"DID_{device.productName}",
        serial        = $"{device.guidInstance}",
        capabilities  = $@"{{""FFBCapable"":{device.FFBCapable.ToString().ToLower()}}}",
      });
      return true;
    }
    return false;                                                                                          // Couldn't attach to device
  }

  public static void DIDeviceAdded(DeviceInfo device){
    Debug.Log($"<color=#9416f9>[DirectInputManager]</color> <color=#6affff>DIDeviceAdded: {device.productName} : {device.guidProduct}</color>");
    GenerateISLayouts();                                                                                   // Ensure a layout is ready for the new device
    AddDIDeviceToIS(device);                                                                               // Add device to IS
  }

  protected void DIDeviceRemoved(DeviceInfo device){
    Debug.Log($"<color=#9416f9>[DirectInputManager]</color> <color=#ff0000>DIDeviceRemoved: {device.productName} : {device.guidProduct}</color>");
    InputSystem.RemoveDevice(this);                                                                        // Remove device from InputSystem, DIManager handles destroying the device for us :)
  }
  
  protected void DeviceStateChanged(DeviceInfo device, FlatJoyState2 state){
    // Convert FlatJoyState2 to FlatJoyState2State (The InputSystem Type)
    GCHandle handle = GCHandle.Alloc(state, GCHandleType.Pinned);
    FlatJoyState2State ISState = (FlatJoyState2State)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(FlatJoyState2State));
    handle.Free();
    
    InputDevice ISDevice = InputSystem.devices.OfType<DirectInputDevice>().Where(d => d.description.serial == device.guidInstance).FirstOrDefault(); // "this" caused issues after domain reload
    if (ISDevice != null)
      InputSystem.QueueStateEvent(ISDevice, ISState);                                                      // Notify InputSystem with updated state
  }
  
  private static void AddAllDIDevicesToIS(){
    foreach (DeviceInfo device in DIManager.devices)
      AddDIDeviceToIS(device);
  }

  // #if UNITY_EDITOR
  // [MenuItem("FFBDev/Add All DI Devices To IS")]
  // #endif
  // private static void AddAllDIDevicesToIS(){
  //   foreach (DeviceInfo device in DIManager.devices)
  //     AddDIDeviceToIS(device);
  // }

  // #if UNITY_EDITOR
  // [MenuItem("FFBDev/Remove All Devices From IS")]
  // private static void RemoveAllDevices(){
  //   while(InputSystem.devices.OfType<DirectInputDevice>().Any()){
  //     InputSystem.RemoveDevice(InputSystem.devices.OfType<DirectInputDevice>().First());
  //   }
  // }

  // [MenuItem("FFBDev/Remove All Layouts From IS")]
  // private static void RemoveAllLayouts(){
  //   foreach (DeviceInfo device in DIManager.devices){
  //     InputSystem.RemoveLayout($"DI_{device.productName}");
  //   }
  // }
  // #endif
}

//////////////////////////////////////////////////////////////
// Input System Processors
//////////////////////////////////////////////////////////////

/// <summary>
/// Unity Input System Processor to center Axis values, like steering wheels
/// </summary>
#if UNITY_EDITOR
[InitializeOnLoad]
#endif
public class CenterAxisProcessor : InputProcessor<float>{
  #if UNITY_EDITOR
  static CenterAxisProcessor(){ Initialize(); }
  #endif

  [RuntimeInitializeOnLoadMethod]
  static void Initialize(){ InputSystem.RegisterProcessor<CenterAxisProcessor>(); }

  public override float Process(float value, InputControl control){
    return (value*2)-1;
  }
}


/// <summary>
/// (Value*-1)+1    Smart Invert, remaps values from 1-0 to 0-1
/// </summary>
#if UNITY_EDITOR
[InitializeOnLoad]
#endif
public class SmartInvertProcessor : InputProcessor<float>{
  #if UNITY_EDITOR
  static SmartInvertProcessor(){ Initialize(); }
  #endif

  [RuntimeInitializeOnLoadMethod]
  static void Initialize(){ InputSystem.RegisterProcessor<SmartInvertProcessor>(); }

  public override float Process(float value, InputControl control){
    return (value*-1)+1;
  }
}