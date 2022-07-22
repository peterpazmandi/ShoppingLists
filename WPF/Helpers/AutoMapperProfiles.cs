using APIRequests.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
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
            CreateMap<ShoppingListDto, ShoppingListViewModel>().ReverseMap();
        }
    }
}
