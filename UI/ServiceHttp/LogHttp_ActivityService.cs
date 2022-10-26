using Share.Dto;
using System.Text.Json;

namespace UI.ServiceHttp
{
    public class LogHttp_ActivityService : ILogHttp_ActivityService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public LogHttp_ActivityService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<Log_ActivityGetDto>> GetLog()
        {
            var response = await _client.GetAsync("log_Activity");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var log = JsonSerializer.Deserialize<List<Log_ActivityGetDto>>(content, _options);
            return log;
        }

        public async Task Delete(Guid Id)
        {
            await _client.DeleteAsync($"log_Activity/{Id}");
        }

        public async Task<Log_ActivityGetDto> GetById(string Id)
        {
            var response = await _client.GetAsync($"log_Activity/{Id}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var log = JsonSerializer.Deserialize<Log_ActivityGetDto>(content, _options);
            return log;
        }
    }
}
