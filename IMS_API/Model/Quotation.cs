using System.ComponentModel.DataAnnotations;

namespace IMS_API.Model
{
    public class Quotation
    {

        public string QUOTATION_NO { get; set; }
        [Required]
        public DateTime QUOTATION_DATE { get; set; }
        [Required]
        public int company_id { get; set; }
        [Required]
        public int Quantity_main { get; set; }
        [Required]
        public decimal discount_main { get; set; }
        [Required]
        public decimal Total_main { get; set; }
        [Required]
        public string user_name { get; set; }
        [Required]
        public int customer_id { get; set; }
        
        [Required]
        public List<QUOTATION_ITEM> QuotationItemValue { get; set; }
    }
    public class QUOTATION_ITEM
    {
        //public string QUOTATION_NO { get; set; }
        [Required]
        public int Row_id { get; set; }
        [Required]
        public int Item_id { get; set; }
        [Required]
        public int Size_id { get; set; }
        public string Style { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Rate { get; set; }
        public decimal discount { get; set; }
        [Required]
        public decimal Total { get; set; }
    }
}
