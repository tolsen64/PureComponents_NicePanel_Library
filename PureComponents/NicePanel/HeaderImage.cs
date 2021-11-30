using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using PureComponents.NicePanel.Design;

namespace PureComponents.NicePanel
{
	/// <summary><P>The image object for <see cref="T:PureComponents.NicePanel.NicePanel" /> control's header and footer.</P></summary>
	[Serializable]
	[TypeConverter(typeof(HeaderImageConverter))]
	public class HeaderImage
	{
		private Image m_Image = null;

		private ImageClipArt m_ImageClipArt = ImageClipArt.PureComponents;

		private NicePanel m_Parent = null;

		/// <summary><P>Specifies the image object inside the header or footer of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control. </P></summary>
		/// <remarks><P>When the <B>Image</B> object is used than the <B>ClipArt</B> is ignored and the value from the Image is taken.</P></remarks>
		[Description("The image from the file.")]
		public Image Image
		{
			get
			{
				return m_Image;
			}
			set
			{
				m_Image = value;
				Invalidate();
			}
		}

		/// <summary><P>Specifies the the image object inside the header or footer of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control. There are number of images to choose from in the clipart.</P></summary>
		[Description("The image from the built-in clipart.")]
		[Editor(typeof(ClipArtTypeEditor), typeof(UITypeEditor))]
		public ImageClipArt ClipArt
		{
			get
			{
				return m_ImageClipArt;
			}
			set
			{
				m_ImageClipArt = value;
				Invalidate();
			}
		}

		/// <summary><P>Default object construction. You normaly do not create the <B>ContainerImage</B> maually.</P></summary>
		public HeaderImage()
		{
		}

		/// <summary><P>Overriden implemenation.</P></summary>
		public override string ToString()
		{
			return "";
		}

		internal void SetParent(NicePanel parent)
		{
			m_Parent = parent;
		}

		private void Invalidate()
		{
			if (m_Parent != null)
			{
				m_Parent.Invalidate();
			}
		}

		private void ResetImage()
		{
			m_Image = null;
			Invalidate();
		}

		private void ResetClipArt()
		{
			m_ImageClipArt = ImageClipArt.None;
			Invalidate();
		}
	}
}
