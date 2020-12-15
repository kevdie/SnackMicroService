using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsCompany.Models
{
    public class ProductsModel
    {
        [Key]
        public int IdProduct { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        public int Price { get; set; }
        public int IdOrder { get; set; }
        
       

    }
}
