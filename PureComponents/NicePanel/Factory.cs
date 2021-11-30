using System;
using System.Text;

namespace PureComponents.NicePanel
{
	internal sealed class Factory
	{
		private static Factory m_oInstance = null;

		private char[] BASE31 = "012345ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

		private short[] INDEX32 = new short[256]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, 0, 1,
			2, 3, 4, 5, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};

		private string m_sX = "qAs-E";

		private Factory()
		{
		}

		internal static Factory GetInstance()
		{
			if (m_oInstance == null)
			{
				m_oInstance = new Factory();
			}
			return m_oInstance;
		}

		private string ToBase31(string sBase64Value)
		{
			char[] array = new char[2 * sBase64Value.Length];
			for (int i = 0; i < sBase64Value.Length; i++)
			{
				array[2 * i] = BASE31[(int)sBase64Value[i] >> 4];
				array[2 * i + 1] = BASE31[sBase64Value[i] & 0xF];
			}
			string text = "";
			for (int j = 0; j < array.Length; j++)
			{
				text += array[j];
			}
			return text;
		}

		private string FromBase31(string sBase31Value)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(sBase31Value);
			byte[] array = new byte[(bytes.Length + 1) / 2];
			for (int i = 0; i < bytes.Length / 2; i++)
			{
				if (2 * i + 1 >= bytes.Length)
				{
					int num;
					if ((num = INDEX32[bytes[2 * i]]) < 0)
					{
						throw new Exception("Invalid licence key");
					}
					array[i] = (byte)(num << 4);
				}
				else
				{
					int num;
					int num2;
					if ((num = INDEX32[bytes[2 * i]]) < 0 || (num2 = INDEX32[bytes[2 * i + 1]]) < 0)
					{
						throw new Exception("Invalid licence key");
					}
					array[i] = (byte)(((byte)num << 4) | (byte)num2);
				}
			}
			return Encoding.ASCII.GetString(array);
		}

		private string ToBase64(string sBase31Value)
		{
			return sBase31Value;
		}

		internal string Generate(string A)
		{
			Random random = new Random((int)DateTime.Now.Ticks);
			int num = (int)(Math.Abs((double)random.Next()) / 100.0);
			Engine engine = new Engine(PAlgorithm.A);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(A);
			string source = num + "-" + ToBase31(engine.EE(stringBuilder.ToString(), num.ToString()));
			return ToBase31(engine.EE(source, m_sX));
		}

		internal string Generate2(string A)
		{
			Engine engine = new Engine(PAlgorithm.A);
			string text = engine.DD(FromBase31(A), m_sX);
			int num = text.IndexOf("-");
			string key = text.Substring(0, num);
			return engine.DD(FromBase31(text.Substring(num + 1)), key);
		}

		internal string Generate3(string A)
		{
			Engine engine = new Engine(PAlgorithm.A);
			return engine.DD(FromBase31(A), m_sX);
		}
	}
}
