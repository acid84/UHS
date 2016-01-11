using System;
using System.Windows.Input;
using Utgiftshantering.Extensions;

namespace Utgiftshantering.Commands
{
	public class RelayCommand : ICommand
	{
		private readonly Action _handler;

		public RelayCommand(Action handler)
		{
			_handler = handler;
		}

		private bool _isEnabled;
		public bool IsEnabled
		{
			get { return _isEnabled; }
			set
			{
				if (value != _isEnabled)
				{
					_isEnabled = value;

					CanExecuteChanged.SafeRaise(this, EventArgs.Empty);
				}
			}
		}

		public bool CanExecute(object parameter)
		{
			return IsEnabled;
		}

		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
			_handler();
		}
	}
}