using System;
using System.Drawing;

namespace MatrixIMG
{
    class Construir
    {
        public void GuardarImagenDesdeMatriz(string rutaArchivo, int[,] matriz)
        {
            if (matriz.GetLength(0) == 0) return;

            else
            {
                using (Bitmap imagen = new Bitmap(matriz.GetLength(0), matriz.GetLength(1)))
                {
                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                        for (int j = 0; j < matriz.GetLength(1); j++)
                        {
                            imagen.SetPixel(j, i, Color.FromArgb(matriz[j, i], matriz[j, i], matriz[j, i]));
                        }
                    }
                    imagen.Save(rutaArchivo, System.Drawing.Imaging.ImageFormat.Png);
                    Console.WriteLine($"Imagen guardada en: {rutaArchivo}");
                    Console.WriteLine("Presione enter para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
