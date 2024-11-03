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

    private void ConfiguraSpinner(bool ativar)
    {

    }
    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        // Exibe o spinner
        spinner.IsVisible = true;
        spinner.IsRunning = true;
        btnLogin.IsEnabled = false; // Desativa o botão de login para evitar múltiplos cliques
        txtEmail.IsEnabled = false;
        txtSenha.IsEnabled = false;

        try
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
                // await Navigation.PushAsync(new InicialPage());

                Application.Current!.MainPage = new AppShell();
            }
        }
        catch
        {
            await DisplayAlert("Erro", "Erro ao tentar efetuar login. Tente mais tarde.", "Ok");
        }
        finally
        {
            spinner.IsVisible = false;
            spinner.IsRunning = false;
            btnLogin.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtSenha.IsEnabled = true;
        }
    }
}
