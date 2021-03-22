using System;
using System.Collections;
using static Common.SysWorks;

namespace Common
{
    public class sysReturn
    {
        public DurumTip Durum = DurumTip.Null;
        public object Sonuc = new object();
        public string SqlString = string.Empty;
        public ArrayList HataListe = new ArrayList();

        public string GetErrors()
        {
            string Hata = "";
            if (HataListe.Count > 0)
            {
                for (int i = 0; i < HataListe.Count; i++)
                {
                    if (HataListe[i].GetType().Name == "Exception")
                        Hata += ((Exception)HataListe[i]).Message + Environment.NewLine;
                    else if (HataListe[i].GetType().Name == "String")
                        Hata += HataListe[i] + Environment.NewLine;
                    else
                        Hata += HataListe[i].ToStringExact() + Environment.NewLine;
                }
            }
            return Hata;
        }

        
    }
   



}
