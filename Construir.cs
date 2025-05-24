using System;
using System.Drawing;

namespace MatrixIMG
{
    class Construir
    {
        public void GuardarImagenDesdeMatriz(string rutaArchivo, int[,] matriz)
        {
            int size = matriz.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    using (Bitmap imagen = new Bitmap(size, size))
                    {
                        imagen.SetPixel(j, i, Color.FromArgb(matriz[j, i], matriz[j, i], matriz[j, i]));

                        imagen.Save(rutaArchivo, System.Drawing.Imaging.ImageFormat.Png);
                        Console.WriteLine($"Imagen guardada en: {rutaArchivo}");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
