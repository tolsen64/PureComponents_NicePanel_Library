using System.Drawing;

namespace PureComponents.NicePanel
{
	internal class NicePanelStyleFactory
	{
		private static NicePanelStyleFactory m_Instance;

		public static NicePanelStyleFactory Instance
		{
			get
			{
				if (m_Instance == null)
				{
					m_Instance = new NicePanelStyleFactory();
				}
				return m_Instance;
			}
		}

		private NicePanelStyleFactory()
		{
		}

		public PanelStyle GetDefaultStyle()
		{
			return new PanelStyle();
		}

		public PanelStyle GetSkyStyle()
		{
			PanelStyle defaultStyle = GetDefaultStyle();
			defaultStyle.ContainerStyle.BackColor = Color.LightCyan;
			defaultStyle.ContainerStyle.BorderColor = Color.RoyalBlue;
			defaultStyle.ContainerStyle.FadeColor = Color.LightSteelBlue;
			defaultStyle.FooterStyle.BackColor = Color.RoyalBlue;
			defaultStyle.FooterStyle.FadeColor = Color.SkyBlue;
			defaultStyle.FooterStyle.ForeColor = Color.PowderBlue;
			defaultStyle.HeaderStyle.BackColor = Color.DeepSkyBlue;
			defaultStyle.HeaderStyle.ButtonColor = Color.PowderBlue;
			defaultStyle.HeaderStyle.FadeColor = Color.MediumBlue;
			defaultStyle.HeaderStyle.ForeColor = Color.PaleTurquoise;
			return defaultStyle;
		}

		public PanelStyle GetOceanStyle()
		{
			PanelStyle defaultStyle = GetDefaultStyle();
			defaultStyle.ContainerStyle.BackColor = Color.LightCyan;
			defaultStyle.ContainerStyle.BorderColor = Color.FromArgb(65, 131, 111);
			defaultStyle.ContainerStyle.FadeColor = Color.FromArgb(137, 197, 179);
			defaultStyle.FooterStyle.BackColor = Color.FromArgb(53, 120, 128);
			defaultStyle.FooterStyle.FadeColor = Color.FromArgb(152, 211, 224);
			defaultStyle.FooterStyle.ForeColor = Color.FromArgb(193, 240, 234);
			defaultStyle.HeaderStyle.BackColor = Color.MediumTurquoise;
			defaultStyle.HeaderStyle.ButtonColor = Color.FromArgb(193, 240, 234);
			defaultStyle.HeaderStyle.FadeColor = Color.FromArgb(43, 103, 109);
			defaultStyle.HeaderStyle.ForeColor = Color.FromArgb(233, 250, 248);
			return defaultStyle;
		}

		public PanelStyle GetForestStyle()
		{
			PanelStyle defaultStyle = GetDefaultStyle();
			defaultStyle.ContainerStyle.BackColor = Color.FromArgb(223, 240, 221);
			defaultStyle.ContainerStyle.BorderColor = Color.DarkGreen;
			defaultStyle.ContainerStyle.FadeColor = Color.FromArgb(155, 207, 152);
			defaultStyle.FooterStyle.BackColor = Color.ForestGreen;
			defaultStyle.FooterStyle.FadeColor = Color.LightGreen;
			defaultStyle.FooterStyle.ForeColor = Color.FromArgb(184, 233, 184);
			defaultStyle.HeaderStyle.BackColor = Color.DarkSeaGreen;
			defaultStyle.HeaderStyle.ButtonColor = Color.FromArgb(184, 233, 184);
			defaultStyle.HeaderStyle.FadeColor = Color.DarkGreen;
			defaultStyle.HeaderStyle.ForeColor = Color.FromArgb(192, 255, 192);
			return defaultStyle;
		}

		public PanelStyle GetSunsetStyle()
		{
			PanelStyle defaultStyle = GetDefaultStyle();
			defaultStyle.ContainerStyle.BackColor = Color.NavajoWhite;
			defaultStyle.ContainerStyle.BorderColor = Color.DarkRed;
			defaultStyle.ContainerStyle.FadeColor = Color.FromArgb(224, 180, 97);
			defaultStyle.ContainerStyle.FocusItemBackColor = Color.FromArgb(192, 255, 255);
			defaultStyle.FooterStyle.BackColor = Color.FromArgb(180, 99, 1);
			defaultStyle.FooterStyle.FadeColor = Color.FromArgb(255, 192, 128);
			defaultStyle.FooterStyle.ForeColor = Color.FromArgb(73, 0, 0);
			defaultStyle.HeaderStyle.BackColor = Color.FromArgb(255, 122, 0);
			defaultStyle.HeaderStyle.ButtonColor = Color.FromArgb(246, 172, 84);
			defaultStyle.HeaderStyle.FadeColor = Color.FromArgb(130, 0, 0);
			defaultStyle.HeaderStyle.ForeColor = Color.NavajoWhite;
			return defaultStyle;
		}

