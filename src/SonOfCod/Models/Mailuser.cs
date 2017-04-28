using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SonOfCod.Models
{
    [Table("MailingList")]
    public class Mailuser
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string favorite { get; set; }
    }
}
