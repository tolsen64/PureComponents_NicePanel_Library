using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace PureComponents.NicePanel.Design
{
	internal class HeaderStyleUIEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			if (context != null)
			{
				return UITypeEditorEditStyle.Modal;
			}
			return base.GetEditStyle(context);
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			PanelStyle panelStyle = context.Instance as PanelStyle;
			NicePanelStyleEditorForm nicePanelStyleEditorForm = new NicePanelStyleEditorForm(panelStyle.Parent.Designer, 1);
			nicePanelStyleEditorForm.ShowDialog();
			return base.EditValue(context, provider, value);
		}
	}
}
