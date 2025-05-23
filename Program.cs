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

            int[,] matrix;

            operacion.TranspuestaInversa(matrix);

            Construir.Cuadriculado cuadriculado = new Construir.Cuadriculado(8, 10); // 8x8 cuadros de 10 píxeles


            construccion.GuardarImagenDesdeMatriz("../../imagenes/cuadricula.png");

            Console.WriteLine("Presione cualquier tecla para salir");
            Console.ReadKey();
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
                        try
                        {
                            if (!File.Exists(Console.ReadLine())) 
                            {
                                Console.WriteLine("El archivo no existe");
                                Console.WriteLine("Presione cualquier tecla para continuar");
                                Console.ReadKey();
                            }
                            else
                            {
                                matrix = extractor.ExtIMG();
                                operacion.Transpuesta(matrix);
                            }
                        }
                        catch (FormatException ex)
                        {
                            op = '-';
                            Console.Clear();
                            Console.WriteLine("Ha ocurrido un error: " + ex.Message);
                            Console.WriteLine("Presione cualquier tecla para continuar");
                            Console.ReadKey();
                        }
                        finally
                        {
                            Console.Clear();
                        }
                        break;
                    case 'b':
                        break;
                    case 'c':
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
