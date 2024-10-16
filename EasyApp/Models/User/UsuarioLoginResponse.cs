namespace EasyApp.Models.User;

public class UsuarioLoginResponse
{
    public bool sucesso => Erros.Count == 0;
    public List<string>? Erros { get; set; }
    public Guid IdUser { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? accessToken { get; set; }
    public string? refreshToken { get; set; }
}
