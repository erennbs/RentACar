﻿using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants {
    public static class Messages {
        public static string CarAdded = "Araç eklendi";
        public static string CarDeleted = "Araç silindi";
        public static string CarUpdated = "Araç güncellendi";
        public static string CarsListed = "Araçlar listelendi";
        public static string InvalidCarName = "Geçersiz araç ismi";
        public static string InvalidCarPrice = "Geçersiz araç fiyatı";


        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandsListed = "Markalar listelendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorsListed = "Renk listelendi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string InvalidUserEmail = "Email yanlış formatta";
        public static string InvalidUserPassword = "Şifre en az sekiz haneli olmalı";
        
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted ="Müşteri silindi";
        public static string CustomerUpdated ="Müşteri güncellendi";
        public static string CustomersListed = "Müşteriler listelendi";

        public static string RentalAdded = "Kiralama eklendi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string RentalsListed = "Kiralamalar listelendi";
        public static string RentalNotReturned = "Kiralanan araç teslim edilmedi";

        public static string CarImageAdded = "Resim eklendi";
        public static string CarImageDeleted = "Resim silindi";
        public static string CarImageUpdated = "Resim güncellendi";
        public static string CarImageListed = "Kiralamalar listelendi";
        public static string CarImageUploadError = "Resim yüklenirken bir sorun oluştu";
        public static string ImageAmountExceeds = "Resim sayısı 5'den fazla olamaz";
        public static string CarImageNoFileExists = "Resim bulunamadı";
        
        public static string AuthorizationDenied = "Yetkiniz yok";
        
        public static string UserRegistered = "Kullanıcı başarıyla kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string EmailAlreadyExists = "Email kullanılıyor";
    }
}
