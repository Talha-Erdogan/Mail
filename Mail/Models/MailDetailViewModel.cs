using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail.Models
{
    public class MailDetailViewModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Header { get; set; }
        public string Body { get; set; } //ajax value


        //select list
        public List<SelectListItem> MailTypeSelectList { get; set; }
    }
}
