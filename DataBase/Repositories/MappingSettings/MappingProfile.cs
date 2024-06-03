using AutoMapper;
using Core.Models;
using DataBase.Repositories.DTOModels;
using Category = DataBase.Repositories.DTOModels.Category;

namespace DataBase.Repositories.MappingSettings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Core.Models.Category, Category>(MemberList.Destination).ReverseMap();
        CreateMap<Product, ProductDTO>(MemberList.Destination).ReverseMap();
        CreateMap<Storage, StorageDTO>(MemberList.Destination).ReverseMap();
    }
}