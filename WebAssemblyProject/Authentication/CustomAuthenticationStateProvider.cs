using Blazored.LocalStorage;
using Flurl.Util;
using Microsoft.AspNetCore.Components.Authorization;
using System.Globalization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace WebAssemblyProject.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorage, HttpClient http)
        {
            _localStorage = localStorage;
            _http = http;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string? token = await _localStorage.GetItemAsStringAsync("token");
            string? expiry = await _localStorage.GetItemAsStringAsync("expiry");
            string? refreshToken = await _localStorage.GetItemAsStringAsync("refreshToken");

            var identity = new ClaimsIdentity();

            _http.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(expiry))
            {
                string[] parts = expiry.Split(new char[] { 'T', '.' });

                var formattedExpireDate = DateTime.ParseExact((parts[0] + " " + parts[1]).Replace("\"", ""), "yyyy-MM-dd HH:mm:ss", null);

                if (formattedExpireDate > DateTime.Now)
                {
                    identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

                    _http.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
                }
                else
                {
                   await Logout();
                }
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            await _localStorage.RemoveItemAsync("expiry");
            await _localStorage.RemoveItemAsync("refreshToken");

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new(new ClaimsIdentity()))));
        }
    }

}
