using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace PureComponents.NicePanel.Design
{
	internal class ClipArtTypeEditor : UITypeEditor
	{
		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override void PaintValue(PaintValueEventArgs pe)
		{
			ImageClipArt imageClipArt = (ImageClipArt)pe.Value;
			Image resourceImage = NicePanel.GetResourceImage(imageClipArt.ToString(), PanelHeaderSize.Small);
			if (resourceImage != null)
			{
				pe.Graphics.DrawImage(resourceImage, pe.Bounds);
			}
		}
	}
}
