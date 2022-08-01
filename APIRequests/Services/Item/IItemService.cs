using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests.Services.Item
{
    public interface IItemService
    {
        Task<T> UpdateItemBoughtStateById<T>(int itemId, bool bought);
    }
}
