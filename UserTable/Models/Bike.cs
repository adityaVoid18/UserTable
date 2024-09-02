using System;
using System.Collections.Generic;

namespace UserTable.Models
{
    public partial class Bike
    {
        public int Id { get; set; }
        public string BikeName { get; set; } = null!;
        public int ModelYear { get; set; }
        public string? ImageBase64 { get; set; }
        public string? ImageUrl { get; set; }
    }
}
