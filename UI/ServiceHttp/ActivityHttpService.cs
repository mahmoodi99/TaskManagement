using Share.Dto;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace UI.ServiceHttp
{
    public class ActivityHttpService : IActivityHttpService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public ActivityHttpService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task Delete(Guid Id)
        {
            await _client.DeleteAsync($"Activity/{Id}");
        }

        public async Task Update(ActivityGetDto activity)
        {
            var activityJson = new StringContent(JsonSerializer.Serialize(activity), Encoding.UTF8, "application/json");
            await _client.PutAsync("Activity", activityJson);
        }

        public async Task<List<ActivityGetDto>> GetActivity()
        {
            var response = await _client.GetAsync("Activity");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var activity = JsonSerializer.Deserialize<List<ActivityGetDto>>(content, _options);
            return activity;
        }

        public async Task<ActivityGetDto> GetById(string Id)
        {
            var response = await _client.GetAsync($"Activity/{Id}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var activity = JsonSerializer.Deserialize<ActivityGetDto>(content, _options);
            return activity;
        }

        public async Task Insert(ActivityGetDto activity)
        {
            var activityJson = new StringContent(JsonSerializer.Serialize(activity), Encoding.UTF8, "application/json");
            await _client.PostAsync("Activity", activityJson);
        }

        public Task<bool> IsExist(Guid Id)
        {
            throw new NotImplementedException();
        }
      
    }
}


