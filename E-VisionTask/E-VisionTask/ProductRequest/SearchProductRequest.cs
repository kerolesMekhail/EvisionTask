using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_VisionTask.ProductRequest
{
    public class SearchProductRequest
    {
        public string Name { get; set; }
        public decimal ? Price { get; set; }
        public DateTime ? CreatedDT { get; set; }
        public bool ? Active { get; set; }
        public DateTime ? ModifiedDT { get; set; }


    }
}
