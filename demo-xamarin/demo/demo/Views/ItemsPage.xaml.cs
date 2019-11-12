using demo.Models;
using demo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace demo.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage {
        private readonly ItemsViewModel _itemsViewModel;
        public ItemsPage(User userLogged) {
            InitializeComponent();

            BindingContext = this._itemsViewModel = new ItemsViewModel(this, userLogged);
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem != null) {
                Navigation.PushAsync(new ShowItemPage((Item) e.SelectedItem));
            }

            list.SelectedItem = null;
        }
    }
}