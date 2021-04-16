using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Business.Constant
{
    public static class Messages
    {
        public static string CompanyAdded = "Firma Başarı ile eklendi";
        public static string CompanyUpdated = "Firma Başarı ile güncellendi";
        public static string CompanyDeleted = "Firma Başarı ile silindi";

        public static string DatabaseAdded = "Database Bilgisi Başarı ile eklendi";
        public static string DatabaseUpdated = "Database Bilgisi Başarı ile güncellendi";
        public static string DatabaseDeleted = "Database Bilgisi Başarı ile silindi";

        public static string LicenceAdded = "Lisans Bilgisi Başarı ile eklendi";
        public static string LicenceUpdated = "Lisans Bilgisi Başarı ile güncellendi";
        public static string LicenceDeleted = "Lisans Bilgisi Başarı ile silindi";

        public static string LocalsAdded = "Şube Bilgisi Başarı ile eklendi";
        public static string LocalsUpdated = "Şube Bilgisi Başarı ile güncellendi";
        public static string LocalsDeleted = "Şube Bilgisi Başarı ile silindi";

        public static string rolesAdded = "Rol Bilgisi Başarı ile eklendi";
        public static string rolesUpdated = "Rol Bilgisi Başarı ile güncellendi";
        public static string rolesDeleted = "Rol Bilgisi Başarı ile silindi";


        public static string usersAdded = "Kullanici Başarı ile eklendi";
        public static string usersUpdated = "Kullanici Bilgisi Başarı ile güncellendi";
        public static string usersDeleted = "Kullanici Bilgisi Başarı ile silindi";

        public static string UserNotFound = "Kullanıcı Bulunamadı.";
        public static string PasswordError = "Kullanıcı veya Sifre Hatali";
        public static string SuccessfullLogin = "Sisteme Giris Basarili";
        public static string UserAlreadyExist = "Kullanıcı daha önce kayıt olmuştur.";
        public static string AccessTokenCreated = "Token Oluşturuldu.";


        #region ValidationMessages

        public static string TaxNumberValidationError = "Vergi Numarasi Boş Bırakılamaz.";
        public static string TaxNumberLengtValidationError = "Vergi Numarasi Uzunluğu hatası";

        #endregion


        public static string AuthorizationDenied = "Yetkiniz Bu İşlemi Yapmaya Uygun Değil.";

        public static string CompanyTaxNumberExistError = "Firma Daha Önce Kayıt Edilmiştir.";
    }
}