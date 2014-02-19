using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Falquan.Web.Models
{
    public class Contact
    {
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}