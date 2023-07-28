using System.ComponentModel.DataAnnotations;

namespace IMS_API.Model
{
    public class QuotationDTO
    {

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
}
