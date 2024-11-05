using EasyApp.Pages;
using EasyApp.Services.ConexaoAPI;

namespace EasyApp
{
    public partial class App : Application
    {
        private readonly IApiService _apiService;
        public App(IApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;            
            SetMainPage();
        }

        private void SetMainPage()
        {
            var accessToken = Preferences.Get("accessToken", string.Empty);
            if (string.IsNullOrEmpty(accessToken))
            {
                MainPage = new NavigationPage(new LoginPage(_apiService));
                return;
            }

            MainPage = new HomePage();
        }
    }
}
