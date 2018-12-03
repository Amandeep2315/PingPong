using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseAccess.Domain;
using PingPong.DataContract;
using DataBaseAccess.Repository;

namespace PingPong.BusinessObject
{
    public class PlayerBusinessObject : IPlayerBusinessObject
    {
        private IPlayerRepository playerRepository;

        public PlayerBusinessObject(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }
        public string Add(PlayerDTO playerData)
        {
            var player = new Player(playerData.FirstName,
                playerData.LastName,
                  playerData.EmailAddress,
                  playerData.Age.HasValue? playerData.Age : null ,
                 playerData.SkillLevel
            );
            return playerRepository.Add(player);
        }

        public IEnumerable<PlayerDTO> GetAllPlayer()
        {
            List<PlayerDTO> PlayerDTO = new List<DataContract.PlayerDTO>();
            foreach (var player in playerRepository.GetAllPlayer().ToList())
            {
                var playerDTO = new PlayerDTO();
                playerDTO.PlayerId = player.Id;
                playerDTO.FirstName = player.FirstName;
                playerDTO.LastName = player.LastName;
                playerDTO.Age = player.Age;
                playerDTO.EmailAddress = player.EmailAddress;
                playerDTO.SkillLevel = player.SkillLevel;
                playerDTO.SkillLevelType = (SkillLevelType)player.SkillLevel;
                PlayerDTO.Add(playerDTO);
            }
            return PlayerDTO;
        }

        public IEnumerable<SkillLevelDTO> GetSkillLevels()
        {
            List<SkillLevelDTO> skills = new List<DataContract.SkillLevelDTO>();
            foreach (var skill in playerRepository.GetSkillLevels())
            {
                skills.Add(new SkillLevelDTO { SkillLevel = skill.SkillLevelId.ToString(), Description = skill.Description });
            }
            return skills;
        }

        public PlayerDTO GetPlayerById(int id)
        {
            var player = playerRepository.GetPlayerById(id);

            var playerDTO = new PlayerDTO();
            if (player != null)
            {
                playerDTO.PlayerId = player.Id;
                playerDTO.FirstName = player.FirstName;
                playerDTO.LastName = player.LastName;
                playerDTO.Age = player.Age;
                playerDTO.EmailAddress = player.EmailAddress;
                playerDTO.SkillLevel = player.SkillLevel;
                playerDTO.SkillLevelType = (SkillLevelType)player.SkillLevel;
            }
            return playerDTO;
        }

        public string DeletePlayer(int id)
        {
            var player = playerRepository.GetPlayerById(id);
            return playerRepository.Remove(player);
        }

        public string UpdatePlayerInfo(PlayerDTO playerData)
        {
            var player = playerRepository.GetPlayerById(playerData.PlayerId);
            player.Change(playerData.FirstName, playerData.LastName, playerData.EmailAddress, playerData.Age.HasValue ? playerData.Age: null , playerData.SkillLevel);
            return playerRepository.Update(player);
        }
    }
}
