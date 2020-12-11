using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_VisionTask.Model
{
    public class Cat_Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        [Column("Active", TypeName = "Bit")]
        public bool Active { get; set; }
    }
}
