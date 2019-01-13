using System;
using System.Collections.Generic;
using System.Linq;
using bookstore.Core.Models;
using bookstore.Shared.Entities;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

namespace bookstore.Client.Services
{
    public class StateContainer
    {
        private readonly LocalStorage _localStorage;

        public StateContainer(LocalStorage localStorage)
        {
            _localStorage = localStorage;

            var savedItems = _localStorage.GetItem<ShoppingCartItem[]>("sc-items");

            if (savedItems != null)
            {
                _shoppingCartItems?.AddRange(savedItems);
            }
        }

        public UserModel CurrentUser
        {
            get => _localStorage.GetItem<UserModel>("current-user");
            set => _localStorage.SetItem("current-user", value);
        }

        private readonly List<ShoppingCartItem> _shoppingCartItems = new List<ShoppingCartItem>();

        public IReadOnlyList<ShoppingCartItem> ShoppingCartItems => _shoppingCartItems;

        public void AddShoppingCartItem(ShoppingCartItem sci)
        {
            if (_shoppingCartItems.Any(x => x.Id == sci.Id))
            {
                ShoppingCartItem oldItem = _shoppingCartItems.First(x => x.Id == sci.Id);

                _shoppingCartItems.Remove(oldItem);
            }

            _shoppingCartItems.Add(sci);

            SaveShoppingCartItems();
        }

        public void AddShoppingCartItems(ICollection<ShoppingCartItem> sci)
        {
            _shoppingCartItems.AddRange(sci);

            SaveShoppingCartItems();
        }

        public void ClearShoppingCart()
        {
            _shoppingCartItems.Clear();

            SaveShoppingCartItems();
        }

        public void SaveShoppingCartItems()
        {
            _localStorage.SetItem("sc-items", _shoppingCartItems);

            NotifyStateChanged();
        }

        public event Action OnChange;
        
        public void NotifyStateChanged() => OnChange?.Invoke();
    }
}
