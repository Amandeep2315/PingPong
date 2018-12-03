using DataBaseAccess.Context;
using DataBaseAccess.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess.Repository
{
   public class PlayerRepository : IPlayerRepository
    {
        private DatabaseContext dbContext;

        public PlayerRepository()
        {
            dbContext = new DatabaseContext();
        }
        public List<Player> GetAllPlayer()
        {
            return dbContext.Player.ToList();
        }

         public List<SkillLevel> GetSkillLevels()
        {
            return dbContext.SkillLevel.ToList();
        }

        public Player GetPlayerById(int Id)
        {
            return dbContext.Player.Where(x=>x.Id == Id).FirstOrDefault();
        }

        public string Add(Player player)
        {
            dbContext.Set<Player>().Add(player);
            dbContext.SaveChanges();
            return "Player Added Successfully";
        }

        public string Remove(Player player)
        {
            dbContext.Set<Player>().Remove(player);
            dbContext.SaveChanges();

            return "Player removed Successfully";
        }

        public string Update(Player player)
        {
            var original = dbContext.Player.Where(s => s.Id == player.Id).FirstOrDefault();
            if (original != null)
            {
                original.FirstName = player.FirstName; 
                original.LastName = player.LastName;
                original.EmailAddress = player.EmailAddress;
                original.Age = player.Age;
                original.SkillLevel = player.SkillLevel;

                dbContext.Entry(original).State = EntityState.Modified;
                dbContext.SaveChanges();
                return "Player details Successfully";
;            }
            return "No Record Found";
        }

    }
}
