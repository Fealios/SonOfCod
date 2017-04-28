using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SonOfCod.ViewModels
{
    public class MailViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
    }
}