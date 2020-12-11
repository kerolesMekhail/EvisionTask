using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_VisionTask.ProductRequest
{
    public class PostProductRequest
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
        [Column("CreatedDT", TypeName = "date")]
        public DateTime CreatedDT { get; set; }
        [Column("ModifiedDT", TypeName = "date")]
        public DateTime ModifiedDT { get; set; }
        [Column("Active", TypeName = "Bit")]
        public bool Active { get; set; }
        public int CatId { get; set; }
    }
}
