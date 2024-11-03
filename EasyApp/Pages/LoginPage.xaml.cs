using EasyApp.Services.ConexaoAPI;

namespace EasyApp.Pages;

public partial class LoginPage : ContentPage
{
    private readonly IApiService _apiService;

    public LoginPage(IApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
    }

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {

        var result = await _apiService.Login(new Models.User.UsuarioLoginRequest(txtEmail.Text, txtSenha.Text));

        if (!result.Status)
            await DisplayAlert("Atenção", result.Mensagem, "Vou verificar.");
        else
        {
            Preferences.Set("accestoken", result.Data.accessToken);
            Preferences.Set("usuarioId", result.Data.IdUser.ToString());
            Preferences.Set("usuarioNome", result.Data.Nome);
            await DisplayAlert("Login", "Login Realizado com Sucesso.", "ok");


        }
    }
}