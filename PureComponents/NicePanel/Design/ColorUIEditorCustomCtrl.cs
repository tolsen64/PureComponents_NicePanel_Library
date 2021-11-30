using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace PureComponents.NicePanel.Design
{
	[ToolboxItem(false)]
	internal class ColorUIEditorCustomCtrl : UserControl
	{
		private Container components = null;

		public event EventHandler ColorPick;

		public ColorUIEditorCustomCtrl()
		{
			InitializeComponent();
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
			System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(PureComponents.NicePanel.Design.ColorUIEditorCustomCtrl));
			BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("$this.BackgroundImage");
			base.Name = "ColorUIEditorCustomCtrl";
			base.Size = new System.Drawing.Size(159, 145);
		}

		private void label37_MouseDown(object sender, MouseEventArgs e)
		{
		}

		protected override void OnMouseUp(MouseEventArgs p)
		{
			base.OnMouseUp(p);
			if (this.ColorPick != null && BackgroundImage != null)
			{
				ColorUIEditorPaletteCtrl.ColorPickEventArgs colorPickEventArgs = new ColorUIEditorPaletteCtrl.ColorPickEventArgs();
				if (p.X < BackgroundImage.Width && p.Y < BackgroundImage.Height && p.X > 1 && p.Y > 1)
				{
					colorPickEventArgs.Color = ((Bitmap)BackgroundImage).GetPixel(p.X, p.Y);
					this.ColorPick(this, colorPickEventArgs);
				}
			}
		}
	}
}
