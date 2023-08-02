using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Udemy.Identity.Models
{
    public class RoleCreateModel
    {
        [Required(ErrorMessage="Ad Alanı gereklidir")]

        public string Name { get; set; }
    }
}
