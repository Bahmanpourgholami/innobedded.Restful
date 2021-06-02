using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innobedded.Restful.Data.Entity
{
   public class User
    {

        [Key]
        public int ID { get; set; }

        [MaxLength(10)]
        public string Name { get; set; }

        [StringLength(10, MinimumLength = 5)]
        [Display(Name ="Password for Enter")]
        public string Password { get; set; }
        
        [EmailAddress(ErrorMessage ="Please Set Correct Email")]
        public string Email { get; set; }

    }
}
