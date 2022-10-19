using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.ML;
using CreadorDelModelo.Modelos;

namespace IdentificadorWeb.Data
{
    public class ServicioClasificador
    {
        private string[] Nombres;
        private PredictionEnginePool<ImagenDeEntrada, PreddicionDeImagen> MotorDePrediccion;

        public ServicioClasificador(PredictionEnginePool<ImagenDeEntrada, PreddicionDeImagen> Motor)
        {
            MotorDePrediccion = Motor;
            string dir = ServicioDireccion.EncontrarDirCompleta(Path.Combine("ModeloTensorFlow", "imagenet_comp_graph_label_strings.txt"));
            Nombres = System.IO.File.ReadAllLines(dir);
        }

        public ResultadoImagen Classify(MemoryStream image)
        { 
            Bitmap bitmapImage = (Bitmap)Image.FromStream(image);
            ImagenDeEntrada ImagenEntrada = new ImagenDeEntrada { Image = bitmapImage };
            PreddicionDeImagen PredicionDeNombres = MotorDePrediccion.Predict(ImagenEntrada);
            float[] Probs = PredicionDeNombres.NombrePred;
            var _Maxima = Probs.Max();
            var MaximaProbabilidad = Probs.AsSpan().IndexOf(_Maxima);
            return new ResultadoImagen()
            {
              Nombre = Nombres[MaximaProbabilidad],
              Probabilidad = _Maxima
            };
        }
    }
}
