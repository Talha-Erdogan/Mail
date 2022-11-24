using System;
using System.Collections.Generic;
using System.Text;

namespace Mail.Business.İnterfaces
{
    public interface IMailDetailService
    {
        List<Data.Entity.MailDetail> GetAll();
        Data.Entity.MailDetail GetById(int id);
        Data.Entity.MailDetail GetByMailTypeId(int typeId);
        int Add(Data.Entity.MailDetail record);
        int Update(Data.Entity.MailDetail record);
    }
}
