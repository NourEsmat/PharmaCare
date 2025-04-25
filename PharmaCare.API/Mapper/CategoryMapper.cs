using AutoMapper;
using PharmaCare.Core.DTO;
using PharmaCare.Core.Entites.Products;

namespace PharmaCare.API.Mapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper() 
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
        }
    }
}
