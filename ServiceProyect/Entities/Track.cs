using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceProyect.Entities
{
    public class Track
    {
        public string Id { get; set; }
        public string Href { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string PreviewUrl { get; set; }
        public string Uri { get; set; }
        public Album Album { get; set; }
    }

    public class TrackDetail
    {
        public Track Track { get; set; }
    }

    public class TracksResponse
    {
        public string Href { get; set; }
        public List<TrackDetail> Items { get; set; }
    }
}