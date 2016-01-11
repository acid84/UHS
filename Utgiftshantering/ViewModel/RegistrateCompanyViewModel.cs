using GalaSoft.MvvmLight.Command;
using Utgiftshantering.Entities;
using Utgiftshantering.Interfaces;

namespace Utgiftshantering.ViewModel
{
	public class RegistrateCompanyViewModel : BaseViewModel
	{
		#region Members
		public Company Comp { get; private set; }
		private readonly ICompanyDataAccess _companyDataAccess;
		#endregion

		#region Construction
		public RegistrateCompanyViewModel(ICompanyDataAccess companyDataAccess)
		{
			_companyDataAccess = companyDataAccess;
			SaveCommand = new RelayCommand(Save, () => true);
			Update();
		}
		#endregion

		#region Methods
		public override void Save()
		{
			_companyDataAccess.SaveCompany(Comp);
			Update();
		}

		public override sealed void Update()
		{
			Comp = new Company();
			RaisePropertyChanged(() => Comp);
		}
		#endregion
	}
}
