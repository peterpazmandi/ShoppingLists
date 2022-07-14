using SimpleTrader.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Commands;
using WPF.State.Authenticator;

namespace WPF.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        private string _username = "pazpeti";
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(CanLogin));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanLogin));
            }
        }

        public bool CanLogin => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);


        public ICommand LoginCommand { get; }
        public ICommand ViewRegisterCommand { get; }


        public LoginViewModel(IAuthenticator authenticator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            this.LoginCommand = new LoginCommand(this, authenticator);
        }


        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();

            base.Dispose();
        }
    }
}
