using System;
using System.Collections.Generic;

namespace UserTable.Models
{
    public partial class UserDataTable
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
