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
    public class MailDetailService : IMailDetailService
    {
        private IConfiguration _config;

        public MailDetailService(IConfiguration config)
        {
            _config = config;
        }


        public List<Data.Entity.MailDetail> GetAll()
        {
            List<Data.Entity.MailDetail> resultList = new List<Data.Entity.MailDetail>();

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                var query = dbContext.MailDetail.AsNoTracking();
                resultList.AddRange(query.ToList());
            }
            return resultList;
        }

        public Data.Entity.MailDetail GetById(int id)
        {
            Data.Entity.MailDetail result = null;

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                result = dbContext.MailDetail.Where(a => a.Id == id).AsNoTracking().SingleOrDefault();
            }

            return result;
        }
        public Data.Entity.MailDetail GetByMailTypeId(int typeId)
        {
            Data.Entity.MailDetail result = null;

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                result = dbContext.MailDetail.Where(a => a.TypeId == typeId).AsNoTracking().SingleOrDefault();
            }

            return result;
        }

        public int Add(Data.Entity.MailDetail record)
        {
            int result = 0;
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                dbContext.Entry(record).State = EntityState.Added;
                result = dbContext.SaveChanges();
            }

            return result;
        }

        public int Update(Data.Entity.MailDetail record)
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
