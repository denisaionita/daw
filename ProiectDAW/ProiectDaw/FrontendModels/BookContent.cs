using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectDAW.Models;

namespace ProiectDAW.FrontendModels
{
    public class BookContent
    {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Year { get; set; }
            public string Description { get; set; }
            public string Language { get; set; }
            public string ISBN { get; set; }
            public List<GenreList> Genres { get; set; }
    }
}
