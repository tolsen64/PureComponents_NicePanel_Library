using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PureComponents.NicePanel.Design
{
	[ToolboxItem(false)]
	internal class ColorUIEditorPaletteLightCtrl : Control
	{
		private Color m_BaseColor;

		private bool m_MouseDown = false;

		public Color Color
		{
			get
			{
				return m_BaseColor;
			}
			set
			{
				m_BaseColor = value;
				Invalidate();
			}
		}

		public event EventHandler ColorPick;

		public ColorUIEditorPaletteLightCtrl()
		{
			SetStyle(ControlStyles.DoubleBuffer, value: true);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (m_MouseDown)
			{
				if (this.ColorPick != null)
				{
					ColorUIEditorPaletteCtrl.ColorPickEventArgs colorPickEventArgs = new ColorUIEditorPaletteCtrl.ColorPickEventArgs();
					colorPickEventArgs.Color = ColorManager.SetBrightness(m_BaseColor, 1.0 - (double)e.Y * 0.014493 / 2.0);
					this.ColorPick(this, colorPickEventArgs);
				}
				Invalidate();
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			m_MouseDown = false;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			m_MouseDown = true;
			if (this.ColorPick != null)
			{
				ColorUIEditorPaletteCtrl.ColorPickEventArgs colorPickEventArgs = new ColorUIEditorPaletteCtrl.ColorPickEventArgs();
				colorPickEventArgs.Color = ColorManager.SetBrightness(m_BaseColor, 1.0 - (double)e.Y * 0.014493 / 2.0);
				this.ColorPick(this, colorPickEventArgs);
			}
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Color color = ColorManager.SetBrightness(m_BaseColor, 0.0);
			for (int i = 0; i < 69; i++)
			{
				color = ColorManager.SetBrightness(m_BaseColor, 1.0 - 0.014493 * (double)i);
				Pen pen = new Pen(color, 2f);
				e.Graphics.DrawLine(pen, 0, i * 2, 10, i * 2);
				pen.Dispose();
			}
			ColorManager.HLS hLS = ColorManager.RGB_to_HLS(m_BaseColor);
			int num = 137 - (int)(hLS.L * 2.0 / 0.014493);
			e.Graphics.DrawLine(Pens.Black, 12, num - 2, 17, num - 2);
			e.Graphics.DrawLine(Pens.Black, 12, num - 1, 17, num - 1);
			e.Graphics.DrawLine(Pens.Black, 12, num, 16, num);
			e.Graphics.DrawLine(Pens.Black, 12, num + 1, 17, num + 1);
		}
	}
}
