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
        private AsyncObservableCollection<EditMemberListingItemViewModel> _membersList;

        public AsyncObservableCollection<EditMemberListingItemViewModel> MembersList
        {
            get { return _membersList; }
            set 
            {
                _membersList = value;
            }
        }

        public EditMemberListingViewModel(ICollection<UsernameDto> Members)
        {
            _membersList = new();

            foreach (var member in Members)
            {
                AddMember(member);
            }
        }

        public void AddMember(UsernameDto member)
        {
            MembersList.Add(new EditMemberListingItemViewModel() 
            { 
                Username = member.Username
            });
        }
    }
}
