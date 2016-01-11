using System;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using Utgiftshantering.Entities;
using Utgiftshantering.Interfaces;

namespace Utgiftshantering.ViewModel
{
	public class RegistratePersonViewModel : BaseViewModel
	{
		#region Members	
		private readonly IPersonDataAccess _personDataAccess;
		public Person Pers
		{
			get; private set;
		}
		#endregion

		#region Construction
		public RegistratePersonViewModel(IPersonDataAccess personDataAccess)
		{
			_personDataAccess = personDataAccess;
			SaveCommand = new RelayCommand(Save, () => true);
			Update();
		}
		#endregion

		#region Methods
		public override void Save()
		{
			Pers.Id = Guid.NewGuid();
			_personDataAccess.SavePerson(Pers);
			Update();
		}

		public override sealed void Update()
		{
			Pers = new Person();
			base.RaisePropertyChanged(() => Pers);
			//InvokePropertyChanged("Pers");
		}
		#endregion
	}
}
