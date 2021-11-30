using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using PureComponents.NicePanel.Design;

namespace PureComponents.NicePanel
{
	/// <summary><P>Specifies the image for a <see cref="T:PureComponents.NicePanel.NicePanel" /> control which si being shown inside the main container pat of the <B>NicePanel</B>.</P></summary>
	[Serializable]
	[TypeConverter(typeof(ContainerImageConverter))]
	public class ContainerImage
	{
		private NicePanel m_Parent = null;

		private ImageClipArt m_ClipArt = ImageClipArt.None;

		private Image m_Image = null;

		private ContainerImageSize m_Size = ContainerImageSize.Small;

		private ContentAlignment m_Alignment = ContentAlignment.BottomRight;

		private int m_Transparency = 50;

		/// <summary><P>Specifies the the image object inside the container of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control. There are number of images to choose from in the clipart.</P></summary>
		[Editor(typeof(ClipArtTypeEditor), typeof(UITypeEditor))]
		[Description("The image from the built-in clipart.")]
		public ImageClipArt ClipArt
		{
			get
			{
				return m_ClipArt;
			}
			set
			{
				m_ClipArt = value;
				Invalidate();
			}
		}

		/// <summary><P>Specifies the image object inside the container of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control. </P></summary>
		/// <remarks><P>When the Image object is used than the <B>ClipArt</B> is ignored and the value from the Image is taken.</P></remarks>
		[Description("The image object from the file.")]
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

		/// <summary><P>Specifies the size of the image of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		/// <remarks><P>There are three sizes available for you to choose from, see <see cref="T:PureComponents.NicePanel.ContainerImageSize" /> for more information.</P></remarks>
		[Description("The size of the image.")]
		public ContainerImageSize Size
		{
			get
			{
				return m_Size;
			}
			set
			{
				m_Size = value;
				Invalidate();
			}
		}

		/// <summary><P>Specifies the alignment of the image inside the container of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		[Description("The alignment of the image.")]
		public ContentAlignment Alignment
		{
			get
			{
				return m_Alignment;
			}
			set
			{
				m_Alignment = value;
				Invalidate();
			}
		}

		/// <summary><P>Specifies the transparency of the image of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		/// <remarks><P>Transparency is in percentage, so the value can be from 0 to 100. Typical setting is 40.</P></remarks>
		[Description("The transparency of the image between 0 and 100.")]
		public int Transparency
		{
			get
			{
				return m_Transparency;
			}
			set
			{
				m_Transparency = value;
				if (m_Transparency < 0)
				{
					m_Transparency = 0;
				}
				if (m_Transparency > 100)
				{
					m_Transparency = 100;
				}
				Invalidate();
			}
		}

		/// <summary><P>Default object construction. You normaly do not create the <B>ContainerImage</B> maually.</P></summary>
		public ContainerImage()
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

		private void ResetClipArt()
		{
			m_ClipArt = ImageClipArt.None;
			Invalidate();
		}

		private void ResetImage()
		{
			m_Image = null;
			Invalidate();
		}
	}
}
