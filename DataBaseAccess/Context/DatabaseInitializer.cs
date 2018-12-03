using DataBaseAccess.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);
            var Beginner = new SkillLevel { Description = "Beginner" };
            context.SkillLevel.Add(Beginner);
            var InterMediate = new SkillLevel { Description = "InterMediate" };
            context.SkillLevel.Add(InterMediate);
            var Advanced = new SkillLevel { Description = "Advanced" };
            context.SkillLevel.Add(Advanced);
            var Expert = new SkillLevel { Description = "Expert" };
            context.SkillLevel.Add(Expert);

            var player = new Player { FirstName = "Roberto", LastName = "Carlos", EmailAddress = "robertocarlos@gmail.com",Age=37,SkillLevel = 4 };
            context.Player.Add(player);
            var player2 = new Player { FirstName = "Roger", LastName = "fedrer", EmailAddress = "rogerfedrer@gmail.com", Age = 32, SkillLevel = 3 };
            context.Player.Add(player2);
            context.SaveChanges();
        }
    }
}
