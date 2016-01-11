using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Utgiftshantering.ValidationRules
{
    public class CompanyNameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string companyName = value as string;

			if(!string.IsNullOrEmpty(companyName))
			{
				if (companyName.Trim(' ').Length == 0)
				{
					return new ValidationResult(false, "Företagsnamn måste anges.");
				}

				if (!Regex.IsMatch(companyName, "^[a-zA-Z0-9åäöÅÄÖ ]+$"))
				{
					return new ValidationResult(false, "Företagsnamn kan enbart innehålla a-ö, A-Ö, 0-9 och mellanslag.");
				}

				return new ValidationResult(true, null);
			}

			return new ValidationResult(false, "Invalid.");
        }
    }
}
