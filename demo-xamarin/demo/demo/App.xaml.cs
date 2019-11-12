using System;
using demo.ViewModels;
using demo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MasterDetailPage = Xamarin.Forms.PlatformConfiguration.WindowsSpecific.MasterDetailPage;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace demo {
    public partial class App : Application {
        public static readonly string BaseUrl = Device.RuntimePlatform == Device.iOS ? "http://localhost:3000" : "http://10.0.2.2:3000";
        public App() {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}