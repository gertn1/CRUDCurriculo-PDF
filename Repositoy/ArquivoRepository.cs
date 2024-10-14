using WebCurriculum.Data;
using WebCurriculum.Interface.Respositoty;

namespace WebCurriculum.Repository
{
    public class ArquivoRepository : IArquivoRepository
    {
        private readonly AppDbContext _context;

        public ArquivoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Arquivo arquivo)
        {
            _context.Arquivos.Add(arquivo);
            await _context.SaveChangesAsync();
        }

        public async Task<Arquivo> GetByIdAsync(int id)
        {
            return await _context.Arquivos.FindAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            var arquivo = await GetByIdAsync(id);
            if (arquivo != null)
            {
                _context.Arquivos.Remove(arquivo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
