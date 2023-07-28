using System.Security.Principal;

namespace IMS_API.Model
{
    public class T_QUOTATION_ITEM
    {
        //public Int64 Quotation_row_id { get; set; }   
        public string Quotation_no { get; set; }
        public int Row_id { get; set; }
        public string Item_name { get; set; }
        public string Size_name { get; set; }
        public string Style_name { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }
        public int Item_id { get; set; }
        public int Size_id { get; set; }
    }
}
