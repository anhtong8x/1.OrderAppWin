using Newtonsoft.Json;
using OrderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Extention
{
    public class DALContext
    {
        // login
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

		// get all table
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

		// get Bill by id tatabl
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
				var t = await httpClient.GetAsync(string.Format(AppSettings.BillByIdTableUrl, idTable));
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
				var t = await httpClient.GetAsync(string.Format(AppSettings.DetailBillByIdBillUrl, idBill));
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

        // update bill
        public static async Task<int> UpdateBill(string token, BillModel _billModel )
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(new {
                    _billModel.Id, _billModel.CashierId, _billModel.CashierName, _billModel.WaitersId, _billModel.WaiterName,
                    _billModel.Paid, _billModel.Money, _billModel.CreateDate, _billModel.Note, _billModel.TableId
                });
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.PostAsync(AppSettings.UpdateQuanityBillUrl, stringContent);
                if (t.IsSuccessStatusCode)
                {
                    var data = await t.Content.ReadAsStringAsync();
                    var dataO = JsonConvert.DeserializeObject<ApiResponseData<BillModel>>(data);
                    return dataO.Output;
                }
                else
                {
                    return 0;
                }
            }
        }

        // update status table
        public static async Task<int> UpdateTable(string token, TableModel _tableModel)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(new
                {
                    _tableModel.Id, 
                    _tableModel.Name,
                    _tableModel.Note,
                    _tableModel.Status
                });
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.PostAsync(AppSettings.UpdateQuanityBillUrl, stringContent);
                if (t.IsSuccessStatusCode)
                {
                    var data = await t.Content.ReadAsStringAsync();
                    var dataO = JsonConvert.DeserializeObject<ApiResponseData<BillModel>>(data);
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
