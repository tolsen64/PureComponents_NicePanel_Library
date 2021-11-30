using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace PureComponents.NicePanel.Design
{
	[ToolboxItem(false)]
	internal class ColorUIEditorPaletteCtrl : UserControl
	{
		internal class ColorPickEventArgs : EventArgs
		{
			public Color Color;
		}

		private Point m_lastPoint = Point.Empty;

		private bool m_MouseDown = false;

		private Container components = null;

		internal event EventHandler ColorPick;

		public ColorUIEditorPaletteCtrl()
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
			System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(PureComponents.NicePanel.Design.ColorUIEditorPaletteCtrl));
			BackgroundImage = (System.Drawing.Bitmap)resourceManager.GetObject("$this.BackgroundImage");
			base.Name = "ESColorUIEditorPaletteCtrl";
			base.Size = new System.Drawing.Size(175, 137);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			m_MouseDown = false;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			m_MouseDown = true;
			if (this.ColorPick != null && BackgroundImage != null)
			{
				ColorPickEventArgs colorPickEventArgs = new ColorPickEventArgs();
				if (e.X < BackgroundImage.Width && e.Y < BackgroundImage.Height && e.X > 1 && e.Y > 1)
				{
					colorPickEventArgs.Color = ((Bitmap)BackgroundImage).GetPixel(e.X, e.Y);
					this.ColorPick(this, colorPickEventArgs);
				}
			}
			ref Point lastPoint = ref m_lastPoint;
			lastPoint = new Point(e.X, e.Y);
			Invalidate();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (!m_MouseDown)
			{
				return;
			}
			if (this.ColorPick != null && BackgroundImage != null)
			{
				ColorPickEventArgs colorPickEventArgs = new ColorPickEventArgs();
				if (e.X < BackgroundImage.Width && e.Y < BackgroundImage.Height && e.X > 1 && e.Y > 1)
				{
					colorPickEventArgs.Color = ((Bitmap)BackgroundImage).GetPixel(e.X, e.Y);
					this.ColorPick(this, colorPickEventArgs);
				}
			}
			ref Point lastPoint = ref m_lastPoint;
			lastPoint = new Point(e.X, e.Y);
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.DrawLine(Pens.White, m_lastPoint.X - 5, m_lastPoint.Y, m_lastPoint.X - 1, m_lastPoint.Y);
			e.Graphics.DrawLine(Pens.White, m_lastPoint.X + 5, m_lastPoint.Y, m_lastPoint.X + 1, m_lastPoint.Y);
			e.Graphics.DrawLine(Pens.White, m_lastPoint.X, m_lastPoint.Y - 5, m_lastPoint.X, m_lastPoint.Y - 1);
			e.Graphics.DrawLine(Pens.White, m_lastPoint.X, m_lastPoint.Y + 5, m_lastPoint.X, m_lastPoint.Y + 1);
		}
	}
}
