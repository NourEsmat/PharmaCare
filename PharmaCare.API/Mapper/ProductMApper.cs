using AutoMapper;
using PharmaCare.Core.DTO;
using PharmaCare.Core.Entites.Products;

namespace PharmaCare.API.Mapper
{
    public class ProductMApper :Profile
    {
        public ProductMApper()
        {
            CreateMap<Product,ProductDTO>()
                .ForMember(p=>p.CategoryName,opt => opt.MapFrom(p => p.Category.name))
                .ReverseMap();

            CreateMap<Photo, PhotoDTO>().ReverseMap();

            CreateMap<AddProductDTO, Product>()
                .ForMember(p => p.photos, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
