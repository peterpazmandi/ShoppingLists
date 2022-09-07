using APIRequests.Services.ShoppingList;
using SimpleTrader.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Commands;
using WPF.State.Authenticator;
using WPF.State.Navigators;
using WPF.ViewModels.Factories;

namespace WPF.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        public bool IsLoggedIn => _authenticator.IsLoggedIn;

        public readonly INavigator Navigator;

        private readonly IAuthenticator _authenticator;

        public ViewModelBase CurrentViewModel => Navigator.CurrentViewModel;
        public ICommand UpdateCurrentViewModelCommand { get; }
        public ICommand HomeCommand { get; }


        public MainViewModel(
            IViewModelFactory viewModelFactory, 
            INavigator navigator, 
            IAuthenticator authenticator, 
            IRenavigator homeRenavigator)
        {
            Navigator = navigator;

            Navigator.StateChanged += Navigator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);

            HomeCommand = new HomeCommand(homeRenavigator);

            _authenticator = authenticator;
            _authenticator.StateChanged += Authenticator_StateChanged;
        }





        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }
        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public override void Dispose()
        {
            Navigator.StateChanged -= Navigator_StateChanged;

            base.Dispose();
        }
    }
}
