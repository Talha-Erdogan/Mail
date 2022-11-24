using System;
using System.Collections.Generic;
using System.Text;

namespace Mail.Business.İnterfaces
{
    public interface IMailTypeService
    {
        List<Data.Entity.MailType> GetAll();
        Data.Entity.MailType GetById(int id);
        int Add(Data.Entity.MailType record);
        int Update(Data.Entity.MailType record);
    }
}
