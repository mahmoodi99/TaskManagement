using Share.Dto;
using System.Text.Json;

namespace UI.ServiceHttp
{
    public class FilterHttpService : IFilterHttpService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public FilterHttpService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<ActivityGetDto>> GetByfilter(string filter)
        {
            var response = await _client.GetAsync($"Search/{filter}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var unit = JsonSerializer.Deserialize<List<ActivityGetDto>>(content, _options);
            return unit;
        }
    }
}
