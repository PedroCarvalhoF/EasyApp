namespace EasyApp.Models.User;

public class UsuarioLoginRequest
{
    public UsuarioLoginRequest(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }

    public string Email { get; private set; }
    public string Senha { get; private set; }
}
