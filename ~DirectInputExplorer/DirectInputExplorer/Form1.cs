using System;
using System.Linq;
using System.Windows.Forms;
using DirectInputManager;


namespace DirectInputExplorer {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    //////////////////////////////////////////////////////////////
    // .NET Events/Actions
    //////////////////////////////////////////////////////////////

    private void Form1_Load(object sender, EventArgs e) {
      DIManager.Initialize();
      ButtonEnumerateDevices.PerformClick();
      if(DIManager.devices.Length != 0) { ComboBoxDevices.SelectedIndex = 0; } // Select first device by default

      // Disable tabs until device is attached
      foreach (TabPage tab in TabController.TabPages) {
        tab.Enabled = false;
      }
      (TabController.TabPages[0] as TabPage).Enabled = true;
      (TabController.TabPages["TabMisc"] as TabPage).Enabled = true;
    }

    private void ButtonEnumerateDevices_Click(object sender, EventArgs e) {
      string ExistingGUID = ComboBoxDevices.SelectedIndex != -1 ? DIManager.devices[ComboBoxDevices.SelectedIndex].guidInstance : ""; // GUID if device selected, empty if not
      DIManager.EnumerateDevices(); // Fetch currently plugged in devices

      ComboBoxDevices.Items.Clear();
      foreach(DeviceInfo device in DIManager.devices) {
        ComboBoxDevices.Items.Add( device.productName );
      }

      if (!String.IsNullOrEmpty(ExistingGUID)) { ComboBoxDevices.SelectedIndex = Array.FindIndex(DIManager.devices, d => d.guidInstance == ExistingGUID); } // Reselect that device
    }

    private void ComboBoxDevices_SelectedIndexChanged(object sender, EventArgs e) {
      UpdateReadoutsWithDeviceData(DIManager.devices[ComboBoxDevices.SelectedIndex]);
    }

    private void ButtonAttatch_Click(object sender, EventArgs e) {
      DIManager.Attach( DIManager.devices[ComboBoxDevices.SelectedIndex] ); // Connect to device
      UpdateReadoutsWithDeviceData(DIManager.devices[ComboBoxDevices.SelectedIndex]);
    }

    private void ButtonRemove_Click(object sender, EventArgs e) {
      DIManager.Destroy(DIManager.devices[ComboBoxDevices.SelectedIndex]); // Destroy device
      UpdateReadoutsWithDeviceData(DIManager.devices[ComboBoxDevices.SelectedIndex]);
    }

    private void TimerPoll_Tick_1(object sender, EventArgs e) {
      // If device connected get data
      if (DIManager.isDeviceActive(DIManager.devices[ComboBoxDevices.SelectedIndex])) { // Currently selected device is attached
        FlatJoyState2 DeviceState = DIManager.GetDeviceState(DIManager.devices[ComboBoxDevices.SelectedIndex]);
        LabelInput.Text = $"buttonsA: {Convert.ToString((long)DeviceState.buttonsA, 2).PadLeft(64, '0')}\nbuttonsB: {Convert.ToString((long)DeviceState.buttonsB, 2).PadLeft(64, '0')}\nlX: {DeviceState.lX}\nlY: {DeviceState.lY}\nlZ: {DeviceState.lZ}\nlU: {DeviceState.lU}\nlV: {DeviceState.lV}\nlRx: {DeviceState.lRx}\nlRy: {DeviceState.lRy}\nlRz: {DeviceState.lRz}\nlVX: {DeviceState.lVX}\nlVY: {DeviceState.lVY}\nlVZ: {DeviceState.lVZ}\nlVU: {DeviceState.lVU}\nlVV: {DeviceState.lVV}\nlVRx: {DeviceState.lVRx}\nlVRy: {DeviceState.lVRy}\nlVRz: {DeviceState.lVRz}\nlAX: {DeviceState.lAX}\nlAY: {DeviceState.lAY}\nlAZ: {DeviceState.lAZ}\nlAU: {DeviceState.lAU}\nlAV: {DeviceState.lAV}\nlARx: {DeviceState.lARx}\nlARy: {DeviceState.lARy}\nlARz: {DeviceState.lARz}\nlFX: {DeviceState.lFX}\nlFY: {DeviceState.lFY}\nlFZ: {DeviceState.lFZ}\nlFU: {DeviceState.lFU}\nlFV: {DeviceState.lFV}\nlFRx: {DeviceState.lFRx}\nlFRy: {DeviceState.lFRy}\nlFRz: {DeviceState.lFRz}\nrgdwPOV: {Convert.ToString((long)DeviceState.rgdwPOV, 2).PadLeft(16, '0')}\n";
      }
    }

