using Share.Dto;
using System.Text.Json;
using System.Text;

namespace UI.ServiceHttp
{
    public class RoleHttpService : IRoleHttpService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public RoleHttpService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task Delete(Guid Id)
        {
            await _client.DeleteAsync($"Role/{Id}");
        }

        public async Task<RoleDto> GetById(string Id)
        {
            var response = await _client.GetAsync($"Role/{Id}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var role = JsonSerializer.Deserialize<RoleDto>(content, _options);
            return role;
        }

        public async Task<List<RoleDto>> GetRole()
        {
            var response = await _client.GetAsync("Role");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var role = JsonSerializer.Deserialize<List<RoleDto>>(content, _options);
            return role;
        }

        public async Task Insert(RoleDto role)
        {
            var roleJson = new StringContent(JsonSerializer.Serialize(role), Encoding.UTF8, "application/json");
            await _client.PostAsync("Role", roleJson);
        }

        public Task<bool> IsExist(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(RoleDto role)
        {
            var roleJson = new StringContent(JsonSerializer.Serialize(role), Encoding.UTF8, "application/json");
            await _client.PutAsync("Role", roleJson);
        }
    }
}
