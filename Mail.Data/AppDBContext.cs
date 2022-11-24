using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mail.Data
{
    public class AppDBContext : DbContext
    {

        private IConfiguration _config;

        public AppDBContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("AppDbConnectionString"));
            }
        }

        //entities
        public DbSet<Mail.Data.Entity.MailDetail> MailDetail { get; set; }
        public DbSet<Mail.Data.Entity.MailType> MailType { get; set; }

    }
}
