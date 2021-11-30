using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using PureComponents.NicePanel.Design;

namespace PureComponents.NicePanel
{
	/// <summary><P>The style of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control's container.</P></summary>
	[Serializable]
	[TypeConverter(typeof(ContainerStyleConverter))]
	public class ContainerStyle
	{
		private PanelStyle m_Parent = null;

		private BorderStyle m_BorderStyle = BorderStyle.Solid;

		private Color m_BorderColor = Color.FromArgb(1, 45, 150);

		private Shape m_Shape = Shape.Squared;

		private Color m_BackColor = Color.FromArgb(142, 179, 231);

		private Color m_FadeColor = Color.FromArgb(217, 232, 252);

		private FillStyle m_FillStyle = FillStyle.DiagonalForward;

		private Color m_FlashItemBackColor = Color.Red;

		private Color m_FocusedChildBackColor = Color.FromArgb(255, 255, 128);

		private CaptionAlign m_CaptionAlign = CaptionAlign.Left;

		/// <summary><P>The border style of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		[Description("The border style of the panel.")]
		public BorderStyle BorderStyle
		{
			get
			{
				return m_BorderStyle;
			}
			set
			{
				m_BorderStyle = value;
				Invalidate();
			}
		}

		/// <summary><P>The base color of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control's container.</P></summary>
		/// <remarks><P>BaseColor is a color which all internal controls take as its default color, defines default foreground for labels, buttons and similar.</P></remarks>
		[Description("The base color of the panel used for labels etc.")]
		[Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
		public Color BaseColor
		{
			get
			{
				if (m_Parent == null || m_Parent.Parent == null)
				{
					return BackColor;
				}
				return m_Parent.Parent.BackColor;
			}
			set
			{
				if (m_Parent != null && m_Parent.Parent != null)
				{
					m_Parent.Parent.BackColor = value;
					Invalidate();
				}
			}
		}

		/// <summary><P>The back color of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control's container control when it receives the focus.</P></summary>
		[Description("The focused back color for item controls.")]
		[Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
		public Color FocusItemBackColor
		{
			get
			{
				return m_FocusedChildBackColor;
			}
			set
			{
				m_FocusedChildBackColor = value;
				Invalidate();
			}
		}

		/// <summary><P>The back color of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control's container controls when they are being flashed.</P></summary>
		/// <remarks><P>To flash a control call the <see cref="T:PureComponents.NicePanel.NicePanel.FlashItem" /> function.</P></remarks>
		[Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
		[Description("The flashing back color for item controls.")]
		public Color FlashItemBackColor
		{
			get
			{
				return m_FlashItemBackColor;
			}
			set
			{
				m_FlashItemBackColor = value;
				Invalidate();
			}
		}

		/// <summary><P>The fore color a <see cref="T:PureComponents.NicePanel.NicePanel" /> control's container.</P></summary>
		[Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
		[Description("The fore color of the panel.")]
		public Color ForeColor
		{
			get
			{
				if (m_Parent == null || m_Parent.Parent == null)
				{
					return BorderColor;
				}
				return m_Parent.Parent.ForeColor;
			}
			set
			{
				if (m_Parent != null && m_Parent.Parent != null)
				{
					m_Parent.Parent.ForeColor = value;
					Invalidate();
				}
			}
		}

		/// <summary><P>The font of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control's container, font is used for captioning and as a default font for subsequent controls like labels and buttons.</P></summary>
		[Description("The font of the panel.")]
		public Font Font
		{
			get
			{
				if (m_Parent == null || m_Parent.Parent == null)
				{
					return null;
				}
				return m_Parent.Parent.Font;
			}
			set
			{
				if (m_Parent != null && m_Parent.Parent != null)
				{
					m_Parent.Parent.Font = value;
					Invalidate();
				}
			}
		}

		/// <summary><P>The border color of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		[Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
		[Description("The border color of the panel.")]
		public Color BorderColor
		{
			get
			{
				return m_BorderColor;
			}
			set
			{
				m_BorderColor = value;
				Invalidate();
			}
		}

		/// <summary><P>The shape style of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		[Description("The shape style of the panel.")]
		public Shape Shape
		{
			get
			{
				return m_Shape;
			}
			set
			{
				m_Shape = value;
				if (m_Parent != null && m_Parent.Parent != null)
				{
					m_Parent.Parent.OnSetShape();
				}
				Invalidate();
			}
		}

		/// <summary><P>The back color of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control's container.</P></summary>
		[Description("The back color of the panel.")]
		[Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
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

		/// <summary><P>The fade color of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control's container when the <B>FillStyle</B> is other than <B>Flat</B>.</P></summary>
		[Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
		[Description("The fade color of the panel.")]
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

		/// <summary><P>The fill style of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control's container.</P></summary>
		[Description("The fill style of the panel.")]
		[Editor(typeof(FillStyleEditor), typeof(UITypeEditor))]
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

		/// <summary><P>The caption alignment of a <see cref="T:PureComponents.NicePanel.NicePanel" /> control's container.</P></summary>
		[Description("Alignment of controls caption in the container style.")]
		public CaptionAlign CaptionAlign
		{
			get
			{
				return m_CaptionAlign;
			}
			set
			{
				m_CaptionAlign = value;
				Invalidate();
			}
		}

		/// <summary><P>Default contruction, you do not normally create the instance directly.</P></summary>
		public ContainerStyle()
		{
		}

		/// <summary><P>Overriden implementation.</P></summary>
		public override string ToString()
		{
			return "";
		}

		internal void SetParent(PanelStyle style)
		{
			m_Parent = style;
		}

		private void Invalidate()
		{
			if (m_Parent != null)
			{
				m_Parent.Invalidate();
			}
		}
	}
}
