using System.Text.Json.Serialization;
using WebCurriculum.Enums;

public class Curriculo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public Nivel Nivel { get; set; }

    [JsonIgnore]
    public ICollection<CurriculoArquivo> CurriculoArquivos { get; set; }
}
