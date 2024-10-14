﻿using WebCurriculum.Enums;

namespace WebCurriculum.DTOs
{
    public class CurriculoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Nivel Nivel { get; set; }
        public string CaminhoImagem { get; set; }

        public IFormFile File { get; set; }
        public ICollection<ArquivoDto> Arquivos { get; set; }
    }

}
