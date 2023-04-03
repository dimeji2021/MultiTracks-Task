using AutoMapper;
using MultiTracks.API.Domain.Models.Dtos;
using MultiTracks.API.Domain.Models.Entities;

namespace MultiTracks.API.Domain.Core.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Artist, ArtistCreateDto>().ReverseMap()
                .ForMember(dest => dest.DateCreation, act => act.MapFrom(time => DateTime.Now));
            CreateMap<SongDto, Song>().ReverseMap();
            CreateMap<ArtistGetDto, Artist>().ReverseMap();


        }
    }
}
