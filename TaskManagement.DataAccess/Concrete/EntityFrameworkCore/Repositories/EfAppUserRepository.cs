using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskManagement.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using TaskManagement.DataAccess.Interfaces;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetirAdminOlmayanlar()
        {
            using var context = new TaskManagementContext();
            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    userRole = resultUserRole
                }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,
                (resultTable, resultRole) => new
                {
                    user = resultTable.user,
                    userRoles = resultTable.userRole,
                    roles = resultRole
                }).Where(I => I.roles.Name == "Member").Select(I => new AppUser()
                {
                    Id = I.user.Id,
                    Name = I.user.Name,
                    Surname = I.user.Surname,
                    Picture = I.user.Picture,
                    Email = I.user.Email,
                    UserName = I.user.UserName
                }).ToList();

        }

        public List<AppUser> GetirAdminOlmayanlar(out int toplamSayfa, string aranacakKelime, int aktifSayfa = 1)
        {
            using var context = new TaskManagementContext();
            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    userRole = resultUserRole
                }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,
                (resultTable, resultRole) => new
                {
                    user = resultTable.user,
                    userRoles = resultTable.userRole,
                    roles = resultRole
                }).Where(I => I.roles.Name == "Member").Select(I => new AppUser()
                {
                    Id = I.user.Id,
                    Name = I.user.Name,
                    Surname = I.user.Surname,
                    Picture = I.user.Picture,
                    Email = I.user.Email,
                    UserName = I.user.UserName
                });
            toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);
            if (!string.IsNullOrWhiteSpace(aranacakKelime))
            {
                result = result.Where(I => I.Name.ToLower().Contains(aranacakKelime.ToLower()) || I.Surname.ToLower().Contains(aranacakKelime.ToLower()));
            }

            result = result.Skip((aktifSayfa - 1) * 3).Take(3);
            return result.ToList();
        }

        public List<DualHelper> GetirEnCokGorevTamamlamisPersoneller()
        {
            using var context = new TaskManagementContext();
            return context.Gorevler.Include(I => I.AppUser).Where(I => I.Durum).GroupBy(I => I.AppUser.UserName)
                .OrderByDescending(I => I.Count()).Take(5)
                .Select(I => new DualHelper() { Isim = I.Key, GorevSayisi = I.Count() }).ToList();
        }

        public List<DualHelper> GetirEnCokGorevdeCalisanPersoneller()
        {
            using var context = new TaskManagementContext();
            return context.Gorevler.Include(I => I.AppUser).Where(I => !I.Durum && I.AppUserId != null).GroupBy(I => I.AppUser.UserName)
                .OrderByDescending(I => I.Count()).Take(5)
                .Select(I => new DualHelper() { Isim = I.Key, GorevSayisi = I.Count() }).ToList();
        }
    }
}
