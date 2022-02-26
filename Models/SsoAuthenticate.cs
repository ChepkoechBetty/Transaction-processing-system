using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPS.Models
{
    public class SsoAuthenticate
    {
        public string Provider { get; set; }
        public string ReturnUrl { get; set; }
    }
}
