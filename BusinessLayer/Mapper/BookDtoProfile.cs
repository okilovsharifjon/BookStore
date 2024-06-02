using AutoMapper;
using StoreDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BookDtoProfile : Profile
    {
        public BookDtoProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();
        }
    }
}
