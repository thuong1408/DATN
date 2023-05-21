using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.Entities
{
    public class Jwt
    {
        #region Property
        /// <summary>
        /// Mã bảo mật của Jwt
        /// </summary>
        public string SecretKey { get; set; }
        #endregion
    }
}
