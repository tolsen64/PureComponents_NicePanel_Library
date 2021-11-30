using System.Collections;
using System.Windows.Forms;

namespace PureComponents.NicePanel
{
	internal class TabOrderComparer : IComparer
	{
		public int Compare(object x, object y)
		{
			Control control = x as Control;
			Control control2 = y as Control;
			if (control.TabIndex < control2.TabIndex)
			{
				return -1;
			}
			if (control.TabIndex > control2.TabIndex)
			{
				return 1;
			}
			return 0;
		}
	}
}
