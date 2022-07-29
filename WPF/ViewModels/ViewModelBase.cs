using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel: ViewModelBase;

    public class ViewModelBase: INotifyPropertyChanged
    {
        public MessageViewModel ErrorMessageViewModel { get; set; }

        public ViewModelBase Owner { get; set; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }



        public virtual void Dispose() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
