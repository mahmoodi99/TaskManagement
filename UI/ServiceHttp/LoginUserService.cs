using Microsoft.AspNetCore.Components;
using Share.Dto;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace UI.ServiceHttp
{    
    public class LoginUserService : ILoginUserService
    {
        private readonly HttpClient _client;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";

        public LoginUserService(HttpClient client,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService,
            IHttpClientFactory httpClientFactory
            )
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
            _httpClientFactory = httpClientFactory;
        }

        public LoginUserDto User { get; private set; }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<LoginUserDto>("user");
        }

        public async Task<string> login(LoginUserDto login)
        {
            var content = new StringContent(JsonSerializer.Serialize(login), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("User/Login", content);                        
            if (response.IsSuccessStatusCode)
            {
                return "Success";
            }
            else
            {
                return "failed";
            }
        }

        public async Task<string> Logout()
        {         
            //await _localStorageService.RemoveItem(_userKey);
            //_navigationManager.NavigateTo("account/login");


            var client = _httpClientFactory.CreateClient("API");
            var response = await client.PostAsync("/Auth/logout", null);
            if (response.IsSuccessStatusCode)
            {
                return "Success";
            }
            return "Failed";
        }

        public async Task<(string Message, UserDto? UserProfile)> UserProfileAsync()
        {
            //var client = _httpClientFactory.CreateClient("API");
            //client.DefaultRequestHeaders.Add()
            var response = await _client.GetAsync("User/userProfile");
            if (response.IsSuccessStatusCode)
            {
                return ("Success", await response.Content.ReadFromJsonAsync<UserDto>());
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return ("Unauthorized", null);
                }
                else
                {
                    return ("Failed", null);
                }
            }
        }
    }
}
