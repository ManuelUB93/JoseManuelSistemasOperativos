using Microsoft.ML.Data;
namespace CreadorDelModelo.Modelos
{
    public class PreddicionDeImagen
    {
        [ColumnName("softmax2")]
        public float[] NombrePred { get; set; }
    }
}