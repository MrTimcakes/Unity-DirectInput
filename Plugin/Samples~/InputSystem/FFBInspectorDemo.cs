using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using DirectInputManager;

public class FFBInspectorDemo : MonoBehaviour {
	public InputActionAsset ControlScheme;																									// Input System control scheme
	DirectInputDevice ISDevice;
	InputActionMap Actions;

	public bool EnableFFB = true;
	public string FFBDeviceName = "Waiting for Play Mode";
	[Range(0,1)] public float FFBAxisValue = 0;

	[Header("FFB Constant Force")]
	public bool ConstantForceEnabled = false;
	[Range(-10000f, 10000f)]public int ConstantForceMagnitude;

	[Header("FFB Damper")]
	public bool DamperForceEnabled = false;
	[Range(-10000f, 10000f)] public int DamperMagnitude;

	[Header("FFB Friction")]
	public bool FrictionForceEnabled = false;
	[Range(-10000f, 10000f)] public int FrictionMagnitude;
	
	[Header("FFB Inertia")]
	public bool InertiaForceEnabled = false;
	[Range(-10000f, 10000f)] public int InertiaMagnitude;
	
	[Header("FFB Spring")]
	public bool SpringForceEnabled = false;
	[Range(0, 10000f)] public uint SpringDeadband;
	[Range(-10000f, 10000f)] public int SpringOffset;
	[Range(0, 10000f)] public int SpringCoefficient;
	[Range(0, 10000f)] public uint SpringSaturation;

	void Start() {
		Actions = ControlScheme.FindActionMap("DirectInputDemo");													      // Find the correct action map 
		Actions.Enable();
	}

	void Update(){
		if(!EnableFFB){ return; }
    if (ISDevice == null) {
      FFBDeviceName = "Waiting for Steering Device";                                        // Reset device name status
      ISDevice = Actions.FindAction("FFBAxis").controls                                     // Select the control intended to have FFB
        .Select(x => x.device)                                                              // Select the "device" child element
        .OfType<DirectInputDevice>()                                                        // Filter to our DirectInput Type
        .Where(d => d.description.capabilities.Contains("\"FFBCapable\":true"))             // Ensure the Device is FFBCapable
        .Where(d => DIManager.Attach(d.description.serial))                                 // Attempt to attach to device
        .FirstOrDefault();                                                                  // Return the first successful or null if none found
      if (ISDevice == null) { return; }
      FFBDeviceName = ISDevice.name + " : " + ISDevice.description.serial;
      Debug.Log($"FFB Device: {ISDevice.description.serial}, Acquired: {DIManager.Attach(ISDevice.description.serial)}");
      DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.ConstantForce);
      DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.Damper);
      DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.Friction);
      DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.Inertia);
      DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.Spring);
		}

		if (ISDevice is not null) {
			FFBAxisValue = Actions.FindAction("FFBAxis").ReadValue<float>(); // Poll state of input axis
			if (ConstantForceEnabled) { DIManager.UpdateConstantForceSimple(ISDevice.description.serial, ConstantForceMagnitude); }
			if (DamperForceEnabled) 	{ DIManager.UpdateDamperSimple(ISDevice.description.serial, DamperMagnitude); }
			if (FrictionForceEnabled) { DIManager.UpdateFrictionSimple(ISDevice.description.serial, FrictionMagnitude); }
			if (InertiaForceEnabled) 	{ DIManager.UpdateInertiaSimple(ISDevice.description.serial, InertiaMagnitude); }
			if (SpringForceEnabled) 	{ DIManager.UpdateSpringSimple(ISDevice.description.serial, SpringDeadband, SpringOffset, SpringCoefficient, SpringCoefficient, SpringSaturation, SpringSaturation); }
		}
	}

	void OnDestroy(){
    if(ISDevice != null){
      DIManager.StopAllFFBEffects(ISDevice.description.serial);
    }
  }
}
