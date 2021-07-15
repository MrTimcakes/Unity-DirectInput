
namespace DirectInputForceFeedbackDemoApp
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
      this.label1 = new System.Windows.Forms.Label();
      this.TimerPoll = new System.Windows.Forms.Timer(this.components);
      this.ButtonPoll = new System.Windows.Forms.Button();
      this.ButtonAttatch = new System.Windows.Forms.Button();
      this.ButtonRemove = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // ComboBoxDevices
      // 
      this.ComboBoxDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ComboBoxDevices.FormattingEnabled = true;
      this.ComboBoxDevices.Location = new System.Drawing.Point(13, 13);
      this.ComboBoxDevices.Name = "ComboBoxDevices";
      this.ComboBoxDevices.Size = new System.Drawing.Size(440, 33);
      this.ComboBoxDevices.TabIndex = 1;
      this.ComboBoxDevices.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDevices_SelectedIndexChanged);
      // 
      // ButtonEnumerateDevices
      // 
      this.ButtonEnumerateDevices.Location = new System.Drawing.Point(460, 13);
      this.ButtonEnumerateDevices.Name = "ButtonEnumerateDevices";
      this.ButtonEnumerateDevices.Size = new System.Drawing.Size(40, 34);
      this.ButtonEnumerateDevices.TabIndex = 2;
      this.ButtonEnumerateDevices.Text = "🔄";
      this.ButtonEnumerateDevices.UseVisualStyleBackColor = true;
      this.ButtonEnumerateDevices.Click += new System.EventHandler(this.ButtonEnumerateDevices_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 49);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(0, 25);
      this.label1.TabIndex = 3;
      // 
      // ButtonPoll
      // 
      this.ButtonPoll.Location = new System.Drawing.Point(596, 53);
      this.ButtonPoll.Name = "ButtonPoll";
      this.ButtonPoll.Size = new System.Drawing.Size(84, 34);
      this.ButtonPoll.TabIndex = 4;
      this.ButtonPoll.Text = "Poll";
      this.ButtonPoll.UseVisualStyleBackColor = true;
      this.ButtonPoll.Click += new System.EventHandler(this.ButtonPoll_Click);
      // 
      // ButtonAttatch
      // 
      this.ButtonAttatch.Location = new System.Drawing.Point(506, 12);
      this.ButtonAttatch.Name = "ButtonAttatch";
      this.ButtonAttatch.Size = new System.Drawing.Size(84, 34);
      this.ButtonAttatch.TabIndex = 5;
      this.ButtonAttatch.Text = "Attatch";
      this.ButtonAttatch.UseVisualStyleBackColor = true;
      this.ButtonAttatch.Click += new System.EventHandler(this.ButtonAttatch_Click);
      // 
      // ButtonRemove
      // 
      this.ButtonRemove.Location = new System.Drawing.Point(596, 13);
      this.ButtonRemove.Name = "ButtonRemove";
      this.ButtonRemove.Size = new System.Drawing.Size(84, 34);
      this.ButtonRemove.TabIndex = 6;
      this.ButtonRemove.Text = "Remove";
      this.ButtonRemove.UseVisualStyleBackColor = true;
      this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
      // 
      // Form1
      // 
      this.ClientSize = new System.Drawing.Size(698, 441);
      this.Controls.Add(this.ButtonRemove);
      this.Controls.Add(this.ButtonAttatch);
      this.Controls.Add(this.ButtonPoll);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.ButtonEnumerateDevices);
      this.Controls.Add(this.ComboBoxDevices);
      this.Name = "Form1";
      this.Text = "Direct Input Explorer";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ComboBox ComboBoxDevices;
    private System.Windows.Forms.Button ButtonEnumerateDevices;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Timer TimerPoll;
    private System.Windows.Forms.Button ButtonPoll;
    private System.Windows.Forms.Button ButtonAttatch;
    private System.Windows.Forms.Button ButtonRemove;
  }
}

