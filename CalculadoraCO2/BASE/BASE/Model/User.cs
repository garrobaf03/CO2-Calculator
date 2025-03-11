using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;

namespace BASE.Model
{

    [Table ("user")]
    class User
    {
        [PrimaryKey, Unique] public int Id { get; set; }
        [MaxLength (100)] public string Name { get; set; }
        [MaxLength(100)] public string Address { get; set; }
        public DateTime Birthdate { get; set; }
        [MaxLength(20)] public string Username { get; set; }
        [MaxLength(20)] public string Password { get; set; }
        [MaxLength(80)] public string Email { get; set; }
    }
}
