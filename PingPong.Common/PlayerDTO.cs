using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.DataContract
{
    [Serializable]
    public class PlayerDTO
    {
        public int PlayerId { get; set; }
       
        [Required]
        [Display(Name = "First Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Please enter atleast 3 characters")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Please enter atleast 3 characters")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Age")]
        [RegularExpression("^[0-9]+$|^$", ErrorMessage = "Invalid Age")]
        public int? Age { get; set; }

        [Required]
        [Display(Name = "Skill Level")]
        public int SkillLevel { get; set; }

        public SkillLevelType SkillLevelType { get; set; }

    }
}
