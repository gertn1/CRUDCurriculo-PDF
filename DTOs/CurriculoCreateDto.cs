using WebCurriculum.Enums;

namespace WebCurriculum.DTOs
{
    public class CurriculoCreateDto
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public Nivel Nivel { get; set; }
    }
}
