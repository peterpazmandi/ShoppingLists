using APIRequests.DTOs;
using APIRequests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels.Members
{
    public class EditMemberListingViewModel: ViewModelBase
    {
        public event RemoveMemberDelegate _removeMember;



        private readonly AsyncObservableCollection<EditMemberListingItemViewModel> _editMemberListingItemViewModels;
        public IEnumerable<EditMemberListingItemViewModel> EditMemberListingItemViewModels => _editMemberListingItemViewModels;



        public EditMemberListingViewModel(ICollection<UsernameDto> Members)
        {
            _editMemberListingItemViewModels = new();
            _removeMember += RemoveMember;

            foreach (var member in Members)
            {
                AddMember(member);
            }
        }

        public void AddMember(UsernameDto member)
        {
            var editMemberListingItemViewModel = new EditMemberListingItemViewModel(_removeMember)
            {
                Username = member.Username
            };

            if (_editMemberListingItemViewModels.Where(x => x.Username.ToLower().Equals(member.Username.ToLower())).Count() == 0)
            {
                _editMemberListingItemViewModels.Add(editMemberListingItemViewModel);
            }
        }

        public void RemoveMember(UsernameDto member)
        {
            var memberToRemove = _editMemberListingItemViewModels
                                    .FirstOrDefault(x => x.Username.ToLower().Equals(member.Username.ToLower()));

            _editMemberListingItemViewModels.Remove(memberToRemove);
        }
    }
}
