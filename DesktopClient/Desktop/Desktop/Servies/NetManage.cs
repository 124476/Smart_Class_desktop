using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Servies
{
    public static class NetManage
    {
        public static HttpClient httpClient = new HttpClient();

        public static void SetBasicAuth(string username, string password)
        {
            var authToken = Encoding.ASCII.GetBytes($"{username}:{password}");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
        }

        public static async Task<T> Get<T>(string controller)
        {
            var response = await httpClient.GetAsync(App.host + controller);
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(content);
            return data;
        }
        public static async Task<HttpResponseMessage> Post<T>(string endpoint, T data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(App.host + endpoint, content);
            return response;
        }

        public static async Task<HttpResponseMessage> Put(string endpoint, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(App.host + endpoint, content);
            return response;
        }

        public static async Task<HttpResponseMessage> Patch(string endpoint, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(App.host + endpoint, content);
            return response;
        }

        public static async Task<HttpResponseMessage> Delete(string path)
        {
            var response = await httpClient.DeleteAsync(App.host + path);
            return response;
        }
        public static async Task<HttpResponseMessage> PatchAsync(string url, string jsonData)
        {
            using (var client = new HttpClient())
            {
                var method = new HttpMethod("PATCH");
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(method, App.host + url) { Content = content };

                var response = await client.SendAsync(request);

                string responseBody = await response.Content.ReadAsStringAsync();

                return response;
            }
        }
    }
}
