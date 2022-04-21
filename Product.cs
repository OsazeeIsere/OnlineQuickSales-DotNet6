
using System.ComponentModel.DataAnnotations;

namespace OnlineQuickSales
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string? ProductName { get; set; }
        public int Quantity { get; set; }

        public double UnitCostPrice { get; set; }
        public double UnitSalesPrice { get; set; }

        //[Required(AllowEmptyStrings = true)]
        //public DateTime ExpiryDate { get; set; }

        //[Required(AllowEmptyStrings = true)]
        //public byte[] Barcode { get; set; }

        //public byte[]? Timestamp { get; set; }

    }
}
