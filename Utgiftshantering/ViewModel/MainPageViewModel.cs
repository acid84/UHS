using System.Collections.ObjectModel;
using Utgiftshantering.DataAccess;
using Utgiftshantering.Entities;
using Utgiftshantering.Factory;
using Utgiftshantering.UserControls.Graph;

namespace Utgiftshantering.ViewModel
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            CompanyDataAccess cda = new CompanyDataAccess(RepositoryFactory<Company>.GetRepository());
            Companys = new ObservableCollection<Company>(cda.LoadAllCompanies());
        }

        public ObservableCollection<Company> Companys { get; set; }
        public Company SelectedCompany { get; set; } 
    }
}
