using AutoMapper;
using IAFerias.API.Models;
using IAFerias.API.Models.DTO;

namespace IAFerias.API.Helpers
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<Choice, ChoiceDTO>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.text));

            CreateMap<ChatGptResponse, GptResponseDTO>()
                .ForMember(dest => dest.Choice, opt => opt.MapFrom(src => src.choices != null ? src.choices.FirstOrDefault() : null));
        }
    }
}
