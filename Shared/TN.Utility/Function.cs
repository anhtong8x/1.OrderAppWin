using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using log4net;
using System.Collections;
using System.Reflection;
using System.Xml;
using Newtonsoft.Json;

namespace TN.Utility
{
    public class Function
    {
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

        public static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        public static string GetBitStr(byte[] data)
        {
            BitArray bits = new BitArray(data);

            string strByte = string.Empty;
            for (int i = 0; i <= bits.Count - 1; i++)
            {
                if (i % 8 == 0)
                {
                    strByte += " ";
                }
                strByte += (bits[i] ? "1" : "0");
            }

            return strByte;
        }

        public static bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }
    }
}
