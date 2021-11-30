using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using PureComponents.NicePanel.Design;

namespace PureComponents.NicePanel
{
	/// <summary><P>Specifies the overal panel style of the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
	[Serializable]
	[TypeConverter(typeof(PanelStyleConverter))]
	public class PanelStyle
	{
		private NicePanel m_Panel = null;

		private ContainerStyle m_ContainerStyle;

		private PanelHeaderStyle m_HeaderStyle;

		private PanelHeaderStyle m_FooterStyle;

		internal NicePanel Parent => m_Panel;

		/// <summary><P>The inner container object style of the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		[Editor(typeof(ContainerStyleUIEditor), typeof(UITypeEditor))]
		[Description("The container style object.")]
		public ContainerStyle ContainerStyle
		{
			get
			{
				return m_ContainerStyle;
			}
			set
			{
				m_ContainerStyle = value;
				Invalidate();
			}
		}

		/// <summary><P>The inner header object style of the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		[Editor(typeof(HeaderStyleUIEditor), typeof(UITypeEditor))]
		[Description("The header style object.")]
		public PanelHeaderStyle HeaderStyle
		{
			get
			{
				return m_HeaderStyle;
			}
			set
			{
				m_HeaderStyle = value;
				Invalidate();
			}
		}

		/// <summary><P>The inner footer object style of the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		[Description("The footer style object.")]
		[Editor(typeof(FooterStyleUIEditor), typeof(UITypeEditor))]
		public PanelHeaderStyle FooterStyle
		{
			get
			{
				return m_FooterStyle;
			}
			set
			{
				m_FooterStyle = value;
				Invalidate();
			}
		}

		/// <summary><P>The static instance of Default style of the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		public static PanelStyle Default => NicePanelStyleFactory.Instance.GetDefaultStyle();

		public static PanelStyle Sky => NicePanelStyleFactory.Instance.GetSkyStyle();

		/// <summary><P>The static instance of Ocean style of the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		public static PanelStyle Ocean => NicePanelStyleFactory.Instance.GetOceanStyle();

		/// <summary><P>The static instance of Forest style of the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		public static PanelStyle Forest => NicePanelStyleFactory.Instance.GetForestStyle();

		/// <summary><P>The static instance of Sunset style of the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		public static PanelStyle Sunset => NicePanelStyleFactory.Instance.GetSunsetStyle();

		/// <summary><P>The static instance of Rose style of the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		public static PanelStyle Rose => NicePanelStyleFactory.Instance.GetRoseStyle();

		/// <summary><P>The static instance of Gold style of the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		public static PanelStyle Gold => NicePanelStyleFactory.Instance.GetGoldStyle();

		/// <summary><P>The static instance of Wood style of the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		public static PanelStyle Wood => NicePanelStyleFactory.Instance.GetWoodStyle();

		/// <summary><P>The static instance of Silver style of the <see cref="T:PureComponents.NicePanel.NicePanel" /> control.</P></summary>
		public static PanelStyle Silver => NicePanelStyleFactory.Instance.GetSilverStyle();

		/// <summary><P>Construction. It is not intended for programmers to be used.</P></summary>
		public PanelStyle()
		{
			m_ContainerStyle = new ContainerStyle();
			m_HeaderStyle = new PanelHeaderStyle();
			m_FooterStyle = new PanelHeaderStyle();
			m_FooterStyle.BackColor = Color.FromArgb(9, 42, 127);
			m_FooterStyle.ForeColor = Color.FromArgb(169, 198, 237);
			m_FooterStyle.FadeColor = Color.FromArgb(102, 145, 215);
			m_FooterStyle.FlashBackColor = Color.FromArgb(243, 122, 1);
			m_FooterStyle.FlashForeColor = Color.White;
			m_FooterStyle.FlashFadeColor = Color.FromArgb(255, 215, 159);
			m_FooterStyle.Font = new Font("Microsoft Sans Serif", 8.25f);
			m_FooterStyle.FillStyle = FillStyle.HorizontalFading;
			m_FooterStyle.Size = PanelHeaderSize.Small;
		}

		/// <summary><P>Overriden implementation.</P></summary>
		public override string ToString()
		{
			return "";
		}

		internal void SetPanel(NicePanel panel)
		{
			m_Panel = panel;
			m_ContainerStyle.SetParent(this);
			m_HeaderStyle.SetParent(this);
			m_FooterStyle.SetParent(this);
		}

		internal void Invalidate()
		{
			if (m_Panel != null)
			{
				m_Panel.Invalidate();
			}
		}
	}
}
