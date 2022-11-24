using Mail.Business.İnterfaces;
using Mail.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mail.Business
{
    public class MailTypeService : IMailTypeService
    {
        private IConfiguration _config;

        public MailTypeService(IConfiguration config)
        {
            _config = config;
        }


        public List<Data.Entity.MailType> GetAll()
        {
            List<Data.Entity.MailType> resultList = new List<Data.Entity.MailType>();

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                var query = dbContext.MailType.AsNoTracking();
                resultList.AddRange(query.ToList());
            }
            return resultList;
        }

        public Data.Entity.MailType GetById(int id)
        {
            Data.Entity.MailType result = null;

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                result = dbContext.MailType.Where(a => a.Id == id).AsNoTracking().SingleOrDefault();
            }

            return result;
        }

        public int Add(Data.Entity.MailType record)
        {
            int result = 0;
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                dbContext.Entry(record).State = EntityState.Added;
                result = dbContext.SaveChanges();
            }

            return result;
        }

        public int Update(Data.Entity.MailType record)
        {
            int result = 0;

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                dbContext.Entry(record).State = EntityState.Modified;
                result = dbContext.SaveChanges();
            }

            return result;
        }
    }
}
