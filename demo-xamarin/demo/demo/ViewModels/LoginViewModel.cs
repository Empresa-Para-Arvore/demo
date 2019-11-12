using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using demo.Models;
using demo.Views;
using ModernHttpClient;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace demo.ViewModels {
    public class LoginViewModel : BaseViewModel {
        private Page _page;
        public UserLogin User { get; } = new UserLogin();
        public LoginViewModel(Page page) {
            this._page = page;
            this.LoginCommand = new Command(async () => await Login());
        }
        
        private async Task Login() {
            var httpClient = new HttpClient(new NativeMessageHandler());
            
            var json = JsonConvert.SerializeObject(this.User);

            try {
                var resp = await httpClient.PostAsync($"{App.BaseUrl}/login",
                    new StringContent(json, Encoding.UTF8, "application/json"));
                var UserLogged = JsonConvert.DeserializeObject<User>(await resp.Content.ReadAsStringAsync());

                if (resp.IsSuccessStatusCode) {
                    await this._page.Navigation.PushModalAsync(new NavigationPage(new ItemsPage(UserLogged)));
                }
            }
            catch (Exception e) {
                Debug.Write(e);
            }
        }
        
        public ICommand LoginCommand { private set; get; }
    }
}