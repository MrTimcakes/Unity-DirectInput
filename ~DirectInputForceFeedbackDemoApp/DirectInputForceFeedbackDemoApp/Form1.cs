using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectInputManager;


namespace DirectInputForceFeedbackDemoApp {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      DIManager.Initialize();
      ButtonEnumerateDevices.PerformClick();
    }

    private void ButtonEnumerateDevices_Click(object sender, EventArgs e) {
      DIManager.EnumerateDevices();
      System.Diagnostics.Debug.WriteLine( Convert.ToString( DIManager.devices.Count() ) );
      ComboBoxDevices.Items.Clear();
      foreach ( var device in DIManager.devices) {
        ComboBoxDevices.Items.Add( device.productName );
      }
      // Update ComboBox logic here
    }

    private void ComboBoxDevices_SelectedIndexChanged(object sender, EventArgs e) {
      // Switch device logic 
    }
  }
}
