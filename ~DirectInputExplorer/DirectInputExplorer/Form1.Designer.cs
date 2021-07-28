
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
      this.LabelCapabilities = new System.Windows.Forms.Label();
      this.TabInput = new System.Windows.Forms.TabPage();
      this.LabelInput = new System.Windows.Forms.Label();
      this.TabFFB = new System.Windows.Forms.TabPage();
      this.GroupSpring = new System.Windows.Forms.GroupBox();
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
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.CBInertia = new System.Windows.Forms.CheckBox();
      this.UDInertiaMagnitude = new System.Windows.Forms.NumericUpDown();
      this.LabelInertiaMagnitude = new System.Windows.Forms.Label();
      this.SliderInertiaMagnitude = new System.Windows.Forms.TrackBar();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.UDFrictionMagnitude = new System.Windows.Forms.NumericUpDown();
      this.CBFriction = new System.Windows.Forms.CheckBox();
      this.LabelFrictionMagnitude = new System.Windows.Forms.Label();
      this.SliderFrictionMagnitude = new System.Windows.Forms.TrackBar();
      this.GroupDamper = new System.Windows.Forms.GroupBox();
      this.UDDamperMagnitude = new System.Windows.Forms.NumericUpDown();
      this.LabelDamperMagnitude = new System.Windows.Forms.Label();
      this.CBDamper = new System.Windows.Forms.CheckBox();
      this.SliderDamperMagnitude = new System.Windows.Forms.TrackBar();
      this.GroupConstantForce = new System.Windows.Forms.GroupBox();
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
      this.GroupSpring.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringDeadband)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringSaturation)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringCoefficient)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringOffset)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringDeadband)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringSaturation)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringCoefficient)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringOffset)).BeginInit();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDInertiaMagnitude)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderInertiaMagnitude)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDFrictionMagnitude)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderFrictionMagnitude)).BeginInit();
      this.GroupDamper.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDDamperMagnitude)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderDamperMagnitude)).BeginInit();
      this.GroupConstantForce.SuspendLayout();
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
      this.TabDeviceInfo.Controls.Add(this.LabelCapabilities);
      this.TabDeviceInfo.Location = new System.Drawing.Point(4, 34);
      this.TabDeviceInfo.Name = "TabDeviceInfo";
      this.TabDeviceInfo.Size = new System.Drawing.Size(1226, 923);
      this.TabDeviceInfo.TabIndex = 3;
      this.TabDeviceInfo.Text = "Info";
      this.TabDeviceInfo.UseVisualStyleBackColor = true;
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
      this.TabFFB.Controls.Add(this.GroupSpring);
      this.TabFFB.Controls.Add(this.groupBox2);
      this.TabFFB.Controls.Add(this.groupBox1);
      this.TabFFB.Controls.Add(this.GroupDamper);
      this.TabFFB.Controls.Add(this.GroupConstantForce);
      this.TabFFB.Location = new System.Drawing.Point(4, 34);
      this.TabFFB.Name = "TabFFB";
      this.TabFFB.Padding = new System.Windows.Forms.Padding(3);
      this.TabFFB.Size = new System.Drawing.Size(1226, 923);
      this.TabFFB.TabIndex = 1;
      this.TabFFB.Text = "FFB";
      this.TabFFB.UseVisualStyleBackColor = true;
      // 
      // GroupSpring
      // 
      this.GroupSpring.Controls.Add(this.CBSpring);
      this.GroupSpring.Controls.Add(this.UDSpringDeadband);
      this.GroupSpring.Controls.Add(this.UDSpringSaturation);
      this.GroupSpring.Controls.Add(this.UDSpringCoefficient);
      this.GroupSpring.Controls.Add(this.UDSpringOffset);
      this.GroupSpring.Controls.Add(this.SliderSpringDeadband);
      this.GroupSpring.Controls.Add(this.LabelSpringDeadband);
      this.GroupSpring.Controls.Add(this.SliderSpringSaturation);
      this.GroupSpring.Controls.Add(this.LabelSpringSaturation);
      this.GroupSpring.Controls.Add(this.SliderSpringCoefficient);
      this.GroupSpring.Controls.Add(this.LabelSpringCoefficient);
      this.GroupSpring.Controls.Add(this.SliderSpringOffset);
      this.GroupSpring.Controls.Add(this.LabelSpringOffset);
      this.GroupSpring.Location = new System.Drawing.Point(6, 80);
      this.GroupSpring.Name = "GroupSpring";
      this.GroupSpring.Size = new System.Drawing.Size(1214, 180);
      this.GroupSpring.TabIndex = 0;
      this.GroupSpring.TabStop = false;
      this.GroupSpring.Text = "   Spring Force";
      // 
      // CBSpring
      // 
      this.CBSpring.AutoSize = true;
      this.CBSpring.Location = new System.Drawing.Point(0, 3);
      this.CBSpring.Name = "CBSpring";
      this.CBSpring.Size = new System.Drawing.Size(22, 21);
      this.CBSpring.TabIndex = 1;
      this.CBSpring.UseVisualStyleBackColor = true;
      // 
      // UDSpringDeadband
      // 
      this.UDSpringDeadband.Enabled = false;
      this.UDSpringDeadband.Location = new System.Drawing.Point(1112, 141);
      this.UDSpringDeadband.Name = "UDSpringDeadband";
      this.UDSpringDeadband.Size = new System.Drawing.Size(96, 31);
      this.UDSpringDeadband.TabIndex = 2;
      // 
      // UDSpringSaturation
      // 
      this.UDSpringSaturation.Enabled = false;
      this.UDSpringSaturation.Location = new System.Drawing.Point(1112, 104);
      this.UDSpringSaturation.Name = "UDSpringSaturation";
      this.UDSpringSaturation.Size = new System.Drawing.Size(96, 31);
      this.UDSpringSaturation.TabIndex = 2;
      // 
      // UDSpringCoefficient
      // 
      this.UDSpringCoefficient.Enabled = false;
      this.UDSpringCoefficient.Location = new System.Drawing.Point(1112, 67);
      this.UDSpringCoefficient.Name = "UDSpringCoefficient";
      this.UDSpringCoefficient.Size = new System.Drawing.Size(96, 31);
      this.UDSpringCoefficient.TabIndex = 2;
      // 
      // UDSpringOffset
      // 
      this.UDSpringOffset.Enabled = false;
      this.UDSpringOffset.Location = new System.Drawing.Point(1112, 30);
      this.UDSpringOffset.Name = "UDSpringOffset";
      this.UDSpringOffset.Size = new System.Drawing.Size(96, 31);
      this.UDSpringOffset.TabIndex = 2;
      // 
      // SliderSpringDeadband
      // 
      this.SliderSpringDeadband.AutoSize = false;
      this.SliderSpringDeadband.BackColor = System.Drawing.SystemColors.Control;
      this.SliderSpringDeadband.Enabled = false;
      this.SliderSpringDeadband.Location = new System.Drawing.Point(108, 141);
      this.SliderSpringDeadband.Maximum = 10000;
      this.SliderSpringDeadband.Minimum = -10000;
      this.SliderSpringDeadband.Name = "SliderSpringDeadband";
      this.SliderSpringDeadband.Size = new System.Drawing.Size(998, 31);
      this.SliderSpringDeadband.TabIndex = 0;
      this.SliderSpringDeadband.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderSpringDeadband.Scroll += new System.EventHandler(this.SliderConstantForce_Scroll);
      // 
      // LabelSpringDeadband
      // 
      this.LabelSpringDeadband.AutoSize = true;
      this.LabelSpringDeadband.Location = new System.Drawing.Point(6, 143);
      this.LabelSpringDeadband.Name = "LabelSpringDeadband";
      this.LabelSpringDeadband.Size = new System.Drawing.Size(99, 25);
      this.LabelSpringDeadband.TabIndex = 3;
      this.LabelSpringDeadband.Text = "Deadband:";
      // 
      // SliderSpringSaturation
      // 
      this.SliderSpringSaturation.AutoSize = false;
      this.SliderSpringSaturation.BackColor = System.Drawing.SystemColors.Control;
      this.SliderSpringSaturation.Enabled = false;
      this.SliderSpringSaturation.Location = new System.Drawing.Point(108, 104);
      this.SliderSpringSaturation.Maximum = 10000;
      this.SliderSpringSaturation.Minimum = -10000;
      this.SliderSpringSaturation.Name = "SliderSpringSaturation";
      this.SliderSpringSaturation.Size = new System.Drawing.Size(998, 31);
      this.SliderSpringSaturation.TabIndex = 0;
      this.SliderSpringSaturation.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderSpringSaturation.Scroll += new System.EventHandler(this.SliderConstantForce_Scroll);
      // 
      // LabelSpringSaturation
      // 
      this.LabelSpringSaturation.AutoSize = true;
      this.LabelSpringSaturation.Location = new System.Drawing.Point(6, 106);
      this.LabelSpringSaturation.Name = "LabelSpringSaturation";
      this.LabelSpringSaturation.Size = new System.Drawing.Size(97, 25);
      this.LabelSpringSaturation.TabIndex = 3;
      this.LabelSpringSaturation.Text = "Saturation:";
      // 
      // SliderSpringCoefficient
      // 
      this.SliderSpringCoefficient.AutoSize = false;
      this.SliderSpringCoefficient.BackColor = System.Drawing.SystemColors.Control;
      this.SliderSpringCoefficient.Enabled = false;
      this.SliderSpringCoefficient.Location = new System.Drawing.Point(108, 67);
      this.SliderSpringCoefficient.Maximum = 10000;
      this.SliderSpringCoefficient.Minimum = -10000;
      this.SliderSpringCoefficient.Name = "SliderSpringCoefficient";
      this.SliderSpringCoefficient.Size = new System.Drawing.Size(998, 31);
      this.SliderSpringCoefficient.TabIndex = 0;
      this.SliderSpringCoefficient.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderSpringCoefficient.Scroll += new System.EventHandler(this.SliderConstantForce_Scroll);
      // 
      // LabelSpringCoefficient
      // 
      this.LabelSpringCoefficient.AutoSize = true;
      this.LabelSpringCoefficient.Location = new System.Drawing.Point(6, 69);
      this.LabelSpringCoefficient.Name = "LabelSpringCoefficient";
      this.LabelSpringCoefficient.Size = new System.Drawing.Size(100, 25);
      this.LabelSpringCoefficient.TabIndex = 3;
      this.LabelSpringCoefficient.Text = "Coefficient:";
      // 
      // SliderSpringOffset
      // 
      this.SliderSpringOffset.AutoSize = false;
      this.SliderSpringOffset.BackColor = System.Drawing.SystemColors.Control;
      this.SliderSpringOffset.Enabled = false;
      this.SliderSpringOffset.Location = new System.Drawing.Point(108, 30);
      this.SliderSpringOffset.Maximum = 10000;
      this.SliderSpringOffset.Minimum = -10000;
      this.SliderSpringOffset.Name = "SliderSpringOffset";
      this.SliderSpringOffset.Size = new System.Drawing.Size(998, 31);
      this.SliderSpringOffset.TabIndex = 0;
      this.SliderSpringOffset.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderSpringOffset.Scroll += new System.EventHandler(this.SliderConstantForce_Scroll);
      // 
      // LabelSpringOffset
      // 
      this.LabelSpringOffset.AutoSize = true;
      this.LabelSpringOffset.Location = new System.Drawing.Point(6, 32);
      this.LabelSpringOffset.Name = "LabelSpringOffset";
      this.LabelSpringOffset.Size = new System.Drawing.Size(65, 25);
      this.LabelSpringOffset.TabIndex = 3;
      this.LabelSpringOffset.Text = "Offset:";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.CBInertia);
      this.groupBox2.Controls.Add(this.UDInertiaMagnitude);
      this.groupBox2.Controls.Add(this.LabelInertiaMagnitude);
      this.groupBox2.Controls.Add(this.SliderInertiaMagnitude);
      this.groupBox2.Location = new System.Drawing.Point(6, 414);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(1214, 68);
      this.groupBox2.TabIndex = 0;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "   Inertia";
      // 
      // CBInertia
      // 
      this.CBInertia.AutoSize = true;
      this.CBInertia.Location = new System.Drawing.Point(0, 3);
      this.CBInertia.Name = "CBInertia";
      this.CBInertia.Size = new System.Drawing.Size(22, 21);
      this.CBInertia.TabIndex = 1;
      this.CBInertia.UseVisualStyleBackColor = true;
      // 
      // UDInertiaMagnitude
      // 
      this.UDInertiaMagnitude.Enabled = false;
      this.UDInertiaMagnitude.Location = new System.Drawing.Point(1112, 30);
      this.UDInertiaMagnitude.Name = "UDInertiaMagnitude";
      this.UDInertiaMagnitude.Size = new System.Drawing.Size(96, 31);
      this.UDInertiaMagnitude.TabIndex = 2;
      // 
      // LabelInertiaMagnitude
      // 
      this.LabelInertiaMagnitude.AutoSize = true;
      this.LabelInertiaMagnitude.Location = new System.Drawing.Point(6, 32);
      this.LabelInertiaMagnitude.Name = "LabelInertiaMagnitude";
      this.LabelInertiaMagnitude.Size = new System.Drawing.Size(102, 25);
      this.LabelInertiaMagnitude.TabIndex = 3;
      this.LabelInertiaMagnitude.Text = "Magnitude:";
      // 
      // SliderInertiaMagnitude
      // 
      this.SliderInertiaMagnitude.AutoSize = false;
      this.SliderInertiaMagnitude.BackColor = System.Drawing.SystemColors.Control;
      this.SliderInertiaMagnitude.Enabled = false;
      this.SliderInertiaMagnitude.Location = new System.Drawing.Point(108, 30);
      this.SliderInertiaMagnitude.Maximum = 10000;
      this.SliderInertiaMagnitude.Minimum = -10000;
      this.SliderInertiaMagnitude.Name = "SliderInertiaMagnitude";
      this.SliderInertiaMagnitude.Size = new System.Drawing.Size(998, 31);
      this.SliderInertiaMagnitude.TabIndex = 0;
      this.SliderInertiaMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderInertiaMagnitude.Scroll += new System.EventHandler(this.SliderConstantForce_Scroll);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.UDFrictionMagnitude);
      this.groupBox1.Controls.Add(this.CBFriction);
      this.groupBox1.Controls.Add(this.LabelFrictionMagnitude);
      this.groupBox1.Controls.Add(this.SliderFrictionMagnitude);
      this.groupBox1.Location = new System.Drawing.Point(6, 340);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(1214, 68);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "   Friction";
      // 
      // UDFrictionMagnitude
      // 
      this.UDFrictionMagnitude.Enabled = false;
      this.UDFrictionMagnitude.Location = new System.Drawing.Point(1112, 30);
      this.UDFrictionMagnitude.Name = "UDFrictionMagnitude";
      this.UDFrictionMagnitude.Size = new System.Drawing.Size(96, 31);
      this.UDFrictionMagnitude.TabIndex = 2;
      // 
      // CBFriction
      // 
      this.CBFriction.AutoSize = true;
      this.CBFriction.Location = new System.Drawing.Point(0, 3);
      this.CBFriction.Name = "CBFriction";
      this.CBFriction.Size = new System.Drawing.Size(22, 21);
      this.CBFriction.TabIndex = 1;
      this.CBFriction.UseVisualStyleBackColor = true;
      // 
      // LabelFrictionMagnitude
      // 
      this.LabelFrictionMagnitude.AutoSize = true;
      this.LabelFrictionMagnitude.Location = new System.Drawing.Point(6, 32);
      this.LabelFrictionMagnitude.Name = "LabelFrictionMagnitude";
      this.LabelFrictionMagnitude.Size = new System.Drawing.Size(102, 25);
      this.LabelFrictionMagnitude.TabIndex = 3;
      this.LabelFrictionMagnitude.Text = "Magnitude:";
      // 
      // SliderFrictionMagnitude
      // 
      this.SliderFrictionMagnitude.AutoSize = false;
      this.SliderFrictionMagnitude.BackColor = System.Drawing.SystemColors.Control;
      this.SliderFrictionMagnitude.Enabled = false;
      this.SliderFrictionMagnitude.Location = new System.Drawing.Point(108, 30);
      this.SliderFrictionMagnitude.Maximum = 10000;
      this.SliderFrictionMagnitude.Minimum = -10000;
      this.SliderFrictionMagnitude.Name = "SliderFrictionMagnitude";
      this.SliderFrictionMagnitude.Size = new System.Drawing.Size(998, 31);
      this.SliderFrictionMagnitude.TabIndex = 0;
      this.SliderFrictionMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderFrictionMagnitude.Scroll += new System.EventHandler(this.SliderConstantForce_Scroll);
      // 
      // GroupDamper
      // 
      this.GroupDamper.Controls.Add(this.UDDamperMagnitude);
      this.GroupDamper.Controls.Add(this.LabelDamperMagnitude);
      this.GroupDamper.Controls.Add(this.CBDamper);
      this.GroupDamper.Controls.Add(this.SliderDamperMagnitude);
      this.GroupDamper.Location = new System.Drawing.Point(6, 266);
      this.GroupDamper.Name = "GroupDamper";
      this.GroupDamper.Size = new System.Drawing.Size(1214, 68);
      this.GroupDamper.TabIndex = 0;
      this.GroupDamper.TabStop = false;
      this.GroupDamper.Text = "   Damper";
      // 
      // UDDamperMagnitude
      // 
      this.UDDamperMagnitude.Enabled = false;
      this.UDDamperMagnitude.Location = new System.Drawing.Point(1112, 30);
      this.UDDamperMagnitude.Name = "UDDamperMagnitude";
      this.UDDamperMagnitude.Size = new System.Drawing.Size(96, 31);
      this.UDDamperMagnitude.TabIndex = 2;
      // 
      // LabelDamperMagnitude
      // 
      this.LabelDamperMagnitude.AutoSize = true;
      this.LabelDamperMagnitude.Location = new System.Drawing.Point(6, 32);
      this.LabelDamperMagnitude.Name = "LabelDamperMagnitude";
      this.LabelDamperMagnitude.Size = new System.Drawing.Size(102, 25);
      this.LabelDamperMagnitude.TabIndex = 3;
      this.LabelDamperMagnitude.Text = "Magnitude:";
      // 
      // CBDamper
      // 
      this.CBDamper.AutoSize = true;
      this.CBDamper.Location = new System.Drawing.Point(0, 3);
      this.CBDamper.Name = "CBDamper";
      this.CBDamper.Size = new System.Drawing.Size(22, 21);
      this.CBDamper.TabIndex = 1;
      this.CBDamper.UseVisualStyleBackColor = true;
      // 
      // SliderDamperMagnitude
      // 
      this.SliderDamperMagnitude.AutoSize = false;
      this.SliderDamperMagnitude.BackColor = System.Drawing.SystemColors.Control;
      this.SliderDamperMagnitude.Enabled = false;
      this.SliderDamperMagnitude.Location = new System.Drawing.Point(108, 30);
      this.SliderDamperMagnitude.Maximum = 10000;
      this.SliderDamperMagnitude.Minimum = -10000;
      this.SliderDamperMagnitude.Name = "SliderDamperMagnitude";
      this.SliderDamperMagnitude.Size = new System.Drawing.Size(998, 31);
      this.SliderDamperMagnitude.TabIndex = 0;
      this.SliderDamperMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderDamperMagnitude.Scroll += new System.EventHandler(this.SliderConstantForce_Scroll);
      // 
      // GroupConstantForce
      // 
      this.GroupConstantForce.Controls.Add(this.CBConstantForce);
      this.GroupConstantForce.Controls.Add(this.UDConstantForceMagnitude);
      this.GroupConstantForce.Controls.Add(this.LabelConstantForceMagnitude);
      this.GroupConstantForce.Controls.Add(this.SliderConstantForceMagnitude);
      this.GroupConstantForce.Location = new System.Drawing.Point(6, 6);
      this.GroupConstantForce.Name = "GroupConstantForce";
      this.GroupConstantForce.Size = new System.Drawing.Size(1214, 68);
      this.GroupConstantForce.TabIndex = 0;
      this.GroupConstantForce.TabStop = false;
      this.GroupConstantForce.Text = "   Constant Force";
      // 
      // CBConstantForce
      // 
      this.CBConstantForce.AutoSize = true;
      this.CBConstantForce.Location = new System.Drawing.Point(0, 3);
      this.CBConstantForce.Name = "CBConstantForce";
      this.CBConstantForce.Size = new System.Drawing.Size(22, 21);
      this.CBConstantForce.TabIndex = 1;
      this.CBConstantForce.UseVisualStyleBackColor = true;
      // 
      // UDConstantForceMagnitude
      // 
      this.UDConstantForceMagnitude.Enabled = false;
      this.UDConstantForceMagnitude.Location = new System.Drawing.Point(1112, 30);
      this.UDConstantForceMagnitude.Name = "UDConstantForceMagnitude";
      this.UDConstantForceMagnitude.Size = new System.Drawing.Size(96, 31);
      this.UDConstantForceMagnitude.TabIndex = 2;
      // 
      // LabelConstantForceMagnitude
      // 
      this.LabelConstantForceMagnitude.AutoSize = true;
      this.LabelConstantForceMagnitude.Location = new System.Drawing.Point(6, 32);
      this.LabelConstantForceMagnitude.Name = "LabelConstantForceMagnitude";
      this.LabelConstantForceMagnitude.Size = new System.Drawing.Size(102, 25);
      this.LabelConstantForceMagnitude.TabIndex = 3;
      this.LabelConstantForceMagnitude.Text = "Magnitude:";
      // 
      // SliderConstantForceMagnitude
      // 
      this.SliderConstantForceMagnitude.AutoSize = false;
      this.SliderConstantForceMagnitude.BackColor = System.Drawing.SystemColors.Control;
      this.SliderConstantForceMagnitude.Enabled = false;
      this.SliderConstantForceMagnitude.Location = new System.Drawing.Point(108, 30);
      this.SliderConstantForceMagnitude.Maximum = 10000;
      this.SliderConstantForceMagnitude.Minimum = -10000;
      this.SliderConstantForceMagnitude.Name = "SliderConstantForceMagnitude";
      this.SliderConstantForceMagnitude.Size = new System.Drawing.Size(998, 31);
      this.SliderConstantForceMagnitude.TabIndex = 0;
      this.SliderConstantForceMagnitude.TickStyle = System.Windows.Forms.TickStyle.None;
      this.SliderConstantForceMagnitude.Scroll += new System.EventHandler(this.SliderConstantForce_Scroll);
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
      this.Load += new System.EventHandler(this.Form1_Load);
      this.TabController.ResumeLayout(false);
      this.TabDeviceInfo.ResumeLayout(false);
      this.TabDeviceInfo.PerformLayout();
      this.TabInput.ResumeLayout(false);
      this.TabInput.PerformLayout();
      this.TabFFB.ResumeLayout(false);
      this.GroupSpring.ResumeLayout(false);
      this.GroupSpring.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringDeadband)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringSaturation)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringCoefficient)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.UDSpringOffset)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringDeadband)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringSaturation)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringCoefficient)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderSpringOffset)).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDInertiaMagnitude)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderInertiaMagnitude)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDFrictionMagnitude)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderFrictionMagnitude)).EndInit();
      this.GroupDamper.ResumeLayout(false);
      this.GroupDamper.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.UDDamperMagnitude)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.SliderDamperMagnitude)).EndInit();
      this.GroupConstantForce.ResumeLayout(false);
      this.GroupConstantForce.PerformLayout();
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
    private System.Windows.Forms.GroupBox GroupConstantForce;
    private System.Windows.Forms.TrackBar SliderConstantForceMagnitude;
    private System.Windows.Forms.GroupBox GroupSpring;
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
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.NumericUpDown UDInertiaMagnitude;
    private System.Windows.Forms.Label LabelInertiaMagnitude;
    private System.Windows.Forms.TrackBar SliderInertiaMagnitude;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.NumericUpDown UDFrictionMagnitude;
    private System.Windows.Forms.Label LabelFrictionMagnitude;
    private System.Windows.Forms.TrackBar SliderFrictionMagnitude;
    private System.Windows.Forms.GroupBox GroupDamper;
    private System.Windows.Forms.NumericUpDown UDDamperMagnitude;
    private System.Windows.Forms.Label LabelDamperMagnitude;
    private System.Windows.Forms.TrackBar SliderDamperMagnitude;
    private System.Windows.Forms.CheckBox CBConstantForce;
    private System.Windows.Forms.CheckBox CBSpring;
    private System.Windows.Forms.CheckBox CBInertia;
    private System.Windows.Forms.CheckBox CBFriction;
    private System.Windows.Forms.CheckBox CBDamper;
  }
}

