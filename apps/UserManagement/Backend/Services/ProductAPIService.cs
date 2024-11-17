using System.Text.Json;
using Backend.DTOs.WithID;
using Backend.Services.ServiceInterfaces;

namespace Backend.Services;

public class ProductAPIService: IProductAPIService
{
    private readonly string _productsApi = "http://ProductManagementService/";
    private readonly HttpClient _httpClient;

    public ProductAPIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<SubsidiaryUsersDTO>?> GetUsersBySubsidiaryId(Guid id)
    {
        
        string url = $"{_productsApi}SubsidiaryUsers/subsidiary/{id}";    
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<SubsidiaryUsersDTO>>(content);
    }

    public async Task<List<SubsidiaryUsersDTO>?> GetUsersByCompanyId(Guid id)
    {
        string url = $"{_productsApi}Subsidiary/company/{id}";
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        List<SubsidiaryDTO>? jsonContent = JsonSerializer.Deserialize<List<SubsidiaryDTO>>(content);
        List<SubsidiaryUsersDTO> users = new List<SubsidiaryUsersDTO>();
        if (jsonContent != null)
            foreach (SubsidiaryDTO subsidiaryDto in jsonContent)
            {
                var subUsers = await GetUsersBySubsidiaryId(subsidiaryDto.subsidiaryId);
                if (subUsers != null)
                {
                    users.AddRange(subUsers);    
                }
            }
        return users;
    }

    public async Task<Guid?> GetCompanyIdByUserId(Guid userId)
    {
        var jsonContent = await GetSubsidiariesUsersByUserId(userId);
        
        if (jsonContent != null)
        {
            string companyUrl = $"{_productsApi}Subsidiary/{jsonContent.First().subsidiaryId}";
            HttpResponseMessage companyResponse = await _httpClient.GetAsync(companyUrl);
            companyResponse.EnsureSuccessStatusCode();
            string companyContent = await companyResponse.Content.ReadAsStringAsync();
            var jsonCompanyContent = JsonSerializer.Deserialize<SubsidiaryDTO>(companyContent);
            return jsonCompanyContent?.companyId;
        }

        return null;
    }

    public async Task<List<SubsidiaryUsersDTO>?> GetSubsidiariesUsersByUserId(Guid userId)
    {
        
        string url = $"{_productsApi}SubsidiaryUsers/user/{userId}";    
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        var jsonContent = JsonSerializer.Deserialize<List<SubsidiaryUsersDTO>>(content);
        return jsonContent;
    }

    public async Task<List<Guid>?> GetSubsidiariesIdsByUserId(Guid userId)
    {
        string url = $"{_productsApi}SubsidiaryUsers/user/{userId}";    
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();
        var jsonContent = JsonSerializer.Deserialize<List<SubsidiaryUsersDTO>>(content);
        if (jsonContent?.Count > 0)
        {
            return jsonContent.Select(dto => dto.subsidiaryId).ToList();
        }
        return null;
    }
}
