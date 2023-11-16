using AutoMapper;
using DeviceLib.Model.Class.Device;
using DeviceLib.Model.Class.DTO.DeviceDTO;
using System.Reflection.PortableExecutable;

namespace server_app.Helper;

public class AutoMapperConfig:Profile
{
    public AutoMapperConfig()
    {
        CreateMap<СharacteristicDTO, Сharacteristic>();
        CreateMap<Сharacteristic, СharacteristicDTO>();

        CreateMap<CharacteristicTypeDTO, CharacteristicType>()
            .ForMember(dest => dest.Characteristics, opt => opt.MapFrom(src => src.Сharacteristic));

        CreateMap<CharacteristicType, CharacteristicTypeDTO>()
            .ForMember(dest => dest.Сharacteristic, opt => opt.MapFrom(src => src.Characteristics));

        CreateMap<SubCategoryDTO, SubCategory>()
            .ForMember(dest => dest.CharacteristicsType, opt => opt.MapFrom(src => src.CharacteristicType));
        CreateMap<SubCategory, SubCategoryDTO>()
            .ForMember(dest => dest.CharacteristicType, opt => opt.MapFrom(src => src.CharacteristicsType));

        CreateMap<CategoryDTO, Category>()
            .ForMember(dest => dest.SubCategories, opt => opt.MapFrom(src => src.SubCategories));
        CreateMap<Category, CategoryDTO>()
            .ForMember(dest => dest.SubCategories, opt => opt.MapFrom(src => src.SubCategories));



        CreateMap<Brand, BrandDTO>();
        CreateMap<BrandDTO, Brand>();

        CreateMap<Product, ProductDTO>()
           .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
           .ForMember(dest => dest.CharacteristicValues, opt => opt.MapFrom(src => src.CharacteristicValues));

        CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.CharacteristicValues, opt => opt.MapFrom(src => src.CharacteristicValues));


    }
}
