using PingPong.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess.Domain
{
    public class Player
    {
        public Player()
        {

        }
        public Player(string firstName, string lastName, string emailAddress, int? age, int skillLevel)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Age = age;
            SkillLevel = skillLevel;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public int? Age { get; set; }

        public int SkillLevel { get; set; }

        public void Change(string firstName, string lastName, string emailAddress, int? age, int skillLevel)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
            this.Age = age;
            this.SkillLevel = skillLevel;
        }

    }
}
