using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.StudentBus.Office.Extention
{
    public class BaseSearchModel<T> where T : class
    {
        public T Data { get; set; }
        public int TotalRows { get; set; } = 0;
        public int Limit { get; set; } = 10;
        public int Page { get; set; } = 1;
        public string ReturnUrl { get; set; }
    }
}
