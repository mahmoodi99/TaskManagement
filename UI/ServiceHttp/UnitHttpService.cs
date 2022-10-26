using Share.Dto;
using System.Text;
using System.Text.Json;

namespace UI.ServiceHttp
{
    public class UnitHttpService : IUnitHttpService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public UnitHttpService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<UnitDto>> GetUnit()
        {
            var response = await _client.GetAsync("Unit");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var unit = JsonSerializer.Deserialize<List<UnitDto>>(content, _options);
            return unit;
        }
        public async Task Delete(Guid Id)
        {
            await _client.DeleteAsync($"Unit/{Id}");
        }

        public async Task<UnitDto> GetById(string Id)
        {
            var response = await _client.GetAsync($"Unit/{Id}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var unit = JsonSerializer.Deserialize<UnitDto>(content, _options);
            return unit;
        }

        public async Task Insert(UnitDto unit)
        {
            var UnitJson = new StringContent(JsonSerializer.Serialize(unit), Encoding.UTF8, "application/json");
            await _client.PostAsync("Unit", UnitJson);
        }

        public Task<bool> IsExist(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(UnitDto unit)
        {
            var UnitJson = new StringContent(JsonSerializer.Serialize(unit), Encoding.UTF8, "application/json");
            await _client.PutAsync("Unit", UnitJson);
        }
    }
}
