using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTest2.DataBase
{
    public class MyContext : DbContext
    {
        private string connectionString = "server=; database = ; user id =; password = ";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

        }
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }


    }
}
