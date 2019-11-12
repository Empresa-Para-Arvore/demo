using System.ComponentModel;
using demo.ViewModels;
using Xamarin.Forms;

namespace demo.Views {
    [DesignTimeVisible(true)]
    public partial class LoginPage : ContentPage {
        private readonly LoginViewModel _loginViewModel;
        public LoginPage() { 
            InitializeComponent();
            
            this.BindingContext = this._loginViewModel = new LoginViewModel(this);
        }
    }
}