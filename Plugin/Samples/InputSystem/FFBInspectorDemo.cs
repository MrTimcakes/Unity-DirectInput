using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using DirectInputManager;
using UnityEditor.Experimental.GraphView;

public class FFBInspectorDemo : MonoBehaviour
{
    public InputActionAsset ControlScheme;                                // Input System control scheme
    DirectInputDevice ISDevice;
    InputActionMap Actions;

    public bool EnableFFB = true;
    public string FFBDeviceName = "Waiting for Play Mode";
    [Range(0, 1)] public float FFBAxisValue = 0;

    [Header("FFB Constant Force")]
    public bool ConstantForceEnabled = false;
    [Range(-10000f, 10000f)] public int ConstantForceMagnitude;

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


    [Header("Periodic & Custom Effects \nPlease note that negative values may result unexpected FFB! \n\nFFB Sine")]
    public bool SineForceEnabled = false;
    [Range(-10000f, 10000f)] public int SineMagnitude;
    [Range(0, 100000)] public uint SinePeriod = 30000;  // Default to 30000 microseconds

    [Header("FFB Square")]
    public bool SquareForceEnabled = false;
    [Range(-10000f, 10000f)] public int SquareMagnitude;
    [Range(0, 100000)] public uint SquarePeriod = 30000;  // Default to 30000 microseconds

    [Header("FFB Triangle")]
    public bool TriangleForceEnabled = false;
    [Range(-10000f, 10000f)] public int TriangleMagnitude;
    [Range(0, 100000)] public uint TrianglePeriod = 30000;  // Default to 30000 microseconds

    [Header("FFB SawtoothUp")]
    public bool SawtoothUpForceEnabled = false;
    [Range(-10000f, 10000f)] public int SawtoothUpMagnitude;
    [Range(0, 100000)] public uint SawtoothUpPeriod = 30000;  // Default to 30000 microseconds

    [Header("FFB SawtoothDown")]
    public bool SawtoothDownForceEnabled = false;
    [Range(-10000f, 10000f)] public int SawtoothDownMagnitude;
    [Range(0, 100000)] public uint SawtoothDownPeriod = 30000;  // Default to 30000 microseconds

    [Header("FFB Ramp")]
    public bool RampForceEnabled = false;
    [Range(-10000f, 10000f)] public int RampStart;
    [Range(-10000f, 10000f)] public int RampEnd;

    bool ConstantForceWasEnabled { get; set; }
    bool DamperForceWasEnabled { get; set; }
    bool FrictionForceWasEnabled { get; set; }
    bool InertiaForceWasEnabled { get; set; }
    bool SpringForceWasEnabled { get; set; }
    bool SineForceWasEnabled { get; set; }
    bool SquareForceWasEnabled { get; set; }
    bool TriangleForceWasEnabled { get; set; }
    bool SawtoothUpForceWasEnabled { get; set; }
    bool SawtoothDownForceWasEnabled { get; set; }
    bool RampForceWasEnabled { get; set; }
    ////////////////bool CustomForceEnabled { get; set; }

    ////////////////[Header("FFB Custom Force - LOOKS TO BE IMCOMPLETE (HAS UNKNOWN ISSUE), Fanatec CSL DD was used fyi.")]
    ////////////////public bool CustomForceEnabled = false;
    ////////////////[Range(-10000f, 10000f)] public int[] CustomForceMagnitudes = new int[10];
    ////////////////[Range(1000, 10000)] public uint CustomForceSamplePeriod = 1000;

    void Start()
    {
        Actions = ControlScheme.FindActionMap("DirectInputDemo");        // Find the correct action map 
        Actions.Enable();
    }

    void Update()
    {
        if (!EnableFFB) { return; }
        if (ISDevice == null)
        {
            FFBDeviceName = "Waiting for Steering Device";               // Reset device name status
            ISDevice = Actions.FindAction("FFBAxis").controls            // Select the control intended to have FFB
                .Select(x => x.device)                                   // Select the "device" child element
                .OfType<DirectInputDevice>()                            // Filter to our DirectInput Type
                .Where(d => d.description.capabilities.Contains("\"FFBCapable\":true"))     // Ensure the Device is FFBCapable
                .Where(d => DIManager.Attach(d.description.serial))      // Attempt to attach to device
                .FirstOrDefault();                                       // Return the first successful or null if none found
            if (ISDevice == null) { return; }
            FFBDeviceName = ISDevice.name + " : " + ISDevice.description.serial;
            Debug.Log($"FFB Device: {ISDevice.description.serial}, Acquired: {DIManager.Attach(ISDevice.description.serial)}");
        }

        if (ISDevice is not null)
        {
            FFBAxisValue = Actions.FindAction("FFBAxis").ReadValue<float>();  // Poll state of input axis

            // Update all enabled effects
            if (ConstantForceEnabled)
            {
                if (ConstantForceWasEnabled)
                    DIManager.UpdateConstantForceSimple(ISDevice.description.serial, ConstantForceMagnitude);
                else
                    DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.ConstantForce);

                ConstantForceWasEnabled = true;
            }
            else if (ConstantForceWasEnabled)
            {
                ConstantForceWasEnabled = false;
                DIManager.DestroyFFBEffect(ISDevice.description.serial, FFBEffects.ConstantForce);
            }

            if (DamperForceEnabled)
            {
                if (DamperForceWasEnabled)
                    DIManager.UpdateDamperSimple(ISDevice.description.serial, DamperMagnitude);
                else
                    DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.Damper);

                DamperForceWasEnabled = true;
            }
            else if (DamperForceWasEnabled)
            {
                DamperForceWasEnabled = false;
                DIManager.DestroyFFBEffect(ISDevice.description.serial, FFBEffects.Damper);
            }

