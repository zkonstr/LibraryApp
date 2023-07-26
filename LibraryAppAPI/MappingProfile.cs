using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibraryAppAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Book, BookDTO>();
            

            CreateMap<UserForCreationDTO, User>();
            CreateMap<BookForCreationDTO, Book>();

            CreateMap<UserForUpdateDTO, User>();
            CreateMap<BookForUpdateDTO, Book>();
        }
    }
}
