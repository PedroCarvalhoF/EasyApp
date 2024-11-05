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
        try
        {
            var result = await _apiService.Login(new Models.User.UsuarioLoginRequest(txtEmail.Text, txtSenha.Text));

            if (!result.Status)
                await DisplayAlert("Atenção", result.Mensagem, "Vou verificar.");
            else
            {
                Preferences.Set("accestoken", result.Data!.accessToken);
                Preferences.Set("usuarioId", result.Data.IdUser.ToString());
                Preferences.Set("usuarioNome", result.Data.Nome);
                await DisplayAlert("Login", "Login Realizado com Sucesso.", "ok");
                Application.Current!.MainPage = new AppShell();
            }

        }
        catch (System.Reflection.TargetInvocationException ex)
        {
            Console.WriteLine("Erro: " + ex.InnerException?.Message);
            Console.WriteLine("Stack Trace: " + ex.InnerException?.StackTrace);
            await DisplayAlert("Erro", "Ocorreu um erro inesperado. Tente novamente.", "Ok");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro Geral: " + ex.Message);
            Console.WriteLine("Stack Trace: " + ex.StackTrace);
            await DisplayAlert("Erro", "Ocorreu um erro inesperado. Tente novamente.", "Ok");
        }


    }

    private void btnCadastro_Clicked(object sender, EventArgs e)
    {

    }
}