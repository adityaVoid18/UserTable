using System;
using System.Collections.Generic;

namespace UserTable.Models
{
    public partial class Bank
    {
        public int AcNo { get; set; }
        public string? Name { get; set; }
        public string? BankName { get; set; }
        public string? ImageFileName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
