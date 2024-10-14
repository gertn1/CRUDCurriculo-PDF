namespace WebCurriculum.Interface.Service
{
    public interface ICurriculoService
    {
        Task<IEnumerable<Curriculo>> GetAllAsync();
        Task<Curriculo> GetByIdAsync(int id);
        Task AddAsync(Curriculo curriculo, ICollection<IFormFile> files);
        Task UpdateAsync(Curriculo curriculo, ICollection<IFormFile> newFiles);
        Task DeleteAsync(int id);
    }

}
