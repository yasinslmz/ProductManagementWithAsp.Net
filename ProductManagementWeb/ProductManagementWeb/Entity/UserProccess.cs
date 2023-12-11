using ProductManagementWeb.Entity.Interfaces;
using ProductManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductManagementWeb.Entity
{
    public class UserProccess : ICrud<User>
    {
        DataContext db=new DataContext();
        public string Add(User entity)
        {
            string result = "";
            var user=db.User.FirstOrDefault(x=>x.Email == entity.Email);
            if(user == null && 
                !String.IsNullOrWhiteSpace(entity.Name) &&
                !String.IsNullOrWhiteSpace(entity.Email) &&
                !String.IsNullOrWhiteSpace(entity.Password))
            {
                db.User.Add(entity);
                db.SaveChanges();
                result = entity.Email+" Kullanıcı Ekleme Başarılı";
            }
            else
            {
                result = entity.Email + " Email Adresi Daha Önce Kayıt Olmuş. Başka Email İle Devam Ediniz.";
            }
            return result;
        }

        public bool Delete(int id)
        {
            var user=db.User.FirstOrDefault(x=> x.Id == id && !x.IsDelete);
            if (user != null)
            {
                user.IsDelete = true;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public User Get(int id)
        {
            var user=db.User.FirstOrDefault(x=>x.Id==id && !x.IsDelete);
            return user;
        }

        public List<User> GetAll()
        {
            return db.User.Where(x=>!x.IsDelete).Include(u => u.Role).ToList();
        }

        public bool Update(User entity, int id)
        {
            var user=db.User.FirstOrDefault(x=>x.Id== id && !x.IsDelete);
            if(user != null)
            {
                user.Name = entity.Name;
                user.Surname = entity.Surname;
                user.IsStatus = entity.IsStatus;
                user.RoleId = entity.RoleId;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public string PasswordChange(int id,string oldPassword,string newPassword, string newPasswordRepeat)
        {
            string result = "";

            var user=db.User.FirstOrDefault(x=>x.Id==id && !x.IsDelete);
            if(user != null)
            {
                if(user.Password==oldPassword)
                {
                    if (user.Password != newPassword)
                    {
                        if (newPassword == newPasswordRepeat)
                        {
                            user.Password = newPassword;
                            db.SaveChanges();
                            result = "Şifre Başarılı Bir Şekilde Değiştirildi.";
                        }
                        else
                        {
                            result = "Girilen Yeni Şifre Uyuşmadı. Tekrar Deneyiniz.";
                        }
                    }
                    else
                    {
                        result = "Eski Şifre Girdiniz. Tekrar Deneyiniz.";
                    }
                }
                else
                {
                    result = "Girilen Şifre Hatalı";
                }
            }
            else
            {
                result = "Kullanıcı Bulunamadı";
            }
            return result;
        }
    }
}