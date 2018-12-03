using DataBaseAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess.Repository
{
    public interface IPlayerRepository
    {
        List<Player> GetAllPlayer();

        List<SkillLevel> GetSkillLevels();

        Player GetPlayerById(int Id);

        string Add(Player player);

        string Remove(Player player);

        string Update(Player player);

    }
}
