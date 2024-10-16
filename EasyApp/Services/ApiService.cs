using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace EasyApp.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _urlBase = "";
    private readonly ILogger<ApiService> _logger;
    JsonSerializerOptions _serializerOptions;

    public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
    }
}
