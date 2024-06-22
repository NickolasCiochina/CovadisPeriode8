using DemoCovadis.Shared.Dtos;
using DemoCovadis.Shared.Requests;
using System.Net.Http.Json;
using System.Text.Json;

public class ReserveringHttpClient
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions jsonOptions;

    public ReserveringHttpClient(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient();
        client.BaseAddress = new Uri("https://localhost:7250/api/Reservering"); // Ensure correct base address

        jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<ReserveringDto[]> GetReserveringen()
    {
        var response = await client.GetAsync(string.Empty);

        if (!response.IsSuccessStatusCode)
        {
            return Array.Empty<ReserveringDto>();
        }

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ReserveringDto[]>(content, jsonOptions) ?? Array.Empty<ReserveringDto>();
    }

    public async Task<ReserveringRequest> CreateReservering(ReserveringRequest reservering)
    {
        var response = await client.PostAsJsonAsync(string.Empty, reservering);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<ReserveringRequest>();

            if (content == null)
            {
                throw new Exception("Error creating reservering: Response content is null");
            }

            return content;
        }
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error creating reservering: {response.StatusCode}, {errorContent}");
        }
    }
}
