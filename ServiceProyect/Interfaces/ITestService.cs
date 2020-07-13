using ServiceProyect.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceProyect
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITestService" in both code and config file together.
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string Ready();

        [OperationContract]
        string Auth(string clientId, string clientSecret, string redirestUri);

        [OperationContract]
        AuthToken Login(string clientId, string clientSecret, string redirestUri, string code, string refreshToken);

        [OperationContract]
        List<Category> GetAllCategories(string clientId, string clientSecret, string redirestUri, string token, string tokenType);

        [OperationContract]
        List<Playlist> GetCategoryPlaylists(string clientId, string clientSecret, string redirestUri, string token, string tokenType, string idCategory);

        [OperationContract]
        List<TrackDetail> GetPlaylistTracks(string clientId, string clientSecret, string redirestUri, string token, string tokenType, string uri, int? limit);
    }
}
