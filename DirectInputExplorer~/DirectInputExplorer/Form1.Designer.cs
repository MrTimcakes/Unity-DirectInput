
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
      this.components = new System.ComponentModel.Container();
      this.ComboBoxDevices = new System.Windows.Forms.ComboBox();
      this.ButtonEnumerateDevices = new System.Windows.Forms.Button();
      this.LabelDeviceInfo = new System.Windows.Forms.Label();
      this.TimerPoll = new System.Windows.Forms.Timer(this.components);
      this.ButtonAttatch = new System.Windows.Forms.Button();
      this.ButtonRemove = new System.Windows.Forms.Button();
      this.TabController = new System.Windows.Forms.TabControl();
      this.TabDeviceInfo = new System.Windows.Forms.TabPage();
      this.LabelFFBCapabilities = new System.Windows.Forms.Label();
      this.LabelCapabilities = new System.Windows.Forms.Label();
      this.TabInput = new System.Windows.Forms.TabPage();
      this.LabelInput = new System.Windows.Forms.Label();
      this.TabFFB = new System.Windows.Forms.TabPage();
      this.GBSpring = new System.Windows.Forms.GroupBox();
      this.CBSpring = new System.Windows.Forms.CheckBox();
      this.UDSpringDeadband = new System.Windows.Forms.NumericUpDown();
      this.UDSpringSaturation = new System.Windows.Forms.NumericUpDown();
      this.UDSpringCoefficient = new System.Windows.Forms.NumericUpDown();
      this.UDSpringOffset = new System.Windows.Forms.NumericUpDown();
      this.SliderSpringDeadband = new System.Windows.Forms.TrackBar();
      this.LabelSpringDeadband = new System.Windows.Forms.Label();
      this.SliderSpringSaturation = new System.Windows.Forms.TrackBar();
      this.LabelSpringSaturation = new System.Windows.Forms.Label();
      this.SliderSpringCoefficient = new System.Windows.Forms.TrackBar();
      this.LabelSpringCoefficient = new System.Windows.Forms.Label();
      this.SliderSpringOffset = new System.Windows.Forms.TrackBar();
      this.LabelSpringOffset = new System.Windows.Forms.Label();
      this.GBInertia = new System.Windows.Forms.GroupBox();
      this.CBInertia = new System.Windows.Forms.CheckBox();
      this.UDInertiaMagnitude = new System.Windows.Forms.NumericUpDown();
      this.LabelInertiaMagnitude = new System.Windows.Forms.Label();
      this.SliderInertiaMagnitude = new System.Windows.Forms.TrackBar();
      this.GBFriction = new System.Windows.Forms.GroupBox();
      this.UDFrictionMagnitude = new System.Windows.Forms.NumericUpDown();
      this.CBFriction = new System.Windows.Forms.CheckBox();
      this.LabelFrictionMagnitude = new System.Windows.Forms.Label();
      this.SliderFrictionMagnitude = new System.Windows.Forms.TrackBar();
      this.GBDamper = new System.Windows.Forms.GroupBox();
      this.UDDamperMagnitude = new System.Windows.Forms.NumericUpDown();
      this.LabelDamperMagnitude = new System.Windows.Forms.Label();
      this.CBDamper = new System.Windows.Forms.CheckBox();
      this.SliderDamperMagnitude = new System.Windows.Forms.TrackBar();
      this.GBConstantForce = new System.Windows.Forms.GroupBox();
      this.CBConstantForce = new System.Windows.Forms.CheckBox();
      this.UDConstantForceMagnitude = new System.Windows.Forms.NumericUpDown();
      this.LabelConstantForceMagnitude = new System.Windows.Forms.Label();
      this.SliderConstantForceMagnitude = new System.Windows.Forms.TrackBar();
      this.TabMisc = new System.Windows.Forms.TabPage();
      this.LabelDebug = new System.Windows.Forms.Label();
      this.ButtonDebug = new System.Windows.Forms.Button();
      this.TabController.SuspendLayout();
      this.TabDeviceInfo.SuspendLayout();
      this.TabInput.SuspendLayout();
      this.TabFFB.SuspendLayout();
      this.GBSpring.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringDeadband)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringSaturation)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringCoefficient)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringOffset)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringDeadband)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringSaturation)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringCoefficient)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringOffset)).BeginInit();
      this.GBInertia.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDInertiaMagnitude)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderInertiaMagnitude)).BeginInit();
      this.GBFriction.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDFrictionMagnitude)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderFrictionMagnitude)).BeginInit();
      this.GBDamper.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDDamperMagnitude)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderDamperMagnitude)).BeginInit();
      this.GBConstantForce.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDConstantForceMagnitude)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderConstantForceMagnitude)).BeginInit();
      this.TabMisc.SuspendLayout();
      this.SuspendLayout();
      // 
      // ComboBoxDevices
      // 
      this.ComboBoxDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ComboBoxDevices.FormattingEnabled = true;
      this.ComboBoxDevices.Location = new System.Drawing.Point(12, 12);
      this.ComboBoxDevices.Name = "ComboBoxDevices";
      this.ComboBoxDevices.Size = new System.Drawing.Size(976, 33);
      this.ComboBoxDevices.TabIndex = 1;
      this.ComboBoxDevices.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDevices_SelectedIndexChanged);
      // 
      // ButtonEnumerateDevices
      // 
      this.ButtonEnumerateDevices.Location = new System.Drawing.Point(994, 12);
      this.ButtonEnumerateDevices.Name = "ButtonEnumerateDevices";
      this.ButtonEnumerateDevices.Size = new System.Drawing.Size(40, 33);
      this.ButtonEnumerateDevices.TabIndex = 2;
      this.ButtonEnumerateDevices.Text = "🔄";
      this.ButtonEnumerateDevices.UseVisualStyleBackColor = true;
      this.ButtonEnumerateDevices.Click += new System.EventHandler(this.ButtonEnumerateDevices_Click);
      // 
      // LabelDeviceInfo
      // 
      this.LabelDeviceInfo.AutoSize = true;
      this.LabelDeviceInfo.Location = new System.Drawing.Point(5, 5);
      this.LabelDeviceInfo.Name = "LabelDeviceInfo";
      this.LabelDeviceInfo.Size = new System.Drawing.Size(105, 25);
      this.LabelDeviceInfo.TabIndex = 3;
      this.LabelDeviceInfo.Text = "Device Info:";
      // 
      // TimerPoll
      // 
      this.TimerPoll.Enabled = true;
      this.TimerPoll.Interval = 20;
      this.TimerPoll.Tick += new System.EventHandler(this.TimerPoll_Tick_1);
      // 
      // ButtonAttatch
      // 
      this.ButtonAttatch.Location = new System.Drawing.Point(1040, 12);
      this.ButtonAttatch.Name = "ButtonAttatch";
      this.ButtonAttatch.Size = new System.Drawing.Size(100, 33);
      this.ButtonAttatch.TabIndex = 5;
      this.ButtonAttatch.Text = "Attatch";
      this.ButtonAttatch.UseVisualStyleBackColor = true;
      this.ButtonAttatch.Click += new System.EventHandler(this.ButtonAttatch_Click);
      // 
      // ButtonRemove
      // 
      this.ButtonRemove.Location = new System.Drawing.Point(1146, 12);
      this.ButtonRemove.Name = "ButtonRemove";
      this.ButtonRemove.Size = new System.Drawing.Size(100, 33);
      this.ButtonRemove.TabIndex = 6;
      this.ButtonRemove.Text = "Remove";
      this.ButtonRemove.UseVisualStyleBackColor = true;
      this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
      // 
      // TabController
      // 
      this.TabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TabController.Controls.Add(this.TabDeviceInfo);
      this.TabController.Controls.Add(this.TabInput);
      this.TabController.Controls.Add(this.TabFFB);
      this.TabController.Controls.Add(this.TabMisc);
      this.TabController.Location = new System.Drawing.Point(12, 51);
      this.TabController.Name = "TabController";
      this.TabController.SelectedIndex = 0;
      this.TabController.Size = new System.Drawing.Size(1234, 961);
      this.TabController.TabIndex = 7;
      // 
      // TabDeviceInfo
      // 
      this.TabDeviceInfo.Controls.Add(this.LabelDeviceInfo);
      this.TabDeviceInfo.Controls.Add(this.LabelFFBCapabilities);
      this.TabDeviceInfo.Controls.Add(this.LabelCapabilities);
      this.TabDeviceInfo.Location = new System.Drawing.Point(4, 34);
      this.TabDeviceInfo.Name = "TabDeviceInfo";
      this.TabDeviceInfo.Size = new System.Drawing.Size(1226, 923);
      this.TabDeviceInfo.TabIndex = 3;
      this.TabDeviceInfo.Text = "Info";
      this.TabDeviceInfo.UseVisualStyleBackColor = true;
      // 
      // LabelFFBCapabilities
      // 
      this.LabelFFBCapabilities.AutoSize = true;
      this.LabelFFBCapabilities.Location = new System.Drawing.Point(5, 494);
      this.LabelFFBCapabilities.MaximumSize = new System.Drawing.Size(1226, 0);
      this.LabelFFBCapabilities.Name = "LabelFFBCapabilities";
      this.LabelFFBCapabilities.Size = new System.Drawing.Size(234, 25);
      this.LabelFFBCapabilities.TabIndex = 4;
      this.LabelFFBCapabilities.Text = "FFBCapabilities: Attatch First";
      // 
      // LabelCapabilities
      // 
      this.LabelCapabilities.AutoSize = true;
      this.LabelCapabilities.Location = new System.Drawing.Point(5, 165);
      this.LabelCapabilities.MaximumSize = new System.Drawing.Size(1226, 0);
      this.LabelCapabilities.Name = "LabelCapabilities";
      this.LabelCapabilities.Size = new System.Drawing.Size(206, 25);
      this.LabelCapabilities.TabIndex = 4;
      this.LabelCapabilities.Text = "Capabilities: Attatch First";
      // 
      // TabInput
      // 
      this.TabInput.Controls.Add(this.LabelInput);
      this.TabInput.Location = new System.Drawing.Point(4, 34);
      this.TabInput.Name = "TabInput";
      this.TabInput.Padding = new System.Windows.Forms.Padding(3);
      this.TabInput.Size = new System.Drawing.Size(1226, 923);
      this.TabInput.TabIndex = 0;
      this.TabInput.Text = "Input";
      this.TabInput.UseVisualStyleBackColor = true;
      // 
      // LabelInput
      // 
      this.LabelInput.AutoSize = true;
      this.LabelInput.Location = new System.Drawing.Point(5, 5);
      this.LabelInput.Name = "LabelInput";
      this.LabelInput.Size = new System.Drawing.Size(152, 25);
      this.LabelInput.TabIndex = 4;
      this.LabelInput.Text = "Input: Attach First";
      // 
      // TabFFB
      // 
      this.TabFFB.Controls.Add(this.GBSpring);
      this.TabFFB.Controls.Add(this.GBInertia);
      this.TabFFB.Controls.Add(this.GBFriction);
      this.TabFFB.Controls.Add(this.GBDamper);
      this.TabFFB.Controls.Add(this.GBConstantForce);
      this.TabFFB.Location = new System.Drawing.Point(4, 34);
      this.TabFFB.Name = "TabFFB";
      this.TabFFB.Padding = new System.Windows.Forms.Padding(3);
      this.TabFFB.Size = new System.Drawing.Size(1226, 923);
      this.TabFFB.TabIndex = 1;
      this.TabFFB.Text = "FFB";
      this.TabFFB.UseVisualStyleBackColor = true;
      // 
      // GBSpring
      // 
      this.GBSpring.Controls.Add(this.CBSpring);
      this.GBSpring.Controls.Add(this.UDSpringDeadband);
      this.GBSpring.Controls.Add(this.UDSpringSaturation);
      this.GBSpring.Controls.Add(this.UDSpringCoefficient);
      this.GBSpring.Controls.Add(this.UDSpringOffset);
      this.GBSpring.Controls.Add(this.SliderSpringDeadband);
      this.GBSpring.Controls.Add(this.LabelSpringDeadband);
      this.GBSpring.Controls.Add(this.SliderSpringSaturation);
      this.GBSpring.Controls.Add(this.LabelSpringSaturation);
      this.GBSpring.Controls.Add(this.SliderSpringCoefficient);
      this.GBSpring.Controls.Add(this.LabelSpringCoefficient);
      this.GBSpring.Controls.Add(this.SliderSpringOffset);
      this.GBSpring.Controls.Add(this.LabelSpringOffset);
      this.GBSpring.Location = new System.Drawing.Point(6, 80);
      this.GBSpring.Name = "GBSpring";
      this.GBSpring.Size = new System.Drawing.Size(1214, 180);
      this.GBSpring.TabIndex = 0;
      this.GBSpring.TabStop = false;
      this.GBSpring.Tag = "Spring";
      this.GBSpring.Text = "   Spring Force";
      this.GBSpring.Click += new System.EventHandler(this.FFB_GroupBox_Click);
      // 
      // CBSpring
      // 
      this.CBSpring.AutoSize = true;
      this.CBSpring.Location = new System.Drawing.Point(0, 3);
      this.CBSpring.Name = "CBSpring";
      this.CBSpring.Size = new System.Drawing.Size(22, 21);
      this.CBSpring.TabIndex = 1;
      this.CBSpring.Tag = "Spring";
      this.CBSpring.UseVisualStyleBackColor = true;
      this.CBSpring.CheckedChanged += new System.EventHandler(this.FFB_CheckBox_CheckedChanged);
      // 
      // UDSpringDeadband
      // 
      this.UDSpringDeadband.Enabled = false;
      this.UDSpringDeadband.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.UDSpringDeadband.Location = new System.Drawing.Point(1112, 141);
      this.UDSpringDeadband.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.UDSpringDeadband.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
      this.UDSpringDeadband.Name = "UDSpringDeadband";
      this.UDSpringDeadband.Size = new System.Drawing.Size(96, 31);
      this.UDSpringDeadband.TabIndex = 2;
      this.UDSpringDeadband.Tag = "SpringDeadband";
      this.UDSpringDeadband.ValueChanged += new System.EventHandler(this.FFB_UpDown_ValueChanged);
      // 
      // UDSpringSaturation
      // 
      this.UDSpringSaturation.Enabled = false;
      this.UDSpringSaturation.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.UDSpringSaturation.Location = new System.Drawing.Point(1112, 104);
      this.UDSpringSaturation.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.UDSpringSaturation.Name = "UDSpringSaturation";
      this.UDSpringSaturation.Size = new System.Drawing.Size(96, 31);
      this.UDSpringSaturation.TabIndex = 2;
      this.UDSpringSaturation.Tag = "SpringSaturation";
      this.UDSpringSaturation.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
      this.UDSpringSaturation.ValueChanged += new System.EventHandler(this.FFB_UpDown_ValueChanged);
      // 
      // UDSpringCoefficient
      // 
      this.UDSpringCoefficient.Enabled = false;
      this.UDSpringCoefficient.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.UDSpringCoefficient.Location = new System.Drawing.Point(1112, 67);
      this.UDSpringCoefficient.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.UDSpringCoefficient.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
      this.UDSpringCoefficient.Name = "UDSpringCoefficient";
      this.UDSpringCoefficient.Size = new System.Drawing.Size(96, 31);
      this.UDSpringCoefficient.TabIndex = 2;
      this.UDSpringCoefficient.Tag = "SpringCoefficient";
      this.UDSpringCoefficient.ValueChanged += new System.EventHandler(this.FFB_UpDown_ValueChanged);
      // 
      // UDSpringOffset
      // 
      this.UDSpringOffset.Enabled = false;
      this.UDSpringOffset.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.UDSpringOffset.Location = new System.Drawing.Point(1112, 30);
      this.UDSpringOffset.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.UDSpringOffset.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
      this.UDSpringOffset.Name = "UDSpringOffset";
      this.UDSpringOffset.Size = new System.Drawing.Size(96, 31);
      this.UDSpringOffset.TabIndex = 2;
      this.UDSpringOffset.Tag = "SpringOffset";
      this.UDSpringOffset.ValueChanged += new System.EventHandler(this.FFB_UpDown_ValueChanged);
      // 
      // SliderSpringDeadband
      // 
      this.SliderSpringDeadband.AutoSize = false;
      this.SliderSpringDeadband.BackColor = System.Drawing.SystemColors.Control;
      this.SliderSpringDeadband.Enabled = false;
      this.SliderSpringDeadband.LargeChange = 50;
      this.SliderSpringDeadband.Location = new System.Drawing.Point(108, 141);
      this.SliderSpringDeadband.Maximum = 10000;
      this.SliderSpringDeadband.Name = "SliderSpringDeadband";
      this.SliderSpringDeadband.Size = new System.Drawing.Size(998, 31);
      this.SliderSpringDeadband.TabIndex = 0;
      this.SliderSpringDeadband.Tag = "SpringDeadband";
      this.SliderSpringDeadband.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderSpringDeadband.Scroll += new System.EventHandler(this.FFB_Slider_Scroll);
      // 
      // LabelSpringDeadband
      // 
      this.LabelSpringDeadband.AutoSize = true;
      this.LabelSpringDeadband.Location = new System.Drawing.Point(6, 143);
      this.LabelSpringDeadband.Name = "LabelSpringDeadband";
      this.LabelSpringDeadband.Size = new System.Drawing.Size(99, 25);
      this.LabelSpringDeadband.TabIndex = 3;
      this.LabelSpringDeadband.Tag = "SpringDeadband";
      this.LabelSpringDeadband.Text = "Deadband:";
      this.LabelSpringDeadband.Click += new System.EventHandler(this.FFB_Label_Click);
      // 
      // SliderSpringSaturation
      // 
      this.SliderSpringSaturation.AutoSize = false;
      this.SliderSpringSaturation.BackColor = System.Drawing.SystemColors.Control;
      this.SliderSpringSaturation.Enabled = false;
      this.SliderSpringSaturation.LargeChange = 50;
      this.SliderSpringSaturation.Location = new System.Drawing.Point(108, 104);
      this.SliderSpringSaturation.Maximum = 10000;
      this.SliderSpringSaturation.Name = "SliderSpringSaturation";
      this.SliderSpringSaturation.Size = new System.Drawing.Size(998, 31);
      this.SliderSpringSaturation.TabIndex = 0;
      this.SliderSpringSaturation.Tag = "SpringSaturation";
      this.SliderSpringSaturation.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderSpringSaturation.Value = 5000;
      this.SliderSpringSaturation.Scroll += new System.EventHandler(this.FFB_Slider_Scroll);
      // 
      // LabelSpringSaturation
      // 
      this.LabelSpringSaturation.AutoSize = true;
      this.LabelSpringSaturation.Location = new System.Drawing.Point(6, 106);
      this.LabelSpringSaturation.Name = "LabelSpringSaturation";
      this.LabelSpringSaturation.Size = new System.Drawing.Size(97, 25);
      this.LabelSpringSaturation.TabIndex = 3;
      this.LabelSpringSaturation.Tag = "SpringSaturation";
      this.LabelSpringSaturation.Text = "Saturation:";
      this.LabelSpringSaturation.Click += new System.EventHandler(this.FFB_Label_Click);
      // 
      // SliderSpringCoefficient
      // 
      this.SliderSpringCoefficient.AutoSize = false;
      this.SliderSpringCoefficient.BackColor = System.Drawing.SystemColors.Control;
      this.SliderSpringCoefficient.Enabled = false;
      this.SliderSpringCoefficient.LargeChange = 50;
      this.SliderSpringCoefficient.Location = new System.Drawing.Point(108, 67);
      this.SliderSpringCoefficient.Maximum = 10000;
      this.SliderSpringCoefficient.Minimum = -10000;
      this.SliderSpringCoefficient.Name = "SliderSpringCoefficient";
      this.SliderSpringCoefficient.Size = new System.Drawing.Size(998, 31);
      this.SliderSpringCoefficient.TabIndex = 0;
      this.SliderSpringCoefficient.Tag = "SpringCoefficient";
      this.SliderSpringCoefficient.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderSpringCoefficient.Scroll += new System.EventHandler(this.FFB_Slider_Scroll);
      // 
      // LabelSpringCoefficient
      // 
      this.LabelSpringCoefficient.AutoSize = true;
      this.LabelSpringCoefficient.Location = new System.Drawing.Point(6, 69);
      this.LabelSpringCoefficient.Name = "LabelSpringCoefficient";
      this.LabelSpringCoefficient.Size = new System.Drawing.Size(100, 25);
      this.LabelSpringCoefficient.TabIndex = 3;
      this.LabelSpringCoefficient.Tag = "SpringCoefficient";
      this.LabelSpringCoefficient.Text = "Coefficient:";
      this.LabelSpringCoefficient.Click += new System.EventHandler(this.FFB_Label_Click);
      // 
      // SliderSpringOffset
      // 
      this.SliderSpringOffset.AutoSize = false;
      this.SliderSpringOffset.BackColor = System.Drawing.SystemColors.Control;
      this.SliderSpringOffset.Enabled = false;
      this.SliderSpringOffset.LargeChange = 50;
      this.SliderSpringOffset.Location = new System.Drawing.Point(108, 30);
      this.SliderSpringOffset.Maximum = 10000;
      this.SliderSpringOffset.Minimum = -10000;
      this.SliderSpringOffset.Name = "SliderSpringOffset";
      this.SliderSpringOffset.Size = new System.Drawing.Size(998, 31);
      this.SliderSpringOffset.TabIndex = 0;
      this.SliderSpringOffset.Tag = "SpringOffset";
      this.SliderSpringOffset.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderSpringOffset.Scroll += new System.EventHandler(this.FFB_Slider_Scroll);
      // 
      // LabelSpringOffset
      // 
      this.LabelSpringOffset.AutoSize = true;
      this.LabelSpringOffset.Location = new System.Drawing.Point(6, 32);
      this.LabelSpringOffset.Name = "LabelSpringOffset";
      this.LabelSpringOffset.Size = new System.Drawing.Size(65, 25);
      this.LabelSpringOffset.TabIndex = 3;
      this.LabelSpringOffset.Tag = "SpringOffset";
      this.LabelSpringOffset.Text = "Offset:";
      this.LabelSpringOffset.Click += new System.EventHandler(this.FFB_Label_Click);
      // 
      // GBInertia
      // 
      this.GBInertia.Controls.Add(this.CBInertia);
      this.GBInertia.Controls.Add(this.UDInertiaMagnitude);
      this.GBInertia.Controls.Add(this.LabelInertiaMagnitude);
      this.GBInertia.Controls.Add(this.SliderInertiaMagnitude);
      this.GBInertia.Location = new System.Drawing.Point(6, 414);
      this.GBInertia.Name = "GBInertia";
      this.GBInertia.Size = new System.Drawing.Size(1214, 68);
      this.GBInertia.TabIndex = 0;
      this.GBInertia.TabStop = false;
      this.GBInertia.Tag = "Inertia";
      this.GBInertia.Text = "   Inertia";
      this.GBInertia.Click += new System.EventHandler(this.FFB_GroupBox_Click);
      // 
      // CBInertia
      // 
      this.CBInertia.AutoSize = true;
      this.CBInertia.Location = new System.Drawing.Point(0, 3);
      this.CBInertia.Name = "CBInertia";
      this.CBInertia.Size = new System.Drawing.Size(22, 21);
      this.CBInertia.TabIndex = 1;
      this.CBInertia.Tag = "Inertia";
      this.CBInertia.UseVisualStyleBackColor = true;
      this.CBInertia.CheckedChanged += new System.EventHandler(this.FFB_CheckBox_CheckedChanged);
      // 
      // UDInertiaMagnitude
      // 
      this.UDInertiaMagnitude.Enabled = false;
      this.UDInertiaMagnitude.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.UDInertiaMagnitude.Location = new System.Drawing.Point(1112, 30);
      this.UDInertiaMagnitude.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.UDInertiaMagnitude.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
      this.UDInertiaMagnitude.Name = "UDInertiaMagnitude";
      this.UDInertiaMagnitude.Size = new System.Drawing.Size(96, 31);
      this.UDInertiaMagnitude.TabIndex = 2;
      this.UDInertiaMagnitude.Tag = "InertiaMagnitude";
      this.UDInertiaMagnitude.ValueChanged += new System.EventHandler(this.FFB_UpDown_ValueChanged);
      // 
      // LabelInertiaMagnitude
      // 
      this.LabelInertiaMagnitude.AutoSize = true;
      this.LabelInertiaMagnitude.Location = new System.Drawing.Point(6, 32);
      this.LabelInertiaMagnitude.Name = "LabelInertiaMagnitude";
      this.LabelInertiaMagnitude.Size = new System.Drawing.Size(102, 25);
      this.LabelInertiaMagnitude.TabIndex = 3;
      this.LabelInertiaMagnitude.Tag = "InertiaMagnitude";
      this.LabelInertiaMagnitude.Text = "Magnitude:";
      this.LabelInertiaMagnitude.Click += new System.EventHandler(this.FFB_Label_Click);
      // 
      // SliderInertiaMagnitude
      // 
      this.SliderInertiaMagnitude.AutoSize = false;
      this.SliderInertiaMagnitude.BackColor = System.Drawing.SystemColors.Control;
      this.SliderInertiaMagnitude.Enabled = false;
      this.SliderInertiaMagnitude.LargeChange = 50;
      this.SliderInertiaMagnitude.Location = new System.Drawing.Point(108, 30);
      this.SliderInertiaMagnitude.Maximum = 10000;
      this.SliderInertiaMagnitude.Minimum = -10000;
      this.SliderInertiaMagnitude.Name = "SliderInertiaMagnitude";
      this.SliderInertiaMagnitude.Size = new System.Drawing.Size(998, 31);
      this.SliderInertiaMagnitude.TabIndex = 0;
      this.SliderInertiaMagnitude.Tag = "InertiaMagnitude";
      this.SliderInertiaMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderInertiaMagnitude.Scroll += new System.EventHandler(this.FFB_Slider_Scroll);
      // 
      // GBFriction
      // 
      this.GBFriction.Controls.Add(this.UDFrictionMagnitude);
      this.GBFriction.Controls.Add(this.CBFriction);
      this.GBFriction.Controls.Add(this.LabelFrictionMagnitude);
      this.GBFriction.Controls.Add(this.SliderFrictionMagnitude);
      this.GBFriction.Location = new System.Drawing.Point(6, 340);
      this.GBFriction.Name = "GBFriction";
      this.GBFriction.Size = new System.Drawing.Size(1214, 68);
      this.GBFriction.TabIndex = 0;
      this.GBFriction.TabStop = false;
      this.GBFriction.Tag = "Friction";
      this.GBFriction.Text = "   Friction";
      this.GBFriction.Click += new System.EventHandler(this.FFB_GroupBox_Click);
      // 
      // UDFrictionMagnitude
      // 
      this.UDFrictionMagnitude.Enabled = false;
      this.UDFrictionMagnitude.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.UDFrictionMagnitude.Location = new System.Drawing.Point(1112, 30);
      this.UDFrictionMagnitude.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.UDFrictionMagnitude.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
      this.UDFrictionMagnitude.Name = "UDFrictionMagnitude";
      this.UDFrictionMagnitude.Size = new System.Drawing.Size(96, 31);
      this.UDFrictionMagnitude.TabIndex = 2;
      this.UDFrictionMagnitude.Tag = "FrictionMagnitude";
      this.UDFrictionMagnitude.ValueChanged += new System.EventHandler(this.FFB_UpDown_ValueChanged);
      // 
      // CBFriction
      // 
      this.CBFriction.AutoSize = true;
      this.CBFriction.Location = new System.Drawing.Point(0, 3);
      this.CBFriction.Name = "CBFriction";
      this.CBFriction.Size = new System.Drawing.Size(22, 21);
      this.CBFriction.TabIndex = 1;
      this.CBFriction.Tag = "Friction";
      this.CBFriction.UseVisualStyleBackColor = true;
      this.CBFriction.CheckedChanged += new System.EventHandler(this.FFB_CheckBox_CheckedChanged);
      // 
      // LabelFrictionMagnitude
      // 
      this.LabelFrictionMagnitude.AutoSize = true;
      this.LabelFrictionMagnitude.Location = new System.Drawing.Point(6, 32);
      this.LabelFrictionMagnitude.Name = "LabelFrictionMagnitude";
      this.LabelFrictionMagnitude.Size = new System.Drawing.Size(102, 25);
      this.LabelFrictionMagnitude.TabIndex = 3;
      this.LabelFrictionMagnitude.Tag = "FrictionMagnitude";
      this.LabelFrictionMagnitude.Text = "Magnitude:";
      this.LabelFrictionMagnitude.Click += new System.EventHandler(this.FFB_Label_Click);
      // 
      // SliderFrictionMagnitude
      // 
      this.SliderFrictionMagnitude.AutoSize = false;
      this.SliderFrictionMagnitude.BackColor = System.Drawing.SystemColors.Control;
      this.SliderFrictionMagnitude.Enabled = false;
      this.SliderFrictionMagnitude.LargeChange = 50;
      this.SliderFrictionMagnitude.Location = new System.Drawing.Point(108, 30);
      this.SliderFrictionMagnitude.Maximum = 10000;
      this.SliderFrictionMagnitude.Minimum = -10000;
      this.SliderFrictionMagnitude.Name = "SliderFrictionMagnitude";
      this.SliderFrictionMagnitude.Size = new System.Drawing.Size(998, 31);
      this.SliderFrictionMagnitude.TabIndex = 0;
      this.SliderFrictionMagnitude.Tag = "FrictionMagnitude";
      this.SliderFrictionMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderFrictionMagnitude.Scroll += new System.EventHandler(this.FFB_Slider_Scroll);
      // 
      // GBDamper
      // 
      this.GBDamper.Controls.Add(this.UDDamperMagnitude);
      this.GBDamper.Controls.Add(this.LabelDamperMagnitude);
      this.GBDamper.Controls.Add(this.CBDamper);
      this.GBDamper.Controls.Add(this.SliderDamperMagnitude);
      this.GBDamper.Location = new System.Drawing.Point(6, 266);
      this.GBDamper.Name = "GBDamper";
      this.GBDamper.Size = new System.Drawing.Size(1214, 68);
      this.GBDamper.TabIndex = 0;
      this.GBDamper.TabStop = false;
      this.GBDamper.Tag = "Damper";
      this.GBDamper.Text = "   Damper";
      this.GBDamper.Click += new System.EventHandler(this.FFB_GroupBox_Click);
      // 
      // UDDamperMagnitude
      // 
      this.UDDamperMagnitude.Enabled = false;
      this.UDDamperMagnitude.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.UDDamperMagnitude.Location = new System.Drawing.Point(1112, 30);
      this.UDDamperMagnitude.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.UDDamperMagnitude.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
      this.UDDamperMagnitude.Name = "UDDamperMagnitude";
      this.UDDamperMagnitude.Size = new System.Drawing.Size(96, 31);
      this.UDDamperMagnitude.TabIndex = 2;
      this.UDDamperMagnitude.Tag = "DamperMagnitude";
      this.UDDamperMagnitude.ValueChanged += new System.EventHandler(this.FFB_UpDown_ValueChanged);
      // 
      // LabelDamperMagnitude
      // 
      this.LabelDamperMagnitude.AutoSize = true;
      this.LabelDamperMagnitude.Location = new System.Drawing.Point(6, 32);
      this.LabelDamperMagnitude.Name = "LabelDamperMagnitude";
      this.LabelDamperMagnitude.Size = new System.Drawing.Size(102, 25);
      this.LabelDamperMagnitude.TabIndex = 3;
      this.LabelDamperMagnitude.Tag = "DamperMagnitude";
      this.LabelDamperMagnitude.Text = "Magnitude:";
      this.LabelDamperMagnitude.Click += new System.EventHandler(this.FFB_Label_Click);
      // 
      // CBDamper
      // 
      this.CBDamper.AutoSize = true;
      this.CBDamper.Location = new System.Drawing.Point(0, 3);
      this.CBDamper.Name = "CBDamper";
      this.CBDamper.Size = new System.Drawing.Size(22, 21);
      this.CBDamper.TabIndex = 1;
      this.CBDamper.Tag = "Damper";
      this.CBDamper.UseVisualStyleBackColor = true;
      this.CBDamper.CheckedChanged += new System.EventHandler(this.FFB_CheckBox_CheckedChanged);
      // 
      // SliderDamperMagnitude
      // 
      this.SliderDamperMagnitude.AutoSize = false;
      this.SliderDamperMagnitude.BackColor = System.Drawing.SystemColors.Control;
      this.SliderDamperMagnitude.Enabled = false;
      this.SliderDamperMagnitude.LargeChange = 50;
      this.SliderDamperMagnitude.Location = new System.Drawing.Point(108, 30);
      this.SliderDamperMagnitude.Maximum = 10000;
      this.SliderDamperMagnitude.Minimum = -10000;
      this.SliderDamperMagnitude.Name = "SliderDamperMagnitude";
      this.SliderDamperMagnitude.Size = new System.Drawing.Size(998, 31);
      this.SliderDamperMagnitude.TabIndex = 0;
      this.SliderDamperMagnitude.Tag = "DamperMagnitude";
      this.SliderDamperMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderDamperMagnitude.Scroll += new System.EventHandler(this.FFB_Slider_Scroll);
      // 
      // GBConstantForce
      // 
      this.GBConstantForce.Controls.Add(this.CBConstantForce);
      this.GBConstantForce.Controls.Add(this.UDConstantForceMagnitude);
      this.GBConstantForce.Controls.Add(this.LabelConstantForceMagnitude);
      this.GBConstantForce.Controls.Add(this.SliderConstantForceMagnitude);
      this.GBConstantForce.Location = new System.Drawing.Point(6, 6);
      this.GBConstantForce.Name = "GBConstantForce";
      this.GBConstantForce.Size = new System.Drawing.Size(1214, 68);
      this.GBConstantForce.TabIndex = 0;
      this.GBConstantForce.TabStop = false;
      this.GBConstantForce.Tag = "ConstantForce";
      this.GBConstantForce.Text = "   Constant Force";
      this.GBConstantForce.Click += new System.EventHandler(this.FFB_GroupBox_Click);
      // 
      // CBConstantForce
      // 
      this.CBConstantForce.AutoSize = true;
      this.CBConstantForce.Location = new System.Drawing.Point(0, 3);
      this.CBConstantForce.Name = "CBConstantForce";
      this.CBConstantForce.Size = new System.Drawing.Size(22, 21);
      this.CBConstantForce.TabIndex = 1;
      this.CBConstantForce.Tag = "ConstantForce";
      this.CBConstantForce.UseVisualStyleBackColor = true;
      this.CBConstantForce.CheckedChanged += new System.EventHandler(this.FFB_CheckBox_CheckedChanged);
      // 
      // UDConstantForceMagnitude
      // 
      this.UDConstantForceMagnitude.Enabled = false;
      this.UDConstantForceMagnitude.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.UDConstantForceMagnitude.Location = new System.Drawing.Point(1112, 30);
      this.UDConstantForceMagnitude.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.UDConstantForceMagnitude.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
      this.UDConstantForceMagnitude.Name = "UDConstantForceMagnitude";
      this.UDConstantForceMagnitude.Size = new System.Drawing.Size(96, 31);
      this.UDConstantForceMagnitude.TabIndex = 2;
      this.UDConstantForceMagnitude.Tag = "ConstantForceMagnitude";
      this.UDConstantForceMagnitude.ValueChanged += new System.EventHandler(this.FFB_UpDown_ValueChanged);
      // 
      // LabelConstantForceMagnitude
      // 
      this.LabelConstantForceMagnitude.AutoSize = true;
      this.LabelConstantForceMagnitude.Location = new System.Drawing.Point(6, 32);
      this.LabelConstantForceMagnitude.Name = "LabelConstantForceMagnitude";
      this.LabelConstantForceMagnitude.Size = new System.Drawing.Size(102, 25);
      this.LabelConstantForceMagnitude.TabIndex = 3;
      this.LabelConstantForceMagnitude.Tag = "ConstantForceMagnitude";
      this.LabelConstantForceMagnitude.Text = "Magnitude:";
      this.LabelConstantForceMagnitude.Click += new System.EventHandler(this.FFB_Label_Click);
      // 
      // SliderConstantForceMagnitude
      // 
      this.SliderConstantForceMagnitude.AutoSize = false;
      this.SliderConstantForceMagnitude.BackColor = System.Drawing.SystemColors.Control;
      this.SliderConstantForceMagnitude.Enabled = false;
      this.SliderConstantForceMagnitude.LargeChange = 50;
      this.SliderConstantForceMagnitude.Location = new System.Drawing.Point(108, 30);
      this.SliderConstantForceMagnitude.Maximum = 10000;
      this.SliderConstantForceMagnitude.Minimum = -10000;
      this.SliderConstantForceMagnitude.Name = "SliderConstantForceMagnitude";
      this.SliderConstantForceMagnitude.Size = new System.Drawing.Size(998, 31);
      this.SliderConstantForceMagnitude.TabIndex = 0;
      this.SliderConstantForceMagnitude.Tag = "ConstantForceMagnitude";
      this.SliderConstantForceMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderConstantForceMagnitude.Scroll += new System.EventHandler(this.FFB_Slider_Scroll);
      // 
      // TabMisc
      // 
      this.TabMisc.Controls.Add(this.LabelDebug);
      this.TabMisc.Controls.Add(this.ButtonDebug);
      this.TabMisc.Location = new System.Drawing.Point(4, 34);
      this.TabMisc.Name = "TabMisc";
      this.TabMisc.Padding = new System.Windows.Forms.Padding(3);
      this.TabMisc.Size = new System.Drawing.Size(1226, 923);
      this.TabMisc.TabIndex = 4;
      this.TabMisc.Text = "Misc";
      this.TabMisc.UseVisualStyleBackColor = true;
      // 
      // LabelDebug
      // 
      this.LabelDebug.AutoSize = true;
      this.LabelDebug.Location = new System.Drawing.Point(6, 3);
      this.LabelDebug.Name = "LabelDebug";
      this.LabelDebug.Size = new System.Drawing.Size(112, 25);
      this.LabelDebug.TabIndex = 1;
      this.LabelDebug.Text = "Debug Stuff:";
      // 
      // ButtonDebug
      // 
      this.ButtonDebug.Location = new System.Drawing.Point(1077, 6);
      this.ButtonDebug.Name = "ButtonDebug";
      this.ButtonDebug.Size = new System.Drawing.Size(143, 55);
      this.ButtonDebug.TabIndex = 0;
      this.ButtonDebug.Text = "Debug";
      this.ButtonDebug.UseVisualStyleBackColor = true;
      this.ButtonDebug.Click += new System.EventHandler(this.ButtonDebug_Click);
      // 
      // Form1
      // 
      this.ClientSize = new System.Drawing.Size(1258, 1024);
      this.Controls.Add(this.TabController);
      this.Controls.Add(this.ButtonRemove);
      this.Controls.Add(this.ButtonAttatch);
      this.Controls.Add(this.ButtonEnumerateDevices);
      this.Controls.Add(this.ComboBoxDevices);
      this.Name = "Form1";
      this.Text = "Direct Input Explorer";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.TabController.ResumeLayout(false);
      this.TabDeviceInfo.ResumeLayout(false);
      this.TabDeviceInfo.PerformLayout();
      this.TabInput.ResumeLayout(false);
      this.TabInput.PerformLayout();
      this.TabFFB.ResumeLayout(false);
      this.GBSpring.ResumeLayout(false);
      this.GBSpring.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringDeadband)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringSaturation)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringCoefficient)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringOffset)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringDeadband)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringSaturation)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringCoefficient)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringOffset)).EndInit();
      this.GBInertia.ResumeLayout(false);
      this.GBInertia.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDInertiaMagnitude)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderInertiaMagnitude)).EndInit();
      this.GBFriction.ResumeLayout(false);
      this.GBFriction.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDFrictionMagnitude)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderFrictionMagnitude)).EndInit();
      this.GBDamper.ResumeLayout(false);
      this.GBDamper.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDDamperMagnitude)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderDamperMagnitude)).EndInit();
      this.GBConstantForce.ResumeLayout(false);
      this.GBConstantForce.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDConstantForceMagnitude)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderConstantForceMagnitude)).EndInit();
      this.TabMisc.ResumeLayout(false);
      this.TabMisc.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.ComboBox ComboBoxDevices;
    private System.Windows.Forms.Button ButtonEnumerateDevices;
    private System.Windows.Forms.Label LabelDeviceInfo;
    private System.Windows.Forms.Timer TimerPoll;
    private System.Windows.Forms.Button ButtonAttatch;
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
  }
}

