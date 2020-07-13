using RestSharp;
using ServiceProyect.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace ServiceProyect.Classes
{
    public class APISpotify
    {
        private string clientId;
        private string clientSecret;
        private string redirestUri;

        public APISpotify(string id, string secret, string uri)
        {
            clientId = id;
            clientSecret = secret;
            redirestUri = uri;
        }

        private String GetUri(string uri)
        {
            StringBuilder builder = new StringBuilder(uri);
            builder.Append("client_id=" + clientId);
            builder.Append("&response_type=code");
            builder.Append("&redirect_uri=" + HttpUtility.UrlEncode(redirestUri));
            builder.Append("&scope=" + "user-read-private user-read-email");
            //builder.Append("&state=" + RandomString(16));
            //builder.Append("&show_dialog=" + true);
            return builder.ToString();
        }

        public string DoAuth()
        {
            string uri = GetUri("https://accounts.spotify.com/authorize/?");
            return uri;
        }

        public AuthToken DoLogin(string code, string refreshToken)
        {
            AuthToken auth = GetToken("https://accounts.spotify.com/api/token", string.Format("code={0}&grant_type=authorization_code&client_id={1}&client_secret={2}&redirect_uri={3}",
                code, clientId, clientSecret, HttpUtility.UrlEncode(redirestUri)));

            if (auth.AccessToken == null && refreshToken != null)
                auth = GetToken("https://accounts.spotify.com/api/token", string.Format("refresh_token={0}&grant_type=refresh_token&client_id={1}&client_secret={2}&redirect_uri={3}",
                refreshToken, clientId, clientSecret, HttpUtility.UrlEncode(redirestUri)));

            return auth;
        }

        public List<Category> GetAllCategories(string token, string tokenType)
        {
            return Response<CategoriesResponse>("https://api.spotify.com/v1/browse/categories?country=AR", token, tokenType).Data.Categories.Items;
        }

        public List<Playlist> GetPlaylists(string token, string tokenType, string idCategory)
        {
            return Response<PlaylistsResponse>(string.Format("https://api.spotify.com/v1/browse/categories/{0}/playlists?country=AR", idCategory), token, tokenType).Data.Playlists.Items;
        }

        public List<TrackDetail> GetTracks(string token, string tokenType, string uri, int? limit)
        {
            return Response<TracksResponse>(string.Format((limit != null ? string.Format(string.Concat(uri, "?limit={0}"), limit) : uri)), token, tokenType).Data.Items;
        }

        private AuthToken GetToken(string uri, string encodedBody)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/x-www-form-urlencoded", encodedBody, ParameterType.RequestBody);
            request.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);

            var response = client.Execute<AuthToken>(request);
            return response.Data;
        }

        private IRestResponse<T> Response<T>(string uri, string token, string tokenType)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.GET);
            request.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);
            request.AddParameter("Authorization", tokenType + " " + token, ParameterType.HttpHeader);

            return client.Execute<T>(request);
        }
    }
}