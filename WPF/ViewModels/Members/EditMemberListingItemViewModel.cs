using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Commands;

namespace WPF.ViewModels.Members
{
    public class EditMemberListingItemViewModel: ViewModelBase
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }



        public ICommand RemoveMemberCommmand { get; set; }



        public EditMemberListingItemViewModel(RemoveMemberDelegate removeMember)
        {
            RemoveMemberCommmand = new RemoveMemberCommand(removeMember);
        }
    }
}
