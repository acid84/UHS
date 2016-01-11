using System;
using System.Collections.Generic;
using System.Windows.Data;
using Utgiftshantering.Entities;
using Utgiftshantering.UserControls.Graph;

namespace Utgiftshantering.Converters
{
    [ValueConversion(typeof(Company), typeof(GraphEntity))]
    public class CompanyToGraphEntityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var company = value as Company;

            if (company != null)
            {
                GraphEntity ge = new GraphEntity();

                ge.Name = company.Name;                
                ge.XAxisValues = new List<string>();
                ge.GraphLines = new List<GraphLineEntity>();                

                var sums = new List<double>();

                foreach (var invoiceRow in company.InvoiceRow)
                {                    
                    ge.XAxisValues.Add(invoiceRow.Invoice.Date.ToString());                    
                    sums.Add(invoiceRow.Sum);
                }

                ge.GraphLines.Add(new GraphLineEntity(ge.Name, "White", sums));

                return ge;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
