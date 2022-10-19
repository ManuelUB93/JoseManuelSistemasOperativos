using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace IdentificadorWeb.Data
{
    public class ImagenSeleccionada
    {
        private IBrowserFile _file;
        private Stream _fileReadStream;
        public string Base64Image { get; private set; }
        public ResultadoImagen ClassificationResult { get; set; }
        public string Name => _file.Name;
        public double UploadedPercentage => 100.0 * _fileReadStream.Position / _file.Size;

        public ImagenSeleccionada(IBrowserFile file)
        {
            _file = file;
        }

        public async Task<MemoryStream> Upload(Action OnDataRead)
        {
            if (_fileReadStream is not null) throw new InvalidOperationException("Already uploaded");

            _fileReadStream = _file.OpenReadStream(10 * 1024 * 1024 /* 10MB */);
            var memoryStream = new MemoryStream();

            var buffer = new byte[80 * 1024];
            while ((await _fileReadStream.ReadAsync(buffer)) != 0)
            {
                await memoryStream.WriteAsync(buffer);
                OnDataRead();
            }
            Base64Image = Convert.ToBase64String(memoryStream.ToArray());

            return memoryStream;
        }
    }
}