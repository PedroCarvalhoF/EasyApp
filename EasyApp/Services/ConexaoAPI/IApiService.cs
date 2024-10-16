using EasyApp.Models;
using EasyApp.Models.User;

namespace EasyApp.Services.ConexaoAPI;
public interface  IApiService
{
    Task<RequestResult<UsuarioLoginResponse>> Login(UsuarioLoginRequest usuarioLoginRequest);
}
