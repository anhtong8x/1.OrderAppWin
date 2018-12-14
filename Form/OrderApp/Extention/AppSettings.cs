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
        // ip server api
        public static string ServerApi
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerApi"];
            }
        }

        // url login
        public static string LoginUrl
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["LoginUrl"];
            }
        }

		// url list table 
		public static string ListOrderTableUrl
		{
			get
			{
				return ServerApi + ConfigurationManager.AppSettings["ListOrderTableUrl"];
			}
		}
		
		// Bill by id table
		public static string BillByIdTableUrl
        {
			get
			{
				return ServerApi + ConfigurationManager.AppSettings["BillByIdTableUrl"];
			}
		}

		// List Detail Bill by idBill
		public static string DetailBillByIdBillUrl
		{
			get
			{
				return ServerApi + ConfigurationManager.AppSettings["DetailBillByIdBillUrl"];
			}
		}

        // Update quanity Bill 
        public static string UpdateQuanityBillUrl
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["UpdateQuanityBillUrl"];
            }
        }

        // Update status table 
        public static string UpdateStatusTableUrl
        {
            get
            {
                return ServerApi + ConfigurationManager.AppSettings["UpdateStatusTableUrl"];
            }
        }

		//UpdateQuanityBillDetailUrl
		public static string UpdateQuanityBillDetailUrl
		{
			get
			{
				return ServerApi + ConfigurationManager.AppSettings["UpdateQuanityBillDetailUrl"];
			}
		}

	}
}
