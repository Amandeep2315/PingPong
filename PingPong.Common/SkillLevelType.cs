using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.DataContract
{
    public enum  SkillLevelType 
    {
        [Display(Name = "Beginner")]
        Beginner = 1,

        [Display(Name = "InterMediate")]
        InterMediate = 2,

        [Display(Name = "Advanced")]
        Advanced = 3,

        [Display(Name = "Expert")]
        Expert = 4
    }
}
