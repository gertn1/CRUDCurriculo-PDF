using System.Text.Json.Serialization;

public class Arquivo
{
    public int Id { get; set; }
    public string NomeArquivo { get; set; }
    public string TipoArquivo { get; set; }
    public string CaminhoServidor { get; set; }

    //public int CurriculoId { get; set; }

    [JsonIgnore]
    public ICollection<CurriculoArquivo> CurriculoArquivos { get; set; }
}
