using AutoMapper;
using Okul.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Areas.Admin.Models.Dtos;

namespace WebUI.Areas.Admin.Models
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Ogrenci, OgrenciDto>();
            CreateMap<OgrenciDto, Ogrenci>();
            CreateMap<Sinif, SinifModel>();
           // CreateMap<List<Sinif>, List<SinifModel>>();
           
        }
    }
}
