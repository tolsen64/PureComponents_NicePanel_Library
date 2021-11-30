using System.Drawing;

namespace PureComponents.NicePanel
{
	public class ClipArtFactory
	{
		public static Image GetClipArtImage(ImageClipArt img, PanelHeaderSize size)
		{
			return NicePanel.GetResourceImage(img.ToString(), size);
		}
	}
}
