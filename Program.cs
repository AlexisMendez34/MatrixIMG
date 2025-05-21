using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixIMG
{
    class Program
    {
        static void Main(string[] args)
        {
            Extraer extractor = new Extraer(); //Extraer la matriz de la imagen monocromática
            Modificar operacion = new Modificar(); //Operaciones con matrices
            Construir construccion = new Construir(); //Crear la nueva imagen a partir de la matriz modificada

            int[,] matrix = extractor.ExtIMG();

            Console.WriteLine("Presione cualquier tecla para salir");
            Console.ReadKey();

            //ALEXIS Se debe realizar una función que pueda leer una imagen monocromática y convertirla a una matriz de píxeles, La función debe devolver la matriz de píxeles.
            //IAN Se requieren realizar las funciones que hagan la transpuesta, y la reversa transpuesta de dicha matriz.
            //TESS Despues se debe crear una imagen a partir de la matriz de píxeles, y guardar la imagen en un archivo.
            var construir = new Construir();
            var cuadriculado = new Construir.Cuadriculado(8, 10); // 8x8 cuadros de 10 píxeles

            int[,] matriz = cuadriculado.GenerarMatriz();
            construir.GuardarImagenDesdeMatriz(matriz, "cuadriculado.png");
            
            //Por ultimo, se debe realizar una interfaz que permita al usuario elegir que proceso realizar.
        }
    }
}
