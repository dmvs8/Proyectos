using System;

namespace segundoParcial
{
    class Program
    {
        static string[,] IntercalarMatrices(string[,] matrizA, string[,] matrizB)
        {
            if ((matrizA.GetLength(0) != matrizB.GetLength(0)) ||
                matrizA.GetLength(1) != matrizB.GetLength(1))
            {
                throw new InvalidOperationException();
            }


            string[,] nuevaMatriz = new string[matrizA.GetLength(0), matrizA.GetLength(1)];

            for (int fila = 0; fila < matrizA.GetLength(0); fila++)
            {
                for (int columna = 0; columna < matrizA.GetLength(1); columna++)
                {
                    if (columna % 2 == 0)
                    {
                        nuevaMatriz[fila, columna] = matrizA[fila, columna];
                    }
                    else
                    {
                        nuevaMatriz[fila, columna] = matrizB[fila, columna];
                    }
                }
            }

            return nuevaMatriz;
        }




        static void Main(string[] args)
        {
            string[,] matrizA = new string[3, 4]
                {{"ASD", "QWE", "ZXC", "QAZ" },
                 {"RTY", "FGH", "VBN", "WSX" },
                 {"UIO", "JKL", "NMÑ", "EDC" }};


            string[,] matrizB = new string[3, 4]
                {{"QQQ", "WWW", "EEE", "PLM" },
                 {"AAA", "SSS", "DDD", "OKN" },
                 {"ZZZ", "NNN", "CCC", "IJB" }};


            string[,] matrizC = IntercalarMatrices(matrizA,matrizB);
            for (int fila = 0; fila < matrizC.GetLength(0); fila++)
            {
                for (int columna = 0; columna < matrizC.GetLength(1); columna++)
                {
                    Console.Write($"[{matrizC[fila,columna]}]");
                }

                Console.WriteLine();
            }

        }
    }
}
