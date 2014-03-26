using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4
{
    [Table("Users")]
    class User
    {
    [PrimaryKey, Unique]
        public string name { get; set; }
        public string email { get; set; }
    }
}
