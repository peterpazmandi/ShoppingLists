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
            System.Console.WriteLine($"userId: {username}, shoppingListId: {shoppingListId}");
            if (_tracker.OnShoppingListOpened(username, shoppingListId))
            {
                System.Console.WriteLine($"userId: {username}, shoppingListId: {shoppingListId}");
                return Clients.All.SendAsync("OpenedShoppingList", "Success", "Success");
            }

            return null;
        }
    }
}