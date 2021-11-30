using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PureComponents.NicePanel.Design
{
	internal class ColorPickForm : Form
	{
		private ColorUIEditorCtrl colorUIEditorCtrl1;

		private Container components = null;

		public Color Color => colorUIEditorCtrl1.Value;

		public ColorPickForm(Color originalValue)
		{
			InitializeComponent();
			colorUIEditorCtrl1.OKClick += colorUIEditorCtrl1_OKClick;
			colorUIEditorCtrl1.CancelClick += colorUIEditorCtrl1_CancelClick;
			colorUIEditorCtrl1.Value = originalValue;
			colorUIEditorCtrl1.OriginalValue = originalValue;
		}

		private void colorUIEditorCtrl1_OKClick(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void colorUIEditorCtrl1_CancelClick(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			colorUIEditorCtrl1 = new PureComponents.NicePanel.Design.ColorUIEditorCtrl();
			SuspendLayout();
			colorUIEditorCtrl1.Location = new System.Drawing.Point(0, 0);
			colorUIEditorCtrl1.Name = "colorUIEditorCtrl1";
			colorUIEditorCtrl1.Size = new System.Drawing.Size(337, 228);
			colorUIEditorCtrl1.TabIndex = 0;
			colorUIEditorCtrl1.Value = System.Drawing.Color.FromArgb(255, 255, 255);
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			base.ClientSize = new System.Drawing.Size(339, 228);
			base.Controls.Add(colorUIEditorCtrl1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ColorPickForm";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "NicePanel Color Picker";
			ResumeLayout(false);
		}
	}
}
