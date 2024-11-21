using System.Text;
using System.Text.Json;
using Backend.DTOs.WithID;
using Backend.Services.ServiceInterfaces;

namespace Backend.Services;

public class UserAPIService: IUserAPIService
{
    private readonly string _userAPI = "http://UserManagementService/";
    private readonly HttpClient _httpClient;

    public UserAPIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool?> IsUserAdminOrHigher(Guid userId)
    {
        string url = $"{_userAPI}User/isAdminOrHigher/{userId}";    
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        return bool.TryParse(content, out bool result) ? result : null;
    }

    public async Task<bool?> IsUserOwnerOrHigher(Guid userId)
    {
        
        string url = $"{_userAPI}User/isOwnerOrHigher/{userId}";    
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        return bool.TryParse(content, out bool result) ? result : null;
    }

    public async Task<bool> IsTokenValid(ValidateTokenDTO token)
    {
        
        string url = $"{_userAPI}Token/IsTokenValid/";    
        string jsonContent = JsonSerializer.Serialize(token);

        // Crear el contenido del POST
        var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync(url, stringContent);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        return bool.TryParse(content, out bool result) && result;
    }
}