using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceProyect.Entities
{
    public class Category
    {
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Icons { get; set; }
        public string Name { get; set; }
    }

    public class Categories
    {
        public string Href { get; set; }
        public List<Category> Items { get; set; }
    }

    public class CategoriesResponse
    {
        public Categories Categories { get; set; }
    }
}