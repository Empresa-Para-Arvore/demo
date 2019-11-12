using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using demo.Models;
using demo.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace demo.ViewModels {
    public class ItemsViewModel : BaseViewModel {
        private Page _page;
        private User _userLogged;
        public ObservableCollection<Item> Items { get; set; }
        public Command AddItemCommand { get; private set; }

        public ItemsViewModel(Page page, User userLogged) {
            this._userLogged = userLogged;
            
            base.Title = userLogged.Name;
            this.Items = new ObservableCollection<Item>(userLogged.Items);
            _userLogged.Items = this.Items;
            
            this._page = page;
            this.AddItemCommand = new Command(async () => await AddItem());

            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "AddItem", async (obj, item) => {
                 Items.Add(item as Item);
                 await this.SendAddItem(item as Item);
            });
            
            MessagingCenter.Subscribe<ShowItemViewModel, Item>(this, "RemoveItem",  (obj, item) => {
                Items.Remove(item as Item);
            });
        }

        private async Task AddItem() {
            await this._page.Navigation.PushAsync(new NewItemPage());
        }

        private async Task SendAddItem(Item item) {
            var httpClient = new HttpClient();

            var req = new NewItemRequest() {
                UserId = this._userLogged.Id,
                item = new ItemRequest(item),
            };
            
            
            var json = JsonConvert.SerializeObject(req);
            var resp = await httpClient.PostAsync($"{App.BaseUrl}/users/item/", new StringContent(json,Encoding.UTF8, "application/json"));
            Debug.Write(resp);
        }
    }
}