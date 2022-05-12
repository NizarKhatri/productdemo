using AutoMapper;
using Product.Core.Dto;
using Product.Core.Entity;

namespace CBM.API.Mappings
{
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            this.CreateMap<ProductDto, Products>()
        .ForMember(x => x.CreatedBy, i => i.Ignore())
        .ForMember(x => x.CreatedOn, i => i.Ignore())
        .ForMember(x => x.LastModifiedBy, i => i.Ignore())
        .ForMember(x => x.LastModifiedOn, i => i.Ignore())
        .ReverseMap();
        }
    }
}
