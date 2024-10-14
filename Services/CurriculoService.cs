using WebCurriculum.Interface.Respositoty;
using WebCurriculum.Interface.Service;

namespace WebCurriculum.Services
{
    public class CurriculoService : ICurriculoService
    {
        private readonly ICurriculoRepository _curriculoRepository;
        private readonly IArquivoService _arquivoService;

        public CurriculoService(ICurriculoRepository curriculoRepository, IArquivoService arquivoService)
        {
            _curriculoRepository = curriculoRepository;
            _arquivoService = arquivoService;
        }

        public async Task<IEnumerable<Curriculo>> GetAllAsync()
        {
            return await _curriculoRepository.GetAllAsync();
        }

        public async Task<Curriculo> GetByIdAsync(int id)
        {
            return await _curriculoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Curriculo curriculo, IFormFile file)
        {
            if (file != null && _arquivoService.IsValidExtension(file.FileName))
            {
                var arquivo = await _arquivoService.SaveFileAsync(file);
                curriculo.CurriculoArquivos = new List<CurriculoArquivo>
                {
                    new CurriculoArquivo { ArquivoId = arquivo.Id }
                };
            }
            else if (file != null)
            {
                throw new Exception($"Tipo de arquivo não permitido: {file.FileName}");
            }

            await _curriculoRepository.AddAsync(curriculo);
        }

        public async Task UpdateAsync(Curriculo curriculo, IFormFile newFile)
        {
            var existingCurriculo = await _curriculoRepository.GetByIdAsync(curriculo.Id);
            if (existingCurriculo == null)
                throw new Exception("Currículo não encontrado.");

            existingCurriculo.Nome = curriculo.Nome;
            existingCurriculo.Email = curriculo.Email;
            existingCurriculo.Telefone = curriculo.Telefone;
            existingCurriculo.Nivel = curriculo.Nivel;

            if (newFile != null && _arquivoService.IsValidExtension(newFile.FileName))
            {
                var arquivo = await _arquivoService.SaveFileAsync(newFile);
                existingCurriculo.CurriculoArquivos.Add(new CurriculoArquivo
                {
                    ArquivoId = arquivo.Id
                });
            }
            else if (newFile != null)
            {
                throw new Exception($"Tipo de arquivo não permitido: {newFile.FileName}");
            }

            await _curriculoRepository.UpdateAsync(existingCurriculo);
        }


        public async Task DeleteAsync(int id)
        {
            var curriculo = await _curriculoRepository.GetByIdAsync(id);
            if (curriculo == null)
                throw new Exception("Currículo não encontrado.");

            // Remove os arquivos associados
            foreach (var ca in curriculo.CurriculoArquivos)
            {
                await _arquivoService.DeleteFileAsync(ca.ArquivoId);
            }

            await _curriculoRepository.DeleteAsync(id);
        }
    }

}
