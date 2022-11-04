using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.SignalR.Model;
using API.SignalR.Tracker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class ShoppingListHub: Hub
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ShoppingListOpeningTracker _tracker;

        public ShoppingListHub(IUnitOfWork unitOfWork, ShoppingListOpeningTracker tracker)
        {
            _unitOfWork = unitOfWork;
            _tracker = tracker;
        }


        public Task ShoppingListOpened(string username, int shoppingListId)
        {
            return Clients.Others.SendAsync("OpenedShoppingList", "Success", "Success");
        }
        public Task UpdateItemBoughtStateById(UpdateItemBoughtDto updateItemBoughtDto)
        {
            System.Console.WriteLine(updateItemBoughtDto);
            return Clients.All.SendAsync("OnItemBoughtStateChanged", updateItemBoughtDto);
        }
    }
}