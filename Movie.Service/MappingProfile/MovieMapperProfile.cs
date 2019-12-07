using AutoMapper;
using Domain.Business.Movie;
using Movie.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Service.MappingProfile
{
    public class MovieMapperProfile : Profile
    {
        public MovieMapperProfile()
        {
            CreateMap<MovieDTO, MovieEntity>()
                .ConstructUsing(x => new MovieEntity(string.IsNullOrEmpty(x.Id) ? MovieId.New : MovieId.With(x.Id)));
        }
    }
}
