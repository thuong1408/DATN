using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.Entities
{
    public class Orders
    {
        public string UserID { get; set; } = string.Empty;
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int TotalMoney { get; set; }
        public int Status { get; set; }
    }
}