    //////////////////////////////////////////////////////////////
    // FFB Tab Functions
    //////////////////////////////////////////////////////////////

    private void FFB_CheckBox_CheckedChanged(object sender, EventArgs e) {
      CheckBox TriggeringCheckBox = (CheckBox)sender;
      EffectsType TriggeringEffectType = (EffectsType)Enum.Parse(typeof(EffectsType), TriggeringCheckBox.Tag.ToString());

      if (TriggeringCheckBox.Checked) { // Enable the effect
        TriggeringCheckBox.Checked = DIManager.EnableFFBEffect(DIManager.devices[ComboBoxDevices.SelectedIndex], TriggeringEffectType); // If enable fails, checkbox will be unchecked
      } else { // Disable the effect
        TriggeringCheckBox.Checked = !DIManager.DestroyFFBEffect(DIManager.devices[ComboBoxDevices.SelectedIndex], TriggeringEffectType);
      }

      foreach (Control element in TriggeringCheckBox.Parent.Controls) { // For each of the children in the parent GroupBox
        if (element is CheckBox) continue; // Don't disable yourself
        element.Enabled = TriggeringCheckBox.Checked;
      }

    }

    private void FFB_GroupBox_Click(object sender, EventArgs e) {
      CheckBox CB = ((GroupBox)sender).Controls.Find("CB" + ((GroupBox)sender).Tag, false).FirstOrDefault() as CheckBox;
      CB.Checked = !CB.Checked;
    }

    private void FFB_Label_Click(object sender, EventArgs e) {
      Label TrigElement = (Label)sender;
      TrackBar TB = TrigElement.Parent.Controls.Find("Slider" + TrigElement.Tag, false).FirstOrDefault() as TrackBar;
      NumericUpDown UD = TrigElement.Parent.Controls.Find("UD" + TrigElement.Tag, false).FirstOrDefault() as NumericUpDown;
      switch (TB.Tag) {
        case string a when a.Contains("Saturation"): // Center Saturation to 5000
          TB.Value = 5000;
          UD.Value = 5000;
          break;
        default:
          TB.Value = 0;
          UD.Value = 0;
          break;
      }
    }

    private void FFB_Slider_Scroll(object sender, EventArgs e) {
      TrackBar TrigElement = (TrackBar)sender;
      // Update UpDown
      NumericUpDown UD = TrigElement.Parent.Controls.Find("UD" + TrigElement.Tag, false).FirstOrDefault() as NumericUpDown;
      UD.Value = TrigElement.Value;
      // FFB Effect has changed
    }

    private void FFB_UpDown_ValueChanged(object sender, EventArgs e) {
      DeviceInfo ActiveDevice = DIManager.devices[ComboBoxDevices.SelectedIndex];
      NumericUpDown TrigElement = (NumericUpDown)sender;
      // Update slider(TrackBar)
      TrackBar TB = TrigElement.Parent.Controls.Find("Slider" + TrigElement.Tag, false).FirstOrDefault() as TrackBar;
      TB.Value = (int)TrigElement.Value;
      // Update Effect
      switch (TrigElement.Parent.Tag) {
        case "ConstantForce":
          DIManager.UpdateConstantForceSimple(ActiveDevice, (int)((TrigElement.Parent.Controls.Find("UDConstantForceMagnitude", false).FirstOrDefault() as NumericUpDown).Value));
          break;
        case "Spring":
          DIManager.UpdateSpringSimple(ActiveDevice,
            (uint)((TrigElement.Parent.Controls.Find("UDSpringDeadband", false).FirstOrDefault() as NumericUpDown).Value),
            (int)((TrigElement.Parent.Controls.Find("UDSpringOffset", false).FirstOrDefault() as NumericUpDown).Value),
            (int)((TrigElement.Parent.Controls.Find("UDSpringCoefficient", false).FirstOrDefault() as NumericUpDown).Value),
            (int)((TrigElement.Parent.Controls.Find("UDSpringCoefficient", false).FirstOrDefault() as NumericUpDown).Value),
            (uint)((TrigElement.Parent.Controls.Find("UDSpringSaturation", false).FirstOrDefault() as NumericUpDown).Value),
            (uint)((TrigElement.Parent.Controls.Find("UDSpringSaturation", false).FirstOrDefault() as NumericUpDown).Value)
          );
          break;
        case "Damper":
          DIManager.UpdateDamperSimple(ActiveDevice, (int)((TrigElement.Parent.Controls.Find("UDDamperMagnitude", false).FirstOrDefault() as NumericUpDown).Value));
          break;
        case "Friction":
          DIManager.UpdateFrictionSimple(ActiveDevice, (int)((TrigElement.Parent.Controls.Find("UDFrictionMagnitude", false).FirstOrDefault() as NumericUpDown).Value));
          break;
        case "Inertia":
          DIManager.UpdateInertiaSimple(ActiveDevice, (int)((TrigElement.Parent.Controls.Find("UDInertiaMagnitude", false).FirstOrDefault() as NumericUpDown).Value));
          break;
        default:
          break;

      }
      //System.Diagnostics.Debug.WriteLine("Changed: " + TrigElement.Parent.Tag);
    }

