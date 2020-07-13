using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceProyect.Entities
{
    public class Album
    {
        public string Href { get; set; }
        public string Name { get; set; }
        public string AlbumType { get; set; }
        public List<Artist> Artists { get; set; }
    }
}