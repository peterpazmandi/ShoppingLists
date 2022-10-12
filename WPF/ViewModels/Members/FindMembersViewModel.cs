using APIRequests.DTOs;
using APIRequests.Services;
using APIRequests.Services.Member;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Commands;

namespace WPF.ViewModels.Members
{
    public class FindMembersViewModel : ViewModelBase
    {
        #region Variables

        private ObservableCollection<UsernameDto> _foundMembers = new ObservableCollection<UsernameDto>(Enumerable.Empty<UsernameDto>());
        public ObservableCollection<UsernameDto> FoundMembers
        {
            get { return _foundMembers; }
            set
            {
                _foundMembers = value;
                OnPropertyChanged(nameof(FoundMembers));
            }
        }

        private string _findMemberText;
        public string FindMemberText
        {
            get { return _findMemberText; }
            set
            {
                HandleFindMemberTextChange(value);
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

        public IUnitOfWork _unitOfWork { get; set; }

        #endregion Variables



        #region Commands

        public ICommand AddMemberCommand { get; set; }

        #endregion Commands


        public FindMembersViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Methods

        private void HandleFindMemberTextChange(string value)
        {
            if (value.Length > 0)
            {
                _findMemberText = value;
            }

            //HasMembersListArrived = value.Length > 0;

            if (value.Length > 2)
            {
                HasMembersListArrived = false;
                IsLoading = true;
                Task.Run(async () =>
                {
                    var members = await FindMembersByUsername();
                    await UpdateMembersList(members);
                    //SetHasMembersListArrived(members);
                    IsLoading = false;
                    OnPropertyChanged(nameof(FindMemberText));
                });
            }
            else
            {
                HasMembersListArrived = false;

                Task.Run(async () =>
                {
                    await UpdateMembersList(Enumerable.Empty<UsernameDto>());
                });
            }
        }

        public void SetHasMembersListArrived(IEnumerable<UsernameDto> members)
        {
            if (members.Count() == 1 && members.First().Username.ToLower().Equals(_findMemberText.ToLower()))
            {
                HasMembersListArrived = false;
            }
            else
            {
                HasMembersListArrived = true;
            }
        }

        public async Task<IEnumerable<UsernameDto>> FindMembersByUsername()
        {
            return await _unitOfWork.MemberService.FindMembersByUsername(_findMemberText);
        }

        private async Task UpdateMembersList(IEnumerable<UsernameDto> foundMembers)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(delegate
            {
                FoundMembers.Clear();

                foreach (var member in foundMembers)
                {
                    FoundMembers.Add(member);
                }
            });
        }

        #endregion Methods
    }
}
