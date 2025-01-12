
namespace DirectInputExplorer
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ComboBoxDevices = new System.Windows.Forms.ComboBox();
            ButtonEnumerateDevices = new System.Windows.Forms.Button();
            LabelDeviceInfo = new System.Windows.Forms.Label();
            TimerPoll = new System.Windows.Forms.Timer(components);
            ButtonAttach = new System.Windows.Forms.Button();
            ButtonRemove = new System.Windows.Forms.Button();
            TabController = new System.Windows.Forms.TabControl();
            TabDeviceInfo = new System.Windows.Forms.TabPage();
            LabelFFBCapabilities = new System.Windows.Forms.Label();
            LabelCapabilities = new System.Windows.Forms.Label();
            TabInput = new System.Windows.Forms.TabPage();
            LabelInput = new System.Windows.Forms.Label();
            TabFFB = new System.Windows.Forms.TabPage();
            GBSine = new System.Windows.Forms.GroupBox();
            checkBox6 = new System.Windows.Forms.CheckBox();
            UDSineMagnitude = new System.Windows.Forms.NumericUpDown();
            label6 = new System.Windows.Forms.Label();
            SliderSineMagnitude = new System.Windows.Forms.TrackBar();
            GBSquare = new System.Windows.Forms.GroupBox();
            checkBox5 = new System.Windows.Forms.CheckBox();
            UDSquareMagnitude = new System.Windows.Forms.NumericUpDown();
            label5 = new System.Windows.Forms.Label();
            SliderSquareMagnitude = new System.Windows.Forms.TrackBar();
            GBTriangle = new System.Windows.Forms.GroupBox();
            checkBox4 = new System.Windows.Forms.CheckBox();
            UDTriangleMagnitude = new System.Windows.Forms.NumericUpDown();
            label4 = new System.Windows.Forms.Label();
            SliderTriangleMagnitude = new System.Windows.Forms.TrackBar();
            GBRampForce = new System.Windows.Forms.GroupBox();
            checkBox3 = new System.Windows.Forms.CheckBox();
            UDRampForceMagnitude = new System.Windows.Forms.NumericUpDown();
            label3 = new System.Windows.Forms.Label();
            SliderRampForceMagnitude = new System.Windows.Forms.TrackBar();
            GBSawtoothUp = new System.Windows.Forms.GroupBox();
            checkBox2 = new System.Windows.Forms.CheckBox();
            UDSawtoothUpMagnitude = new System.Windows.Forms.NumericUpDown();
            label2 = new System.Windows.Forms.Label();
            SliderSawtoothUpMagnitude = new System.Windows.Forms.TrackBar();
            GBSawtoothDown = new System.Windows.Forms.GroupBox();
            checkBox1 = new System.Windows.Forms.CheckBox();
            UDSawtoothDownMagnitude = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            SliderSawtoothDownMagnitude = new System.Windows.Forms.TrackBar();
            GBSpring = new System.Windows.Forms.GroupBox();
            CBSpring = new System.Windows.Forms.CheckBox();
            UDSpringDeadband = new System.Windows.Forms.NumericUpDown();
            UDSpringSaturation = new System.Windows.Forms.NumericUpDown();
            UDSpringCoefficient = new System.Windows.Forms.NumericUpDown();
            UDSpringOffset = new System.Windows.Forms.NumericUpDown();
            SliderSpringDeadband = new System.Windows.Forms.TrackBar();
            LabelSpringDeadband = new System.Windows.Forms.Label();
            SliderSpringSaturation = new System.Windows.Forms.TrackBar();
            LabelSpringSaturation = new System.Windows.Forms.Label();
            SliderSpringCoefficient = new System.Windows.Forms.TrackBar();
            LabelSpringCoefficient = new System.Windows.Forms.Label();
            SliderSpringOffset = new System.Windows.Forms.TrackBar();
            LabelSpringOffset = new System.Windows.Forms.Label();
            GBInertia = new System.Windows.Forms.GroupBox();
            CBInertia = new System.Windows.Forms.CheckBox();
            UDInertiaMagnitude = new System.Windows.Forms.NumericUpDown();
            LabelInertiaMagnitude = new System.Windows.Forms.Label();
            SliderInertiaMagnitude = new System.Windows.Forms.TrackBar();
            GBFriction = new System.Windows.Forms.GroupBox();
            UDFrictionMagnitude = new System.Windows.Forms.NumericUpDown();
            CBFriction = new System.Windows.Forms.CheckBox();
            LabelFrictionMagnitude = new System.Windows.Forms.Label();
            SliderFrictionMagnitude = new System.Windows.Forms.TrackBar();
            GBDamper = new System.Windows.Forms.GroupBox();
            UDDamperMagnitude = new System.Windows.Forms.NumericUpDown();
            LabelDamperMagnitude = new System.Windows.Forms.Label();
            CBDamper = new System.Windows.Forms.CheckBox();
            SliderDamperMagnitude = new System.Windows.Forms.TrackBar();
            GBConstantForce = new System.Windows.Forms.GroupBox();
            CBConstantForce = new System.Windows.Forms.CheckBox();
            UDConstantForceMagnitude = new System.Windows.Forms.NumericUpDown();
            LabelConstantForceMagnitude = new System.Windows.Forms.Label();
            SliderConstantForceMagnitude = new System.Windows.Forms.TrackBar();
            tabPage1 = new System.Windows.Forms.TabPage();
            GBCuss = new System.Windows.Forms.GroupBox();
            UDCustomForceSamplePeriod = new System.Windows.Forms.NumericUpDown();
            label16 = new System.Windows.Forms.Label();
            SliderCustomForceSamplePeriod = new System.Windows.Forms.TrackBar();
            UDCustomForceMagnitude9 = new System.Windows.Forms.NumericUpDown();
            label15 = new System.Windows.Forms.Label();
            SliderCustomForceMagnitude9 = new System.Windows.Forms.TrackBar();
            UDCustomForceMagnitude8 = new System.Windows.Forms.NumericUpDown();
            label14 = new System.Windows.Forms.Label();
            SliderCustomForceMagnitude8 = new System.Windows.Forms.TrackBar();
            UDCustomForceMagnitude7 = new System.Windows.Forms.NumericUpDown();
            label13 = new System.Windows.Forms.Label();
            SliderCustomForceMagnitude7 = new System.Windows.Forms.TrackBar();
            UDCustomForceMagnitude6 = new System.Windows.Forms.NumericUpDown();
            label12 = new System.Windows.Forms.Label();
            SliderCustomForceMagnitude6 = new System.Windows.Forms.TrackBar();
            UDCustomForceMagnitude5 = new System.Windows.Forms.NumericUpDown();
            label11 = new System.Windows.Forms.Label();
            SliderCustomForceMagnitude5 = new System.Windows.Forms.TrackBar();
            UDCustomForceMagnitude4 = new System.Windows.Forms.NumericUpDown();
            label10 = new System.Windows.Forms.Label();
            SliderCustomForceMagnitude4 = new System.Windows.Forms.TrackBar();
            UDCustomForceMagnitude3 = new System.Windows.Forms.NumericUpDown();
            label9 = new System.Windows.Forms.Label();
            SliderCustomForceMagnitude3 = new System.Windows.Forms.TrackBar();
            UDCustomForceMagnitude2 = new System.Windows.Forms.NumericUpDown();
            label8 = new System.Windows.Forms.Label();
            SliderCustomForceMagnitude2 = new System.Windows.Forms.TrackBar();
            UDCustomForceMagnitude1 = new System.Windows.Forms.NumericUpDown();
            label7 = new System.Windows.Forms.Label();
            SliderCustomForceMagnitude1 = new System.Windows.Forms.TrackBar();
            CBCustomForce = new System.Windows.Forms.CheckBox();
            UDCustomForceMagnitude0 = new System.Windows.Forms.NumericUpDown();
            LblCustomForceMagnitude0 = new System.Windows.Forms.Label();
            SliderCustomForceMagnitude0 = new System.Windows.Forms.TrackBar();
            TabMisc = new System.Windows.Forms.TabPage();
            LabelDebug = new System.Windows.Forms.Label();
            ButtonDebug = new System.Windows.Forms.Button();
            TabController.SuspendLayout();
            TabDeviceInfo.SuspendLayout();
            TabInput.SuspendLayout();
            TabFFB.SuspendLayout();
            GBSine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UDSineMagnitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderSineMagnitude).BeginInit();
            GBSquare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UDSquareMagnitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderSquareMagnitude).BeginInit();
            GBTriangle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UDTriangleMagnitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderTriangleMagnitude).BeginInit();
            GBRampForce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UDRampForceMagnitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderRampForceMagnitude).BeginInit();
            GBSawtoothUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UDSawtoothUpMagnitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderSawtoothUpMagnitude).BeginInit();
            GBSawtoothDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UDSawtoothDownMagnitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderSawtoothDownMagnitude).BeginInit();
            GBSpring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UDSpringDeadband).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UDSpringSaturation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UDSpringCoefficient).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UDSpringOffset).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderSpringDeadband).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderSpringSaturation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderSpringCoefficient).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderSpringOffset).BeginInit();
            GBInertia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UDInertiaMagnitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderInertiaMagnitude).BeginInit();
            GBFriction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UDFrictionMagnitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderFrictionMagnitude).BeginInit();
            GBDamper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UDDamperMagnitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderDamperMagnitude).BeginInit();
            GBConstantForce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UDConstantForceMagnitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderConstantForceMagnitude).BeginInit();
            tabPage1.SuspendLayout();
            GBCuss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceSamplePeriod).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceSamplePeriod).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude0).BeginInit();
            TabMisc.SuspendLayout();
            SuspendLayout();
            // 
            // ComboBoxDevices
            // 
            ComboBoxDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ComboBoxDevices.FormattingEnabled = true;
            ComboBoxDevices.Location = new System.Drawing.Point(12, 12);
            ComboBoxDevices.Name = "ComboBoxDevices";
            ComboBoxDevices.Size = new System.Drawing.Size(976, 23);
            ComboBoxDevices.TabIndex = 1;
            ComboBoxDevices.SelectedIndexChanged += ComboBoxDevices_SelectedIndexChanged;
            // 
            // ButtonEnumerateDevices
            // 
            ButtonEnumerateDevices.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ButtonEnumerateDevices.Location = new System.Drawing.Point(994, 12);
            ButtonEnumerateDevices.Name = "ButtonEnumerateDevices";
            ButtonEnumerateDevices.Size = new System.Drawing.Size(40, 23);
            ButtonEnumerateDevices.TabIndex = 2;
            ButtonEnumerateDevices.Text = "🔄";
            ButtonEnumerateDevices.UseVisualStyleBackColor = true;
            ButtonEnumerateDevices.Click += ButtonEnumerateDevices_Click;
            // 
            // LabelDeviceInfo
            // 
            LabelDeviceInfo.AutoSize = true;
            LabelDeviceInfo.Location = new System.Drawing.Point(5, 5);
            LabelDeviceInfo.Name = "LabelDeviceInfo";
            LabelDeviceInfo.Size = new System.Drawing.Size(69, 15);
            LabelDeviceInfo.TabIndex = 3;
            LabelDeviceInfo.Text = "Device Info:";
            // 
            // TimerPoll
            // 
            TimerPoll.Enabled = true;
            TimerPoll.Interval = 20;
            TimerPoll.Tick += TimerPoll_Tick_1;
            // 
            // ButtonAttach
            // 
            ButtonAttach.Location = new System.Drawing.Point(1040, 12);
            ButtonAttach.Name = "ButtonAttach";
            ButtonAttach.Size = new System.Drawing.Size(100, 23);
            ButtonAttach.TabIndex = 5;
            ButtonAttach.Text = "Attach";
            ButtonAttach.UseVisualStyleBackColor = true;
            ButtonAttach.Click += ButtonAttach_Click;
            // 
            // ButtonRemove
            // 
            ButtonRemove.Location = new System.Drawing.Point(1146, 12);
            ButtonRemove.Name = "ButtonRemove";
            ButtonRemove.Size = new System.Drawing.Size(100, 23);
            ButtonRemove.TabIndex = 6;
            ButtonRemove.Text = "Remove";
            ButtonRemove.UseVisualStyleBackColor = true;
            ButtonRemove.Click += ButtonRemove_Click;
            // 
            // TabController
            // 
            TabController.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TabController.Controls.Add(TabDeviceInfo);
            TabController.Controls.Add(TabInput);
            TabController.Controls.Add(TabFFB);
            TabController.Controls.Add(tabPage1);
            TabController.Controls.Add(TabMisc);
            TabController.Location = new System.Drawing.Point(12, 41);
            TabController.Name = "TabController";
            TabController.SelectedIndex = 0;
            TabController.Size = new System.Drawing.Size(1234, 665);
            TabController.TabIndex = 7;
            // 
            // TabDeviceInfo
            // 
            TabDeviceInfo.Controls.Add(LabelDeviceInfo);
            TabDeviceInfo.Controls.Add(LabelFFBCapabilities);
            TabDeviceInfo.Controls.Add(LabelCapabilities);
            TabDeviceInfo.Location = new System.Drawing.Point(4, 24);
            TabDeviceInfo.Name = "TabDeviceInfo";
            TabDeviceInfo.Size = new System.Drawing.Size(1226, 637);
            TabDeviceInfo.TabIndex = 3;
            TabDeviceInfo.Text = "Info";
            TabDeviceInfo.UseVisualStyleBackColor = true;
            // 
            // LabelFFBCapabilities
            // 
            LabelFFBCapabilities.AutoSize = true;
            LabelFFBCapabilities.Location = new System.Drawing.Point(5, 408);
            LabelFFBCapabilities.MaximumSize = new System.Drawing.Size(1226, 0);
            LabelFFBCapabilities.Name = "LabelFFBCapabilities";
            LabelFFBCapabilities.Size = new System.Drawing.Size(157, 15);
            LabelFFBCapabilities.TabIndex = 4;
            LabelFFBCapabilities.Text = "FFBCapabilities: Attatch First";
            // 
            // LabelCapabilities
            // 
            LabelCapabilities.AutoSize = true;
            LabelCapabilities.Location = new System.Drawing.Point(5, 165);
            LabelCapabilities.MaximumSize = new System.Drawing.Size(1226, 0);
            LabelCapabilities.Name = "LabelCapabilities";
            LabelCapabilities.Size = new System.Drawing.Size(138, 15);
            LabelCapabilities.TabIndex = 4;
            LabelCapabilities.Text = "Capabilities: Attatch First";
            // 
            // TabInput
            // 
            TabInput.Controls.Add(LabelInput);
            TabInput.Location = new System.Drawing.Point(4, 24);
            TabInput.Name = "TabInput";
            TabInput.Padding = new System.Windows.Forms.Padding(3);
            TabInput.Size = new System.Drawing.Size(1226, 637);
            TabInput.TabIndex = 0;
            TabInput.Text = "Input";
            TabInput.UseVisualStyleBackColor = true;
            // 
            // LabelInput
            // 
            LabelInput.AutoSize = true;
            LabelInput.Location = new System.Drawing.Point(5, 5);
            LabelInput.Name = "LabelInput";
            LabelInput.Size = new System.Drawing.Size(101, 15);
            LabelInput.TabIndex = 4;
            LabelInput.Text = "Input: Attach First";
            // 
            // TabFFB
            // 
            TabFFB.Controls.Add(GBSine);
            TabFFB.Controls.Add(GBSquare);
            TabFFB.Controls.Add(GBTriangle);
            TabFFB.Controls.Add(GBRampForce);
            TabFFB.Controls.Add(GBSawtoothUp);
            TabFFB.Controls.Add(GBSawtoothDown);
            TabFFB.Controls.Add(GBSpring);
            TabFFB.Controls.Add(GBInertia);
            TabFFB.Controls.Add(GBFriction);
            TabFFB.Controls.Add(GBDamper);
            TabFFB.Controls.Add(GBConstantForce);
            TabFFB.Location = new System.Drawing.Point(4, 24);
            TabFFB.Name = "TabFFB";
            TabFFB.Padding = new System.Windows.Forms.Padding(3);
            TabFFB.Size = new System.Drawing.Size(1226, 637);
            TabFFB.TabIndex = 1;
            TabFFB.Text = "FFB";
            TabFFB.UseVisualStyleBackColor = true;
            // 
            // GBSine
            // 
            GBSine.Controls.Add(checkBox6);
            GBSine.Controls.Add(UDSineMagnitude);
            GBSine.Controls.Add(label6);
            GBSine.Controls.Add(SliderSineMagnitude);
            GBSine.Location = new System.Drawing.Point(6, 568);
            GBSine.Name = "GBSine";
            GBSine.Size = new System.Drawing.Size(403, 69);
            GBSine.TabIndex = 5;
            GBSine.TabStop = false;
            GBSine.Tag = "Sine";
            GBSine.Text = "   Sine";
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new System.Drawing.Point(0, 3);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new System.Drawing.Size(15, 14);
            checkBox6.TabIndex = 1;
            checkBox6.Tag = "Sine";
            checkBox6.UseVisualStyleBackColor = true;
            checkBox6.CheckedChanged += FFB_CheckBox_CheckedChanged;
            // 
            // UDSineMagnitude
            // 
            UDSineMagnitude.Enabled = false;
            UDSineMagnitude.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDSineMagnitude.Location = new System.Drawing.Point(301, 31);
            UDSineMagnitude.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDSineMagnitude.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDSineMagnitude.Name = "UDSineMagnitude";
            UDSineMagnitude.Size = new System.Drawing.Size(96, 23);
            UDSineMagnitude.TabIndex = 2;
            UDSineMagnitude.Tag = "SineMagnitude";
            UDSineMagnitude.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 32);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(68, 15);
            label6.TabIndex = 3;
            label6.Tag = "InertiaMagnitude";
            label6.Text = "Magnitude:";
            // 
            // SliderSineMagnitude
            // 
            SliderSineMagnitude.AccessibleName = "SliderSineMagnitude";
            SliderSineMagnitude.AutoSize = false;
            SliderSineMagnitude.BackColor = System.Drawing.SystemColors.Control;
            SliderSineMagnitude.Enabled = false;
            SliderSineMagnitude.LargeChange = 50;
            SliderSineMagnitude.Location = new System.Drawing.Point(74, 31);
            SliderSineMagnitude.Maximum = 10000;
            SliderSineMagnitude.Name = "SliderSineMagnitude";
            SliderSineMagnitude.Size = new System.Drawing.Size(221, 31);
            SliderSineMagnitude.TabIndex = 0;
            SliderSineMagnitude.Tag = "SineMagnitude";
            SliderSineMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderSineMagnitude.Scroll += FFB_Slider_Scroll;
            // 
            // GBSquare
            // 
            GBSquare.Controls.Add(checkBox5);
            GBSquare.Controls.Add(UDSquareMagnitude);
            GBSquare.Controls.Add(label5);
            GBSquare.Controls.Add(SliderSquareMagnitude);
            GBSquare.Location = new System.Drawing.Point(415, 568);
            GBSquare.Name = "GBSquare";
            GBSquare.Size = new System.Drawing.Size(410, 71);
            GBSquare.TabIndex = 5;
            GBSquare.TabStop = false;
            GBSquare.Tag = "Square";
            GBSquare.Text = "   Square";
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new System.Drawing.Point(0, 3);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new System.Drawing.Size(15, 14);
            checkBox5.TabIndex = 1;
            checkBox5.Tag = "Square";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox5.CheckedChanged += FFB_CheckBox_CheckedChanged;
            // 
            // UDSquareMagnitude
            // 
            UDSquareMagnitude.Enabled = false;
            UDSquareMagnitude.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDSquareMagnitude.Location = new System.Drawing.Point(308, 32);
            UDSquareMagnitude.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDSquareMagnitude.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDSquareMagnitude.Name = "UDSquareMagnitude";
            UDSquareMagnitude.Size = new System.Drawing.Size(96, 23);
            UDSquareMagnitude.TabIndex = 2;
            UDSquareMagnitude.Tag = "SquareMagnitude";
            UDSquareMagnitude.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 32);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(68, 15);
            label5.TabIndex = 3;
            label5.Tag = "InertiaMagnitude";
            label5.Text = "Magnitude:";
            // 
            // SliderSquareMagnitude
            // 
            SliderSquareMagnitude.AccessibleName = "SliderSquareMagnitude";
            SliderSquareMagnitude.AutoSize = false;
            SliderSquareMagnitude.BackColor = System.Drawing.SystemColors.Control;
            SliderSquareMagnitude.Enabled = false;
            SliderSquareMagnitude.LargeChange = 50;
            SliderSquareMagnitude.Location = new System.Drawing.Point(80, 31);
            SliderSquareMagnitude.Maximum = 10000;
            SliderSquareMagnitude.Name = "SliderSquareMagnitude";
            SliderSquareMagnitude.Size = new System.Drawing.Size(222, 31);
            SliderSquareMagnitude.TabIndex = 0;
            SliderSquareMagnitude.Tag = "SquareMagnitude";
            SliderSquareMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderSquareMagnitude.Scroll += FFB_Slider_Scroll;
            // 
            // GBTriangle
            // 
            GBTriangle.Controls.Add(checkBox4);
            GBTriangle.Controls.Add(UDTriangleMagnitude);
            GBTriangle.Controls.Add(label4);
            GBTriangle.Controls.Add(SliderTriangleMagnitude);
            GBTriangle.Location = new System.Drawing.Point(831, 571);
            GBTriangle.Name = "GBTriangle";
            GBTriangle.Size = new System.Drawing.Size(389, 68);
            GBTriangle.TabIndex = 4;
            GBTriangle.TabStop = false;
            GBTriangle.Tag = "Triangle";
            GBTriangle.Text = "   Triangle";
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new System.Drawing.Point(0, 3);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new System.Drawing.Size(15, 14);
            checkBox4.TabIndex = 1;
            checkBox4.Tag = "Triangle";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += FFB_CheckBox_CheckedChanged;
            // 
            // UDTriangleMagnitude
            // 
            UDTriangleMagnitude.Enabled = false;
            UDTriangleMagnitude.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDTriangleMagnitude.Location = new System.Drawing.Point(287, 32);
            UDTriangleMagnitude.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDTriangleMagnitude.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDTriangleMagnitude.Name = "UDTriangleMagnitude";
            UDTriangleMagnitude.Size = new System.Drawing.Size(96, 23);
            UDTriangleMagnitude.TabIndex = 2;
            UDTriangleMagnitude.Tag = "TriangleMagnitude";
            UDTriangleMagnitude.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 32);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(68, 15);
            label4.TabIndex = 3;
            label4.Tag = "InertiaMagnitude";
            label4.Text = "Magnitude:";
            // 
            // SliderTriangleMagnitude
            // 
            SliderTriangleMagnitude.AccessibleName = "SliderTriangleMagnitude";
            SliderTriangleMagnitude.AutoSize = false;
            SliderTriangleMagnitude.BackColor = System.Drawing.SystemColors.Control;
            SliderTriangleMagnitude.Enabled = false;
            SliderTriangleMagnitude.LargeChange = 50;
            SliderTriangleMagnitude.Location = new System.Drawing.Point(80, 31);
            SliderTriangleMagnitude.Maximum = 10000;
            SliderTriangleMagnitude.Name = "SliderTriangleMagnitude";
            SliderTriangleMagnitude.Size = new System.Drawing.Size(201, 31);
            SliderTriangleMagnitude.TabIndex = 0;
            SliderTriangleMagnitude.Tag = "TriangleMagnitude";
            SliderTriangleMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderTriangleMagnitude.Scroll += FFB_Slider_Scroll;
            // 
            // GBRampForce
            // 
            GBRampForce.Controls.Add(checkBox3);
            GBRampForce.Controls.Add(UDRampForceMagnitude);
            GBRampForce.Controls.Add(label3);
            GBRampForce.Controls.Add(SliderRampForceMagnitude);
            GBRampForce.Location = new System.Drawing.Point(415, 491);
            GBRampForce.Name = "GBRampForce";
            GBRampForce.Size = new System.Drawing.Size(410, 71);
            GBRampForce.TabIndex = 4;
            GBRampForce.TabStop = false;
            GBRampForce.Tag = "RampForce";
            GBRampForce.Text = "   RampForce";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new System.Drawing.Point(0, 3);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(15, 14);
            checkBox3.TabIndex = 1;
            checkBox3.Tag = "RampForce";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += FFB_CheckBox_CheckedChanged;
            // 
            // UDRampForceMagnitude
            // 
            UDRampForceMagnitude.Enabled = false;
            UDRampForceMagnitude.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDRampForceMagnitude.Location = new System.Drawing.Point(301, 31);
            UDRampForceMagnitude.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDRampForceMagnitude.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDRampForceMagnitude.Name = "UDRampForceMagnitude";
            UDRampForceMagnitude.Size = new System.Drawing.Size(96, 23);
            UDRampForceMagnitude.TabIndex = 2;
            UDRampForceMagnitude.Tag = "RampForceMagnitude";
            UDRampForceMagnitude.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 32);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(68, 15);
            label3.TabIndex = 3;
            label3.Tag = "InertiaMagnitude";
            label3.Text = "Magnitude:";
            // 
            // SliderRampForceMagnitude
            // 
            SliderRampForceMagnitude.AccessibleName = "SliderRampForceMagnitude";
            SliderRampForceMagnitude.AutoSize = false;
            SliderRampForceMagnitude.BackColor = System.Drawing.SystemColors.Control;
            SliderRampForceMagnitude.Enabled = false;
            SliderRampForceMagnitude.LargeChange = 50;
            SliderRampForceMagnitude.Location = new System.Drawing.Point(74, 31);
            SliderRampForceMagnitude.Maximum = 10000;
            SliderRampForceMagnitude.Minimum = -10000;
            SliderRampForceMagnitude.Name = "SliderRampForceMagnitude";
            SliderRampForceMagnitude.Size = new System.Drawing.Size(221, 31);
            SliderRampForceMagnitude.TabIndex = 0;
            SliderRampForceMagnitude.Tag = "RampForceMagnitude";
            SliderRampForceMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderRampForceMagnitude.Scroll += FFB_Slider_Scroll;
            // 
            // GBSawtoothUp
            // 
            GBSawtoothUp.Controls.Add(checkBox2);
            GBSawtoothUp.Controls.Add(UDSawtoothUpMagnitude);
            GBSawtoothUp.Controls.Add(label2);
            GBSawtoothUp.Controls.Add(SliderSawtoothUpMagnitude);
            GBSawtoothUp.Location = new System.Drawing.Point(6, 491);
            GBSawtoothUp.Name = "GBSawtoothUp";
            GBSawtoothUp.Size = new System.Drawing.Size(403, 71);
            GBSawtoothUp.TabIndex = 4;
            GBSawtoothUp.TabStop = false;
            GBSawtoothUp.Tag = "SawtoothUp";
            GBSawtoothUp.Text = "   SawtoothUp";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new System.Drawing.Point(0, 3);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(15, 14);
            checkBox2.TabIndex = 1;
            checkBox2.Tag = "SawtoothUp";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += FFB_CheckBox_CheckedChanged;
            // 
            // UDSawtoothUpMagnitude
            // 
            UDSawtoothUpMagnitude.Enabled = false;
            UDSawtoothUpMagnitude.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDSawtoothUpMagnitude.Location = new System.Drawing.Point(301, 31);
            UDSawtoothUpMagnitude.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDSawtoothUpMagnitude.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDSawtoothUpMagnitude.Name = "UDSawtoothUpMagnitude";
            UDSawtoothUpMagnitude.Size = new System.Drawing.Size(96, 23);
            UDSawtoothUpMagnitude.TabIndex = 2;
            UDSawtoothUpMagnitude.Tag = "SawtoothUpMagnitude";
            UDSawtoothUpMagnitude.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 32);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 15);
            label2.TabIndex = 3;
            label2.Tag = "InertiaMagnitude";
            label2.Text = "Magnitude:";
            // 
            // SliderSawtoothUpMagnitude
            // 
            SliderSawtoothUpMagnitude.AccessibleName = "SliderSawtoothUpMagnitude";
            SliderSawtoothUpMagnitude.AutoSize = false;
            SliderSawtoothUpMagnitude.BackColor = System.Drawing.SystemColors.Control;
            SliderSawtoothUpMagnitude.Enabled = false;
            SliderSawtoothUpMagnitude.LargeChange = 50;
            SliderSawtoothUpMagnitude.Location = new System.Drawing.Point(80, 31);
            SliderSawtoothUpMagnitude.Maximum = 10000;
            SliderSawtoothUpMagnitude.Name = "SliderSawtoothUpMagnitude";
            SliderSawtoothUpMagnitude.Size = new System.Drawing.Size(215, 31);
            SliderSawtoothUpMagnitude.TabIndex = 0;
            SliderSawtoothUpMagnitude.Tag = "SawtoothUpMagnitude";
            SliderSawtoothUpMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderSawtoothUpMagnitude.Scroll += FFB_Slider_Scroll;
            // 
            // GBSawtoothDown
            // 
            GBSawtoothDown.Controls.Add(checkBox1);
            GBSawtoothDown.Controls.Add(UDSawtoothDownMagnitude);
            GBSawtoothDown.Controls.Add(label1);
            GBSawtoothDown.Controls.Add(SliderSawtoothDownMagnitude);
            GBSawtoothDown.Location = new System.Drawing.Point(831, 494);
            GBSawtoothDown.Name = "GBSawtoothDown";
            GBSawtoothDown.Size = new System.Drawing.Size(389, 68);
            GBSawtoothDown.TabIndex = 1;
            GBSawtoothDown.TabStop = false;
            GBSawtoothDown.Tag = "SawtoothDown";
            GBSawtoothDown.Text = "   SawtoothDown";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(0, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(15, 14);
            checkBox1.TabIndex = 1;
            checkBox1.Tag = "SawtoothDown";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += FFB_CheckBox_CheckedChanged;
            // 
            // UDSawtoothDownMagnitude
            // 
            UDSawtoothDownMagnitude.Enabled = false;
            UDSawtoothDownMagnitude.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDSawtoothDownMagnitude.Location = new System.Drawing.Point(287, 32);
            UDSawtoothDownMagnitude.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDSawtoothDownMagnitude.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDSawtoothDownMagnitude.Name = "UDSawtoothDownMagnitude";
            UDSawtoothDownMagnitude.Size = new System.Drawing.Size(96, 23);
            UDSawtoothDownMagnitude.TabIndex = 2;
            UDSawtoothDownMagnitude.Tag = "SawtoothDownMagnitude";
            UDSawtoothDownMagnitude.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(68, 15);
            label1.TabIndex = 3;
            label1.Tag = "InertiaMagnitude";
            label1.Text = "Magnitude:";
            // 
            // SliderSawtoothDownMagnitude
            // 
            SliderSawtoothDownMagnitude.AccessibleName = "SliderSawtoothDownMagnitude";
            SliderSawtoothDownMagnitude.AutoSize = false;
            SliderSawtoothDownMagnitude.BackColor = System.Drawing.SystemColors.Control;
            SliderSawtoothDownMagnitude.Enabled = false;
            SliderSawtoothDownMagnitude.LargeChange = 50;
            SliderSawtoothDownMagnitude.Location = new System.Drawing.Point(80, 31);
            SliderSawtoothDownMagnitude.Maximum = 10000;
            SliderSawtoothDownMagnitude.Name = "SliderSawtoothDownMagnitude";
            SliderSawtoothDownMagnitude.Size = new System.Drawing.Size(201, 31);
            SliderSawtoothDownMagnitude.TabIndex = 0;
            SliderSawtoothDownMagnitude.Tag = "SawtoothDownMagnitude";
            SliderSawtoothDownMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderSawtoothDownMagnitude.Scroll += FFB_Slider_Scroll;
            // 
            // GBSpring
            // 
            GBSpring.Controls.Add(CBSpring);
            GBSpring.Controls.Add(UDSpringDeadband);
            GBSpring.Controls.Add(UDSpringSaturation);
            GBSpring.Controls.Add(UDSpringCoefficient);
            GBSpring.Controls.Add(UDSpringOffset);
            GBSpring.Controls.Add(SliderSpringDeadband);
            GBSpring.Controls.Add(LabelSpringDeadband);
            GBSpring.Controls.Add(SliderSpringSaturation);
            GBSpring.Controls.Add(LabelSpringSaturation);
            GBSpring.Controls.Add(SliderSpringCoefficient);
            GBSpring.Controls.Add(LabelSpringCoefficient);
            GBSpring.Controls.Add(SliderSpringOffset);
            GBSpring.Controls.Add(LabelSpringOffset);
            GBSpring.Location = new System.Drawing.Point(6, 80);
            GBSpring.Name = "GBSpring";
            GBSpring.Size = new System.Drawing.Size(1214, 180);
            GBSpring.TabIndex = 0;
            GBSpring.TabStop = false;
            GBSpring.Tag = "Spring";
            GBSpring.Text = "   Spring Force";
            GBSpring.Click += FFB_GroupBox_Click;
            // 
            // CBSpring
            // 
            CBSpring.AutoSize = true;
            CBSpring.Location = new System.Drawing.Point(0, 3);
            CBSpring.Name = "CBSpring";
            CBSpring.Size = new System.Drawing.Size(15, 14);
            CBSpring.TabIndex = 1;
            CBSpring.Tag = "Spring";
            CBSpring.UseVisualStyleBackColor = true;
            CBSpring.CheckedChanged += FFB_CheckBox_CheckedChanged;
            // 
            // UDSpringDeadband
            // 
            UDSpringDeadband.Enabled = false;
            UDSpringDeadband.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDSpringDeadband.Location = new System.Drawing.Point(1112, 141);
            UDSpringDeadband.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDSpringDeadband.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDSpringDeadband.Name = "UDSpringDeadband";
            UDSpringDeadband.Size = new System.Drawing.Size(96, 23);
            UDSpringDeadband.TabIndex = 2;
            UDSpringDeadband.Tag = "SpringDeadband";
            UDSpringDeadband.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // UDSpringSaturation
            // 
            UDSpringSaturation.Enabled = false;
            UDSpringSaturation.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDSpringSaturation.Location = new System.Drawing.Point(1112, 104);
            UDSpringSaturation.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDSpringSaturation.Name = "UDSpringSaturation";
            UDSpringSaturation.Size = new System.Drawing.Size(96, 23);
            UDSpringSaturation.TabIndex = 2;
            UDSpringSaturation.Tag = "SpringSaturation";
            UDSpringSaturation.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            UDSpringSaturation.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // UDSpringCoefficient
            // 
            UDSpringCoefficient.Enabled = false;
            UDSpringCoefficient.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDSpringCoefficient.Location = new System.Drawing.Point(1112, 67);
            UDSpringCoefficient.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDSpringCoefficient.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDSpringCoefficient.Name = "UDSpringCoefficient";
            UDSpringCoefficient.Size = new System.Drawing.Size(96, 23);
            UDSpringCoefficient.TabIndex = 2;
            UDSpringCoefficient.Tag = "SpringCoefficient";
            UDSpringCoefficient.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // UDSpringOffset
            // 
            UDSpringOffset.Enabled = false;
            UDSpringOffset.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDSpringOffset.Location = new System.Drawing.Point(1112, 30);
            UDSpringOffset.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDSpringOffset.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDSpringOffset.Name = "UDSpringOffset";
            UDSpringOffset.Size = new System.Drawing.Size(96, 23);
            UDSpringOffset.TabIndex = 2;
            UDSpringOffset.Tag = "SpringOffset";
            UDSpringOffset.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // SliderSpringDeadband
            // 
            SliderSpringDeadband.AutoSize = false;
            SliderSpringDeadband.BackColor = System.Drawing.SystemColors.Control;
            SliderSpringDeadband.Enabled = false;
            SliderSpringDeadband.LargeChange = 50;
            SliderSpringDeadband.Location = new System.Drawing.Point(108, 141);
            SliderSpringDeadband.Maximum = 10000;
            SliderSpringDeadband.Name = "SliderSpringDeadband";
            SliderSpringDeadband.Size = new System.Drawing.Size(998, 31);
            SliderSpringDeadband.TabIndex = 0;
            SliderSpringDeadband.Tag = "SpringDeadband";
            SliderSpringDeadband.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderSpringDeadband.Scroll += FFB_Slider_Scroll;
            // 
            // LabelSpringDeadband
            // 
            LabelSpringDeadband.AutoSize = true;
            LabelSpringDeadband.Location = new System.Drawing.Point(6, 143);
            LabelSpringDeadband.Name = "LabelSpringDeadband";
            LabelSpringDeadband.Size = new System.Drawing.Size(64, 15);
            LabelSpringDeadband.TabIndex = 3;
            LabelSpringDeadband.Tag = "SpringDeadband";
            LabelSpringDeadband.Text = "Deadband:";
            LabelSpringDeadband.Click += FFB_Label_Click;
            // 
            // SliderSpringSaturation
            // 
            SliderSpringSaturation.AutoSize = false;
            SliderSpringSaturation.BackColor = System.Drawing.SystemColors.Control;
            SliderSpringSaturation.Enabled = false;
            SliderSpringSaturation.LargeChange = 50;
            SliderSpringSaturation.Location = new System.Drawing.Point(108, 104);
            SliderSpringSaturation.Maximum = 10000;
            SliderSpringSaturation.Name = "SliderSpringSaturation";
            SliderSpringSaturation.Size = new System.Drawing.Size(998, 31);
            SliderSpringSaturation.TabIndex = 0;
            SliderSpringSaturation.Tag = "SpringSaturation";
            SliderSpringSaturation.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderSpringSaturation.Value = 5000;
            SliderSpringSaturation.Scroll += FFB_Slider_Scroll;
            // 
            // LabelSpringSaturation
            // 
            LabelSpringSaturation.AutoSize = true;
            LabelSpringSaturation.Location = new System.Drawing.Point(6, 106);
            LabelSpringSaturation.Name = "LabelSpringSaturation";
            LabelSpringSaturation.Size = new System.Drawing.Size(64, 15);
            LabelSpringSaturation.TabIndex = 3;
            LabelSpringSaturation.Tag = "SpringSaturation";
            LabelSpringSaturation.Text = "Saturation:";
            LabelSpringSaturation.Click += FFB_Label_Click;
            // 
            // SliderSpringCoefficient
            // 
            SliderSpringCoefficient.AutoSize = false;
            SliderSpringCoefficient.BackColor = System.Drawing.SystemColors.Control;
            SliderSpringCoefficient.Enabled = false;
            SliderSpringCoefficient.LargeChange = 50;
            SliderSpringCoefficient.Location = new System.Drawing.Point(108, 67);
            SliderSpringCoefficient.Maximum = 10000;
            SliderSpringCoefficient.Minimum = -10000;
            SliderSpringCoefficient.Name = "SliderSpringCoefficient";
            SliderSpringCoefficient.Size = new System.Drawing.Size(998, 31);
            SliderSpringCoefficient.TabIndex = 0;
            SliderSpringCoefficient.Tag = "SpringCoefficient";
            SliderSpringCoefficient.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderSpringCoefficient.Scroll += FFB_Slider_Scroll;
            // 
            // LabelSpringCoefficient
            // 
            LabelSpringCoefficient.AutoSize = true;
            LabelSpringCoefficient.Location = new System.Drawing.Point(6, 69);
            LabelSpringCoefficient.Name = "LabelSpringCoefficient";
            LabelSpringCoefficient.Size = new System.Drawing.Size(68, 15);
            LabelSpringCoefficient.TabIndex = 3;
            LabelSpringCoefficient.Tag = "SpringCoefficient";
            LabelSpringCoefficient.Text = "Coefficient:";
            LabelSpringCoefficient.Click += FFB_Label_Click;
            // 
            // SliderSpringOffset
            // 
            SliderSpringOffset.AutoSize = false;
            SliderSpringOffset.BackColor = System.Drawing.SystemColors.Control;
            SliderSpringOffset.Enabled = false;
            SliderSpringOffset.LargeChange = 50;
            SliderSpringOffset.Location = new System.Drawing.Point(108, 30);
            SliderSpringOffset.Maximum = 10000;
            SliderSpringOffset.Minimum = -10000;
            SliderSpringOffset.Name = "SliderSpringOffset";
            SliderSpringOffset.Size = new System.Drawing.Size(998, 31);
            SliderSpringOffset.TabIndex = 0;
            SliderSpringOffset.Tag = "SpringOffset";
            SliderSpringOffset.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderSpringOffset.Scroll += FFB_Slider_Scroll;
            // 
            // LabelSpringOffset
            // 
            LabelSpringOffset.AutoSize = true;
            LabelSpringOffset.Location = new System.Drawing.Point(6, 32);
            LabelSpringOffset.Name = "LabelSpringOffset";
            LabelSpringOffset.Size = new System.Drawing.Size(42, 15);
            LabelSpringOffset.TabIndex = 3;
            LabelSpringOffset.Tag = "SpringOffset";
            LabelSpringOffset.Text = "Offset:";
            LabelSpringOffset.Click += FFB_Label_Click;
            // 
            // GBInertia
            // 
            GBInertia.Controls.Add(CBInertia);
            GBInertia.Controls.Add(UDInertiaMagnitude);
            GBInertia.Controls.Add(LabelInertiaMagnitude);
            GBInertia.Controls.Add(SliderInertiaMagnitude);
            GBInertia.Location = new System.Drawing.Point(6, 414);
            GBInertia.Name = "GBInertia";
            GBInertia.Size = new System.Drawing.Size(1214, 68);
            GBInertia.TabIndex = 0;
            GBInertia.TabStop = false;
            GBInertia.Tag = "Inertia";
            GBInertia.Text = "   Inertia";
            GBInertia.Click += FFB_GroupBox_Click;
            // 
            // CBInertia
            // 
            CBInertia.AutoSize = true;
            CBInertia.Location = new System.Drawing.Point(0, 3);
            CBInertia.Name = "CBInertia";
            CBInertia.Size = new System.Drawing.Size(15, 14);
            CBInertia.TabIndex = 1;
            CBInertia.Tag = "Inertia";
            CBInertia.UseVisualStyleBackColor = true;
            CBInertia.CheckedChanged += FFB_CheckBox_CheckedChanged;
            // 
            // UDInertiaMagnitude
            // 
            UDInertiaMagnitude.Enabled = false;
            UDInertiaMagnitude.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDInertiaMagnitude.Location = new System.Drawing.Point(1112, 30);
            UDInertiaMagnitude.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDInertiaMagnitude.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDInertiaMagnitude.Name = "UDInertiaMagnitude";
            UDInertiaMagnitude.Size = new System.Drawing.Size(96, 23);
            UDInertiaMagnitude.TabIndex = 2;
            UDInertiaMagnitude.Tag = "InertiaMagnitude";
            UDInertiaMagnitude.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // LabelInertiaMagnitude
            // 
            LabelInertiaMagnitude.AutoSize = true;
            LabelInertiaMagnitude.Location = new System.Drawing.Point(6, 32);
            LabelInertiaMagnitude.Name = "LabelInertiaMagnitude";
            LabelInertiaMagnitude.Size = new System.Drawing.Size(68, 15);
            LabelInertiaMagnitude.TabIndex = 3;
            LabelInertiaMagnitude.Tag = "InertiaMagnitude";
            LabelInertiaMagnitude.Text = "Magnitude:";
            LabelInertiaMagnitude.Click += FFB_Label_Click;
            // 
            // SliderInertiaMagnitude
            // 
            SliderInertiaMagnitude.AutoSize = false;
            SliderInertiaMagnitude.BackColor = System.Drawing.SystemColors.Control;
            SliderInertiaMagnitude.Enabled = false;
            SliderInertiaMagnitude.LargeChange = 50;
            SliderInertiaMagnitude.Location = new System.Drawing.Point(108, 30);
            SliderInertiaMagnitude.Maximum = 10000;
            SliderInertiaMagnitude.Minimum = -10000;
            SliderInertiaMagnitude.Name = "SliderInertiaMagnitude";
            SliderInertiaMagnitude.Size = new System.Drawing.Size(998, 31);
            SliderInertiaMagnitude.TabIndex = 0;
            SliderInertiaMagnitude.Tag = "InertiaMagnitude";
            SliderInertiaMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderInertiaMagnitude.Scroll += FFB_Slider_Scroll;
            // 
            // GBFriction
            // 
            GBFriction.Controls.Add(UDFrictionMagnitude);
            GBFriction.Controls.Add(CBFriction);
            GBFriction.Controls.Add(LabelFrictionMagnitude);
            GBFriction.Controls.Add(SliderFrictionMagnitude);
            GBFriction.Location = new System.Drawing.Point(6, 340);
            GBFriction.Name = "GBFriction";
            GBFriction.Size = new System.Drawing.Size(1214, 68);
            GBFriction.TabIndex = 0;
            GBFriction.TabStop = false;
            GBFriction.Tag = "Friction";
            GBFriction.Text = "   Friction";
            GBFriction.Click += FFB_GroupBox_Click;
            // 
            // UDFrictionMagnitude
            // 
            UDFrictionMagnitude.Enabled = false;
            UDFrictionMagnitude.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDFrictionMagnitude.Location = new System.Drawing.Point(1112, 30);
            UDFrictionMagnitude.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDFrictionMagnitude.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDFrictionMagnitude.Name = "UDFrictionMagnitude";
            UDFrictionMagnitude.Size = new System.Drawing.Size(96, 23);
            UDFrictionMagnitude.TabIndex = 2;
            UDFrictionMagnitude.Tag = "FrictionMagnitude";
            UDFrictionMagnitude.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // CBFriction
            // 
            CBFriction.AutoSize = true;
            CBFriction.Location = new System.Drawing.Point(0, 3);
            CBFriction.Name = "CBFriction";
            CBFriction.Size = new System.Drawing.Size(15, 14);
            CBFriction.TabIndex = 1;
            CBFriction.Tag = "Friction";
            CBFriction.UseVisualStyleBackColor = true;
            CBFriction.CheckedChanged += FFB_CheckBox_CheckedChanged;
            // 
            // LabelFrictionMagnitude
            // 
            LabelFrictionMagnitude.AutoSize = true;
            LabelFrictionMagnitude.Location = new System.Drawing.Point(6, 32);
            LabelFrictionMagnitude.Name = "LabelFrictionMagnitude";
            LabelFrictionMagnitude.Size = new System.Drawing.Size(68, 15);
            LabelFrictionMagnitude.TabIndex = 3;
            LabelFrictionMagnitude.Tag = "FrictionMagnitude";
            LabelFrictionMagnitude.Text = "Magnitude:";
            LabelFrictionMagnitude.Click += FFB_Label_Click;
            // 
            // SliderFrictionMagnitude
            // 
            SliderFrictionMagnitude.AutoSize = false;
            SliderFrictionMagnitude.BackColor = System.Drawing.SystemColors.Control;
            SliderFrictionMagnitude.Enabled = false;
            SliderFrictionMagnitude.LargeChange = 50;
            SliderFrictionMagnitude.Location = new System.Drawing.Point(108, 30);
            SliderFrictionMagnitude.Maximum = 10000;
            SliderFrictionMagnitude.Minimum = -10000;
            SliderFrictionMagnitude.Name = "SliderFrictionMagnitude";
            SliderFrictionMagnitude.Size = new System.Drawing.Size(998, 31);
            SliderFrictionMagnitude.TabIndex = 0;
            SliderFrictionMagnitude.Tag = "FrictionMagnitude";
            SliderFrictionMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderFrictionMagnitude.Scroll += FFB_Slider_Scroll;
            // 
            // GBDamper
            // 
            GBDamper.Controls.Add(UDDamperMagnitude);
            GBDamper.Controls.Add(LabelDamperMagnitude);
            GBDamper.Controls.Add(CBDamper);
            GBDamper.Controls.Add(SliderDamperMagnitude);
            GBDamper.Location = new System.Drawing.Point(6, 266);
            GBDamper.Name = "GBDamper";
            GBDamper.Size = new System.Drawing.Size(1214, 68);
            GBDamper.TabIndex = 0;
            GBDamper.TabStop = false;
            GBDamper.Tag = "Damper";
            GBDamper.Text = "   Damper";
            GBDamper.Click += FFB_GroupBox_Click;
            // 
            // UDDamperMagnitude
            // 
            UDDamperMagnitude.Enabled = false;
            UDDamperMagnitude.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDDamperMagnitude.Location = new System.Drawing.Point(1112, 30);
            UDDamperMagnitude.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDDamperMagnitude.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDDamperMagnitude.Name = "UDDamperMagnitude";
            UDDamperMagnitude.Size = new System.Drawing.Size(96, 23);
            UDDamperMagnitude.TabIndex = 2;
            UDDamperMagnitude.Tag = "DamperMagnitude";
            UDDamperMagnitude.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // LabelDamperMagnitude
            // 
            LabelDamperMagnitude.AutoSize = true;
            LabelDamperMagnitude.Location = new System.Drawing.Point(6, 32);
            LabelDamperMagnitude.Name = "LabelDamperMagnitude";
            LabelDamperMagnitude.Size = new System.Drawing.Size(68, 15);
            LabelDamperMagnitude.TabIndex = 3;
            LabelDamperMagnitude.Tag = "DamperMagnitude";
            LabelDamperMagnitude.Text = "Magnitude:";
            LabelDamperMagnitude.Click += FFB_Label_Click;
            // 
            // CBDamper
            // 
            CBDamper.AutoSize = true;
            CBDamper.Location = new System.Drawing.Point(0, 3);
            CBDamper.Name = "CBDamper";
            CBDamper.Size = new System.Drawing.Size(15, 14);
            CBDamper.TabIndex = 1;
            CBDamper.Tag = "Damper";
            CBDamper.UseVisualStyleBackColor = true;
            CBDamper.CheckedChanged += FFB_CheckBox_CheckedChanged;
            // 
            // SliderDamperMagnitude
            // 
            SliderDamperMagnitude.AutoSize = false;
            SliderDamperMagnitude.BackColor = System.Drawing.SystemColors.Control;
            SliderDamperMagnitude.Enabled = false;
            SliderDamperMagnitude.LargeChange = 50;
            SliderDamperMagnitude.Location = new System.Drawing.Point(108, 30);
            SliderDamperMagnitude.Maximum = 10000;
            SliderDamperMagnitude.Minimum = -10000;
            SliderDamperMagnitude.Name = "SliderDamperMagnitude";
            SliderDamperMagnitude.Size = new System.Drawing.Size(998, 31);
            SliderDamperMagnitude.TabIndex = 0;
            SliderDamperMagnitude.Tag = "DamperMagnitude";
            SliderDamperMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderDamperMagnitude.Scroll += FFB_Slider_Scroll;
            // 
            // GBConstantForce
            // 
            GBConstantForce.Controls.Add(CBConstantForce);
            GBConstantForce.Controls.Add(UDConstantForceMagnitude);
            GBConstantForce.Controls.Add(LabelConstantForceMagnitude);
            GBConstantForce.Controls.Add(SliderConstantForceMagnitude);
            GBConstantForce.Location = new System.Drawing.Point(6, 6);
            GBConstantForce.Name = "GBConstantForce";
            GBConstantForce.Size = new System.Drawing.Size(1214, 68);
            GBConstantForce.TabIndex = 0;
            GBConstantForce.TabStop = false;
            GBConstantForce.Tag = "ConstantForce";
            GBConstantForce.Text = "   Constant Force";
            GBConstantForce.Click += FFB_GroupBox_Click;
            // 
            // CBConstantForce
            // 
            CBConstantForce.AutoSize = true;
            CBConstantForce.Location = new System.Drawing.Point(0, 3);
            CBConstantForce.Name = "CBConstantForce";
            CBConstantForce.Size = new System.Drawing.Size(15, 14);
            CBConstantForce.TabIndex = 1;
            CBConstantForce.Tag = "ConstantForce";
            CBConstantForce.UseVisualStyleBackColor = true;
            CBConstantForce.CheckedChanged += FFB_CheckBox_CheckedChanged;
            // 
            // UDConstantForceMagnitude
            // 
            UDConstantForceMagnitude.Enabled = false;
            UDConstantForceMagnitude.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDConstantForceMagnitude.Location = new System.Drawing.Point(1112, 30);
            UDConstantForceMagnitude.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDConstantForceMagnitude.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDConstantForceMagnitude.Name = "UDConstantForceMagnitude";
            UDConstantForceMagnitude.Size = new System.Drawing.Size(96, 23);
            UDConstantForceMagnitude.TabIndex = 2;
            UDConstantForceMagnitude.Tag = "ConstantForceMagnitude";
            UDConstantForceMagnitude.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // LabelConstantForceMagnitude
            // 
            LabelConstantForceMagnitude.AutoSize = true;
            LabelConstantForceMagnitude.Location = new System.Drawing.Point(6, 32);
            LabelConstantForceMagnitude.Name = "LabelConstantForceMagnitude";
            LabelConstantForceMagnitude.Size = new System.Drawing.Size(68, 15);
            LabelConstantForceMagnitude.TabIndex = 3;
            LabelConstantForceMagnitude.Tag = "ConstantForceMagnitude";
            LabelConstantForceMagnitude.Text = "Magnitude:";
            LabelConstantForceMagnitude.Click += FFB_Label_Click;
            // 
            // SliderConstantForceMagnitude
            // 
            SliderConstantForceMagnitude.AutoSize = false;
            SliderConstantForceMagnitude.BackColor = System.Drawing.SystemColors.Control;
            SliderConstantForceMagnitude.Enabled = false;
            SliderConstantForceMagnitude.LargeChange = 50;
            SliderConstantForceMagnitude.Location = new System.Drawing.Point(108, 30);
            SliderConstantForceMagnitude.Maximum = 10000;
            SliderConstantForceMagnitude.Minimum = -10000;
            SliderConstantForceMagnitude.Name = "SliderConstantForceMagnitude";
            SliderConstantForceMagnitude.Size = new System.Drawing.Size(998, 31);
            SliderConstantForceMagnitude.TabIndex = 0;
            SliderConstantForceMagnitude.Tag = "ConstantForceMagnitude";
            SliderConstantForceMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderConstantForceMagnitude.Scroll += FFB_Slider_Scroll;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(GBCuss);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(1226, 637);
            tabPage1.TabIndex = 5;
            tabPage1.Text = "custom forces";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // GBCuss
            // 
            GBCuss.Controls.Add(UDCustomForceSamplePeriod);
            GBCuss.Controls.Add(label16);
            GBCuss.Controls.Add(SliderCustomForceSamplePeriod);
            GBCuss.Controls.Add(UDCustomForceMagnitude9);
            GBCuss.Controls.Add(label15);
            GBCuss.Controls.Add(SliderCustomForceMagnitude9);
            GBCuss.Controls.Add(UDCustomForceMagnitude8);
            GBCuss.Controls.Add(label14);
            GBCuss.Controls.Add(SliderCustomForceMagnitude8);
            GBCuss.Controls.Add(UDCustomForceMagnitude7);
            GBCuss.Controls.Add(label13);
            GBCuss.Controls.Add(SliderCustomForceMagnitude7);
            GBCuss.Controls.Add(UDCustomForceMagnitude6);
            GBCuss.Controls.Add(label12);
            GBCuss.Controls.Add(SliderCustomForceMagnitude6);
            GBCuss.Controls.Add(UDCustomForceMagnitude5);
            GBCuss.Controls.Add(label11);
            GBCuss.Controls.Add(SliderCustomForceMagnitude5);
            GBCuss.Controls.Add(UDCustomForceMagnitude4);
            GBCuss.Controls.Add(label10);
            GBCuss.Controls.Add(SliderCustomForceMagnitude4);
            GBCuss.Controls.Add(UDCustomForceMagnitude3);
            GBCuss.Controls.Add(label9);
            GBCuss.Controls.Add(SliderCustomForceMagnitude3);
            GBCuss.Controls.Add(UDCustomForceMagnitude2);
            GBCuss.Controls.Add(label8);
            GBCuss.Controls.Add(SliderCustomForceMagnitude2);
            GBCuss.Controls.Add(UDCustomForceMagnitude1);
            GBCuss.Controls.Add(label7);
            GBCuss.Controls.Add(SliderCustomForceMagnitude1);
            GBCuss.Controls.Add(CBCustomForce);
            GBCuss.Controls.Add(UDCustomForceMagnitude0);
            GBCuss.Controls.Add(LblCustomForceMagnitude0);
            GBCuss.Controls.Add(SliderCustomForceMagnitude0);
            GBCuss.Location = new System.Drawing.Point(6, 22);
            GBCuss.Name = "GBCuss";
            GBCuss.Size = new System.Drawing.Size(1214, 609);
            GBCuss.TabIndex = 1;
            GBCuss.TabStop = false;
            GBCuss.Tag = "CustomForce";
            GBCuss.Text = "   CustomForce";
            // 
            // UDCustomForceSamplePeriod
            // 
            UDCustomForceSamplePeriod.AccessibleDescription = "UDCustomForceMagnitude0";
            UDCustomForceSamplePeriod.Enabled = false;
            UDCustomForceSamplePeriod.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDCustomForceSamplePeriod.Location = new System.Drawing.Point(1112, 553);
            UDCustomForceSamplePeriod.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDCustomForceSamplePeriod.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDCustomForceSamplePeriod.Name = "UDCustomForceSamplePeriod";
            UDCustomForceSamplePeriod.Size = new System.Drawing.Size(96, 23);
            UDCustomForceSamplePeriod.TabIndex = 32;
            UDCustomForceSamplePeriod.Tag = "CustomForceMagnitude";
            UDCustomForceSamplePeriod.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(6, 555);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(86, 15);
            label16.TabIndex = 33;
            label16.Tag = "CustomForceMag";
            label16.Text = "Sample Period:";
            // 
            // SliderCustomForceSamplePeriod
            // 
            SliderCustomForceSamplePeriod.AutoSize = false;
            SliderCustomForceSamplePeriod.BackColor = System.Drawing.SystemColors.Control;
            SliderCustomForceSamplePeriod.Enabled = false;
            SliderCustomForceSamplePeriod.LargeChange = 50;
            SliderCustomForceSamplePeriod.Location = new System.Drawing.Point(108, 553);
            SliderCustomForceSamplePeriod.Maximum = 10000;
            SliderCustomForceSamplePeriod.Minimum = 1000;
            SliderCustomForceSamplePeriod.Name = "SliderCustomForceSamplePeriod";
            SliderCustomForceSamplePeriod.Size = new System.Drawing.Size(998, 31);
            SliderCustomForceSamplePeriod.TabIndex = 31;
            SliderCustomForceSamplePeriod.Tag = "CustomForceMagnitude";
            SliderCustomForceSamplePeriod.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderCustomForceSamplePeriod.Value = 1000;
            SliderCustomForceSamplePeriod.Scroll += FFB_Slider_Scroll;
            // 
            // UDCustomForceMagnitude9
            // 
            UDCustomForceMagnitude9.AccessibleDescription = "UDCustomForceMagnitude0";
            UDCustomForceMagnitude9.Enabled = false;
            UDCustomForceMagnitude9.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDCustomForceMagnitude9.Location = new System.Drawing.Point(1112, 487);
            UDCustomForceMagnitude9.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDCustomForceMagnitude9.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDCustomForceMagnitude9.Name = "UDCustomForceMagnitude9";
            UDCustomForceMagnitude9.Size = new System.Drawing.Size(96, 23);
            UDCustomForceMagnitude9.TabIndex = 29;
            UDCustomForceMagnitude9.Tag = "CustomForceMagnitude";
            UDCustomForceMagnitude9.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label15
            // 
            label15.AccessibleName = "LblCustomForceMagnitude0";
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(6, 489);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(68, 15);
            label15.TabIndex = 30;
            label15.Tag = "LblCustomForceMag0";
            label15.Text = "Magnitude:";
            // 
            // SliderCustomForceMagnitude9
            // 
            SliderCustomForceMagnitude9.AutoSize = false;
            SliderCustomForceMagnitude9.BackColor = System.Drawing.SystemColors.Control;
            SliderCustomForceMagnitude9.Enabled = false;
            SliderCustomForceMagnitude9.LargeChange = 50;
            SliderCustomForceMagnitude9.Location = new System.Drawing.Point(108, 487);
            SliderCustomForceMagnitude9.Maximum = 10000;
            SliderCustomForceMagnitude9.Minimum = -10000;
            SliderCustomForceMagnitude9.Name = "SliderCustomForceMagnitude9";
            SliderCustomForceMagnitude9.Size = new System.Drawing.Size(998, 31);
            SliderCustomForceMagnitude9.TabIndex = 28;
            SliderCustomForceMagnitude9.Tag = "CustomForceMagnitude";
            SliderCustomForceMagnitude9.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderCustomForceMagnitude9.Scroll += FFB_Slider_Scroll;
            // 
            // UDCustomForceMagnitude8
            // 
            UDCustomForceMagnitude8.AccessibleDescription = "UDCustomForceMagnitude0";
            UDCustomForceMagnitude8.Enabled = false;
            UDCustomForceMagnitude8.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDCustomForceMagnitude8.Location = new System.Drawing.Point(1112, 433);
            UDCustomForceMagnitude8.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDCustomForceMagnitude8.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDCustomForceMagnitude8.Name = "UDCustomForceMagnitude8";
            UDCustomForceMagnitude8.Size = new System.Drawing.Size(96, 23);
            UDCustomForceMagnitude8.TabIndex = 26;
            UDCustomForceMagnitude8.Tag = "CustomForceMagnitude";
            UDCustomForceMagnitude8.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label14
            // 
            label14.AccessibleName = "LblCustomForceMagnitude0";
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(6, 435);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(68, 15);
            label14.TabIndex = 27;
            label14.Tag = "LblCustomForceMag0";
            label14.Text = "Magnitude:";
            // 
            // SliderCustomForceMagnitude8
            // 
            SliderCustomForceMagnitude8.AutoSize = false;
            SliderCustomForceMagnitude8.BackColor = System.Drawing.SystemColors.Control;
            SliderCustomForceMagnitude8.Enabled = false;
            SliderCustomForceMagnitude8.LargeChange = 50;
            SliderCustomForceMagnitude8.Location = new System.Drawing.Point(108, 433);
            SliderCustomForceMagnitude8.Maximum = 10000;
            SliderCustomForceMagnitude8.Minimum = -10000;
            SliderCustomForceMagnitude8.Name = "SliderCustomForceMagnitude8";
            SliderCustomForceMagnitude8.Size = new System.Drawing.Size(998, 31);
            SliderCustomForceMagnitude8.TabIndex = 25;
            SliderCustomForceMagnitude8.Tag = "CustomForceMagnitude";
            SliderCustomForceMagnitude8.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderCustomForceMagnitude8.Scroll += FFB_Slider_Scroll;
            // 
            // UDCustomForceMagnitude7
            // 
            UDCustomForceMagnitude7.AccessibleDescription = "UDCustomForceMagnitude0";
            UDCustomForceMagnitude7.Enabled = false;
            UDCustomForceMagnitude7.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDCustomForceMagnitude7.Location = new System.Drawing.Point(1112, 380);
            UDCustomForceMagnitude7.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDCustomForceMagnitude7.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDCustomForceMagnitude7.Name = "UDCustomForceMagnitude7";
            UDCustomForceMagnitude7.Size = new System.Drawing.Size(96, 23);
            UDCustomForceMagnitude7.TabIndex = 23;
            UDCustomForceMagnitude7.Tag = "CustomForceMagnitude";
            UDCustomForceMagnitude7.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label13
            // 
            label13.AccessibleName = "LblCustomForceMagnitude0";
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(6, 382);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(68, 15);
            label13.TabIndex = 24;
            label13.Tag = "LblCustomForceMag0";
            label13.Text = "Magnitude:";
            // 
            // SliderCustomForceMagnitude7
            // 
            SliderCustomForceMagnitude7.AutoSize = false;
            SliderCustomForceMagnitude7.BackColor = System.Drawing.SystemColors.Control;
            SliderCustomForceMagnitude7.Enabled = false;
            SliderCustomForceMagnitude7.LargeChange = 50;
            SliderCustomForceMagnitude7.Location = new System.Drawing.Point(108, 380);
            SliderCustomForceMagnitude7.Maximum = 10000;
            SliderCustomForceMagnitude7.Minimum = -10000;
            SliderCustomForceMagnitude7.Name = "SliderCustomForceMagnitude7";
            SliderCustomForceMagnitude7.Size = new System.Drawing.Size(998, 31);
            SliderCustomForceMagnitude7.TabIndex = 22;
            SliderCustomForceMagnitude7.Tag = "CustomForceMagnitude";
            SliderCustomForceMagnitude7.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderCustomForceMagnitude7.Scroll += FFB_Slider_Scroll;
            // 
            // UDCustomForceMagnitude6
            // 
            UDCustomForceMagnitude6.AccessibleDescription = "UDCustomForceMagnitude0";
            UDCustomForceMagnitude6.Enabled = false;
            UDCustomForceMagnitude6.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDCustomForceMagnitude6.Location = new System.Drawing.Point(1112, 328);
            UDCustomForceMagnitude6.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDCustomForceMagnitude6.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDCustomForceMagnitude6.Name = "UDCustomForceMagnitude6";
            UDCustomForceMagnitude6.Size = new System.Drawing.Size(96, 23);
            UDCustomForceMagnitude6.TabIndex = 20;
            UDCustomForceMagnitude6.Tag = "CustomForceMagnitude";
            UDCustomForceMagnitude6.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label12
            // 
            label12.AccessibleName = "LblCustomForceMagnitude0";
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(6, 330);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(68, 15);
            label12.TabIndex = 21;
            label12.Tag = "LblCustomForceMag0";
            label12.Text = "Magnitude:";
            // 
            // SliderCustomForceMagnitude6
            // 
            SliderCustomForceMagnitude6.AutoSize = false;
            SliderCustomForceMagnitude6.BackColor = System.Drawing.SystemColors.Control;
            SliderCustomForceMagnitude6.Enabled = false;
            SliderCustomForceMagnitude6.LargeChange = 50;
            SliderCustomForceMagnitude6.Location = new System.Drawing.Point(108, 328);
            SliderCustomForceMagnitude6.Maximum = 10000;
            SliderCustomForceMagnitude6.Minimum = -10000;
            SliderCustomForceMagnitude6.Name = "SliderCustomForceMagnitude6";
            SliderCustomForceMagnitude6.Size = new System.Drawing.Size(998, 31);
            SliderCustomForceMagnitude6.TabIndex = 19;
            SliderCustomForceMagnitude6.Tag = "CustomForceMagnitude";
            SliderCustomForceMagnitude6.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderCustomForceMagnitude6.Scroll += FFB_Slider_Scroll;
            // 
            // UDCustomForceMagnitude5
            // 
            UDCustomForceMagnitude5.AccessibleDescription = "UDCustomForceMagnitude0";
            UDCustomForceMagnitude5.Enabled = false;
            UDCustomForceMagnitude5.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDCustomForceMagnitude5.Location = new System.Drawing.Point(1112, 276);
            UDCustomForceMagnitude5.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDCustomForceMagnitude5.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDCustomForceMagnitude5.Name = "UDCustomForceMagnitude5";
            UDCustomForceMagnitude5.Size = new System.Drawing.Size(96, 23);
            UDCustomForceMagnitude5.TabIndex = 17;
            UDCustomForceMagnitude5.Tag = "CustomForceMagnitude";
            UDCustomForceMagnitude5.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label11
            // 
            label11.AccessibleName = "LblCustomForceMagnitude0";
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(6, 278);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(68, 15);
            label11.TabIndex = 18;
            label11.Tag = "LblCustomForceMag0";
            label11.Text = "Magnitude:";
            // 
            // SliderCustomForceMagnitude5
            // 
            SliderCustomForceMagnitude5.AutoSize = false;
            SliderCustomForceMagnitude5.BackColor = System.Drawing.SystemColors.Control;
            SliderCustomForceMagnitude5.Enabled = false;
            SliderCustomForceMagnitude5.LargeChange = 50;
            SliderCustomForceMagnitude5.Location = new System.Drawing.Point(108, 276);
            SliderCustomForceMagnitude5.Maximum = 10000;
            SliderCustomForceMagnitude5.Minimum = -10000;
            SliderCustomForceMagnitude5.Name = "SliderCustomForceMagnitude5";
            SliderCustomForceMagnitude5.Size = new System.Drawing.Size(998, 31);
            SliderCustomForceMagnitude5.TabIndex = 16;
            SliderCustomForceMagnitude5.Tag = "CustomForceMagnitude";
            SliderCustomForceMagnitude5.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderCustomForceMagnitude5.Scroll += FFB_Slider_Scroll;
            // 
            // UDCustomForceMagnitude4
            // 
            UDCustomForceMagnitude4.AccessibleDescription = "UDCustomForceMagnitude0";
            UDCustomForceMagnitude4.Enabled = false;
            UDCustomForceMagnitude4.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDCustomForceMagnitude4.Location = new System.Drawing.Point(1112, 226);
            UDCustomForceMagnitude4.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDCustomForceMagnitude4.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDCustomForceMagnitude4.Name = "UDCustomForceMagnitude4";
            UDCustomForceMagnitude4.Size = new System.Drawing.Size(96, 23);
            UDCustomForceMagnitude4.TabIndex = 14;
            UDCustomForceMagnitude4.Tag = "CustomForceMagnitude";
            UDCustomForceMagnitude4.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label10
            // 
            label10.AccessibleName = "LblCustomForceMagnitude0";
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(6, 228);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(68, 15);
            label10.TabIndex = 15;
            label10.Tag = "LblCustomForceMag0";
            label10.Text = "Magnitude:";
            // 
            // SliderCustomForceMagnitude4
            // 
            SliderCustomForceMagnitude4.AutoSize = false;
            SliderCustomForceMagnitude4.BackColor = System.Drawing.SystemColors.Control;
            SliderCustomForceMagnitude4.Enabled = false;
            SliderCustomForceMagnitude4.LargeChange = 50;
            SliderCustomForceMagnitude4.Location = new System.Drawing.Point(108, 226);
            SliderCustomForceMagnitude4.Maximum = 10000;
            SliderCustomForceMagnitude4.Minimum = -10000;
            SliderCustomForceMagnitude4.Name = "SliderCustomForceMagnitude4";
            SliderCustomForceMagnitude4.Size = new System.Drawing.Size(998, 31);
            SliderCustomForceMagnitude4.TabIndex = 13;
            SliderCustomForceMagnitude4.Tag = "CustomForceMagnitude";
            SliderCustomForceMagnitude4.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderCustomForceMagnitude4.Scroll += FFB_Slider_Scroll;
            // 
            // UDCustomForceMagnitude3
            // 
            UDCustomForceMagnitude3.AccessibleDescription = "UDCustomForceMagnitude0";
            UDCustomForceMagnitude3.Enabled = false;
            UDCustomForceMagnitude3.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDCustomForceMagnitude3.Location = new System.Drawing.Point(1112, 179);
            UDCustomForceMagnitude3.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDCustomForceMagnitude3.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDCustomForceMagnitude3.Name = "UDCustomForceMagnitude3";
            UDCustomForceMagnitude3.Size = new System.Drawing.Size(96, 23);
            UDCustomForceMagnitude3.TabIndex = 11;
            UDCustomForceMagnitude3.Tag = "CustomForceMagnitude";
            UDCustomForceMagnitude3.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label9
            // 
            label9.AccessibleName = "LblCustomForceMagnitude0";
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(6, 181);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(68, 15);
            label9.TabIndex = 12;
            label9.Tag = "LblCustomForceMag0";
            label9.Text = "Magnitude:";
            // 
            // SliderCustomForceMagnitude3
            // 
            SliderCustomForceMagnitude3.AutoSize = false;
            SliderCustomForceMagnitude3.BackColor = System.Drawing.SystemColors.Control;
            SliderCustomForceMagnitude3.Enabled = false;
            SliderCustomForceMagnitude3.LargeChange = 50;
            SliderCustomForceMagnitude3.Location = new System.Drawing.Point(108, 179);
            SliderCustomForceMagnitude3.Maximum = 10000;
            SliderCustomForceMagnitude3.Minimum = -10000;
            SliderCustomForceMagnitude3.Name = "SliderCustomForceMagnitude3";
            SliderCustomForceMagnitude3.Size = new System.Drawing.Size(998, 31);
            SliderCustomForceMagnitude3.TabIndex = 10;
            SliderCustomForceMagnitude3.Tag = "CustomForceMagnitude";
            SliderCustomForceMagnitude3.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderCustomForceMagnitude3.Scroll += FFB_Slider_Scroll;
            // 
            // UDCustomForceMagnitude2
            // 
            UDCustomForceMagnitude2.AccessibleDescription = "UDCustomForceMagnitude0";
            UDCustomForceMagnitude2.Enabled = false;
            UDCustomForceMagnitude2.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDCustomForceMagnitude2.Location = new System.Drawing.Point(1112, 129);
            UDCustomForceMagnitude2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDCustomForceMagnitude2.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDCustomForceMagnitude2.Name = "UDCustomForceMagnitude2";
            UDCustomForceMagnitude2.Size = new System.Drawing.Size(96, 23);
            UDCustomForceMagnitude2.TabIndex = 8;
            UDCustomForceMagnitude2.Tag = "CustomForceMagnitude";
            UDCustomForceMagnitude2.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label8
            // 
            label8.AccessibleName = "LblCustomForceMagnitude0";
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 131);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(68, 15);
            label8.TabIndex = 9;
            label8.Tag = "LblCustomForceMag0";
            label8.Text = "Magnitude:";
            // 
            // SliderCustomForceMagnitude2
            // 
            SliderCustomForceMagnitude2.AutoSize = false;
            SliderCustomForceMagnitude2.BackColor = System.Drawing.SystemColors.Control;
            SliderCustomForceMagnitude2.Enabled = false;
            SliderCustomForceMagnitude2.LargeChange = 50;
            SliderCustomForceMagnitude2.Location = new System.Drawing.Point(108, 129);
            SliderCustomForceMagnitude2.Maximum = 10000;
            SliderCustomForceMagnitude2.Minimum = -10000;
            SliderCustomForceMagnitude2.Name = "SliderCustomForceMagnitude2";
            SliderCustomForceMagnitude2.Size = new System.Drawing.Size(998, 31);
            SliderCustomForceMagnitude2.TabIndex = 7;
            SliderCustomForceMagnitude2.Tag = "CustomForceMagnitude";
            SliderCustomForceMagnitude2.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderCustomForceMagnitude2.Scroll += FFB_Slider_Scroll;
            // 
            // UDCustomForceMagnitude1
            // 
            UDCustomForceMagnitude1.AccessibleDescription = "UDCustomForceMagnitude0";
            UDCustomForceMagnitude1.Enabled = false;
            UDCustomForceMagnitude1.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDCustomForceMagnitude1.Location = new System.Drawing.Point(1112, 80);
            UDCustomForceMagnitude1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDCustomForceMagnitude1.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDCustomForceMagnitude1.Name = "UDCustomForceMagnitude1";
            UDCustomForceMagnitude1.Size = new System.Drawing.Size(96, 23);
            UDCustomForceMagnitude1.TabIndex = 5;
            UDCustomForceMagnitude1.Tag = "CustomForceMagnitude";
            UDCustomForceMagnitude1.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // label7
            // 
            label7.AccessibleName = "LblCustomForceMagnitude0";
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 82);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(68, 15);
            label7.TabIndex = 6;
            label7.Tag = "LblCustomForceMag0";
            label7.Text = "Magnitude:";
            // 
            // SliderCustomForceMagnitude1
            // 
            SliderCustomForceMagnitude1.AutoSize = false;
            SliderCustomForceMagnitude1.BackColor = System.Drawing.SystemColors.Control;
            SliderCustomForceMagnitude1.Enabled = false;
            SliderCustomForceMagnitude1.LargeChange = 50;
            SliderCustomForceMagnitude1.Location = new System.Drawing.Point(108, 80);
            SliderCustomForceMagnitude1.Maximum = 10000;
            SliderCustomForceMagnitude1.Minimum = -10000;
            SliderCustomForceMagnitude1.Name = "SliderCustomForceMagnitude1";
            SliderCustomForceMagnitude1.Size = new System.Drawing.Size(998, 31);
            SliderCustomForceMagnitude1.TabIndex = 4;
            SliderCustomForceMagnitude1.Tag = "CustomForceMagnitude";
            SliderCustomForceMagnitude1.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderCustomForceMagnitude1.Scroll += FFB_Slider_Scroll;
            // 
            // CBCustomForce
            // 
            CBCustomForce.AutoSize = true;
            CBCustomForce.Location = new System.Drawing.Point(0, 3);
            CBCustomForce.Name = "CBCustomForce";
            CBCustomForce.Size = new System.Drawing.Size(15, 14);
            CBCustomForce.TabIndex = 1;
            CBCustomForce.Tag = "CustomForce";
            CBCustomForce.UseVisualStyleBackColor = true;
            CBCustomForce.CheckedChanged += FFB_CheckBox_CheckedChanged;
            // 
            // UDCustomForceMagnitude0
            // 
            UDCustomForceMagnitude0.AccessibleDescription = "UDCustomForceMagnitude0";
            UDCustomForceMagnitude0.Enabled = false;
            UDCustomForceMagnitude0.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            UDCustomForceMagnitude0.Location = new System.Drawing.Point(1112, 30);
            UDCustomForceMagnitude0.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            UDCustomForceMagnitude0.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            UDCustomForceMagnitude0.Name = "UDCustomForceMagnitude0";
            UDCustomForceMagnitude0.Size = new System.Drawing.Size(96, 23);
            UDCustomForceMagnitude0.TabIndex = 2;
            UDCustomForceMagnitude0.Tag = "CustomForceMagnitude";
            UDCustomForceMagnitude0.ValueChanged += FFB_UpDown_ValueChanged;
            // 
            // LblCustomForceMagnitude0
            // 
            LblCustomForceMagnitude0.AutoSize = true;
            LblCustomForceMagnitude0.Location = new System.Drawing.Point(6, 32);
            LblCustomForceMagnitude0.Name = "LblCustomForceMagnitude0";
            LblCustomForceMagnitude0.Size = new System.Drawing.Size(68, 15);
            LblCustomForceMagnitude0.TabIndex = 3;
            LblCustomForceMagnitude0.Tag = "LblCustomForceMag0";
            LblCustomForceMagnitude0.Text = "Magnitude:";
            // 
            // SliderCustomForceMagnitude0
            // 
            SliderCustomForceMagnitude0.AutoSize = false;
            SliderCustomForceMagnitude0.BackColor = System.Drawing.SystemColors.Control;
            SliderCustomForceMagnitude0.Enabled = false;
            SliderCustomForceMagnitude0.LargeChange = 50;
            SliderCustomForceMagnitude0.Location = new System.Drawing.Point(108, 30);
            SliderCustomForceMagnitude0.Maximum = 10000;
            SliderCustomForceMagnitude0.Minimum = -10000;
            SliderCustomForceMagnitude0.Name = "SliderCustomForceMagnitude0";
            SliderCustomForceMagnitude0.Size = new System.Drawing.Size(998, 31);
            SliderCustomForceMagnitude0.TabIndex = 0;
            SliderCustomForceMagnitude0.Tag = "CustomForceMagnitude";
            SliderCustomForceMagnitude0.TickStyle = System.Windows.Forms.TickStyle.None;
            SliderCustomForceMagnitude0.Scroll += FFB_Slider_Scroll;
            // 
            // TabMisc
            // 
            TabMisc.Controls.Add(LabelDebug);
            TabMisc.Controls.Add(ButtonDebug);
            TabMisc.Location = new System.Drawing.Point(4, 24);
            TabMisc.Name = "TabMisc";
            TabMisc.Padding = new System.Windows.Forms.Padding(3);
            TabMisc.Size = new System.Drawing.Size(1226, 637);
            TabMisc.TabIndex = 4;
            TabMisc.Text = "Misc";
            TabMisc.UseVisualStyleBackColor = true;
            // 
            // LabelDebug
            // 
            LabelDebug.AutoSize = true;
            LabelDebug.Location = new System.Drawing.Point(6, 3);
            LabelDebug.Name = "LabelDebug";
            LabelDebug.Size = new System.Drawing.Size(73, 15);
            LabelDebug.TabIndex = 1;
            LabelDebug.Text = "Debug Stuff:";
            // 
            // ButtonDebug
            // 
            ButtonDebug.Location = new System.Drawing.Point(1077, 6);
            ButtonDebug.Name = "ButtonDebug";
            ButtonDebug.Size = new System.Drawing.Size(143, 55);
            ButtonDebug.TabIndex = 0;
            ButtonDebug.Text = "Debug";
            ButtonDebug.UseVisualStyleBackColor = true;
            ButtonDebug.Click += ButtonDebug_Click;
            // 
            // Form1
            // 
            ClientSize = new System.Drawing.Size(1258, 718);
            Controls.Add(TabController);
            Controls.Add(ButtonRemove);
            Controls.Add(ButtonAttach);
            Controls.Add(ButtonEnumerateDevices);
            Controls.Add(ComboBoxDevices);
            Name = "Form1";
            Text = "Direct Input Explorer";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            TabController.ResumeLayout(false);
            TabDeviceInfo.ResumeLayout(false);
            TabDeviceInfo.PerformLayout();
            TabInput.ResumeLayout(false);
            TabInput.PerformLayout();
            TabFFB.ResumeLayout(false);
            GBSine.ResumeLayout(false);
            GBSine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UDSineMagnitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderSineMagnitude).EndInit();
            GBSquare.ResumeLayout(false);
            GBSquare.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UDSquareMagnitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderSquareMagnitude).EndInit();
            GBTriangle.ResumeLayout(false);
            GBTriangle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UDTriangleMagnitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderTriangleMagnitude).EndInit();
            GBRampForce.ResumeLayout(false);
            GBRampForce.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UDRampForceMagnitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderRampForceMagnitude).EndInit();
            GBSawtoothUp.ResumeLayout(false);
            GBSawtoothUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UDSawtoothUpMagnitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderSawtoothUpMagnitude).EndInit();
            GBSawtoothDown.ResumeLayout(false);
            GBSawtoothDown.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UDSawtoothDownMagnitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderSawtoothDownMagnitude).EndInit();
            GBSpring.ResumeLayout(false);
            GBSpring.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UDSpringDeadband).EndInit();
            ((System.ComponentModel.ISupportInitialize)UDSpringSaturation).EndInit();
            ((System.ComponentModel.ISupportInitialize)UDSpringCoefficient).EndInit();
            ((System.ComponentModel.ISupportInitialize)UDSpringOffset).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderSpringDeadband).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderSpringSaturation).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderSpringCoefficient).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderSpringOffset).EndInit();
            GBInertia.ResumeLayout(false);
            GBInertia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UDInertiaMagnitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderInertiaMagnitude).EndInit();
            GBFriction.ResumeLayout(false);
            GBFriction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UDFrictionMagnitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderFrictionMagnitude).EndInit();
            GBDamper.ResumeLayout(false);
            GBDamper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UDDamperMagnitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderDamperMagnitude).EndInit();
            GBConstantForce.ResumeLayout(false);
            GBConstantForce.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UDConstantForceMagnitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderConstantForceMagnitude).EndInit();
            tabPage1.ResumeLayout(false);
            GBCuss.ResumeLayout(false);
            GBCuss.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceSamplePeriod).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceSamplePeriod).EndInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude9).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude9).EndInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude8).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude8).EndInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude7).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude7).EndInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude6).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude6).EndInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude5).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude5).EndInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude4).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude4).EndInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude3).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude3).EndInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude2).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude2).EndInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude1).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude1).EndInit();
            ((System.ComponentModel.ISupportInitialize)UDCustomForceMagnitude0).EndInit();
            ((System.ComponentModel.ISupportInitialize)SliderCustomForceMagnitude0).EndInit();
            TabMisc.ResumeLayout(false);
            TabMisc.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ComboBox ComboBoxDevices;
    private System.Windows.Forms.Button ButtonEnumerateDevices;
    private System.Windows.Forms.Label LabelDeviceInfo;
    private System.Windows.Forms.Timer TimerPoll;
    private System.Windows.Forms.Button ButtonAttach;
    private System.Windows.Forms.Button ButtonRemove;
    private System.Windows.Forms.TabControl TabController;
    private System.Windows.Forms.TabPage TabDeviceInfo;
    private System.Windows.Forms.TabPage TabInput;
    private System.Windows.Forms.TabPage TabFFB;
    private System.Windows.Forms.Label LabelCapabilities;
    private System.Windows.Forms.Label LabelInput;
    private System.Windows.Forms.TabPage TabMisc;
    private System.Windows.Forms.Label LabelDebug;
    private System.Windows.Forms.Button ButtonDebug;
    private System.Windows.Forms.GroupBox GBConstantForce;
    private System.Windows.Forms.TrackBar SliderConstantForceMagnitude;
    private System.Windows.Forms.GroupBox GBSpring;
    private System.Windows.Forms.NumericUpDown UDConstantForceMagnitude;
    private System.Windows.Forms.NumericUpDown UDSpringSaturation;
    private System.Windows.Forms.NumericUpDown UDSpringCoefficient;
    private System.Windows.Forms.NumericUpDown UDSpringOffset;
    private System.Windows.Forms.TrackBar SliderSpringSaturation;
    private System.Windows.Forms.Label LabelSpringSaturation;
    private System.Windows.Forms.TrackBar SliderSpringCoefficient;
    private System.Windows.Forms.Label LabelSpringCoefficient;
    private System.Windows.Forms.TrackBar SliderSpringOffset;
    private System.Windows.Forms.Label LabelSpringOffset;
    private System.Windows.Forms.Label LabelConstantForceMagnitude;
    private System.Windows.Forms.NumericUpDown UDSpringDeadband;
    private System.Windows.Forms.TrackBar SliderSpringDeadband;
    private System.Windows.Forms.Label LabelSpringDeadband;
    private System.Windows.Forms.GroupBox GBInertia;
    private System.Windows.Forms.NumericUpDown UDInertiaMagnitude;
    private System.Windows.Forms.Label LabelInertiaMagnitude;
    private System.Windows.Forms.TrackBar SliderInertiaMagnitude;
    private System.Windows.Forms.GroupBox GBFriction;
    private System.Windows.Forms.NumericUpDown UDFrictionMagnitude;
    private System.Windows.Forms.Label LabelFrictionMagnitude;
    private System.Windows.Forms.TrackBar SliderFrictionMagnitude;
    private System.Windows.Forms.GroupBox GBDamper;
    private System.Windows.Forms.NumericUpDown UDDamperMagnitude;
    private System.Windows.Forms.Label LabelDamperMagnitude;
    private System.Windows.Forms.TrackBar SliderDamperMagnitude;
    private System.Windows.Forms.CheckBox CBConstantForce;
    private System.Windows.Forms.CheckBox CBSpring;
    private System.Windows.Forms.CheckBox CBInertia;
    private System.Windows.Forms.CheckBox CBFriction;
    private System.Windows.Forms.CheckBox CBDamper;
    private System.Windows.Forms.Label LabelFFBCapabilities;
        private System.Windows.Forms.GroupBox GBSawtoothDown;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown UDSawtoothDownMagnitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar SliderSawtoothDownMagnitude;
        private System.Windows.Forms.GroupBox GBRampForce;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.NumericUpDown UDRampForceMagnitude;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar SliderRampForceMagnitude;
        private System.Windows.Forms.GroupBox GBSawtoothUp;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.NumericUpDown UDSawtoothUpMagnitude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar SliderSawtoothUpMagnitude;
        private System.Windows.Forms.GroupBox GBSine;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.NumericUpDown UDSineMagnitude;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar SliderSineMagnitude;
        private System.Windows.Forms.GroupBox GBSquare;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.NumericUpDown UDSquareMagnitude;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar SliderSquareMagnitude;
        private System.Windows.Forms.GroupBox GBTriangle;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.NumericUpDown UDTriangleMagnitude;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar SliderTriangleMagnitude;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox GBCuss;
        private System.Windows.Forms.CheckBox CBCustomForce;
        private System.Windows.Forms.NumericUpDown UDCustomForceMagnitude0;
        private System.Windows.Forms.Label LblCustomForceMagnitude0;
        private System.Windows.Forms.TrackBar SliderCustomForceMagnitude0;
        private System.Windows.Forms.NumericUpDown UDCustomForceSamplePeriod;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar SliderCustomForceSamplePeriod;
        private System.Windows.Forms.NumericUpDown UDCustomForceMagnitude9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar SliderCustomForceMagnitude9;
        private System.Windows.Forms.NumericUpDown UDCustomForceMagnitude8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar SliderCustomForceMagnitude8;
        private System.Windows.Forms.NumericUpDown UDCustomForceMagnitude7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar SliderCustomForceMagnitude7;
        private System.Windows.Forms.NumericUpDown UDCustomForceMagnitude6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar SliderCustomForceMagnitude6;
        private System.Windows.Forms.NumericUpDown UDCustomForceMagnitude5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar SliderCustomForceMagnitude5;
        private System.Windows.Forms.NumericUpDown UDCustomForceMagnitude4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar SliderCustomForceMagnitude4;
        private System.Windows.Forms.NumericUpDown UDCustomForceMagnitude3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar SliderCustomForceMagnitude3;
        private System.Windows.Forms.NumericUpDown UDCustomForceMagnitude2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar SliderCustomForceMagnitude2;
        private System.Windows.Forms.NumericUpDown UDCustomForceMagnitude1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar SliderCustomForceMagnitude1;
    }
}

