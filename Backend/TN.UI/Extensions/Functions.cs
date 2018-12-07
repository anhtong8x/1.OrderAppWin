using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using TN.Domain.Model;
namespace Microsoft.AspNetCore.Mvc.Rendering
{
    public static class LabelExtensions
    {
        public static IHtmlContent EnumGetDisplayName(this IHtmlHelper helper, Enum value)
        {
            Type enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            MemberInfo member = enumType.GetMember(enumValue)[0];
            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }
            return new HtmlString(string.Format("{0}", outString));
        }
        public static IHtmlContent DateToString(this IHtmlHelper helper, DateTime? value, string type = "")
        {
            if (value == null) return new HtmlString("");
            else
            {
                return new HtmlString(value?.ToString("dd/MM/yyyy"));
            }
        }
        public static IHtmlContent GetOrder(this IHtmlHelper helper, int i, int page)
        {
            return new HtmlString(((page - 1) + i).ToString());
        }
        public static IHtmlContent DisplayStatus(this IHtmlHelper helper, int i, int page)
        {
            return new HtmlString(((page - 1) + i).ToString());
        }
    }
}
static class StaticExtensions
{
        public static void ForEach<T>(this IEnumerable<T> ie, Action<T> action)
        {
            foreach (var i in ie)
            {
                action(i);
            }
        }
    //public static string GetStringVaule(this Enum value)
    //{
    //    return ((int)value).ToString();
    //}
    public static string GetDisplayName(this Enum value)
        {
            Type enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            System.Reflection.MemberInfo member = enumType.GetMember(enumValue)[0];

            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }
            return outString;
        }
    public static string DateToString(this DateTime? value, string type="")
    {
        if (value == null) return "";
        else
        {
            return value?.ToString("dd/MM/yyyy");
        }
    }
}
namespace TN.UI.Extensions
{
    public class EntityExtention<T> where T:class
    {
        public static Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> a)
        {
            return a;
        }
    }

    public class MapModel<O> where O : new()
    {
        public static O Go<I>(I input)
        {
            var result = new O();
            try
            {
                IList<PropertyInfo> iProps = new List<PropertyInfo>(input.GetType().GetProperties());
                IList<PropertyInfo> oProps = new List<PropertyInfo>(result.GetType().GetProperties());
                foreach (PropertyInfo prop in iProps)
                {
                    foreach (PropertyInfo item in oProps)
                    {
                        if (prop.Name == item.Name)
                        {
                            if (item.PropertyType.FullName.Contains(prop.PropertyType.Name) || prop.PropertyType.FullName.Contains(item.PropertyType.Name) || prop.PropertyType.FullName== item.PropertyType.Name)
                            {
                                item.SetValue(result, prop.GetValue(input, null));
                            }
                            continue;
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }
            return default(O);
        }
    }
    
    public class Functions
    {
      

        public static int DateTimeToUnixTimestamp(DateTime dateTime)
        {
            TimeSpan span = (TimeSpan)(dateTime.ToUniversalTime() - new DateTime(0x7b2, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            return (int)span.TotalSeconds;
        }
        public static double CalcuDistance(double srcLong, double srcLat, double desLong, double desLat)
        {
            double num = srcLong * 0.017453292519943295;
            double d = srcLat * 0.017453292519943295;
            double num3 = desLong * 0.017453292519943295;
            double num4 = desLat * 0.017453292519943295;
            double num5 = num3 - num;
            double num6 = num4 - d;
            double num7 = Math.Pow(Math.Sin(num6 / 2.0), 2.0) + ((Math.Cos(d) * Math.Cos(num4)) * Math.Pow(Math.Sin(num5 / 2.0), 2.0));
            double num8 = 2.0 * Math.Atan2(Math.Sqrt(num7), Math.Sqrt(1.0 - num7));
            return (6378.5 * num8);
        }
        public static bool CheckInLocation(double srcLong, double srcLat, double desLong, double desLat, double Rkm)
        {
            if (CalcuDistance(srcLong, srcLat, desLong, desLat) > Rkm)
            {
                return false;
            }
            return true;
        }
      
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime time = new DateTime(0x7b2, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return time.AddSeconds(unixTimeStamp).ToLocalTime();
        }



        public static int GenSTT(int cstt,int page)
        {
            return (page - 1) + cstt;
        }
        public static LogUserModel GetLogUser(string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<LogUserModel>(data);
            }
            catch
            {
                return null;
            }
        }
        private static string identString = "";
        public static string FormatJson(string str)
        {
            var indent = 0;
            var quoted = false;
            var sb = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                switch (ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, ++indent).ForEach(item => sb.Append(identString));
                        }
                        break;
                    case '}':
                    case ']':
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, --indent).ForEach(item => sb.Append(identString));
                        }
                        sb.Append(ch);
                        break;
                    case '"':
                        sb.Append(ch);
                        bool escaped = false;
                        var index = i;
                        while (index > 0 && str[--index] == '\\')
                            escaped = !escaped;
                        if (!escaped)
                            quoted = !quoted;
                        break;
                    case ',':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, indent).ForEach(item => sb.Append(identString));
                        }
                        break;
                    case ':':
                        sb.Append(ch);
                        if (!quoted)
                            sb.Append(" ");
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }
            return sb.ToString();
        }
        public static string FormatReturnUrl(string returnUrl, string urlDefault)
        {
            try
            {
                return string.IsNullOrEmpty(returnUrl) ? urlDefault : returnUrl.ToString();
            }
            catch
            {
                return urlDefault;
            }
        }
       
        public static string ToJson(object data)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(data, serializerSettings);
            return json;
        }
        public static long ConvertToUnixTime(DateTime datetime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (long)(datetime - sTime).TotalSeconds;
        }

        public static double DistanceInMeter(double lat1, double lon1, double lat2, double lon2)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(Deg2rad(lat1)) * Math.Sin(Deg2rad(lat2)) + Math.Cos(Deg2rad(lat1)) * Math.Cos(Deg2rad(lat2)) * Math.Cos(Deg2rad(theta));
            dist = Math.Acos(dist);
            dist = Rad2deg(dist);
            dist = dist * 60 * 1.1515;

            // meter
            dist = dist * 1.609344 * 1000;

            return (dist);
        }

        private static double Deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private static double Rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
        public static double ConvertToDouble(string input,string type)
        {
            try
            {
             return Convert.ToDouble(input, CultureInfo.GetCultureInfo(type).NumberFormat);
            }
            catch
            {
                return 0;
            }
        }
        public static string ConvertDoubleToString(double input, string type)
        {
            try
            {
                return input.ToString(CultureInfo.GetCultureInfo(type).NumberFormat); ;
            }
            catch
            {
                return "0";
            }
        }
    }
}
