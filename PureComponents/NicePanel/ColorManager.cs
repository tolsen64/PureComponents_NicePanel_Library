using System;
using System.Drawing;

namespace PureComponents.NicePanel
{
	internal class ColorManager
	{
		internal class HLS
		{
			private double m_H;

			private double m_S;

			private double m_L;

			public double H
			{
				get
				{
					return m_H;
				}
				set
				{
					m_H = value;
					m_H = ((m_H > 1.0) ? 1.0 : ((m_H < 0.0) ? 0.0 : m_H));
				}
			}

			public double S
			{
				get
				{
					return m_S;
				}
				set
				{
					m_S = value;
					m_S = ((m_S > 1.0) ? 1.0 : ((m_S < 0.0) ? 0.0 : m_S));
				}
			}

			public double L
			{
				get
				{
					return m_L;
				}
				set
				{
					m_L = value;
					m_L = ((m_L > 1.0) ? 1.0 : ((m_L < 0.0) ? 0.0 : m_L));
				}
			}

			public HLS()
			{
				m_H = 0.0;
				m_S = 0.0;
				m_L = 0.0;
			}
		}

		public static Color SetBrightness(Color c, double brightness)
		{
			HLS hLS = RGB_to_HLS(c);
			hLS.L = brightness;
			return HLS_to_RGB(hLS);
		}

		public static Color ModifyBrightness(Color c, double brightness)
		{
			HLS hLS = RGB_to_HLS(c);
			hLS.L *= brightness;
			return HLS_to_RGB(hLS);
		}

		public static Color SetSaturation(Color c, double Saturation)
		{
			HLS hLS = RGB_to_HLS(c);
			hLS.S = Saturation;
			return HLS_to_RGB(hLS);
		}

		public static Color ModifySaturation(Color c, double Saturation)
		{
			HLS hLS = RGB_to_HLS(c);
			hLS.S *= Saturation;
			return HLS_to_RGB(hLS);
		}

		public static Color SetHue(Color c, double Hue)
		{
			HLS hLS = RGB_to_HLS(c);
			hLS.H = Hue;
			return HLS_to_RGB(hLS);
		}

		public static Color ModifyHue(Color c, double Hue)
		{
			HLS hLS = RGB_to_HLS(c);
			hLS.H *= Hue;
			return HLS_to_RGB(hLS);
		}

		public static Color HLS_to_RGB(HLS hls)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			if (hls.L == 0.0)
			{
				num = (num2 = (num3 = 0.0));
			}
			else if (hls.S == 0.0)
			{
				num = (num2 = (num3 = hls.L));
			}
			else
			{
				double num4 = ((hls.L <= 0.5) ? (hls.L * (1.0 + hls.S)) : (hls.L + hls.S - hls.L * hls.S));
				double num5 = 2.0 * hls.L - num4;
				double[] array = new double[3]
				{
					hls.H + 0.33333333333333331,
					hls.H,
					hls.H - 0.33333333333333331
				};
				double[] array2 = new double[3];
				double[] array3 = array2;
				for (int i = 0; i < 3; i++)
				{
					if (array[i] < 0.0)
					{
						double[] array4 = (array2 = array);
						int num6 = i;
						IntPtr intPtr = (IntPtr)num6;
						array4[num6] = array2[(long)intPtr] + 1.0;
					}
					if (array[i] > 1.0)
					{
						double[] array5 = (array2 = array);
						int num7 = i;
						IntPtr intPtr = (IntPtr)num7;
						array5[num7] = array2[(long)intPtr] - 1.0;
					}
					if (6.0 * array[i] < 1.0)
					{
						array3[i] = num5 + (num4 - num5) * array[i] * 6.0;
					}
					else if (2.0 * array[i] < 1.0)
					{
						array3[i] = num4;
					}
					else if (3.0 * array[i] < 2.0)
					{
						array3[i] = num5 + (num4 - num5) * (2.0 / 3.0 - array[i]) * 6.0;
					}
					else
					{
						array3[i] = num5;
					}
				}
				num = array3[0];
				num2 = array3[1];
				num3 = array3[2];
			}
			return Color.FromArgb((int)(255.0 * num), (int)(255.0 * num2), (int)(255.0 * num3));
		}

		public static HLS RGB_to_HLS(Color c)
		{
			HLS hLS = new HLS();
			hLS.H = (double)c.GetHue() / 360.0;
			hLS.L = c.GetBrightness();
			hLS.S = c.GetSaturation();
			return hLS;
		}
	}
}
