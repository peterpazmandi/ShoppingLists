﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    public class UserViewModel: ViewModelBase
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set 
            { 
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public UserViewModel()
        {

        }

        public UserViewModel(UserViewModel userViewModel)
        {
            Username = userViewModel.Username;
        }
    }
}
