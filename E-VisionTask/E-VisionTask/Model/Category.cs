using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_VisionTask.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("Active", TypeName = "Bit")]
        public bool Active { get; set; }
    }
}
