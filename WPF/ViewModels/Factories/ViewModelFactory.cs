using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.State.Navigators;

namespace WPF.ViewModels.Factories
{
    public class ViewModelFactory: IViewModelFactory
    {
        private readonly CreateViewModel<RegisterViewModel> _createRegisterViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;


        public ViewModelFactory(CreateViewModel<RegisterViewModel> createRegisterViewModel, CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            _createRegisterViewModel = createRegisterViewModel;
            _createLoginViewModel = createLoginViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Register:
                    return _createRegisterViewModel();
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Home:
                    return null;
                    break;
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
