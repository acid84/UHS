using System;
using System.Windows.Data;
using Utgiftshantering.Entities;

namespace Utgiftshantering.Converters
{
	[ValueConversion(typeof(string), typeof(Company))]
	public class CompanyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var företag = value as string;

			if (företag != null)
			{
				return new Company { Name = företag };
			}

			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var company = value as Company;

			if (company != null)
			{
				return company.Name;
			}

			return string.Empty;
		}
	}
}
