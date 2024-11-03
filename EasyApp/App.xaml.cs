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
            MainPage = new NavigationPage(new LoginPage(_apiService));

        }
    }
}
