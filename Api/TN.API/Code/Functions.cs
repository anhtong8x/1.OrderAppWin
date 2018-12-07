using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TN.API.Code
{
    public class Functions
    {
        public static double DateTimeToUnixTicks(DateTime? dt)
        {
            if (dt == null) return 0;
            TimeSpan epochTicks = new TimeSpan(new DateTime(1970, 1, 1).Ticks);
            TimeSpan unixTicks = new TimeSpan(dt.Value.Ticks) - epochTicks;
            return unixTicks.TotalSeconds;
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public static async Task<AddressResponse> GetLatLngOfAddress(string address, HttpClient httpClient)
        {
            int retry = 1;
            bool success = false;
            do
            {
                try
                {
                    string url = GenerateGeocodingAPI(address,retry);
                    using (var response = await httpClient.GetAsync(url))
                    {
                        var resultText = await response.Content.ReadAsStringAsync();
                        if (response.StatusCode == System.Net.HttpStatusCode.OK) // 200 - OK
                        {
                            var results = JsonConvert.DeserializeObject<AddressResponse>(resultText);
                            var result = results.results.FirstOrDefault();
                            if (result != null)
                            {
                                success = true;
                                return results;
                            }
                        }
                    }
                }
                catch
                {
                    throw;
                }

                if (!success)
                    Thread.Sleep(100);

                retry++;
            } while (!success || retry <= 3);

            return null;
        }

        

        private static string GenerateGeocodingAPI(string address,int retry)
        {
            string api = "https://maps.googleapis.com/maps/api/geocode/json?latlng={latlng}&amp;key={keygoogle}";
            api = api.Replace("{latlng}", address).Replace("{keygoogle}", ListKeyGoogleMap.FirstOrDefault(m=>m.Id==retry)?.Key);
            return api;
        }
        public static List<KeyGoogleMapModel> ListKeyGoogleMap
        {
            get
            {
                return new List<KeyGoogleMapModel>() {
                    new KeyGoogleMapModel{Id=1,Key = "AIzaSyALInyIlW4HSTWYInDtS0qDx8E2wwHiPvk"},
                    new KeyGoogleMapModel{Id=2,Key = "AIzaSyD9cAZzkYm28mKhRz_UfcqCJzjlG02xhGk"},
                    new KeyGoogleMapModel{Id=3,Key = "AIzaSyDqlOBVd5iJtrx4TGrwX5v-ViIrJYB9PfE"},
                };
            }
        }
    }
}
public class KeyGoogleMapModel
{
    public int Id { get; set; }
    public string Key { get; set; }
}
public class AddressResponse
{
    public List<Address> results { get; set; }
    public string status { get; set; }
}
public class Address
{
    public List<AddressComponents> address_components { get; set; }
    public string formatted_address { get; set; }
    public object geometry { get; set; }
    public string placeId { get; set; }
    public List<string> types { get; set; }
}
public class AddressComponents
{
    public string long_name { get; set; }
    public string short_name { get; set; }
    public List<string> types { get; set; }
}
public class  AddressStudent
{
    public string Key { get; set; }
    public List<AddressComponents> address_components { get; set; }
}
