using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using WebProyect.Models;

namespace WebProyect.Controllers
{
    public class HomeController : Controller
    {
        private string clientId = WebConfigurationManager.AppSettings["ClientId"];
        private string clientSecret = WebConfigurationManager.AppSettings["ClientSecret"];
        private string redirestUri = WebConfigurationManager.AppSettings["RedirestUri"];

        public ActionResult Index()
        {
            spotifyService.ITestService service = new spotifyService.TestServiceClient();

            string uri = service.Auth(clientId, clientSecret, redirestUri);

            return Redirect(uri);
        }

        public ActionResult Login(string code)
        {
            spotifyService.ITestService service = new spotifyService.TestServiceClient();

            spotifyService.AuthToken auth = service.Login(clientId, clientSecret, redirestUri, code, (string)Session["RefreshToken"]);

            Session["Token"] = auth.AccessToken;
            Session["TokenType"] = auth.TokenType;
            if(auth.RefreshToken != null)
                Session["RefreshToken"] = auth.RefreshToken;

            List<spotifyService.Category> categories = new List<spotifyService.Category>();
            categories = service.GetAllCategories(clientId, clientSecret, redirestUri, (string)Session["Token"], (string)Session["TokenType"]).ToList();
            ViewBag.Categories = categories;

            return View("/Views/Category/Search.cshtml");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}