using Share.Dto;
using System.Text;
using System.Text.Json;

namespace UI.ServiceHttp
{
    public  class UserHttpService : IUserHttpService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public UserHttpService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public UserDto User { get; private set; }

        public async Task Delete(Guid Id)
        {
            await _client.DeleteAsync($"User/{Id}");
        }

        public async Task<UserDto> GetById(string Id)
        {
            var response = await _client.GetAsync($"User/{Id}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var user = JsonSerializer.Deserialize<UserDto>(content, _options);
            return user;
        }

        public async Task<List<UserDto>> GetUser()
        {
            var response = await _client.GetAsync("User");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var user = JsonSerializer.Deserialize<List<UserDto>>(content, _options);
            return user;
        }

        public async Task Insert(UserDto user)
        {
            var userJson = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            await _client.PostAsync("User/Register", userJson);
        }

        public Task<bool> IsExist(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(UserDto user)
        {
            var userJson = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            await _client.PutAsync("User", userJson);
        }
    }
}
