using System.Windows.Input;
using demo.Models;
using Xamarin.Forms;

namespace demo.ViewModels {
    public class ShowItemViewModel : BaseViewModel {
        public Page _page;
        public Item Item { get; }
        public ICommand DeleteItemCommand { get; }

        public ShowItemViewModel(Page page, Item item) {
            this._page = page;
            this.Item = item;
            
            this.DeleteItemCommand = new Command(DeleteItem);
        }

        private void DeleteItem() {
            MessagingCenter.Send(this, "RemoveItem", Item);
            this._page.Navigation.PopAsync();
        }
    }
}