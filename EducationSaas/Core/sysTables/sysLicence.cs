using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.sysTables
{
    public class sysLicence
    {
        public int ID { get; set; }
        public int CompanyId { get; set; }

        public int LocalId { get; set; }
        public string GuiForLicence { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
    

    }
   
}
