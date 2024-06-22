using DemoCovadis.Shared.Dtos;
using System.Text.Json;

namespace DemoCovadis.Shared.Clients;

public class UserHttpClient
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions jsonOptions;

    public UserHttpClient(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient();
        client.BaseAddress = new Uri("https://localhost:7250/api/User");

        jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<UserDto[]> GetUsers()
    {
        var response = await client.GetAsync(string.Empty);

        if (!response.IsSuccessStatusCode)
        {
            return Array.Empty<UserDto>();
        }

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<UserDto[]>(content, jsonOptions) ?? Array.Empty<UserDto>();
    }
}
