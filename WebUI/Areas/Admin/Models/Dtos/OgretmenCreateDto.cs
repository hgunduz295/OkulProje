using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Areas.Admin.Models.Dtos
{
    public class OgretmenCreateDto
    {
        public OgretmenDto OgretmenDto { get; set; }
        public SelectList Sinif { get; set; }


    }
}
