using DataBaseAccess.Domain;
using PingPong.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.BusinessObject
{
   public interface IPlayerBusinessObject
    {
        IEnumerable<PlayerDTO> GetAllPlayer();

        IEnumerable<SkillLevelDTO> GetSkillLevels();

        PlayerDTO GetPlayerById(int Id);

        string Add(PlayerDTO player);

        string DeletePlayer(int id);

        string UpdatePlayerInfo(PlayerDTO player);
    }
}
