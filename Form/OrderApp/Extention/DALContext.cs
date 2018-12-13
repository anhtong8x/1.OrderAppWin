using Newtonsoft.Json;
using OrderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Extention
{
    public class DALContext
    {
        // 1. login
        public static async Task<ApiResponseData<UserInfoModel>> LoginAsync(string username, string password)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(new { username, password });
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.PostAsync(AppSettings.LoginUrl, stringContent);
                if (t.IsSuccessStatusCode)
                {
                    var data = await t.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ApiResponseData<UserInfoModel>>(data);
                }
                else
                {
                    return null;
                }
            }
        }

		// 2. get all table
		public static async Task<List<TableModel>> GetAllOrderTable()
		{

			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
				httpClient.DefaultRequestHeaders.Accept.Clear();
				//httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
				//httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var json = JsonConvert.SerializeObject(new { });
				var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
				var t = await httpClient.GetAsync(AppSettings.ListOrderTableUrl);
				if (t.IsSuccessStatusCode)
				{
					var data = await t.Content.ReadAsStringAsync();
					var dataO = JsonConvert.DeserializeObject<ApiResponseData<List<TableModel>>>(data);
					return dataO.Data;
				}
				else
				{
					return new List<TableModel>();
				}
			}
		}

		// 3. get Bill by id tatabl
		public static async Task<BillModel> GetBillByIdTable(int idTable)
		{

			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
				httpClient.DefaultRequestHeaders.Accept.Clear();
				//httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
				//httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var json = JsonConvert.SerializeObject(new { });
				var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
				var t = await httpClient.GetAsync(AppSettings.OrderTableByIdUrl);
				if (t.IsSuccessStatusCode)
				{
					var data = await t.Content.ReadAsStringAsync();
					var dataO = JsonConvert.DeserializeObject<ApiResponseData<BillModel>>(data);
					return dataO.Data;
				}
				else
				{
					return new BillModel();
				}
			}
		}

		// get list DetailBill by IdBill
		public static async Task<List<BillDetailModel>> GetsDetailBillByIdBill(int idBill)
		{

			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
				httpClient.DefaultRequestHeaders.Accept.Clear();

				var json = JsonConvert.SerializeObject(new { });
				var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
				var t = await httpClient.GetAsync(string.Format(AppSettings.ListOrderTableUrl,idBill));
				if (t.IsSuccessStatusCode)
				{
					var data = await t.Content.ReadAsStringAsync();
					var dataO = JsonConvert.DeserializeObject<ApiResponseData<List<BillDetailModel>>>(data);
					return dataO.Data;
				}
				else
				{
					return new List<BillDetailModel>();
				}
			}
		}

	}
}
