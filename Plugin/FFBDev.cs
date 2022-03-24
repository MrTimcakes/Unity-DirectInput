using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using DirectInputManager;

public class FFBDev : MonoBehaviour
{
  public InputActionAsset ActionAsset;
  InputActionMap VehicleActions;

  public float dev1;

  DirectInputDevice DIDevice = null;
  public string DIDeviceName = "Waiting for Steering Device";
  public AudioClip ConnectionSound;

  [Range(-1,1)]float CF = 0;

  private void OnEnable() { ActionAsset.Enable();  }
  private void OnDisable(){ ActionAsset.Disable(); } 

  void Awake() {
    VehicleActions = ActionAsset.FindActionMap("Vehicle");

    VehicleActions.FindAction("Steering").performed += onSteering;
  }

  void onSteering (InputAction.CallbackContext ctx){ dev1 = ctx.ReadValue<float>() * 1000; }//Vehicle.data.Set(Channel.Input, InputData.Steer,     (int)(ctx.ReadValue<float>()*10000)); }

  // // Update is called once per frame
  // void Update() {

  // }
  
  async void FixedUpdate() {
    if(DIDevice == null){
      DIDeviceName = "Waiting for Steering Device";                                         // Reset device name status
      // var actions = (gameObject.GetComponentInParent(typeof(VPInputSystem)) as VPInputSystem).ActionAsset.FindActionMap("VehicleActions");
      var actions = VehicleActions;
      DIDevice = actions.FindAction("Steering").controls                                    // From the control map, fetch  the devices for the steering input
        .Select(x => x.device)                                                              // Select the "device" child element
        .OfType<DirectInputDevice>()                                                        // Filter to our DirectInput Type
        .Where(d => d.deviceInfo.FFBCapable)                                                // Ensure the Device is FFBCapable
        .Where(d => DIManager.Attach(d.deviceInfo))                                         // Attempt to attach to device
        .Where(d => DIManager.EnableFFBEffect(d.deviceInfo, FFBEffects.ConstantForce))
        .Where(d => DIManager.EnableFFBEffect(d.deviceInfo, FFBEffects.Spring))
        .Where(d => DIManager.EnableFFBEffect(d.deviceInfo, FFBEffects.Damper))
        .FirstOrDefault();                                                                  // Return the first successful or null if none found
      if(DIDevice == null){return;}
      DIDeviceName = DIDevice.deviceInfo.productName + ":" + DIDevice.deviceInfo.guidInstance;
      if(ConnectionSound!=null){ AudioSource.PlayClipAtPoint(ConnectionSound, transform.position); } // Play sound effect
    }

    // DIManager.UpdateConstantForceSimple(DIDevice.deviceInfo, (int)CF*1000);
  }
}
