using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using demo.Models;
using demo.Views;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace demo.ViewModels {
    public class NewItemViewModel : BaseViewModel {
        private Page _page;
        public Item Item { get; } = new Item();
        public ObservableCollection<Tag> Tags { get; private set; } = new ObservableCollection<Tag>();
        public ICommand SaveItemCommand { get; }

        public NewItemViewModel(Page page) {
            this._page = page;
            this.SaveItemCommand = new Command(SaveItem);
        }

        public async Task FetchTags() {
            var httpClient = new HttpClient();
            
            var resp = await httpClient.GetAsync($"{App.BaseUrl}/tag");
            var TangsOnBase = JsonConvert.DeserializeObject<List<Tag>>(await resp.Content.ReadAsStringAsync()); 
            if (resp.IsSuccessStatusCode) {
                this.Tags = new ObservableCollection<Tag>(TangsOnBase);    
            }
        }
        
        
        private void SaveItem() {
            MessagingCenter.Send(this, "AddItem", Item); 
            this._page.Navigation.PopAsync();
        }
    }
}