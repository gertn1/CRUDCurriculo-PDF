namespace WebCurriculum.Interface.Respositoty
{
    public interface ICurriculoRepository
    {
        Task<IEnumerable<Curriculo>> GetAllAsync();
        Task<Curriculo> GetByIdAsync(int id);
        Task AddAsync(Curriculo curriculo);
        Task UpdateAsync(Curriculo curriculo);
        Task DeleteAsync(int id);
    }



}
