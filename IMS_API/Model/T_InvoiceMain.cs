namespace IMS_API.Model
{
    public class T_InvoiceMain
    {
        public DateTime Invoice_Date { get; set; }
        public string Invoice_no { get; set; }
        public string customer_name { get; set; }
        public int Quantity { get; set; }
        public decimal discount { get; set; }
        public decimal Sub_Total { get; set; }
        public decimal transports { get; set; }
        public decimal loading { get; set; }
        public decimal sgst { get; set; }
        public decimal cgst { get; set; }
        public decimal igst { get; set; }
        public decimal net_amount { get; set; }
        public string user_name { get; set; }
        public int customer_id { get; set; }
        public int company_id { get; set; }
        public string Status { get; set; }
    }
}
