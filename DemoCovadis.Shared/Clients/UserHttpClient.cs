﻿using DemoCovadis.Shared.Dtos;
using System.Text.Json;

namespace DemoCovadis.Shared.Clients;

public class UserHttpClient
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions jsonOptions;

    public UserHttpClient(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient();
        client.BaseAddress = new Uri("https://localhost:7250/User");

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
            return [];
        }

        var content = await response.Content.ReadAsStringAsync();
        var users = JsonSerializer.Deserialize<UserDto[]>(content, jsonOptions);

        if (users is null)
        {
            return [];
        }

        return users;
    }
}