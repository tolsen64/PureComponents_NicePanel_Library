using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;

namespace PureComponents.NicePanel.Design
{
	internal class FillStyleEditor : UITypeEditor
	{
		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override void PaintValue(PaintValueEventArgs pe)
		{
			FillStyle fillStyle = (FillStyle)pe.Value;
			Brush brush = null;
			switch (fillStyle)
			{
			case FillStyle.Flat:
				brush = new SolidBrush(Color.White);
				break;
			case FillStyle.DiagonalBackward:
				brush = new LinearGradientBrush(pe.Bounds, Color.Black, Color.White, LinearGradientMode.BackwardDiagonal);
				break;
			case FillStyle.DiagonalForward:
				brush = new LinearGradientBrush(pe.Bounds, Color.Black, Color.White, LinearGradientMode.ForwardDiagonal);
				break;
			case FillStyle.HorizontalFading:
				brush = new LinearGradientBrush(pe.Bounds, Color.Black, Color.White, LinearGradientMode.Horizontal);
				break;
			case FillStyle.VerticalFading:
				brush = new LinearGradientBrush(pe.Bounds, Color.Black, Color.White, LinearGradientMode.Vertical);
				break;
			}
			pe.Graphics.FillRectangle(brush, pe.Bounds);
			brush.Dispose();
		}
	}
}
