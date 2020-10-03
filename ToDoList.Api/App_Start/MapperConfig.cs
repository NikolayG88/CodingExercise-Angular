using Application.Interfaces;
using Domain.Entities;
using AutoMapper;

namespace CodingExercise.API.App_Start
{

    public class MapperConfig : MapperConfiguration
    {
        public MapperConfig() : base(cfg =>
        {
            cfg.CreateMap<IToDoItem, ToDoItem>().ReverseMap();
        })
        {

        }
    }

}