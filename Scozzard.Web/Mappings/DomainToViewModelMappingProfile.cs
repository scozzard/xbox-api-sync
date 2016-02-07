using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Scozzard.Model;
using Scozzard.Web.ViewModels;

namespace Scozzard.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<Gadget, GadgetViewModel>();
            Mapper.CreateMap<XboxUser, XboxUserViewModel>();
            Mapper.CreateMap<Activity, ActivityViewModel>();
        }
    }
}