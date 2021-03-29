using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Dtos
{
    public class UserForRegisterDto : IDto
    {
        
        /// <summary>
        /// user tablosuna gidecek olan ilk admin kullanicisi icin
        /// </summary>
        public string Email { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }
      
        /// <summary>
        /// buradan aşağısı company tablosuna 
        /// </summary>
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string Adress { get; set; }
        
    }

}
