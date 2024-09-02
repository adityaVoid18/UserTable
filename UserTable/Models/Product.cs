using System;
using System.Collections.Generic;

namespace UserTable.Models
{
    public partial class Product
    {
        public int SNo { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; } = null!;
    }
}