		public PanelStyle GetRoseStyle()
		{
			PanelStyle defaultStyle = GetDefaultStyle();
			defaultStyle.ContainerStyle.BackColor = Color.FromArgb(245, 201, 205);
			defaultStyle.ContainerStyle.BorderColor = Color.FromArgb(200, 34, 51);
			defaultStyle.ContainerStyle.FadeColor = Color.FromArgb(235, 137, 147);
			defaultStyle.ContainerStyle.FocusItemBackColor = Color.FromArgb(192, 255, 255);
			defaultStyle.FooterStyle.BackColor = Color.FromArgb(188, 0, 0);
			defaultStyle.FooterStyle.FadeColor = Color.FromArgb(254, 163, 179);
			defaultStyle.FooterStyle.ForeColor = Color.FromArgb(254, 187, 183);
			defaultStyle.HeaderStyle.BackColor = Color.Red;
			defaultStyle.HeaderStyle.ButtonColor = Color.FromArgb(254, 187, 183);
			defaultStyle.HeaderStyle.FadeColor = Color.DarkRed;
			defaultStyle.HeaderStyle.ForeColor = Color.MistyRose;
			return defaultStyle;
		}

		public PanelStyle GetGoldStyle()
		{
			PanelStyle defaultStyle = GetDefaultStyle();
			defaultStyle.ContainerStyle.BackColor = Color.FromArgb(254, 246, 204);
			defaultStyle.ContainerStyle.BorderColor = Color.DarkGoldenrod;
			defaultStyle.ContainerStyle.FadeColor = Color.FromArgb(253, 228, 139);
			defaultStyle.ContainerStyle.FocusItemBackColor = Color.FromArgb(192, 255, 255);
			defaultStyle.FooterStyle.BackColor = Color.FromArgb(204, 145, 30);
			defaultStyle.FooterStyle.FadeColor = Color.Gold;
			defaultStyle.FooterStyle.ForeColor = Color.FromArgb(246, 228, 130);
			defaultStyle.HeaderStyle.BackColor = Color.Goldenrod;
			defaultStyle.HeaderStyle.ButtonColor = Color.FromArgb(246, 228, 130);
			defaultStyle.HeaderStyle.FadeColor = Color.SaddleBrown;
			defaultStyle.HeaderStyle.ForeColor = Color.FromArgb(255, 255, 192);
			return defaultStyle;
		}

		public PanelStyle GetWoodStyle()
		{
			PanelStyle defaultStyle = GetDefaultStyle();
			defaultStyle.ContainerStyle.BackColor = Color.FromArgb(234, 225, 225);
			defaultStyle.ContainerStyle.BorderColor = Color.FromArgb(119, 85, 85);
			defaultStyle.ContainerStyle.FadeColor = Color.FromArgb(190, 163, 163);
			defaultStyle.ContainerStyle.FocusItemBackColor = Color.FromArgb(192, 255, 255);
			defaultStyle.FooterStyle.BackColor = Color.FromArgb(144, 104, 104);
			defaultStyle.FooterStyle.FadeColor = Color.FromArgb(221, 207, 207);
			defaultStyle.FooterStyle.ForeColor = Color.FromArgb(211, 191, 191);
			defaultStyle.HeaderStyle.BackColor = Color.FromArgb(185, 157, 157);
			defaultStyle.HeaderStyle.ButtonColor = Color.FromArgb(211, 191, 191);
			defaultStyle.HeaderStyle.FadeColor = Color.FromArgb(109, 79, 79);
			defaultStyle.HeaderStyle.ForeColor = Color.FromArgb(235, 226, 226);
			return defaultStyle;
		}

		public PanelStyle GetSilverStyle()
		{
			PanelStyle defaultStyle = GetDefaultStyle();
			defaultStyle.ContainerStyle.BackColor = Color.WhiteSmoke;
			defaultStyle.ContainerStyle.BorderColor = Color.Gray;
			defaultStyle.ContainerStyle.FadeColor = Color.Gainsboro;
			defaultStyle.ContainerStyle.FocusItemBackColor = Color.FromArgb(192, 255, 255);
			defaultStyle.FooterStyle.BackColor = Color.Gray;
			defaultStyle.FooterStyle.FadeColor = Color.LightGray;
			defaultStyle.FooterStyle.ForeColor = Color.Gainsboro;
			defaultStyle.HeaderStyle.BackColor = Color.Silver;
			defaultStyle.HeaderStyle.ButtonColor = Color.Gainsboro;
			defaultStyle.HeaderStyle.FadeColor = Color.FromArgb(51, 51, 51);
			defaultStyle.HeaderStyle.ForeColor = Color.WhiteSmoke;
			return defaultStyle;
		}
	}
}
