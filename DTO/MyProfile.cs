using AutoMapper;

namespace DotNetCore_RestApi_Sqlite.DTO
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<Item, ItemDTO>();
            CreateMap<SubItem, SubItemDTO>();
        }
    }
}