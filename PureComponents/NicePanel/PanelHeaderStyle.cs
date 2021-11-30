using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using PureComponents.NicePanel.Design;

namespace PureComponents.NicePanel
{
	/// <summary><P>Specifies the style of the header or footer object on the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
	[Serializable]
	[TypeConverter(typeof(PanelHeaderStyleConverter))]
	public class PanelHeaderStyle
	{
		private PanelStyle m_oParent;

		private Color m_BackColor = Color.FromArgb(102, 145, 215);

		private Color m_ForeColor = Color.FromArgb(215, 230, 251);

		private Color m_FadeColor = Color.FromArgb(9, 42, 127);

		private Color m_FlashBackColor = Color.FromArgb(243, 122, 1);

		private Color m_FlashForeColor = Color.White;

		private Color m_FlashFadeColor = Color.FromArgb(255, 215, 159);

		private Color m_ButtonColor = Color.FromArgb(172, 191, 227);

		private ContentAlignment m_TextAlign = ContentAlignment.MiddleLeft;

		private Font m_Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);

		private FillStyle m_FillStyle = FillStyle.VerticalFading;

		private PanelHeaderSize m_Size = PanelHeaderSize.Medium;

		/// <summary><P>Specifies the back color of the header or footer object on the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		[Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
		[Description("Back color of the header.")]
		public Color BackColor
		{
			get
			{
				return m_BackColor;
			}
			set
			{
				m_BackColor = value;
				Invalidate();
			}
		}

		/// <summary><P>Specifies the fore color of the header or footer object on the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		[Description("The fore color of the header.")]
		[Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
		public Color ForeColor
		{
			get
			{
				return m_ForeColor;
			}
			set
			{
				m_ForeColor = value;
				Invalidate();
			}
		}

		/// <summary><P>Specifies the fade color of the header or footer object on the <see cref="T:PureComponents.NicePanel.NicePanel" /> control for the fading fill styles.</P></summary>
		[Description("The fade color of the header used in the gradient fill modes.")]
		[Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
		public Color FadeColor
		{
			get
			{
				return m_FadeColor;
			}
			set
			{
				m_FadeColor = value;
				Invalidate();
			}
		}

		/// <summary><P>Specifies the back color of the header or footer object on the <see cref="T:PureComponents.NicePanel.NicePanel" /> control during the flashing.</P></summary>
		[Description("The flash back color of the header.")]
		[Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
		public Color FlashBackColor
		{
			get
			{
				return m_FlashBackColor;
			}
			set
			{
				m_FlashBackColor = value;
				Invalidate();
			}
		}

		/// <summary><P>Specifies the fore color of the header or footer object on the <see cref="T:PureComponents.NicePanel.NicePanel" /> control during flashing.</P></summary>
		[Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
		[Description("The flash fore color of the header.")]
		public Color FlashForeColor
		{
			get
			{
				return m_FlashForeColor;
			}
			set
			{
				m_FlashForeColor = value;
				Invalidate();
			}
		}

		/// <summary><P>Specifies the fade color of the header or footer object on the <see cref="T:PureComponents.NicePanel.NicePanel" /> control during flashing.</P></summary>
		[Description("The flash fade color of the header used in the gradient fill modes.")]
		[Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
		public Color FlashFadeColor
		{
			get
			{
				return m_FlashFadeColor;
			}
			set
			{
				m_FlashFadeColor = value;
				Invalidate();
			}
		}

		/// <summary><P>Specifies the color of buttons on the header object on the <see cref="T:PureComponents.NicePanel.NicePanel" /> control. Has no meaning on footer objects.</P></summary>
		[Description("The color for button object of the header.")]
		[Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
		public Color ButtonColor
		{
			get
			{
				return m_ButtonColor;
			}
			set
			{
				m_ButtonColor = value;
				Invalidate();
			}
		}

		/// <summary><P>Specifies the text alignment of the header or footer object on the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		[DefaultValue(ContentAlignment.MiddleLeft)]
		[Description("The text align for text of the header.")]
		public ContentAlignment TextAlign
		{
			get
			{
				return m_TextAlign;
			}
			set
			{
				m_TextAlign = value;
				Invalidate();
			}
		}

		/// <summary><P>Specifies the size of the header or footer object on the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		[Description("The size of the header.")]
		public PanelHeaderSize Size
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

		/// <summary><P>Specifies the font of the header or footer object on the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		[Description("The font of the header.")]
		public Font Font
		{
			get
			{
				return m_Font;
			}
			set
			{
				m_Font = value;
				Invalidate();
			}
		}

		/// <summary><P>Specifies the fill style of the header or footer object on the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		[Editor(typeof(FillStyleEditor), typeof(UITypeEditor))]
		[Description("The fill style of the header.")]
		public FillStyle FillStyle
		{
			get
			{
				return m_FillStyle;
			}
			set
			{
				m_FillStyle = value;
				Invalidate();
			}
		}

		/// <summary><P>Construction. It is not intended for a programmer to create instances manually.</P></summary>
		public PanelHeaderStyle()
		{
		}

		/// <summary><P>Construction. It is not intended for a programmer to create instances manually.</P></summary>
		public PanelHeaderStyle(PanelStyle Parent)
		{
			m_oParent = Parent;
		}

		/// <summary><P>Overriden implementation.</P></summary>
		public override string ToString()
		{
			return "";
		}

		internal void SetParent(PanelStyle Parent)
		{
			m_oParent = Parent;
		}

		internal void Invalidate()
		{
			if (m_oParent != null)
			{
				m_oParent.Invalidate();
			}
		}
	}
}
