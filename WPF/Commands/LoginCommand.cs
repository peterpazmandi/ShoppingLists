using APIRequests.Exceptions;
using Microsoft.Toolkit.Uwp.Notifications;
using SimpleTrader.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.State.Authenticator;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class LoginCommand: AsyncCommandBase
    {
        public readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator, IRenavigator renavigator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;

            _loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _loginViewModel.CanLogin && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _loginViewModel.ErrorMessage = String.Empty;

            try
            {
                await _authenticator.Login(_loginViewModel.Username, _loginViewModel.Password);

                //new ToastContentBuilder()
                //                .AddArgument("action", "viewConversation")
                //                .AddArgument("conversationId", 9813)
                //                .AddText("Successful login")
                //                .AddText($"Successfully logged in as: {_loginViewModel.Username}")
                //                .Show();

                _renavigator.Renavigate();
            }
            catch (Exception exception)
            {
                _loginViewModel.ErrorMessage = exception.Message;
            }
        }

        private void LoginViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.CanLogin))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
