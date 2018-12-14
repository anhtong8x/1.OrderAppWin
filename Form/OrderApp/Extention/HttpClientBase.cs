using Newtonsoft.Json;
using OrderApp.Extention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
	public class HttpClientBase<T> where T : class
	{

		public static async Task<List<T>> Gets(string url)
		{

			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
				httpClient.DefaultRequestHeaders.Accept.Clear();

				var json = JsonConvert.SerializeObject(new { });
				var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
				var t = await httpClient.GetAsync(url);
				if (t.IsSuccessStatusCode)
				{
					var data = await t.Content.ReadAsStringAsync();
					var dataO = JsonConvert.DeserializeObject<ApiResponseData<List<T>>>(data);
					return dataO.Data;
				}
				else
				{
					return new List<T>();
				}
			}
		}

		public static async Task<T> Get(string url)
		{

			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
				httpClient.DefaultRequestHeaders.Accept.Clear();

				var json = JsonConvert.SerializeObject(new { });
				var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
				var t = await httpClient.GetAsync(url);
				if (t.IsSuccessStatusCode)
				{
					var data = await t.Content.ReadAsStringAsync();
					var dataO = JsonConvert.DeserializeObject<ApiResponseData<T>>(data);
					return dataO.Data;
				}
				else
				{
					return null;
				}
			}
		}

		public async static Task<int> Put(string url, T obj, string token)
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(url);
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var json = JsonConvert.SerializeObject(obj);
				var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
				var t = await httpClient.PutAsync(url, stringContent);
				if (t.IsSuccessStatusCode)
				{
					var data = await t.Content.ReadAsStringAsync();
					var dataO = JsonConvert.DeserializeObject<ApiResponseData<T>>(data);
					return dataO.Output;
				}
				else
				{
					return 0;
				}
			}
		}

		public async static Task<int> Post(string url, T obj, string token)
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(url);
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var json = JsonConvert.SerializeObject(obj);
				var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
				var t = await httpClient.PostAsync(url, stringContent);
				if (t.IsSuccessStatusCode)
				{
					var data = await t.Content.ReadAsStringAsync();
					var dataO = JsonConvert.DeserializeObject<ApiResponseData<T>>(data);
					return dataO.Output;
				}
				else
				{
					return 0;
				}
			}
		}

		public async static Task<int> Delete(string url, int id, string token)
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(url);
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var json = JsonConvert.SerializeObject(new { });
				var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
				var t = await httpClient.DeleteAsync(string.Format(url, id));
				if (t.IsSuccessStatusCode)
				{
					var data = await t.Content.ReadAsStringAsync();
					var dataO = JsonConvert.DeserializeObject<ApiResponseData<object>>(data);
					return dataO.Output;
				}
				else
				{
					return 0;
				}
			}
		}



	}
}
