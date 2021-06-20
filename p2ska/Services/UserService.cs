using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using p2ska.Extensions;
using p2ska.Models;

namespace p2ska.Services
{
    public class UserService
    {
        private readonly string _username;
        private readonly string _password;
        private readonly string _dbUrl;
        private readonly string _email;
        private readonly HttpClient _httpClient;

        public UserService()
        {
            _username = Environment.GetEnvironmentVariable("USERNAME");
            _password = Environment.GetEnvironmentVariable("PASSWORD");
            _dbUrl = Environment.GetEnvironmentVariable("DB_URL");
            _email = Environment.GetEnvironmentVariable("EMAIL");
            _httpClient = new HttpClient();
        }

        public async Task<Response> GetResponse()
        {
            return await SendRequest(RequestContent());
        }

        private StringContent RequestContent()
        {
            var request = new Request()
            {
                Email = _email
            };
            return new StringContent(request.ToJson(), Encoding.UTF8, "application/json");
        }

        private async Task<Response> SendRequest(StringContent stringContent)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", GetAuthorizationHeader());
            var httpResponse = await _httpClient.PostAsync(_dbUrl, stringContent);
            return JsonConvert.DeserializeObject<Response>(await httpResponse.Content.ReadAsStringAsync());
        }

        private string GetAuthorizationHeader()
        {
            var bytes = Encoding.ASCII.GetBytes($"{_username}:{_password}");
            var base64String = Convert.ToBase64String(bytes);
            var header = new AuthenticationHeaderValue("Basic", base64String).ToString();
            return header;
        }
    }
}