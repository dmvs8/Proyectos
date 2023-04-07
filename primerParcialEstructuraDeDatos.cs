using System;

namespace primerParcialEstructuraDeDatos
{

    class Jugador
    {
        public string Nombre;
        public ConsoleColor ColorFicha;
        public int Posicion;
    }



    class Program
    {

        static string PedirNombre(string mensaje)
        {
            string nombre;
            Console.WriteLine(mensaje);
            nombre = Console.ReadLine();
            return nombre;
        }



        static int PedirIntEnRango(string mensaje, int min, int max)
        {
            int respuesta;
            string respuestaString;
            Console.WriteLine(mensaje);
            respuestaString = Console.ReadLine();

            while (!int.TryParse(respuestaString, out respuesta) ||
                !(respuesta >= min && respuesta <= max))
            {
                Console.WriteLine();
                Console.WriteLine("Respuesta inválida. Elija un número entre 1 y 5");

                Console.WriteLine(mensaje);
                respuestaString = Console.ReadLine();
            }

            return respuesta;
        }



        static ConsoleColor PedirColor()
        {
            Console.WriteLine("");
            Console.WriteLine("Elija un color para su ficha:");
            Console.WriteLine("1.Rojo");
            Console.WriteLine("2.Magenta");
            Console.WriteLine("3.Verde");
            Console.WriteLine("4.Amarillo");
            Console.WriteLine("5.Cian");
            int respuesta = PedirIntEnRango("Su elección:", 1, 5);

            ConsoleColor ColorElegido = ConsoleColor.Black;
            switch (respuesta)
            {
                case 1:
                    ColorElegido = ConsoleColor.Red;
                    break;
                case 2:
                    ColorElegido = ConsoleColor.Magenta;
                    break;
                case 3:
                    ColorElegido = ConsoleColor.Green;
                    break;
                case 4:
                    ColorElegido = ConsoleColor.Yellow;
                    break;
                case 5:
                    ColorElegido = ConsoleColor.Cyan;
                    break;
            }

            return ColorElegido;
        }



        static void AplicarColorEnMensaje(ConsoleColor color, string mensaje)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }



        static void PedirPresionDeTecla()
        {
            Console.WriteLine("Presione una tecla para tirar el dado...");
            Console.ReadKey();
        }



        static int TirarDado()
        {
            Random dado = new Random();
            int numero = dado.Next(1, 7);

            Console.WriteLine($"El valor del dado es {numero}");
            return numero;
        }



        static Jugador AsignarTurno(Jugador ganadorTurno, Jugador primerJugador, Jugador segundoJugador)
        {
            int valorDado = TirarDado();

            if (valorDado <= 3)
            {
                ganadorTurno = primerJugador;
            }
            else
            {
                ganadorTurno = segundoJugador;
            }

            Console.WriteLine($"Comienza {ganadorTurno.Nombre}");
            return ganadorTurno;
        }



        static bool EsRelay(int numero)
        {
            bool EsRelay;
            if (numero % 10 == 0 && numero < 60)
            {
                EsRelay = true;
            }
            else
            {
                EsRelay = false;
            }
            return EsRelay;
        }



        static void AplicarRelay(Jugador jugadorTurno)
        {
            Console.WriteLine();
            AplicarColorEnMensaje(jugadorTurno.ColorFicha, $"{jugadorTurno.Nombre} ha encontrado un relay! Avanza 10 casilleros");
            jugadorTurno.Posicion += 10;
        }



        static bool EsPortal(int numero)
        {
            bool EsPortal;
            if (numero == 6 || numero == 12 || numero == 24 || numero == 48)
            {
                EsPortal = true;
            }
            else
            {
                EsPortal = false;
            }
            return EsPortal;
        }



