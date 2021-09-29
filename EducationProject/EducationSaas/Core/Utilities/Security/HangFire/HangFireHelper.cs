using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities.Security.HangFire
{
    public class HangFireHelper
    {
        public IConfiguration Configuration { get; }
        private HangFireOptions _hangFireOptions;
       
        public  HangFireHelper (IConfiguration configuration)
        {
            Configuration = configuration;
            _hangFireOptions= configuration.GetSection("HangFireConfiguration").Get<HangFireOptions>();
        }

      

    }
}
