using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BrandAdded = "Marka bilgisi eklendi.";

        public static string BrandUpdated = "Marka bilgisi güncellendi";

        public static string BrandDeleted = "Marka bilgisi silindi.";

        public static string BrandListed = "Marka bilgileri listelendi.";

        public static string ColorAdded = "Renk bilgisi eklendi.";

        public static string ColorUpdated = "Renk bilgisi güncellendi.";

        public static string ColorDeleted = "Renk bilgisi silindi.";

        public static string CarUpdated = "Araç bilgisi güncellendi";

        public static string CarDeleted = "Araç bilgisi silindi";

        public static string CarAdded = "Araç bilgisi eklendi";

        public static string CarListed = "Araçlar listelendi.";

        public static string RentalUpdated = "Araç kiralama bilgisi güncellendi";

        public static string RentalDeleted = "Araç kiralama bilgisi silindi";

        public static string RentalAdded = "Araç kiralama bilgisi eklendi";

        public static string ErrorRentalAdded = "Araç kiralama bilgisi eklenemedi";

        public static string RentalListed = "Araçların kiralama bilgileri listelendi.";

        public static string CarImageCountExceeded = "Bir aracın en fazla 5 tane resmi olabilir.";

        public static string SuccessUploadOfCarImage = "Resim başarıyla eklendi.";

        public static string CarImageDeletedSuccessfully = "Resim başarıyla silindi";

        public static string CarImageUpdatedSuccesfully = "Resim başarıyla güncellendi.";

        public static string UserNotFound = "Kullanıcı bulunamadı.";

        public static string PasswordError = "Şifre hatalı.";
        public static string SuccesfulLogin = "Başarılı giriş.";

        public static string UserAlreadyExist = "Bu kullanıcı zaten mevcut.";

        public static string UserRegistered = "Kullanıcı sisteme kayıt edilmiştir.";

        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
    }
}
