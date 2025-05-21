using System;
using System.Drawing;

namespace MatrixIMG
{
    class Construir
    {
        public void GuardarImagenDesdeMatriz(string rutaArchivo)
        {
            int[,] matriz = new int[2, 2]
            {
                { 0, 255 },
                { 255, 0 }
            };

            int ancho = 2;
            int alto = 2;

            using (Bitmap imagen = new Bitmap(ancho, alto))
            {
                imagen.SetPixel(0, 0, Color.FromArgb(matriz[0, 0], matriz[0, 0], matriz[0, 0]));
                imagen.SetPixel(1, 0, Color.FromArgb(matriz[1, 0], matriz[1, 0], matriz[1, 0]));
                imagen.SetPixel(0, 1, Color.FromArgb(matriz[0, 1], matriz[0, 1], matriz[0, 1]));
                imagen.SetPixel(1, 1, Color.FromArgb(matriz[1, 1], matriz[1, 1], matriz[1, 1]));

                imagen.Save(rutaArchivo, System.Drawing.Imaging.ImageFormat.Png);
                Console.WriteLine($"Imagen guardada en: {rutaArchivo}");
                Console.ReadKey();
            }
        }


        public class Cuadriculado
        {
            private int cuadros;
            private int tamañoCuadro;

            public Cuadriculado(int cuadros, int tamañoCuadro)
            {
                this.cuadros = cuadros;
                this.tamañoCuadro = tamañoCuadro;
            }

            public int[,] GenerarMatriz()
            {
                int ancho = cuadros * tamañoCuadro;
                int alto = cuadros * tamañoCuadro;
                int[,] matriz = new int[ancho, alto];

                for (int y = 0; y < alto; y++)
                {
                    for (int x = 0; x < ancho; x++)
                    {
                        int fila = y / tamañoCuadro;
                        int columna = x / tamañoCuadro;
                        bool esNegro = (fila + columna) % 2 == 0;
                        matriz[x, y] = esNegro ? 0 : 255;
                    }
                }
                Console.WriteLine("Imagen creada, cuadricula....");
                Console.ReadKey();
                return matriz;
            }
        }
    }
}
