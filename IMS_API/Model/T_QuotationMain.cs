using System;
using System.ComponentModel.DataAnnotations;

namespace IMS_API.Model
{
    public class T_QuotationMain
    {
        public DateTime QUOTATION_DATE { get; set; }
        public string QUOTATION_NO { get; set; }
        public string customer_name { get; set; }
        public int Quantity { get; set; }
        public decimal discount { get; set; }
        public decimal Total { get; set; }
        public string user_name { get; set; }
        public int customer_id { get; set; }
        
        public string Status { get; set; }
    }
}
