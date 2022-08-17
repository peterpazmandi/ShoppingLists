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
                this.HasMembersListArrived = false;
                this.IsLoading = true;
                _findMemberText = value;
                Task.Run(async () =>
                {
                    await Task.Delay(3000);
                    OnPropertyChanged(nameof(FindMemberText));
                    this.HasMembersListArrived = true;
                    this.IsLoading = false;
                });
            }
        }

        private bool _hasMembersListArrived = false;
        public bool HasMembersListArrived
        {
            get { return _hasMembersListArrived; }
            set 
            { 
                _hasMembersListArrived = value;
                OnPropertyChanged(nameof(HasMembersListArrived));
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
