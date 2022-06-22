using AutoMapper;
using Okul.Domain;
using WebUI.Areas.Admin.Models.Dtos;

namespace WebUI.Areas.Admin.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Ogrenci, OgrenciDto>();
            CreateMap<OgrenciDto, Ogrenci>();
            CreateMap<Ogretmen, OgretmenDto>();
            CreateMap<OgretmenDto, Ogretmen>();
            CreateMap<Sinif, SinifModel>();
            // CreateMap<List<Sinif>, List<SinifModel>>();

        }
    }
}
