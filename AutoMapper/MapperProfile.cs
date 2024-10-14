using AutoMapper;
using WebCurriculum.DTOs;

namespace WebCurriculum.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Curriculo, CurriculoDto>()
                .ForMember(dest => dest.CaminhoImagem, opt => opt.MapFrom(src =>
                    src.CurriculoArquivos.FirstOrDefault() != null
                        ? src.CurriculoArquivos.FirstOrDefault().Arquivo.CaminhoServidor
                        : null));

            CreateMap<CurriculoCreateDto, Curriculo>();
            CreateMap<Arquivo, ArquivoDto>();
            CreateMap<CurriculoArquivo, CurriculoArquivoDto>();
            CreateMap<CurriculoEditDto, Curriculo>(); 
        }
    }
}
