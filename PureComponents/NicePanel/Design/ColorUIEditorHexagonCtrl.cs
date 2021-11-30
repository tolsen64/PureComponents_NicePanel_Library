using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Windows.Forms;

namespace PureComponents.NicePanel.Design
{
	internal class ColorUIEditorHexagonCtrl : UserControl
	{
		private Container components = null;

		public event EventHandler ColorPick;

		public ColorUIEditorHexagonCtrl()
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

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.StartFigure();
			graphicsPath.AddLine(0, base.Height / 2, base.Width / 3 - 14, 0);
			graphicsPath.AddLine(base.Width / 3 - 12, 0, base.Width / 3 * 2 + 14, 0);
			graphicsPath.AddLine(base.Width / 3 * 2 + 14, 0, base.Width, base.Height / 2);
			graphicsPath.AddLine(base.Width, base.Height / 2, base.Width / 3 * 2 + 14, base.Height);
			graphicsPath.AddLine(base.Width / 3 * 2 + 14, base.Height, base.Width / 3 - 14, base.Height);
			graphicsPath.AddLine(base.Width / 3 - 14, base.Height, 0, base.Height / 2);
			graphicsPath.CloseFigure();
			Region region2 = (base.Region = new Region(graphicsPath));
		}

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(PureComponents.NicePanel.Design.ColorUIEditorHexagonCtrl));
			BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("$this.BackgroundImage");
			base.Name = "ColorUIEditorHexagonCtrl";
			base.Size = new System.Drawing.Size(161, 138);
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
