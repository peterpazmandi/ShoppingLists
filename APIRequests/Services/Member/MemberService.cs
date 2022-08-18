using APIRequests.Accounts;
using APIRequests.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.Services.Member
{
    public sealed class MemberService : IMemberService
    {
        private readonly ShoppingListsHttpClient _client;
        private readonly IAccountStore _accountStore;

        public MemberService(ShoppingListsHttpClient client, IAccountStore accountStore)
        {
            _client = client;
            _accountStore = accountStore;
        }

        public async Task<IEnumerable<UsernameDto>> FindMembersByUsername(string username)
        {
            return await _client.GetAsync<IEnumerable<UsernameDto>>($"Member/FindMembersByUsername?username={username}", _accountStore.CurrentAccount.Token);
        }
    }
}
