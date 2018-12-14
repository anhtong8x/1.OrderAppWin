using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TN.StudentBus.Office.Extention
{
    public class DALContext
    {
        private static readonly TaskFactory _myTaskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);
        public static T RunSync<T>(Func<Task<T>> func)
        {
            CultureInfo cultureUi = CultureInfo.CurrentUICulture;
            CultureInfo culture = CultureInfo.CurrentCulture;
            return _myTaskFactory.StartNew<Task<T>>(delegate
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = cultureUi;
                return func();
            }).Unwrap<T>().GetAwaiter().GetResult();
        }
        public static async Task<bool> IsLoginAsync(string token)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(new {  });
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.PostAsync(AppSettings.IsLoginUrl, stringContent);
                if(t.IsSuccessStatusCode)
                {
                    var data = await t.Content.ReadAsStringAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static async Task<ApiResponseData<UserInfoModel>> LoginAsync(string username,string password)
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
        public static async Task<List<SchoolModel>> FindSchool(string token)
        {

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(new {});
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.GetAsync(AppSettings.SchoolUrl);
                if (t.IsSuccessStatusCode)
                {
                    var data = await t.Content.ReadAsStringAsync();
                    var dataO=  JsonConvert.DeserializeObject<ApiResponseData<List<SchoolModel>>>(data);
                    return dataO.Data;
                }
                else
                {
                    return new List<SchoolModel>();
                }
            }
        }
        public static async Task<List<ClassOfSchoolModel>> FindClassOfSchool(string token,int schoolId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(new {   });
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.GetAsync(string.Format(AppSettings.ClassOfSchoollUrl,schoolId));
                if (t.IsSuccessStatusCode)
                {
                    var data = await t.Content.ReadAsStringAsync();
                    var dataO = JsonConvert.DeserializeObject<ApiResponseData<List<ClassOfSchoolModel>>>(data);
                    return dataO.Data;
                }
                else
                {
                    return new List<ClassOfSchoolModel>();
                }
            }
        }
        public static async Task<ApiResponseData<List<StudentModel>>> FindStudent(string token, int page,int limit,string key, int schoolId, int classOfSchoolId, bool? status)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(new { });
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.GetAsync(string.Format(AppSettings.StudentUrl, page, limit, key, schoolId, classOfSchoolId, status));
                if (t.IsSuccessStatusCode)
                {
                    var data = await t.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ApiResponseData<List<StudentModel>>>(data);
                    
                }
                else
                {
                    return new ApiResponseData<List<StudentModel>>() {Data = new List<StudentModel>() };
                }
            }
        }
        public static async Task<StudentModel> StudentById(string token, int studentId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(new { });
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.GetAsync(string.Format(AppSettings.StudentByIdUrl, studentId));
                if (t.IsSuccessStatusCode)
                {
                    var data = await t.Content.ReadAsStringAsync();
                    var dataO = JsonConvert.DeserializeObject<ApiResponseData<StudentModel>>(data);
                    return dataO.Data;
                }
                else
                {
                    return null;
                }
            }
        }
        public static async Task<int> StudentCreate(string token, StudentModel use)
        {
			using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(AppSettings.StudentCreate);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(use);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.PostAsync(AppSettings.StudentCreate, stringContent);
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
        public static async Task<int> StudentUpdate(string token, StudentModel use)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(AppSettings.StudentUpdate);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(use);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.PutAsync(AppSettings.StudentUpdate, stringContent);
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
        public static async Task<int> StudentDelete(string token, int studentId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(AppSettings.StudentDelete);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(new { });
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.DeleteAsync(string.Format(AppSettings.StudentDelete, studentId));
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
        public static async Task<List<StudentModel>> StudentFingerPrints(string token)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(new { });
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.GetAsync(AppSettings.StudentFingerPrints);
                if (t.IsSuccessStatusCode)
                {
                    var data = await t.Content.ReadAsStringAsync();
                    var dataO = JsonConvert.DeserializeObject<ApiResponseData<List<StudentModel>>>(data);
                    return dataO.Data;
                }
                else
                {
                    return new List<StudentModel>();
                }
            }
        }
        public static async Task<StudentModel> StudentByFinger(string token, int fingerId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(new { });
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.GetAsync(string.Format(AppSettings.StudentByFinger, fingerId));
                if (t.IsSuccessStatusCode)
                {
                    var data = await t.Content.ReadAsStringAsync();
                    var dataO = JsonConvert.DeserializeObject<ApiResponseData<StudentModel>>(data);
                    return dataO.Data;
                }
                else
                {
                    return null;
                }
            }
        }
        public static async Task<int> StudentUpdateFinger(string token, int studentId, int stt, string template)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(AppSettings.ServerApi);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(new { });
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var t = await httpClient.PostAsync(string.Format(AppSettings.StudentUpdateFinger, studentId, stt, template), stringContent);
                if (t.IsSuccessStatusCode)
                {
                    var data = await t.Content.ReadAsStringAsync();
                    var dataO = JsonConvert.DeserializeObject<ApiResponseData<StudentModel>>(data);
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
