using Share.Dto;
using System.Text;
using System.Text.Json;

namespace UI.ServiceHttp
{
    public class StatusHttpService : IStatusHttpService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public StatusHttpService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        
        public async Task<List<StatusDto>> GetStatus()
        {
            var response = await _client.GetAsync("Status");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var status = JsonSerializer.Deserialize<List<StatusDto>>(content, _options);
            return status;
        }

        public async Task<StatusDto> GetById(string Id)
        {
            var response = await _client.GetAsync($"Status/{Id}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var status = JsonSerializer.Deserialize<StatusDto>(content, _options);
            return status;
        }
        public async Task Delete(Guid Id)
        {
            await _client.DeleteAsync($"Status/{Id}");
        }
       
        public async Task Insert(StatusDto status)
        {
            var statusJson = new StringContent(JsonSerializer.Serialize(status), Encoding.UTF8, "application/json");
            await _client.PostAsync("Status", statusJson);
        }

        public Task<bool> IsExist(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(StatusDto status)
        {
            var statusJson = new StringContent(JsonSerializer.Serialize(status), Encoding.UTF8, "application/json");
            await _client.PutAsync("Status", statusJson);
        }
    }
}
