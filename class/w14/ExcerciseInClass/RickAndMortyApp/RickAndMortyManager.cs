using System.Text.Json;

namespace RickAndMortyApp;

public class RickAndMortyManager
{
    private readonly HttpClient _httpClient;
    private const string ApiBaseUrl = "https://rickandmortyapi.com/api";

    public RickAndMortyManager()
    {
        _httpClient = new HttpClient();
    }

    public RickAndMortyManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Get character ID by name
    public async Task<Character> GetCharacterByNameAsync(string Name)
    {
        try
        {
            // Get one character by name
            var response = await _httpClient.GetAsync($"{ApiBaseUrl}/character/?name={Name}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var characterResponse = JsonSerializer.Deserialize<CharacterResponse>(
                content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true, AllowTrailingCommas = true }
            );

            var character = characterResponse?.Results.FirstOrDefault(c => c.Name.Equals(Name, StringComparison.OrdinalIgnoreCase));

            return character ?? new Character();
        }
        catch
        {
            return new Character();
        }
    }

    // Get all episodes filtered by character íd
    public async Task<List<Episode>> GetEpisodesByCharacterAsync(Character character) 
    {
        try
        {
            // Get all episodes (paged)
            var response = await _httpClient.GetAsync($"{ApiBaseUrl}/episode/");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var episodeResponse = JsonSerializer.Deserialize<EpisodeResponse>(
                content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true, AllowTrailingCommas = true }
            );

            var characterUrl = $"{ApiBaseUrl}/character/{character.Id}";

            return episodeResponse?.Results
                .Where(e => e.Characters != null && e.Characters.Contains(characterUrl))
                .ToList()
                ?? new List<Episode>();
        }
        catch
        {
            return new List<Episode>();
        }
    }
}
