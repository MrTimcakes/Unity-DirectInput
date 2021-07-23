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
    // Utility Functions
    //////////////////////////////////////////////////////////////

    private void UpdateReadoutsWithDeviceData(DeviceInfo Device) {
      LabelDeviceInfo.Text = $"deviceType: {Device.deviceType}\nguidInstance: {Device.guidInstance}\nguidProduct: {Device.guidProduct}\ninstanceName: {Device.instanceName}\nproductName: {Device.productName}";

      if (DIManager.isDeviceActive(DIManager.devices[ComboBoxDevices.SelectedIndex])) { // Currently selected device is attached
        (TabController.TabPages["TabInput"] as TabPage).Enabled = true; // Enable the Input Tab as we're connected
        DIDEVCAPS DeviceCaps = DIManager.GetDeviceCapabilities(Device);
        LabelCapabilities.Text = $"dwSize: {DeviceCaps.dwSize}\ndwFlags: {DeviceCaps.dwFlags}\ndwDevType: {Convert.ToString(DeviceCaps.dwDevType, 2).PadLeft(32, '0')}\ndwAxes: {DeviceCaps.dwAxes}\ndwButtons: {DeviceCaps.dwButtons}\ndwPOVs: {DeviceCaps.dwPOVs}\ndwFFSamplePeriod: {DeviceCaps.dwFFSamplePeriod}\ndwFFMinTimeResolution: {DeviceCaps.dwFFMinTimeResolution}\ndwFirmwareRevision: {DeviceCaps.dwFirmwareRevision}\ndwHardwareRevision: {DeviceCaps.dwHardwareRevision}\ndwFFDriverVersion: {DeviceCaps.dwFFDriverVersion}";

        if (DIManager.FFBCapable(Device)) { // Device FFB Capable, enable the Tab
          (TabController.TabPages["TabFFB"] as TabPage).Enabled = true;
        } else {
          (TabController.TabPages["TabFFB"] as TabPage).Enabled = false;
        }

      } else { // Device isn't attached, default readouts
        LabelInput.Text = "Input: Attatch First";
        LabelCapabilities.Text = "Capabilities: Attatch First";
        (TabController.TabPages["TabInput"] as TabPage).Enabled = false;
        (TabController.TabPages["TabFFB"]   as TabPage).Enabled = false;
      }
    }

    //////////////////////////////////////////////////////////////
    // Debug Functions
    //////////////////////////////////////////////////////////////
    private void ButtonDebug_Click(object sender, EventArgs e) {
      System.Diagnostics.Debug.WriteLine( DIManager.activeDevices.Count() );
      System.Diagnostics.Debug.WriteLine( string.Join("\n", DIManager.GetActiveDevices()) );

      FlatJoyState2 DeviceState = DIManager.GetDeviceState(DIManager.devices[ComboBoxDevices.SelectedIndex]);
      LabelInput.Text = $"buttonsA: {Convert.ToString((long)DeviceState.buttonsA, 2).PadLeft(64, '0')}\nbuttonsB: {Convert.ToString((long)DeviceState.buttonsB, 2).PadLeft(64, '0')}\nlX: {DeviceState.lX}\nlY: {DeviceState.lY}\nlZ: {DeviceState.lZ}\nlU: {DeviceState.lU}\nlV: {DeviceState.lV}\nlRx: {DeviceState.lRx}\nlRy: {DeviceState.lRy}\nlRz: {DeviceState.lRz}\nlVX: {DeviceState.lVX}\nlVY: {DeviceState.lVY}\nlVZ: {DeviceState.lVZ}\nlVU: {DeviceState.lVU}\nlVV: {DeviceState.lVV}\nlVRx: {DeviceState.lVRx}\nlVRy: {DeviceState.lVRy}\nlVRz: {DeviceState.lVRz}\nlAX: {DeviceState.lAX}\nlAY: {DeviceState.lAY}\nlAZ: {DeviceState.lAZ}\nlAU: {DeviceState.lAU}\nlAV: {DeviceState.lAV}\nlARx: {DeviceState.lARx}\nlARy: {DeviceState.lARy}\nlARz: {DeviceState.lARz}\nlFX: {DeviceState.lFX}\nlFY: {DeviceState.lFY}\nlFZ: {DeviceState.lFZ}\nlFU: {DeviceState.lFU}\nlFV: {DeviceState.lFV}\nlFRx: {DeviceState.lFRx}\nlFRy: {DeviceState.lFRy}\nlFRz: {DeviceState.lFRz}\nrgdwPOV: {Convert.ToString((long)DeviceState.rgdwPOV, 2).PadLeft(16, '0')}\n";
    }

    private void SliderConstantForce_Scroll(object sender, EventArgs e) {

    }
  }
}
