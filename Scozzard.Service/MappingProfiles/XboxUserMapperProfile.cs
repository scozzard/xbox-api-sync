using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Scozzard.XboxApiClient.Model;
using Scozzard.Model;

namespace Scozzard.Service.MappingProfiles
{
    public class XboxUserMapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<xbox_user, XboxUser>()
                .ForMember(dest => dest.XboxUserID, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.GamerTag, opt => opt.MapFrom(src => src.Gamertag))
                .ForMember(dest => dest.Gamerscore, opt => opt.MapFrom(src => src.Gamerscore))
                .ForMember(dest => dest.GameDisplayName, opt => opt.MapFrom(src => src.GameDisplayName))
                .ForMember(dest => dest.GameDisplayPicRaw, opt => opt.MapFrom(src => src.GameDisplayPicRaw))
                .ForMember(dest => dest.XboxOneRep, opt => opt.MapFrom(src => src.XboxOneRep));
        }
    }
}
