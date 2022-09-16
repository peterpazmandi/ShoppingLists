using APIRequests.DTOs;
using APIRequests.Services.Member;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Commands;

namespace WPF.ViewModels
{
    public class FindMembersViewModel : ViewModelBase
    {
        #region Variables

        private ObservableCollection<UsernameDto> _members = new ObservableCollection<UsernameDto>(Enumerable.Empty<UsernameDto>());
        public ObservableCollection<UsernameDto> Members
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
                this.HandleFindMemberTextChange(value);
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


        private string _selectedMember;
        public string SelectedMember
        {
            get { return _selectedMember; }
            set
            {
                if (value != null)
                {
                    _selectedMember = value;
                    OnPropertyChanged(nameof(SelectedMember));
                }
            }
        }

        public IMemberService _memberService { get; set; }

        #endregion Variables



        #region Commands

        public ICommand AddMemberCommand { get; set; }
        public ICommand RemoveMemberCommand { get; set; }

        #endregion Commands


        public FindMembersViewModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        #region Methods

        private void HandleFindMemberTextChange(string value)
        {
            if (value.Length > 0)
            {
                this._findMemberText = value;
            }

            if (value.Length > 2)
            {
                this.HasMembersListArrived = false;
                this.IsLoading = true;
                Task.Run(async () =>
                {
                    var members = await FindMembersByUsername();
                    await this.UpdateMembersList(members);
                    this.SetHasMembersListArrivedIfMembersCountOneEqualsToFindMemberText(members);
                    this.IsLoading = false;
                    OnPropertyChanged(nameof(FindMemberText));
                });
            }
            else
            {
                this.HasMembersListArrived = false;

                Task.Run(async () =>
                {
                    await this.UpdateMembersList(Enumerable.Empty<UsernameDto>());
                });
            }
        }

        public void SetHasMembersListArrivedIfMembersCountOneEqualsToFindMemberText(IEnumerable<UsernameDto> members)
        {
            if (members.Count() == 1 && members.First().Username.ToLower().Equals(_findMemberText.ToLower()))
            {
                this.HasMembersListArrived = false;
            }
            else
            {
                this.HasMembersListArrived = true;
            }
        }

        public async Task<IEnumerable<UsernameDto>> FindMembersByUsername()
        {
            return await _memberService.FindMembersByUsername(_findMemberText);
        }

        private async Task UpdateMembersList(IEnumerable<UsernameDto> foundMembers)
        {
            App.Current.Dispatcher.Invoke((System.Action)delegate
            {
                this.Members.Clear();

                foreach (var member in foundMembers)
                {
                    this.Members.Add(member);
                }
            });
        }

        #endregion Methods
    }
}
