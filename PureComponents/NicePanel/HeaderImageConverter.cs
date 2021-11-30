using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace PureComponents.NicePanel
{
	internal sealed class HeaderImageConverter : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException("null argument");
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				ConstructorInfo constructor = typeof(HeaderImage).GetConstructor(Type.EmptyTypes);
				if (constructor != null)
				{
					return new InstanceDescriptor(constructor, null, isComplete: false);
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
