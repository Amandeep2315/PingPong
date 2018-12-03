using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Configuration;
using System.Net.Http.Formatting;
using PingPong.DataContract;

namespace PingPong.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        HttpClient _httpClient;
        public HomeController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIURI"].ToString());
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = new PlayerDTO();
            var response = _httpClient.GetAsync("api/PlayerApi/GetAllPlayer").Result;
            if (response.IsSuccessStatusCode)
            {
                return View(response.Content.ReadAsAsync(typeof(List<PlayerDTO>)).Result);
            }

            return View(model);
        }

        private SelectList GetSkillLevels()
        {
            var response = _httpClient.GetAsync("api/PlayerApi/GetSkillLevels").Result;
            if (response.IsSuccessStatusCode)
            {
                var skills = (List<SkillLevelDTO>)response.Content.ReadAsAsync(typeof(List<SkillLevelDTO>)).Result;
                return new SelectList(skills, "SkillLevel", "Description");
            }
            return null;
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.SkillLevels = GetSkillLevels();
            return View(new PlayerDTO());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add(PlayerDTO player)
        {
            ViewBag.SkillLevels = GetSkillLevels();

            if (ModelState.IsValid)
            {
                var response = _httpClient.PostAsync("api/PlayerApi/AddPlayer", player, new JsonMediaTypeFormatter()).Result;
                if (response.IsSuccessStatusCode)
                {
                    var model = response.Content.ReadAsAsync<string>().Result;
                    TempData["message"] = "Player Added Successfully";
                    return RedirectToAction("Index", "Home", new { message = response });
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int playerId)
        {
            var player = GetPlayer(playerId.ToString());
            ViewBag.SkillLevels = GetSkillLevels();
            return View(player);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(PlayerDTO player)
        {
            ViewBag.SkillLevels = GetSkillLevels();
            if (ModelState.IsValid)
            {
                var response = _httpClient.PostAsJsonAsync("api/PlayerApi/EditPlayer", player).Result;
                if (response.IsSuccessStatusCode)
                {
                    var model = response.Content.ReadAsAsync<string>().Result;
                    TempData["message"] = "Player Upadated Successfully";
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int playerID)
        {
            if (ModelState.IsValid)
            {
                var response = _httpClient.PostAsJsonAsync("api/PlayerApi/DeletePlayer", playerID.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = (string)response.Content.ReadAsAsync(typeof(string)).Result;
                    TempData["message"] = "Deleted Successfully";
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        private PlayerDTO GetPlayer(string playerId)
        {
            string id = playerId;
            var response = _httpClient.GetAsync(string.Format("api/PlayerApi/GetPlayer/{0}", id)).Result;
            if (response.IsSuccessStatusCode)
            {
                var player = (PlayerDTO)response.Content.ReadAsAsync(typeof(PlayerDTO)).Result;
                return player;
            }
            return null;
        }



    }
}