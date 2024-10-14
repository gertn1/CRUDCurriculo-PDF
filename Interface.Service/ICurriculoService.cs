namespace WebCurriculum.Interface.Service
{
    public interface ICurriculoService
    {
        Task<IEnumerable<Curriculo>> GetAllAsync();
        Task<Curriculo> GetByIdAsync(int id);
        Task AddAsync(Curriculo curriculo, IFormFile file);
        Task UpdateAsync(Curriculo curriculo, IFormFile newFile);
        Task DeleteAsync(int id);
    }

}
