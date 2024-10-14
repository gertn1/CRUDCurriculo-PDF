
using WebCurriculum.Interface.Respositoty;
using WebCurriculum.Interface.Service;

namespace WebCurriculum.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly IArquivoRepository _arquivoRepository;
        private readonly IWebHostEnvironment _environment;

        private readonly List<string> _allowedExtensions = new List<string>
        {
            ".pdf", ".docx", ".doc", ".png", ".jpg", ".jpeg", ".gif"
        };

        private const long _maxFileSize = 10 * 1024 * 1024;

        public ArquivoService(IArquivoRepository arquivoRepository, IWebHostEnvironment environment)
        {
            _arquivoRepository = arquivoRepository;
            _environment = environment;
        }

        public bool IsValidExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return _allowedExtensions.Contains(extension);
        }

        public async Task<Arquivo> SaveFileAsync(IFormFile file)
        {
            if (file.Length > _maxFileSize)
                throw new Exception("O tamanho do arquivo excede o limite permitido.");

         
            var rootPath = _environment.WebRootPath ?? _environment.ContentRootPath;
            if (string.IsNullOrEmpty(rootPath))
                throw new Exception("O caminho raiz do aplicativo não foi encontrado.");

            var uploadsFolder = Path.Combine(rootPath, "uploads");
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var arquivo = new Arquivo
            {
                NomeArquivo = file.FileName,
                TipoArquivo = file.ContentType,
                CaminhoServidor = Path.Combine("uploads", uniqueFileName)
            };

            await _arquivoRepository.AddAsync(arquivo);
            return arquivo;
        }

        public async Task DeleteFileAsync(int id)
        {
            var arquivo = await _arquivoRepository.GetByIdAsync(id);
            if (arquivo != null)
            {
                var rootPath = _environment.WebRootPath ?? _environment.ContentRootPath;
                if (string.IsNullOrEmpty(rootPath))
                    throw new Exception("O caminho raiz do aplicativo não foi encontrado.");

                var filePath = Path.Combine(rootPath, arquivo.CaminhoServidor);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                await _arquivoRepository.DeleteAsync(id);
            }
        }
    }
}
