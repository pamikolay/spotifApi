using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceProyect.Entities
{
    public class Playlist
    {
        public string Description { get; set; }
        public string Id { get; set; }
        public string Href { get; set; }
        public List<Image> Images { get; set; }
        public List<PlaylistTrack> Tracks { get; set; }
    }

    public class Playlists
    {
        public string Href { get; set; }
        public List<Playlist> Items { get; set; }
    }

    public class PlaylistsResponse
    {
        public Playlists Playlists { get; set; }
    }
}