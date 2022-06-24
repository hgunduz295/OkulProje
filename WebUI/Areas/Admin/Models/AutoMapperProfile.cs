using AutoMapper;
using Okul.Domain;
using WebUI.Areas.Admin.Models.Dtos;

namespace WebUI.Areas.Admin.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Ogrenci, OgrenciCreateDto>();
            CreateMap<OgrenciCreateDto, Ogrenci>();
            CreateMap<Ogretmen, OgretmenCreateDto>();
            CreateMap<OgretmenCreateDto, Ogretmen>();
            CreateMap<Sinif, SinifModel>();
            CreateMap<Brans, BransModel>();

            // CreateMap<List<Sinif>, List<SinifModel>>();

        }
    }
}