    //////////////////////////////////////////////////////////////
    // Utility Functions
    //////////////////////////////////////////////////////////////

    private void UpdateReadoutsWithDeviceData(DeviceInfo Device) {
      LabelDeviceInfo.Text = $"deviceType: {Device.deviceType}\nguidInstance: {Device.guidInstance}\nguidProduct: {Device.guidProduct}\ninstanceName: {Device.instanceName}\nproductName: {Device.productName}";

      if (DIManager.isDeviceActive(DIManager.devices[ComboBoxDevices.SelectedIndex])) { // Currently selected device is attached
        (TabController.TabPages["TabInput"] as TabPage).Enabled = true; // Enable the Input Tab as we're connected
        DIDEVCAPS DeviceCaps = DIManager.GetDeviceCapabilities(Device);
        LabelCapabilities.Text = $"dwSize: {DeviceCaps.dwSize}\ndwFlags: {DeviceCaps.dwFlags}\ndwDevType: {Convert.ToString(DeviceCaps.dwDevType, 2).PadLeft(32, '0')}\ndwAxes: {DeviceCaps.dwAxes}\ndwButtons: {DeviceCaps.dwButtons}\ndwPOVs: {DeviceCaps.dwPOVs}\ndwFFSamplePeriod: {DeviceCaps.dwFFSamplePeriod}\ndwFFMinTimeResolution: {DeviceCaps.dwFFMinTimeResolution}\ndwFirmwareRevision: {DeviceCaps.dwFirmwareRevision}\ndwHardwareRevision: {DeviceCaps.dwHardwareRevision}\ndwFFDriverVersion: {DeviceCaps.dwFFDriverVersion}";

        
        if (DIManager.FFBCapable(Device)) {
          (TabController.TabPages["TabFFB"] as TabPage).Enabled = true; // If Device is FFB capable, enable the tab
          LabelFFBCapabilities.Text = string.Join("\n", DIManager.GetDeviceFFBCapabilities(Device));
        } else {
          (TabController.TabPages["TabFFB"] as TabPage).Enabled = false;
          LabelFFBCapabilities.Text = "FFBCapabilities: FFB Unsupported";
        }

      } else { // Device isn't attached, default readouts
        LabelInput.Text = "Input: Attatch First";
        LabelCapabilities.Text = "Capabilities: Attatch First";
        LabelFFBCapabilities.Text = "FFBCapabilities: Attatch First";
        (TabController.TabPages["TabInput"] as TabPage).Enabled = false;
        (TabController.TabPages["TabFFB"]   as TabPage).Enabled = false;
      }
    }

    //////////////////////////////////////////////////////////////
    // Debug Functions
    //////////////////////////////////////////////////////////////
    private void ButtonDebug_Click(object sender, EventArgs e) {
      //System.Diagnostics.Debug.WriteLine( DIManager.activeDevices.Count() );
      //System.Diagnostics.Debug.WriteLine(string.Join("\n", DIManager.GetActiveDevices()));

      //DIManager.EnableFFBEffect(DIManager.devices[ComboBoxDevices.SelectedIndex], EffectsType.ConstantForce);

      //LabelDebug.Text = string.Join("\n", DIManager.GetDeviceFFBCapabilities(DIManager.devices[ComboBoxDevices.SelectedIndex]));

      LabelDebug.Text = string.Join("\n", DIManager.DEBUG1(DIManager.devices[ComboBoxDevices.SelectedIndex]));
    }

  }
}
