using System;
using System.IO;

namespace CreadorDelModelo
{
    class Program
    {
        static void Main(string[] args)
        {
            var Dir1 = "ModeloTensorFlow/tensorflow_inception_graph.pb";
            var Dir2 = "PredictionModel.zip";
            var Creador = new CreadorDeModelo(Dir1, Dir2);
            Creador.Run();
        }
    }
}
