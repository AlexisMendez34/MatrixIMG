using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace MatrixIMG
{
    class Extraer
    {
        public void ExtIMG()
        {
            if (File.Exists("imagenes/casillas.png"))
            {
                Console.WriteLine("Extracción de matriz preparada");
            }
            else
            {
                Console.WriteLine("Imgen no encontrada");
            }
        }
    }
}
