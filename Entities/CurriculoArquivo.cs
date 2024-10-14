using System.Text.Json.Serialization;

public class CurriculoArquivo
{
    public int CurriculoId { get; set; }

    [JsonIgnore]
    public Curriculo Curriculo { get; set; }

    public int ArquivoId { get; set; }

    [JsonIgnore]
    public Arquivo Arquivo { get; set; }
}
