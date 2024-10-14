using AutoMapper;
using WebCurriculum.DTOs;

namespace WebCurriculum.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Curriculo, CurriculoDto>()
           .ForMember(dest => dest.Arquivos, opt => opt.MapFrom(src => src.CurriculoArquivos.Select(ca => ca.Arquivo)));

            CreateMap<CurriculoCreateDto, Curriculo>();
            CreateMap<Arquivo, ArquivoDto>();
            CreateMap<CurriculoArquivo, CurriculoArquivoDto>();
        }
    }
}
