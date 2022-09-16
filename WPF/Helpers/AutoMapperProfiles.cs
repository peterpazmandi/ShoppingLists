using APIRequests.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.ViewModels;

namespace WPF.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ShoppingListDto, ShoppingListViewModel>();
            CreateMap<ShoppingListViewModel, UpdateShoppingListDto>().ReverseMap();
            CreateMap<UsernameDto, UserViewModel>().ReverseMap();
            CreateMap<UserViewModel, string>();
            CreateMap<ItemDto, ItemViewModel>().ReverseMap();
        }
    }
}
