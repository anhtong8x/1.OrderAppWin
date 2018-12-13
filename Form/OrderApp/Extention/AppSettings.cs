using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Extention
{
    public class AppSettings
    {
        // 1. ip server api
        public static string ServerApi
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerApi"];
            }
        }

        // 2. url login
        public static string LoginUrl
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["LoginUrl"];
            }
        }

		// 3. url login
		public static string ListOrderTableUrl
		{
			get
			{
				return ServerApi + ConfigurationManager.AppSettings["ListOrderTableUrl"];
			}
		}
		
		// Uurl login
		public static string OrderTableByIdUrl
		{
			get
			{
				return ServerApi + ConfigurationManager.AppSettings["OrderTableByIdUrl"];
			}
		}

		// Uurl login
		public static string DetailBillByIdBillUrl
		{
			get
			{
				return ServerApi + ConfigurationManager.AppSettings["DetailBillByIdBillUrl"];
			}
		}

	}
}
