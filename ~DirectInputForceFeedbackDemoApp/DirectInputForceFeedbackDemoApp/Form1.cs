using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace DirectInputForceFeedbackDemoApp
{
  public partial class Form1 : Form
  {
    const string DLLFile = "C:\\Users\\Ducky\\Documents\\GitHub\\Unity-ForceFeedback\\~DirectInputForceFeedback\\x64\\Release\\DirectInputForceFeedback.dll";

    [DllImport(DLLFile)] public static extern double add(double a, double b);

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      textBox1.Text = Convert.ToString(add(5, 5));
    }
  }
}
