using Utgiftshantering.DataAccess;
using Utgiftshantering.Entities;
using Utgiftshantering.Factory;

namespace Utgiftshantering.ViewModel
{
	public class MainViewModel : BaseViewModel
	{
		public InvoiceViewModel InvoiceViewModel { get; set; }
		public RegistrateCompanyViewModel RegistrateCompanyViewModel { get; set; }
		public RegistratePersonViewModel RegistratePersonViewModel { get; set; }
		public RegistrateInvoiceViewModel RegisterInvoiceViewModel { get; set; }
		public LoginViewModel LoginViewModel { get; set; }

		public MainViewModel()
		{
			var personData = new PersonDataAccess(RepositoryFactory<Person>.GetRepository());
			var companyData = new CompanyDataAccess(RepositoryFactory<Company>.GetRepository());
			var invoiceData = new InvoiceDataAccess(RepositoryFactory<Invoice>.GetRepository(), RepositoryFactory<InvoiceRow>.GetRepository());
			var userData = new UserDataAccess(RepositoryFactory<User>.GetRepository());

			RegistratePersonViewModel = new RegistratePersonViewModel(personData);
			RegistrateCompanyViewModel = new RegistrateCompanyViewModel(companyData);
			RegisterInvoiceViewModel = new RegistrateInvoiceViewModel(invoiceData, companyData, personData);
			InvoiceViewModel = new InvoiceViewModel(invoiceData);


			userData.AddUser("admin", "admin");
			LoginViewModel = new LoginViewModel(userData);
		}

		public override void Update()
		{
			RegistrateCompanyViewModel.Update();
			RegistratePersonViewModel.Update();
			RegisterInvoiceViewModel.Update();
			InvoiceViewModel.Update();
		}
	}
}