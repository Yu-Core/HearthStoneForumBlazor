using Blazored.LocalStorage;
using HearthStoneForum.Client.Utility;
using Microsoft.AspNetCore.Components.Authorization;
using SqlSugar;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using HearthStoneForum.Model.DTORest;
using HearthStoneForum.Model.DTOAdd;

namespace HearthStoneForum.Client.Service
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }


        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<ApiResult<string>> Login(UserInfoDTOLogin loginModel)
        {
            var result = await _httpClient.PostAsJsonAsync("https://localhost:7243/api/Authoize/login", loginModel);
            var loginResult = result.Content.ReadFromJsonAsync<ApiResult<string>>().Result;

            if (! loginResult.Successful)
            {
                return loginResult;
            }

            await _localStorage.SetItemAsync("authToken", loginResult.Data);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginResult.Data);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Data);

            return loginResult;
        }

        public async Task<ApiResult<string>> Register(UserInfoDTOAdd registerModel)
        {
            var result = await _httpClient.PostAsJsonAsync("userInfos", registerModel);

            return result.Content.ReadFromJsonAsync<ApiResult<string>>().Result;
        }
    }

}
