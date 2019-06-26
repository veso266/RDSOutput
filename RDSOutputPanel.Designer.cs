/*
 * Created by SharpDevelop.
 * User: Administrador
 * Date: 29/03/2015
 * Time: 19:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SDRSharp.RDSOutput
{
	partial class RDSOutputPanel
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBoxRDSSpyOn = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBoxRFtapOn = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(6, 49);
			this.listBox1.Name = "listBox1";
			this.listBox1.ScrollAlwaysVisible = true;
			this.listBox1.Size = new System.Drawing.Size(198, 108);
			this.listBox1.TabIndex = 6;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBoxRDSSpyOn);
			this.groupBox1.Controls.Add(this.listBox1);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(210, 170);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "RDS Spy Connection";
			// 
			// checkBoxRDSSpyOn
			// 
			this.checkBoxRDSSpyOn.Location = new System.Drawing.Point(16, 19);
			this.checkBoxRDSSpyOn.Name = "checkBoxRDSSpyOn";
			this.checkBoxRDSSpyOn.Size = new System.Drawing.Size(104, 24);
			this.checkBoxRDSSpyOn.TabIndex = 1;
			this.checkBoxRDSSpyOn.Text = "Enable";
			this.checkBoxRDSSpyOn.UseVisualStyleBackColor = true;
			this.checkBoxRDSSpyOn.CheckedChanged += new System.EventHandler(this.CheckBoxPDSSpyOnCheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.checkBoxRFtapOn);
			this.groupBox2.Location = new System.Drawing.Point(3, 179);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(210, 47);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "RFtap Connection";
			// 
			// checkBoxRFtapOn
			// 
			this.checkBoxRFtapOn.Location = new System.Drawing.Point(16, 21);
			this.checkBoxRFtapOn.Name = "checkBoxRFtapOn";
			this.checkBoxRFtapOn.Size = new System.Drawing.Size(104, 24);
			this.checkBoxRFtapOn.TabIndex = 0;
			this.checkBoxRFtapOn.Text = "Enable";
			this.checkBoxRFtapOn.UseVisualStyleBackColor = true;
			this.checkBoxRFtapOn.CheckedChanged += new System.EventHandler(this.CheckBoxRFtapOnCheckedChanged);
			// 
			// RDSOutputPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "RDSOutputPanel";
			this.Size = new System.Drawing.Size(250, 260);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	
	private System.Windows.Forms.ListBox listBox1;
	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.CheckBox checkBoxRFtapOn;
	private System.Windows.Forms.GroupBox groupBox2;
	private System.Windows.Forms.CheckBox checkBoxRDSSpyOn;
	
  }
}
