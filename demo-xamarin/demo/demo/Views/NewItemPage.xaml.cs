using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using demo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace demo.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage {
        private readonly NewItemViewModel _newItemViewModel;
        public NewItemPage() {
            InitializeComponent();
            this.BindingContext = _newItemViewModel = new NewItemViewModel(this);
            
            InitializeTags();
        }

        async Task InitializeTags() {
            await this._newItemViewModel.FetchTags();
            
            double fixedTagWidth = 85;
            double fixedTagHeight = 30;

            int nColumns = (int)Math.Floor(Application.Current.MainPage.Width / fixedTagWidth);
            int nRows = (int)Math.Ceiling((double)this._newItemViewModel.Tags.Count / nColumns);

            for (var i = 0; i < nRows; i++) {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (var j = 0; j < nColumns; j++) {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            var currentItem = 0;
            for (var i = 0; i < nRows; i++) {
                for (var j = 0; j < nColumns; j++, currentItem++) {
                    if (currentItem >= this._newItemViewModel.Tags.Count) return; 
                    
                    var btn = new Button() {
                        WidthRequest = fixedTagWidth,
                        Text = this._newItemViewModel.Tags[currentItem].Description,
                        VerticalOptions = LayoutOptions.Center,  
                        HorizontalOptions = LayoutOptions.Center,
                        BorderWidth = 1,
                        CornerRadius = 10,
                        BorderColor = Color.RoyalBlue
                    };

                    btn.Clicked += clicked;
                    
                    grid.Children.Add(btn, j, i);
                }
            }
        }

        void clicked(object sender, EventArgs e) {
            var btn = (Button) sender;
            var selectedTag = this._newItemViewModel.Tags.First(t => t.Description.Equals(btn.Text)).Description;
            
            if (btn.BackgroundColor == Color.Gray) {
                 btn.BackgroundColor = Color.Transparent;
                 btn.TextColor = Color.Default;
                 this._newItemViewModel.Item.Tags.Remove(selectedTag);     
            }
            else {
                btn.BackgroundColor = Color.Gray;
                btn.TextColor = Color.White;
                this._newItemViewModel.Item.Tags.Add(selectedTag);
            }
        }
        
    }
}