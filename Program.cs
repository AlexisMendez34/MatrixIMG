using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

            string archivo = null;
            int[,] matrix;            
            char op = '-';
            do
            {
                Console.WriteLine(" -------------------------------");
                Console.WriteLine("|\t---MATRIX IMG---\t|");
                Console.WriteLine("|-------------------------------|");
                Console.WriteLine("|\ta) Transpuesta\t\t|");
                Console.WriteLine("|\tb) Reflexión\t\t|");
                Console.WriteLine("|\tc) Ruido\t\t|");
                Console.WriteLine("|\td) Salir\t\t|");
                Console.WriteLine(" -------------------------------");
                Console.WriteLine("\nArchivo actual: " + (String.IsNullOrEmpty(archivo) ? "Ninguno" : archivo));

                Console.Write("\nIngrese un inciso: ");
                try
                {
                    op =char.Parse(Console.ReadLine().ToLower());
                }
                catch (FormatException ex)
                {
                    op = '-';
                    Console.Clear();
                    Console.WriteLine("Ha ocurrido un error: "+ex.Message);
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                }
                finally
                {
                    Console.Clear();
                }

                switch (op)
                {
                    case 'a':
                        Console.Write("Ingrese el nombre de la imagen: ");
                        archivo = Console.ReadLine();
                        matrix = extractor.ExtIMG(archivo);
                        matrix = operacion.Transpuesta(matrix);
                        construccion.GuardarImagenDesdeMatriz("../../imagenes/transpuesta_" + archivo, matrix);
                        Console.Clear();
                        break;
                    case 'b':
                        archivo = Console.ReadLine();
                        matrix = extractor.ExtIMG(archivo);
                        matrix = operacion.TranspuestaInversa(matrix);
                        construccion.GuardarImagenDesdeMatriz("../../imagenes/reflexion_" + archivo, matrix);
                        Console.Clear();
                        break;
                    case 'c':
                        archivo = Console.ReadLine();
                        matrix = extractor.ExtIMG(archivo);
                        matrix = operacion.GenerarRuido(matrix);
                        construccion.GuardarImagenDesdeMatriz("../../imagenes/ruido_" + archivo, matrix);
                        break;
                    case 'd':
                        break;
                    case '-':
                        break;
                    default:
                        break;
                }
            }
            while (op != 'd');

            //ALEXIS Se debe realizar una función que pueda leer una imagen monocromática y convertirla a una matriz de píxeles, La función debe devolver la matriz de píxeles.
            //IAN Se requieren realizar las funciones que hagan la transpuesta, y la reversa transpuesta de dicha matriz.
            //TESS Despues se debe crear una imagen a partir de la matriz de píxeles, y guardar la imagen en un archivo.
            
            //Por ultimo, se debe realizar una interfaz que permita al usuario elegir que proceso realizar.
        }
    }
}
