using APIRequests.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    public class FindMembersViewModel : ViewModelBase
    {
        private ObservableCollection<MemberDto> _members = new ObservableCollection<MemberDto>();
        public ObservableCollection<MemberDto> Members
        {
            get { return _members; }
            set 
            { 
                _members = value;
                OnPropertyChanged(nameof(Members));
            }
        }

        private string _findMemberText;
        public string FindMemberText
        {
            get { return _findMemberText; }
            set 
            { 
                _findMemberText = value;
                OnPropertyChanged(nameof(FindMemberText));
            }
        }


        public FindMembersViewModel()
        {
            this.Members.Add(new MemberDto("Peti"));
            this.Members.Add(new MemberDto("Viki"));
            this.Members.Add(new MemberDto("Dávid"));
        }
    }
}
