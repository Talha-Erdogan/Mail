using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mail.Data.Entity
{
    [Table("MailDetail")]
    public class MailDetail
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }


        [Required]
        public int TypeId { get; set; }


        [StringLength(500)]
        public string Header { get; set; }


        public string Body { get; set; }
    }
}
