namespace IMS_API.Model
{
    public class T_InvoiceItem
    {
        //public Int64 _row_id { get; set; }   
        public string Invoice_no { get; set; }
        public int Row_id { get; set; }
        public string Item_name { get; set; }
        public string Size_name { get; set; }
        public string Style_name { get; set; }
        public int BALANCE_Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }
        public int Item_id { get; set; }
        public int Size_id { get; set; }
    }
}
