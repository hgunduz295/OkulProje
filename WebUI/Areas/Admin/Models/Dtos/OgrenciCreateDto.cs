using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Areas.Admin.Models.Dtos
{
    public class OgrenciCreateDto
    {
        public OgrenciDto OgrenciDto { get; set; }
        public SelectList Sinif { get; set; }
    }
}
