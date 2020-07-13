using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;

namespace WebProyect.Controllers
{
    public class CategoryController : Controller
    {
        private string clientId = WebConfigurationManager.AppSettings["ClientId"];
        private string clientSecret = WebConfigurationManager.AppSettings["ClientSecret"];
        private string redirestUri = WebConfigurationManager.AppSettings["RedirestUri"];

        [HttpPost]
        public ActionResult GetSongs(string idCategory)
        {
            spotifyService.ITestService service = new spotifyService.TestServiceClient();

            List<spotifyService.Playlist> playlists = new List<spotifyService.Playlist>();
            playlists = service.GetCategoryPlaylists(clientId, clientSecret, redirestUri, (string)Session["Token"], (string)Session["TokenType"], idCategory).ToList();

            List<spotifyService.TrackDetail> tracks = new List<spotifyService.TrackDetail>();
            tracks = getSongs(service, playlists, 15);

            return Json(tracks);
        }

        public List<spotifyService.TrackDetail> getSongs(spotifyService.ITestService service, List<spotifyService.Playlist> playlists, int qty)
        {
            List<spotifyService.TrackDetail> tracks = new List<spotifyService.TrackDetail>();
            int i = 0;

            while (tracks.Count < qty)
            {
                List<spotifyService.TrackDetail> tracksTemp = new List<spotifyService.TrackDetail>();
                tracksTemp = service.GetPlaylistTracks(clientId, clientSecret, redirestUri, (string)Session["Token"], (string)Session["TokenType"], playlists[i].Tracks.Select(s => s.Href).First(), 15).ToList();

                tracks.AddRange(tracksTemp.Take(qty - tracks.Count));
                i++;
            }

            return tracks;
        }
    }
}