namespace WebCurriculum.Interface.Respositoty
{
    public interface IArquivoRepository
    {
        Task AddAsync(Arquivo arquivo);
        Task<Arquivo> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }

}
