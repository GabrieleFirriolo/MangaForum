using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models.Utilities.Responses
{
    public class GetMangaByIdResponse : DefaultResponse
    {
        public List<Manga> mangas { get; set; }

    }
}
