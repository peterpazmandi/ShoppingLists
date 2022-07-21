using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIRequests
{
    public class ShoppingListsHttpClient
    {
        public readonly HttpClient _client;

        public ShoppingListsHttpClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> GetAsync<T>(string uri, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await _client.GetAsync(uri);
            string jsonResponse = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

        public async Task<T> PostAsync<T>(string uri, object requestObject)
        {
            string dataStr = JsonConvert.SerializeObject(requestObject);
            StringContent data = new StringContent(dataStr, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(
                    uri,
                    data);

            if (response.StatusCode != HttpStatusCode.NoContent && response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException(response.Content.ReadAsStringAsync().Result);
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                T responseObject = JsonConvert.DeserializeObject<T>(responseBody);
                return responseObject;
            }

            return default;
        }
    }
}