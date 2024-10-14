using Microsoft.EntityFrameworkCore;
using WebCurriculum.Data;
using WebCurriculum.Interface.Respositoty;

namespace WebCurriculum.Repository
{
    public class CurriculoRepository : ICurriculoRepository
    {
        private readonly AppDbContext _context;

        public CurriculoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Curriculo>> GetAllAsync()
        {
            return await _context.Curriculos
                .Include(c => c.CurriculoArquivos)
                    .ThenInclude(ca => ca.Arquivo)
                .ToListAsync();
        }

        public async Task<Curriculo> GetByIdAsync(int id)
        {
            return await _context.Curriculos
                .Include(c => c.CurriculoArquivos)
                    .ThenInclude(ca => ca.Arquivo)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Curriculo curriculo)
        {
            _context.Curriculos.Add(curriculo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Curriculo curriculo)
        {
            _context.Curriculos.Update(curriculo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var curriculo = await GetByIdAsync(id);
            if (curriculo != null)
            {
                _context.Curriculos.Remove(curriculo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
