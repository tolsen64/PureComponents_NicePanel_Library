using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace PureComponents.NicePanel.Design
{
	internal class ColorUIEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			if (context != null)
			{
				return UITypeEditorEditStyle.DropDown;
			}
			return base.GetEditStyle(context);
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (context != null && provider != null)
			{
				IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
				if (windowsFormsEditorService != null)
				{
					ColorUIEditorCtrl colorUIEditorCtrl = new ColorUIEditorCtrl((Color)value, windowsFormsEditorService);
					colorUIEditorCtrl.Value = (Color)value;
					windowsFormsEditorService.DropDownControl(colorUIEditorCtrl);
					value = colorUIEditorCtrl.Value;
					return value;
				}
			}
			return base.EditValue(context, provider, value);
		}

		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override void PaintValue(PaintValueEventArgs e)
		{
			Color color = (Color)e.Value;
			Brush brush = new SolidBrush(color);
			e.Graphics.FillRectangle(brush, e.Bounds);
			brush.Dispose();
		}
	}
}
