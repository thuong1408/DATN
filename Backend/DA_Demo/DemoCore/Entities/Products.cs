using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.Entities
{
    public class Products
    {
        
        public int ProductID { get; set; }
        public string ProcductName { get; set; } = string.Empty;

        public int OriginalPrice { get; set; }
        public int Price { get; set; }
        public string? Thumbnail { get; set; } 
        public string? Description { get; set; }
        public int Number { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int status  { get; set; }
        public int CategoryID { get; set; }
        public int isDelete { get; set; }
    }
}
