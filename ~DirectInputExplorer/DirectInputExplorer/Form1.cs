using System;
using System.Linq;
using System.Windows.Forms;
using DirectInputManager;


namespace DirectInputExplorer {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      DIManager.Initialize();
      ButtonEnumerateDevices.PerformClick();
      if(DIManager.devices.Length != 0) { ComboBoxDevices.SelectedIndex = 0; } // Select first device by default

      // Disable tabs until device is attached
      foreach (TabPage tab in TabController.TabPages) {
        //tab.Enabled = false;

        //tab.Font = new System.Drawing.Font(tab.Font, System.Drawing.FontStyle.Strikeout);
      }
      (TabController.TabPages[0] as TabPage).Enabled = true;
    }

    private void ButtonEnumerateDevices_Click(object sender, EventArgs e) {
      DIManager.EnumerateDevices();
      //System.Diagnostics.Debug.WriteLine( Convert.ToString( DIManager.devices.Count() ) );
      ComboBoxDevices.Items.Clear();
      foreach ( var device in DIManager.devices) {
        ComboBoxDevices.Items.Add( device.productName );
      }
    }

    private void ComboBoxDevices_SelectedIndexChanged(object sender, EventArgs e) {
      var SelectedDevice = DIManager.devices[ComboBoxDevices.SelectedIndex];
      LabelDeviceInfo.Text = $"deviceType: {SelectedDevice.deviceType}\nguidInstance: {SelectedDevice.guidInstance}\nguidProduct: {SelectedDevice.guidProduct}\ninstanceName: {SelectedDevice.instanceName}\nproductName: {SelectedDevice.productName}";
    }
    private void ButtonAttatch_Click(object sender, EventArgs e) {
      DIManager.Attach( DIManager.devices[ComboBoxDevices.SelectedIndex] ); // Connect to device
    }

    private void ButtonRemove_Click(object sender, EventArgs e) {
      DIManager.Destroy(DIManager.devices[ComboBoxDevices.SelectedIndex]); // Destroy device
    }

    private void ButtonPoll_Click(object sender, EventArgs e) {
      DIManager.GetActiveDevices();
      /// Poll Device
      FlatJoyState2 DeviceState = DIManager.GetDeviceState(DIManager.devices[ComboBoxDevices.SelectedIndex]);
      LabelDeviceInfo.Text = $"buttonsA: {Convert.ToString((long)DeviceState.buttonsA, 2).PadLeft(64,'0')}\nbuttonsB: {Convert.ToString((long)DeviceState.buttonsB, 2).PadLeft(64, '0')}\nlX: {DeviceState.lX}\nlY: {DeviceState.lY}\nlZ: {DeviceState.lZ}\nlU: {DeviceState.lU}\nlV: {DeviceState.lV}\nlRx: {DeviceState.lRx}\nlRy: {DeviceState.lRy}\nlRz: {DeviceState.lRz}\nlVX: {DeviceState.lVX}\nlVY: {DeviceState.lVY}\nlVZ: {DeviceState.lVZ}\nlVU: {DeviceState.lVU}\nlVV: {DeviceState.lVV}\nlVRx: {DeviceState.lVRx}\nlVRy: {DeviceState.lVRy}\nlVRz: {DeviceState.lVRz}\nlAX: {DeviceState.lAX}\nlAY: {DeviceState.lAY}\nlAZ: {DeviceState.lAZ}\nlAU: {DeviceState.lAU}\nlAV: {DeviceState.lAV}\nlARx: {DeviceState.lARx}\nlARy: {DeviceState.lARy}\nlARz: {DeviceState.lARz}\nlFX: {DeviceState.lFX}\nlFY: {DeviceState.lFY}\nlFZ: {DeviceState.lFZ}\nlFU: {DeviceState.lFU}\nlFV: {DeviceState.lFV}\nlFRx: {DeviceState.lFRx}\nlFRy: {DeviceState.lFRy}\nlFRz: {DeviceState.lFRz}\nrgdwPOV: {Convert.ToString((long)DeviceState.rgdwPOV, 2).PadLeft(16, '0')}\n";
    }

    private void ButtonCapabilities_Click(object sender, EventArgs e) {
      DIDEVCAPS DeviceCaps = DIManager.GetDeviceCapabilities(DIManager.devices[ComboBoxDevices.SelectedIndex]);
      LabelCapabilities.Text = $"dwSize: {DeviceCaps.dwSize}\ndwFlags: {DeviceCaps.dwFlags}\ndwDevType: {Convert.ToString(DeviceCaps.dwDevType, 2).PadLeft(32, '0')}\ndwAxes: {DeviceCaps.dwAxes}\ndwButtons: {DeviceCaps.dwButtons}\ndwPOVs: {DeviceCaps.dwPOVs}\ndwFFSamplePeriod: {DeviceCaps.dwFFSamplePeriod}\ndwFFMinTimeResolution: {DeviceCaps.dwFFMinTimeResolution}\ndwFirmwareRevision: {DeviceCaps.dwFirmwareRevision}\ndwHardwareRevision: {DeviceCaps.dwHardwareRevision}\ndwFFDriverVersion: {DeviceCaps.dwFFDriverVersion}";

    }
  }
}
