using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.Entities
{
    public class Account
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role{ get; set; } = string.Empty;
        public string UserID { get; set; } = string.Empty;
        public int isDelete { get; set; }
    }
}
