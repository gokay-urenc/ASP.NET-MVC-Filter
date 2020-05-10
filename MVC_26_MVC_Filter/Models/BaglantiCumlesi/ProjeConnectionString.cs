using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_26_MVC_Filter.Models.BaglantiCumlesi
{
    public class ProjeConnectionString : DbContext // DbContext veritabanıyla iletişim kuran classtır. Bu yüzden miras almalıyız.
    {
        public ProjeConnectionString()
        {
            Database.Connection.ConnectionString = "Server=.;Database=KullaniciDataBase;Trusted_Connection=true";
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}