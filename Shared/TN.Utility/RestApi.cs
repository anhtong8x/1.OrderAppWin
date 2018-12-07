using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TN.Utility
{
    public class RestApi
    {
        readonly HttpClient Http;
        string _baseAddress = "";

        public RestApi(string baseAddress)
        {
            _baseAddress = baseAddress;
            Http = new HttpClient();
            Http.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            //Http.DefaultRequestHeaders.Add("ClientId", AppSettings.ClientId);
            //Http.DefaultRequestHeaders.Add("Token", AppSettings.Token);
        }

        static ulong CreateHash64(string str)
        {
            byte[] utf8 = System.Text.Encoding.UTF8.GetBytes(str);

            ulong value = (ulong)utf8.Length;
            for (int n = 0; n < utf8.Length; n++)
            {
                value += (ulong)utf8[n] << ((n * 5) % 56);
            }
            return value;
        }

        protected async Task<T> SendRequestAsync<T>(HttpMethod method, string url, object data = null, CancellationToken ctoken = default(CancellationToken))
        {
            string json = "";
            var fileName = CreateHash64(url).ToString();

            try
            {
                var request = new HttpRequestMessage(method, new Uri(_baseAddress + url));
                if (method == HttpMethod.Post || method == HttpMethod.Put)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                }
                var response = await Http.SendAsync(request, ctoken).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                var byteArray = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                json = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);

            }
            catch (Exception ex)
            {
                Log.Error("RestApi_SendRequestAsync", $"Http request error: {ex.Message}, ex");
            }
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
