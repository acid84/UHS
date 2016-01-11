using System.Windows;
using System.Windows.Input;
using Utgiftshantering.Commands;
using Utgiftshantering.Interfaces;

namespace Utgiftshantering.ViewModel
{
	public class LoginViewModel : BaseViewModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public bool Authenticated { get; set; }
		
		public ICommand LoginCommand { get; set; }

		private readonly IUserDataAccess _userDataAccess;

		public LoginViewModel(IUserDataAccess userDataAccess)
		{
			LoginCommand = new RelayCommand(Login) { IsEnabled = true};
			_userDataAccess = userDataAccess;
		}

		private void Login()
		{
			if (!string.IsNullOrEmpty(UserName))
			{
				var user = _userDataAccess.GetUserByName(UserName);

				if(user == null || user.Password != Password)
				{
					UpdateAuthenticated(false);
					MessageBox.Show("Login failed.");
					return;
				}

				UpdateAuthenticated(true);
				MessageBox.Show("Login accepted");
			}
			else
			{
				UpdateAuthenticated(false);
				MessageBox.Show("You must enter a username");
			}
		}

		private void UpdateAuthenticated(bool value)
		{
			Authenticated = value;
			RaisePropertyChanged(() => Authenticated);
		}
	}
}
