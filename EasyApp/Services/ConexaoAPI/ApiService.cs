using EasyApp.Models;
using EasyApp.Models.User;
using EasyApp.Services.Helpers;
using Microsoft.Extensions.Logging;
using RestSharp;
using System.Text.Json;

namespace EasyApp.Services.ConexaoAPI
{
    public class ApiService : IApiService
    {
        private readonly string _urlBase;
        private readonly JsonSerializerOptions _options;        
        private readonly ILogger<ApiService> _logger;

        public ApiService(ILogger<ApiService> logger)
        {
            _urlBase = ConexoesHelper.ConexaoApi;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };            
            _logger = logger;
        }
        public async Task<RequestResult<UsuarioLoginResponse>> Login(UsuarioLoginRequest usuarioLoginRequest)
        {
            try
            {
                var url = _urlBase + "account/login";
                using (RestClient client = new RestClient(url))
                {

                    RestRequest request = new RestRequest(url, Method.Post)
                    {
                        RequestFormat = DataFormat.Json
                    };

                    request.AddBody(usuarioLoginRequest);

                    RestResponse response = await client.ExecuteAsync(request);
                    if (response.StatusCode == 0)
                    {
                        throw new Exception(response.ErrorMessage);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        var resposta = JsonSerializer.Deserialize<RequestResult<UsuarioLoginResponse>>(response.Content, _options);

                        return resposta ?? new RequestResult<UsuarioLoginResponse>();
                    }

                    return new RequestResult<UsuarioLoginResponse>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