        static void AplicarPortal(Jugador jugadorTurno)
        {
            if (jugadorTurno.Posicion == 6 || jugadorTurno.Posicion == 24)
            {
                Console.WriteLine();
                AplicarColorEnMensaje(jugadorTurno.ColorFicha, $"{jugadorTurno.Nombre} ha pasado por un portal!");
                AplicarColorEnMensaje(jugadorTurno.ColorFicha, "Avanza la misma cantidad de casilleros que el valor de su ubicación actual");
                jugadorTurno.Posicion *= 2;
            }
            else if (jugadorTurno.Posicion == 12 || jugadorTurno.Posicion == 48)
            {
                Console.WriteLine();
                AplicarColorEnMensaje(jugadorTurno.ColorFicha, $"{jugadorTurno.Nombre} ha pasado por un portal!");
                AplicarColorEnMensaje(jugadorTurno.ColorFicha, "Retrocede la mitad de cantidad de casilleros que el valor de su ubicación actual");
                jugadorTurno.Posicion /= 2;
            }
        }



        static bool EsAgujeroNegro(int numero)
        {
            bool EsAgujeroNegro;
            if (numero == 32 || numero == 38 || numero == 53)
            {
                EsAgujeroNegro = true;
            }
            else
            {
                EsAgujeroNegro = false;
            }
            return EsAgujeroNegro;
        }



        static void AplicarAgujeroNegro(Jugador jugadorTurno)
        {
            Console.WriteLine();
            AplicarColorEnMensaje(jugadorTurno.ColorFicha, $"{jugadorTurno.Nombre} ha caído en un agujero negro!");
            AplicarColorEnMensaje(jugadorTurno.ColorFicha, "Vuelve al casillero 0");
            jugadorTurno.Posicion = 0;
        }



        static bool EsCampoDeAsteroides(int numero)
        {
            bool EsCampoDeAsteroides;
            if (numero % 5 == 0 && numero % 10 != 0 && numero < 64)
            {
                EsCampoDeAsteroides = true;
            }
            else
            {
                EsCampoDeAsteroides = false;
            }
            return EsCampoDeAsteroides;
        }



        static void AplicarCampoDeAsteroides(Jugador jugadorTurno, Jugador primerJugador, Jugador segundoJugador)
        {
            Console.WriteLine();
            AplicarColorEnMensaje(jugadorTurno.ColorFicha, $"{jugadorTurno.Nombre} ha llegado a un campo de asteroides!");
            AplicarColorEnMensaje(jugadorTurno.ColorFicha, "Para salir tire el dado y así obtener una cantidad de maniobras a realizar");
            Console.WriteLine();
            PedirPresionDeTecla();
            double cantidadManiobras = TirarDado();

            Console.WriteLine();
            AplicarColorEnMensaje(jugadorTurno.ColorFicha, $"Para ejecutar las maniobras debe tirar el dado {cantidadManiobras} veces mas");
            AplicarColorEnMensaje(jugadorTurno.ColorFicha, "Cada valor resultante se suma y el total se divide por la cantidad de maniobras");
            AplicarColorEnMensaje(jugadorTurno.ColorFicha, "Mientras el resultado no sea un número entero, no continúa con su turno habitual");
            Console.WriteLine();

            double sumatoria = 0;
            for (int i = 1; i <= cantidadManiobras; i++)
            {
                PedirPresionDeTecla();
                int valorDado = TirarDado();
                sumatoria += valorDado;
            }
            double resultado = sumatoria / cantidadManiobras;

            if (resultado % 1 != 0)
            {
                AplicarColorEnMensaje(jugadorTurno.ColorFicha, $"El resultado es {resultado} Todavía no ha salido del campo de asteroides");
            }
            else if (resultado % 1 == 0)
            {
                AplicarColorEnMensaje(jugadorTurno.ColorFicha, $"El resultado es {resultado} Ha salido del campo de asteroides!");

                PedirPresionDeTecla();
                int turnoFueraDelCampo = TirarDado();
                jugadorTurno.Posicion += turnoFueraDelCampo;
            }

        }



