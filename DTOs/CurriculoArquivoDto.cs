public class CurriculoArquivoDto
{
    public int CurriculoId { get; set; }
    public int ArquivoId { get; set; }
    // Do not include navigation properties that could cause cycles
}
