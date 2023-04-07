using System;

namespace segundoParcialIsteaFit
{
    class Program
    {
        static int PedirIntEnRango(string mensaje, int min, int max)
        {
            int respuesta;
            string respuestaStr;
            Console.WriteLine(mensaje);
            respuestaStr = Console.ReadLine();

            while (!int.TryParse(respuestaStr, out respuesta) ||
                !(respuesta >= min && respuesta <= max))
            {
                Console.WriteLine();
                Console.WriteLine("Respuesta inválida");
                Console.WriteLine(mensaje);
                respuestaStr = Console.ReadLine();
            }

            return respuesta;
        }



        static int MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Ver total de pasos dados");
            Console.WriteLine("2. Ver calorías perdidas totales");
            Console.WriteLine("3. Calcular cantidad promedio de calorías quemadas");
            Console.WriteLine("4. Determinar día de mayor actividad");
            Console.WriteLine("5. Determinar día de menor actividad");

            return PedirIntEnRango("Elija una opción:", 1, 5);
        }



        static int SumarPasos(int[] array)
        {
            int suma = 0;

            for (int i = 0; i < array.Length; i++)
            {
                suma += array[i];
            }

            return suma;
        }



        static double CalcularCaloriasPerdidas(int valor)
        {
            return valor * 0.03;
        }



        static double CalcularTotalCaloriasPerdidas(int[] array)
        {
            double totalCalorias = 0;
            for (int i = 0; i < array.Length; i++)
            {
              totalCalorias += CalcularCaloriasPerdidas(array[i]);
            }

            return totalCalorias;
        }



        static double CalcularPromedioCaloriasPerdidas(int[] array)
        {
            return CalcularTotalCaloriasPerdidas(array) / array.Length;
        }



        static int BuscarDiaMayorActividad(int[] array)
        {
            int indiceDiaMayorActividad = 0;
            int mayorActividad = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > mayorActividad)
                {
                    indiceDiaMayorActividad = i;
                    mayorActividad = array[i];
                }
            }

            return indiceDiaMayorActividad;
        }



        static int BuscarDiaMenorActividad(int[] array)
        {
            int indiceDiaMenorActividad = 0;
            int menorActividad = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < menorActividad)
                {
                    indiceDiaMenorActividad = i;
                    menorActividad = array[i];
                }
            }

            return indiceDiaMenorActividad;
        }






        static void Main(string[] args)
        {
            int cantDias = PedirIntEnRango("Ingrese la cantidad de días que desea registrar:", 1, int.MaxValue);
            int[] dias = new int[cantDias];


            Console.WriteLine();
            for (int i = 0; i < dias.Length; i++)
            {
                dias[i] = PedirIntEnRango($"Indique la cantidad de pasos realizados en el dia {i + 1}:", 0, int.MaxValue);
            }


            while (true)
            {
                int opcionElegida = MostrarMenu();
                switch (opcionElegida)
                {
                    case 1:
                        int totalPasos = SumarPasos(dias);
                        Console.WriteLine();
                        Console.WriteLine($"El total de pasos dados es {totalPasos}");
                        break;
                    case 2:
                        double totalCaloriasPerdidas = CalcularTotalCaloriasPerdidas(dias);
                        Console.WriteLine();
                        Console.WriteLine($"Las calorías perdidas totales son {totalCaloriasPerdidas}");
                        break;
                    case 3:
                        double promedioCaloriasPerdidas = CalcularPromedioCaloriasPerdidas(dias);
                        Console.WriteLine();
                        Console.WriteLine($"El promedio de calorías quemadas es {promedioCaloriasPerdidas}");
                        break;
                    case 4:
                        int diaMayorActividad = BuscarDiaMayorActividad(dias);
                        Console.WriteLine();
                        Console.WriteLine($"El día de mayor actividad es el {diaMayorActividad + 1}º");
                        break;
                    case 5:
                        int diaMenorActividad = BuscarDiaMenorActividad(dias);
                        Console.WriteLine();
                        Console.WriteLine($"El día de menor actividad es el {diaMenorActividad + 1}º");
                        break;
                } 

            }

        }
    }
}
