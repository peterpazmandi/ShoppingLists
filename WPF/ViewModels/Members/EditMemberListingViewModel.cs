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
        private readonly AsyncObservableCollection<EditMemberListingItemViewModel> _editMemberListingItemViews;
        public IEnumerable<EditMemberListingItemViewModel> EditMemberListingItemViewModels => _editMemberListingItemViews;

        public EditMemberListingViewModel(ICollection<UsernameDto> Members)
        {
            _editMemberListingItemViews = new();

            foreach (var member in Members)
            {
                AddMember(member);
            }
        }

        public void AddMember(UsernameDto member)
        {
            var editMemberListingItemViewModel = new EditMemberListingItemViewModel()
            {
                Username = member.Username
            };

            if (_editMemberListingItemViews.Where(x => x.Username.ToLower().Equals(member.Username.ToLower())).Count() == 0)
            {
                _editMemberListingItemViews.Add(editMemberListingItemViewModel);
            }
        }
    }
}
