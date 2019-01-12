using System;
using bookstore.Core.Models;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

namespace bookstore.Client.Services
{
    public class StateContainer
    {
        private readonly LocalStorage _localStorage;

        public StateContainer(LocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        public UserModel CurrentUser
        {
            get => _localStorage.GetItem<UserModel>("current-user");
            set => _localStorage.SetItem("current-user", value);
        }

        public event Action OnChange;
        
        public void NotifyStateChanged() => OnChange?.Invoke();
    }
}
