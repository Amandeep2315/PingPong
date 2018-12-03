using AutoMapper;
using DataBaseAccess.Domain;
using DataBaseAccess.Repository;
using PingPong.BusinessObject;
using PingPong.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PingPong.WebAPI.Controllers
{
    public class PlayerApiController : ApiController
    {

        private IPlayerBusinessObject playerBusinessObject;

        public PlayerApiController(IPlayerBusinessObject playerBusinessObject)
        {
            this.playerBusinessObject = playerBusinessObject;
        }

        [Route("api/PlayerApi/GetAllPlayer")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<PlayerDTO>))]
        public IHttpActionResult GetAllPlayer()
        {
            var PlayerInfo = playerBusinessObject.GetAllPlayer();
            return Ok(PlayerInfo);
        }

        [Route("api/PlayerApi/GetSkillLevels")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<SkillLevelDTO>))]
        public IHttpActionResult GetSkillLevels()
        {
            var skills = playerBusinessObject.GetSkillLevels();
            return Ok(skills);
        }

        [HttpGet]
        [Route("api/PlayerApi/GetPlayer/{id}")]
        [ResponseType(typeof(PlayerDTO))]
        public IHttpActionResult GetPlayer([FromUri]string id)
        {
            var playerID = 0;
            int.TryParse(id, out playerID);
            var playerDTO = playerBusinessObject.GetPlayerById(playerID);
            if (playerDTO == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return Ok(playerDTO); ;
        }

        // POST: api/Player
        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/PlayerApi/AddPlayer")]
        public IHttpActionResult AddPlayer(PlayerDTO playerData)
        {
            if (ModelState.IsValid)
            {
                return Ok(playerBusinessObject.Add(playerData));
            }
            return BadRequest();
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/PlayerApi/EditPlayer")]
        public IHttpActionResult EditPlayer(PlayerDTO playerData)
        {
            if (ModelState.IsValid)
            {
                return Ok(playerBusinessObject.UpdatePlayerInfo(playerData));
            }
            return BadRequest();
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("api/PlayerApi/DeletePlayer")]
        public IHttpActionResult DeletePlayer([FromBody]string id)
        {
            var playerID = 0;
            int.TryParse(id, out playerID);
            return Ok(playerBusinessObject.DeletePlayer(playerID));

        }
    }
}
