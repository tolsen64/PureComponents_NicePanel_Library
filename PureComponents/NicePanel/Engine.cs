using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PureComponents.NicePanel
{
	internal class Engine
	{
		internal static Encoding m_oDefaultEncoding = Encoding.GetEncoding(1250);

		private SymmetricAlgorithm m_oCryptoService;

		internal Engine(PAlgorithm eAlgorithm)
		{
			switch (eAlgorithm)
			{
			case PAlgorithm.A:
				m_oCryptoService = new DESCryptoServiceProvider();
				break;
			case PAlgorithm.B:
				m_oCryptoService = new RC2CryptoServiceProvider();
				break;
			case PAlgorithm.C:
				m_oCryptoService = new RijndaelManaged();
				break;
			}
		}

		private byte[] GetKey(string Key)
		{
			string s = Key;
			if (m_oCryptoService.LegalKeySizes.Length > 0)
			{
				int i = m_oCryptoService.LegalKeySizes[0].MinSize;
				if (m_oCryptoService.LegalKeySizes[0].SkipSize > 0)
				{
					for (; Key.Length * 8 > i; i += m_oCryptoService.LegalKeySizes[0].SkipSize)
					{
					}
				}
				if (Key.Length * 8 < i)
				{
					s = Key.PadRight(i / 8, ' ');
				}
				else if (Key.Length * 8 > i)
				{
					s = Key.Substring(0, (i + 7) / 8);
				}
			}
			return Encoding.ASCII.GetBytes(s);
		}

		internal string EE(string Source, string Key)
		{
			if (Source == "" || Source == null)
			{
				return "";
			}
			byte[] array = ((!IsUnicode(Source)) ? String2ByteArray(Source) : Encoding.Convert(Encoding.Unicode, m_oDefaultEncoding, Encoding.Unicode.GetBytes(Source)));
			m_oDefaultEncoding.GetString(array);
			Source = null;
			return EE(array, Key);
		}

		internal string EEUnicode(string Source, string Key)
		{
			if (Source == "" || Source == null)
			{
				return "";
			}
			byte[] aBytes = Encoding.Convert(Encoding.Unicode, m_oDefaultEncoding, Encoding.Unicode.GetBytes(Source));
			return EE(aBytes, Key);
		}

		internal string EE(string Source, string Key, Encoding oEncoding)
		{
			if (Source == "" || Source == null)
			{
				return "";
			}
			byte[] aBytes = Encoding.Convert(oEncoding, m_oDefaultEncoding, oEncoding.GetBytes(Source));
			Source = null;
			return EE(aBytes, Key);
		}

		internal string EE(byte[] aBytes, string Key)
		{
			if (aBytes == null)
			{
				return "";
			}
			return Convert.ToBase64String(EEByte(aBytes, Key));
		}

		internal byte[] EEByte(byte[] bytIn, string Key)
		{
			MemoryStream memoryStream = new MemoryStream();
			byte[] key = GetKey(Key);
			m_oCryptoService.Key = key;
			m_oCryptoService.IV = key;
			ICryptoTransform transform = m_oCryptoService.CreateEncryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytIn, 0, bytIn.Length);
			cryptoStream.FlushFinalBlock();
			bytIn = null;
			return memoryStream.ToArray();
		}

		internal string DD(string Source, string Key, Encoding oEncoding)
		{
			if (Source == "" || Source == null)
			{
				return "";
			}
			return oEncoding.GetString(Encoding.Convert(m_oDefaultEncoding, oEncoding, DDByte(Convert.FromBase64String(Source), Key)));
		}

		internal string DD(string Source, string Key)
		{
			if (Source == "" || Source == null)
			{
				return "";
			}
			try
			{
				return ByteArray2String(DDByte(Convert.FromBase64String(Source), Key));
			}
			catch
			{
				return Source;
			}
		}

		internal byte[] DDByte(string Source, string Key)
		{
			if (Source == "" || Source == null)
			{
				return null;
			}
			return DDByte(Convert.FromBase64String(Source), Key);
		}

		internal byte[] DDByte(byte[] bytIn, string Key)
		{
			MemoryStream stream = new MemoryStream(bytIn, 0, bytIn.Length);
			bytIn = null;
			byte[] key = GetKey(Key);
			m_oCryptoService.Key = key;
			m_oCryptoService.IV = key;
			ICryptoTransform transform = m_oCryptoService.CreateDecryptor();
			CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Read);
			BCollection bCollection = new BCollection();
			byte[] array = new byte[10240];
			int num;
			while ((num = cryptoStream.Read(array, 0, 10240)) == 10240)
			{
				bCollection.Add(array);
				array = new byte[10240];
			}
			if (num > 0)
			{
				bCollection.Add(array, 0, num);
			}
			return bCollection.Join();
		}

		internal bool IsUnicode(string strTestedString)
		{
			int length = strTestedString.Length;
			while (length-- > 0)
			{
				if (strTestedString[length] > 'ÿ')
				{
					return true;
				}
			}
			return false;
		}

		internal string ToBase64String(byte[] aBuffer, int nMaxLineLength)
		{
			string text = Convert.ToBase64String(aBuffer);
			int num = (text.Length - 1) / nMaxLineLength;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i <= num; i++)
			{
				stringBuilder.Append(text.Substring((i - 1) * nMaxLineLength, nMaxLineLength));
				stringBuilder.Append('\n');
			}
			stringBuilder.Append(text.Substring(num * nMaxLineLength));
			stringBuilder.Append('\n');
			return stringBuilder.ToString();
		}

		internal string ToHexStringSeperatedWithDoubleDot(byte[] aBytes)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in aBytes)
			{
				string text = b.ToString("X");
				if (!text.Equals("0") || stringBuilder.Length != 0)
				{
					stringBuilder.Append(':');
					if (text.Length == 1 && stringBuilder.Length != 0)
					{
						stringBuilder.Append('0');
					}
					stringBuilder.Append(text);
				}
			}
			if (stringBuilder.Length == 0 && aBytes.Length > 0)
			{
				return "0";
			}
			return stringBuilder.ToString();
		}

		internal static byte[] String2ByteArray(string strValue)
		{
			byte[] array = new byte[strValue.Length];
			int length = strValue.Length;
			while (length-- > 0)
			{
				array[length] = (byte)strValue[length];
			}
			return array;
		}

		internal static string ByteArray2String(byte[] strValue)
		{
			StringBuilder stringBuilder = new StringBuilder(strValue.Length, strValue.Length);
			for (int i = 0; i < strValue.Length; i++)
			{
				stringBuilder.Append((char)strValue[i]);
			}
			return stringBuilder.ToString();
		}
	}
}
