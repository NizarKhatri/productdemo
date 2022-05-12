using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API
{
    public class AppSettings
    {
        public string DirectoryPath { get; set; }
        public string AuthenticateRedirect { get; set; }
        public string UnAuthorizeRedirect { get; set; }
        public int FileLockDuration { get; set; }
    }
}
