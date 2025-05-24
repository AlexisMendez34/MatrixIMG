using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixIMG
{
    class Modificar : Extraer
    {
        public int[,] Transpuesta(int[,] modMatrix) 
        {
            if (modMatrix.GetLength(0) == 0) return modMatrix;
            int[,] tempMatrix = new int[modMatrix.GetLength(0), modMatrix.GetLength(1)];

            for (int j = 0; j < modMatrix.GetLength(1); j++) // El arreglo se recorre por cada renglon y después sigue a la siguiente columna
            {
                for (int i = 0; i < modMatrix.GetLength(0); i++)
                {
                    int pixel = modMatrix[j, i];
                    char pix = Renderizar(pixel);
                    Console.Write(pix + " ");
                    tempMatrix[i, j] = pixel;
                }
                Console.Write("\n");
            }
            Console.Write("\nTranspuesta lista\n\n");

            Console.Write("Presione enter para continuar...");
            Console.ReadKey();

            return tempMatrix;
        }

        public int[,] TranspuestaInversa(int[,] modMatrix)
        {
            if (modMatrix.GetLength(0) == 0) return modMatrix;
            int[,] tempMatrix = new int[modMatrix.GetLength(0), modMatrix.GetLength(1)];

            for (int j = modMatrix.GetLength(1) - 1; j >= 0; j--) // Igual que la transpuesta solamente que el arreglo empieza desde el último elemento del arreglo
            {
                for (int i = modMatrix.GetLength(0) - 1; i >= 0; i--)
                {
                    int pixel = modMatrix[j, i];
                    char pix = Renderizar(pixel);
                    Console.Write(pix + " ");
                    try
                    {
                        tempMatrix[modMatrix.GetLength(0) - j, modMatrix.GetLength(1) - i] = modMatrix[i, j];
                    }
                    catch { }
                }
                Console.Write("\n");
            }
            Console.Write("\nTranspuesta e inversa lista\n\n");

            Console.Write("Presione enter para continuar...");
            Console.ReadKey();

            return tempMatrix;
        }

        public int[,] GenerarRuido(int[,] modMatrix)
        {
            if (modMatrix.GetLength(0) == 0) return modMatrix;
            int tamImg = modMatrix.Length;
            Random rnd = new Random();

            Console.Write("Ingrese el porcentaje de ruido deseado (0-1): ");

            try
            {
                double porcentajeRuido = double.Parse(Console.ReadLine());

                if (porcentajeRuido < 0 || porcentajeRuido > 1)
                    throw new ArgumentOutOfRangeException("Ingresa un porcentaje de ruido adecuado");

                for (int i = 0; i < modMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < modMatrix.GetLength(1); j++)
                    {
                        int pixel = modMatrix[j, i];

                        if (rnd.NextDouble() < porcentajeRuido)
                        {
                            int ruido = rnd.Next(-50, 51); // Genera un ruido entre -50 y 50
                            pixel += ruido;
                            pixel = Math.Max(0, Math.Min(255, pixel)); // Asegura que pixel no salga del rango de [0, 255]
                        }

                        modMatrix[j, i] = pixel;
                    }
                }
                Console.Write("\nEl ruuido agregado correctamente\n\n");
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Write("Presione enter para continuar...");
                Console.ReadKey();
            }

            return modMatrix;
        }
    }
}
