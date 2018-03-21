using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace People.Models
{
    [Table("people")]
    public class Person
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }

        [MaxLength(250),Unique]
        public string name { get; set; }
    }
}
