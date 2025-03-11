using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace BASE.Model
{
	[Table("calculadora")]
	class Calculadora
	{

        [PrimaryKey] public String Id { get; set; }


        [MaxLength(100)] public String OrganizationName { get; set; }


        [MaxLength(100)] public String EmisionType { get; set; }


        [MaxLength(100)] public String EmisionName { get; set; }


        


        
    }
}

