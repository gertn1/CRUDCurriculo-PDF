namespace WebCurriculum.Interface.Service
{
    public interface IArquivoService
    {
        Task<Arquivo> SaveFileAsync(IFormFile file);
        Task DeleteFileAsync(int id);
        bool IsValidExtension(string fileName);
    }

}