        static void AplicarTiradaExacta(Jugador jugadorTurno, int numero)
        {
            Console.WriteLine();
            AplicarColorEnMensaje(jugadorTurno.ColorFicha, "El valor de su posición es mayor al casillero final! (64)");
            AplicarColorEnMensaje(jugadorTurno.ColorFicha, "Se mantiene en el mismo casillero");
            jugadorTurno.Posicion -= numero;
        }






        static void Main(string[] args)
        {
            Jugador jugadorUno = new Jugador();
            Jugador jugadorDos = new Jugador();
            Jugador jugadorActual = new Jugador();
            int valorDado = 0;
            bool jugando = true;


            while (jugando)
            {
                jugadorUno.Nombre = PedirNombre("Bienvenido al Juego de la Oca en el Espacio! Indique su nombre:");
                jugadorDos.Nombre = PedirNombre("Bienvenido al Juego de la Oca en el Espacio! Indique su nombre:");


                jugadorUno.ColorFicha = PedirColor();
                jugadorDos.ColorFicha = PedirColor();
                while (jugadorDos.ColorFicha == jugadorUno.ColorFicha)
                {
                    Console.WriteLine($"Su elección de color ya fue tomada por {jugadorUno.Nombre}");
                    jugadorDos.ColorFicha = PedirColor();
                }


                PedirPresionDeTecla();
                jugadorActual = AsignarTurno(jugadorActual, jugadorUno, jugadorDos);


                while (jugadorUno.Posicion < 64 && jugadorDos.Posicion < 64)
                {
                    Console.WriteLine();
                    AplicarColorEnMensaje(jugadorUno.ColorFicha, $"La ficha de {jugadorUno.Nombre} está en el casillero {jugadorUno.Posicion}");
                    AplicarColorEnMensaje(jugadorDos.ColorFicha, $"La ficha de {jugadorDos.Nombre} está en el casillero {jugadorDos.Posicion}");


                    PedirPresionDeTecla();


                    if (!(EsCampoDeAsteroides(jugadorActual.Posicion)))
                    {
                        valorDado = TirarDado();
                        jugadorActual.Posicion += valorDado;
                    }


                    if (EsRelay(jugadorActual.Posicion))
                    {
                        AplicarRelay(jugadorActual);
                    }
                    else if (EsPortal(jugadorActual.Posicion))
                    {
                        AplicarPortal(jugadorActual);
                    }
                    else if (EsAgujeroNegro(jugadorActual.Posicion))
                    {
                        AplicarAgujeroNegro(jugadorActual);
                    }
                    else if (EsCampoDeAsteroides(jugadorActual.Posicion))
                    {
                        AplicarCampoDeAsteroides(jugadorActual, jugadorUno, jugadorDos);
                    }
                    else if (jugadorActual.Posicion > 64)
                    {
                        AplicarTiradaExacta(jugadorActual, valorDado);
                    }


                    if (jugadorActual == jugadorUno)
                    {
                        jugadorActual = jugadorDos;
                    }
                    else if (jugadorActual == jugadorDos)
                    {
                        jugadorActual = jugadorUno;
                    }

                }


                if (jugadorUno.Posicion == 64)
                {
                    Console.WriteLine();
                    AplicarColorEnMensaje(jugadorUno.ColorFicha, $"Felicidades! {jugadorUno.Nombre} ha ganado!");
                    Console.WriteLine("Gracias por jugar al Juego de la Oca Espacial!");
                    jugando = false;
                }
                else if (jugadorDos.Posicion == 64)
                {
                    Console.WriteLine();
                    AplicarColorEnMensaje(jugadorDos.ColorFicha, $"Felicidades! {jugadorDos.Nombre} ha ganado!");
                    Console.WriteLine("Gracias por jugar al Juego de la Oca Espacial!");
                    jugando = false;
                }

            }

        }
    }
}