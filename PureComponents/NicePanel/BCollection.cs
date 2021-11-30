using System;
using System.Collections;

namespace PureComponents.NicePanel
{
	internal class BCollection : ArrayList, ICollection, IEnumerable
	{
		internal int LengthInBytes
		{
			get
			{
				int num = 0;
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						byte[] array = (byte[])enumerator.Current;
						num += array.Length;
					}
					return num;
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
		}

		public override int Add(object value)
		{
			return Add((byte[])value);
		}

		internal int Add(byte[] value)
		{
			return base.Add(value);
		}

		internal int Add(byte[] value, int nStartIndex, int nLength)
		{
			byte[] array = new byte[nLength];
			for (int i = 0; i < nLength; i++)
			{
				array[i] = value[i + nStartIndex];
			}
			return base.Add(array);
		}

		internal int Add(byte b)
		{
			byte[] value = new byte[1];
			return Add(value);
		}

		internal byte[] Join()
		{
			byte[] array = null;
			lock (this)
			{
				int lengthInBytes = LengthInBytes;
				if (lengthInBytes == 0)
				{
					Clear();
					return null;
				}
				array = new byte[lengthInBytes];
				int num = 0;
				while (Count > 0)
				{
					((byte[])this[0]).CopyTo(array, num);
					num += ((byte[])this[0]).Length;
					RemoveAt(0);
				}
				Add(array);
				return array;
			}
		}
	}
}
