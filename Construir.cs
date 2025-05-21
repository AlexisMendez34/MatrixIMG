using System;
using System.Drawing;

namespace MatrixIMG
{
    class Construir
    {
        public void GuardarImagenDesdeMatriz(int[,] matriz, string rutaArchivo)
        {
            int ancho = matriz.GetLength(0);
            int alto = matriz.GetLength(1);

            using (Bitmap imagen = new Bitmap(ancho, alto))
            {
                for (int y = 0; y < alto; y++)
                {
                    for (int x = 0; x < ancho; x++)
                    {
                        int valor = matriz[x, y];
                        Color color = Color.FromArgb(valor, valor, valor); // Blanco o negro
                        imagen.SetPixel(x, y, color);
                    }
                }

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
