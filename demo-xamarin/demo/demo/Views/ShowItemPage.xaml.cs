using System;
using demo.Models;
using demo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace demo.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowItemPage : ContentPage {
        private readonly ShowItemViewModel _showItemViewModel;
        public ShowItemPage(Item item) {
            InitializeComponent();
            
            this.BindingContext = _showItemViewModel = new ShowItemViewModel(this, item);
            InitializeTags();
        }
        
        void InitializeTags() {
            double fixedTagWidth = 85;
            double fixedTagHeight = 30;

            int nColumns = (int)Math.Floor(Application.Current.MainPage.Width / fixedTagWidth);
            int nRows = (int)Math.Ceiling((double)this._showItemViewModel.Item.Tags.Count / nColumns);

            for (var i = 0; i < nRows; i++) {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (var j = 0; j < nColumns; j++) {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            var currentItem = 0;
            for (var i = 0; i < nRows; i++) {
                for (var j = 0; j < nColumns; j++, currentItem++) {
                    if (currentItem >= this._showItemViewModel.Item.Tags.Count) return; 
                    
                    var btn = new Button() {
                        WidthRequest = fixedTagWidth,
                        Text = _showItemViewModel.Item.Tags[currentItem],
                        VerticalOptions = LayoutOptions.Center,  
                        HorizontalOptions = LayoutOptions.Center,
                        BorderWidth = 1,
                        CornerRadius = 10,
                        BorderColor = Color.RoyalBlue,
                        IsEnabled = false,
                        TextColor = Color.Black,
                    }; 
                    
                    grid.Children.Add(btn, j, i);
                }
            }
        }
    }
}