            if (FrictionForceEnabled)
            {
                if (FrictionForceWasEnabled)
                    DIManager.UpdateFrictionSimple(ISDevice.description.serial, FrictionMagnitude);
                else
                    DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.Friction);

                FrictionForceWasEnabled = true;
            }
            else if (FrictionForceWasEnabled)
            {
                FrictionForceWasEnabled = false;
                DIManager.DestroyFFBEffect(ISDevice.description.serial, FFBEffects.Friction);
            }

            if (InertiaForceEnabled)
            {
                if (InertiaForceWasEnabled)
                    DIManager.UpdateInertiaSimple(ISDevice.description.serial, InertiaMagnitude);
                else
                    DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.Inertia);

                InertiaForceWasEnabled = true;
            }
            else if (InertiaForceWasEnabled)
            {
                InertiaForceWasEnabled = false;
                DIManager.DestroyFFBEffect(ISDevice.description.serial, FFBEffects.Inertia);
            }

            if (SpringForceEnabled)
            {
                if (SpringForceWasEnabled)
                    DIManager.UpdateSpringSimple(ISDevice.description.serial, SpringDeadband, SpringOffset,
                        SpringCoefficient, SpringCoefficient, SpringSaturation, SpringSaturation);
                else
                    DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.Spring);

                SpringForceWasEnabled = true;
            }
            else if (SpringForceWasEnabled)
            {
                DIManager.DestroyFFBEffect(ISDevice.description.serial, FFBEffects.Spring);
                SpringForceWasEnabled = false;
            }

            if (SineForceEnabled)
            {
                if (SineForceWasEnabled)
                    DIManager.UpdatePeriodicSimple(ISDevice.description.serial, FFBEffects.Sine, SineMagnitude, SinePeriod);
                else
                    DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.Sine);

                SineForceWasEnabled = true;
            }
            else if (SineForceWasEnabled)
            {
                SineForceWasEnabled = false;
                DIManager.DestroyFFBEffect(ISDevice.description.serial, FFBEffects.Sine);
            }

            if (SquareForceEnabled)
            {
                if (SquareForceWasEnabled)
                    DIManager.UpdatePeriodicSimple(ISDevice.description.serial, FFBEffects.Square, SquareMagnitude, SquarePeriod);
                else
                    DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.Square);

                SquareForceWasEnabled = true;
            }
            else if (SquareForceWasEnabled)
            {
                SquareForceWasEnabled = false;
                DIManager.DestroyFFBEffect(ISDevice.description.serial, FFBEffects.Square);
            }

            if (TriangleForceEnabled)
            {
                if (TriangleForceWasEnabled)
                    DIManager.UpdatePeriodicSimple(ISDevice.description.serial, FFBEffects.Triangle, TriangleMagnitude, TrianglePeriod);
                else
                    DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.Triangle);

                TriangleForceWasEnabled = true;
            }
            else if (TriangleForceWasEnabled)
            {
                TriangleForceWasEnabled = false;
                DIManager.DestroyFFBEffect(ISDevice.description.serial, FFBEffects.Triangle);
            }

            if (SawtoothUpForceEnabled)
            {
                if (SawtoothUpForceWasEnabled)
                    DIManager.UpdatePeriodicSimple(ISDevice.description.serial, FFBEffects.SawtoothUp, SawtoothUpMagnitude, SawtoothUpPeriod);
                else
                    DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.SawtoothUp);

                SawtoothUpForceWasEnabled = true;
            }
            else if (SawtoothUpForceWasEnabled)
            {
                SawtoothUpForceWasEnabled = false;
                DIManager.DestroyFFBEffect(ISDevice.description.serial, FFBEffects.SawtoothUp);
            }

            if (SawtoothDownForceEnabled)
            {
                if (SawtoothUpForceWasEnabled)
                    DIManager.UpdatePeriodicSimple(ISDevice.description.serial, FFBEffects.SawtoothDown, SawtoothDownMagnitude, SawtoothDownPeriod);
                else
                    DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.SawtoothDown);

                SawtoothDownForceWasEnabled = true;

            }
            else if (SawtoothDownForceWasEnabled)
            {
                SawtoothDownForceWasEnabled = false;
                DIManager.DestroyFFBEffect(ISDevice.description.serial, FFBEffects.SawtoothDown);
            }

            if (RampForceEnabled)
            {
                if (RampForceWasEnabled)
                    DIManager.UpdatePeriodicSimple(ISDevice.description.serial, FFBEffects.RampForce, 0, 0, RampStart, RampEnd);
                else
                    DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.RampForce);

                RampForceWasEnabled = true;
            }
            else if (RampForceWasEnabled)
            {
                RampForceWasEnabled = false;
                DIManager.DestroyFFBEffect(ISDevice.description.serial, FFBEffects.RampForce);
            }


            //////////////////if (CustomForceEnabled)
            ////////////////// {  if (CustomForceWasEnabled)  DIManager.EnableFFBEffect(ISDevice.description.serial, FFBEffects.CustomForce);
            //////////////////    else DIManager.UpdateCustomForceEffect(ISDevice.description.serial, CustomForceMagnitudes, CustomForceSamplePeriod); CustomForceEnabled = true;}
            //////////////////else if (CustomForceEnabled) {
            //////////////////    DIManager.DestroyFFBEffect(ISDevice.description.serial, FFBEffects.CustomForce); CustomForceEnabled = false;}
        }
    }

    void OnDestroy()
    {
        if (ISDevice != null)
        {
            DIManager.Destroy(ISDevice.description.serial);
        }
    }
}
