using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    class AspectSimple
    {
        //[ValidationAspect(typeof(CompanyValidator), Priority = 1)] //add methoduna girmeden araya girip once kontrol saglar
        //[SecuredOperation("Company.List")]

        //[CacheAspect(duration: 10)]  //10 dakika boyunca cache te sonra db den tekrar cache e seklinde bir dongu
        //[PerformanceAspect(interval: 5)]
        //[TransactionScopeAspect]
        //[LogAspect(typeof(DatabaseLogger))]
    }
}
