using Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string CarNameInvalid = "Araç İsmi Geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarsListed = "Araçlar Listelendi";
        public static string CarNotAvailable = "Araç Uygun Değil";
        public static string Added = "Eklenmiştir";
        public static string Deleted = "Silinmiştir";
        public static string Updated = "Güncellenmiştir";
        public static string AuthorizationDenied= "Yetkisiz Giriş";
        public static string UserRegistered= "Kullanıcı Kayıt Oldu.";
        public static string UserAlreadyExists ="Kullanıcı Zaten Mevcut.";
        public static string UserNotFound= "Kullanıcı Bulunamadı";
        public static string AccessTokenCreated= "Token Oluşturuldu";
        public static string SuccessfulLogin ="Giriş Başarılı";
        public static string PasswordError ="Şifre Hatalı";
        public static string CustomerNotExist= "Kullanıcı Bulunamadı";
        public static string NotEngouhFindex = "Findeks Puanı Yeterli Değil";
        public static string EngouhFindex = "Findeks Puanı Yeterli";
    }
}
