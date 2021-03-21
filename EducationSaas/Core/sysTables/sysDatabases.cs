using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.sysTables
{
    public class sysDatabases
    {
        public int ID { get; set; }
        public int CompanyId { get; set; }
        public int LocalId { get; set; }
        public string DbName { get; set; }
        public string DbPass { get; set; }
        public string DbSunucu { get; set; }
        public string DbUser { get; set; }


    }

}
