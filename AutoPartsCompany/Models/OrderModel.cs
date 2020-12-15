using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsCompany.Models
{
    public class OrderModel
    {
        [Key]
        public int IdOrder { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public DateTime date { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public String Description { get; set; }
    }
}
