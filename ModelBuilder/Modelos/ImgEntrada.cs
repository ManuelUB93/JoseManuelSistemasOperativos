using Microsoft.ML.Transforms.Image;
using System.Drawing;

namespace CreadorDelModelo.Modelos
{
    public class ImagenDeEntrada
    {
        [ImageType(224, 224)]
        public Bitmap Image { get; set; }
    }
}