using ServiceProyect.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceProyect
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TestService.svc or TestService.svc.cs at the Solution Explorer and start debugging.
    public class TestService : ITestService
    {
        public void DoWork()
        {
        }

        public string Ready()
        {
            return ("Do Work!");
        }

        public string Auth(string clientId, string clientSecret, string redirestUri)
        {
            var api = new Classes.APISpotify(clientId, clientSecret, redirestUri);

            return api.DoAuth();
        }

        public AuthToken Login(string clientId, string clientSecret, string redirestUri, string code, string refreshToken)
        {
            var api = new Classes.APISpotify(clientId, clientSecret, redirestUri);

            return api.DoLogin(code, refreshToken);
        }

        public List<Category> GetAllCategories(string clientId, string clientSecret, string redirestUri, string token, string tokenType)
        {
            var api = new Classes.APISpotify(clientId, clientSecret, redirestUri);

            return api.GetAllCategories(token, tokenType);
        }

        public List<Playlist> GetCategoryPlaylists(string clientId, string clientSecret, string redirestUri, string token, string tokenType, string idCategory)
        {
            var api = new Classes.APISpotify(clientId, clientSecret, redirestUri);

            return api.GetPlaylists(token, tokenType, idCategory);
        }

        public List<TrackDetail> GetPlaylistTracks(string clientId, string clientSecret, string redirestUri, string token, string tokenType, string uri, int? limit)
        {
            var api = new Classes.APISpotify(clientId, clientSecret, redirestUri);

            return api.GetTracks(token, tokenType, uri, limit);
        }
    }
}
