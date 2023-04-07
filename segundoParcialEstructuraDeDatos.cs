using System;
using System.Collections.Generic;

namespace segundoParcialEstructuraDeDatos
{
    enum Palo
    {
        Pica,
        Corazon,
        Diamante,
        Trebol
    }



    enum Numero
    {
        NroA,
        Nro2,
        Nro3,
        Nro4,
        Nro5,
        Nro6,
        Nro7,
        Nro8,
        Nro9,
        Nro10,
        NroJ,
        NroQ,
        NroK
    }



    class Carta
    {
        public Palo Palo;
        public Numero Numero;
    }



    class Jugador
    {
        public string Nombre;
        public List<Carta> Mano = new List<Carta>();
        public bool SePlanto;
        public decimal Dinero;
        public decimal Apuesta;
    }



    class Mazo
    {
        public List<Carta> Cartas = new List<Carta>();
        public List<Carta> CartasMezcladas = new List<Carta>();

    }



    class Mesa
    {
        public List<Jugador> Jugadores = new List<Jugador>();
        public Mazo Mazo = new Mazo();
        public Jugador Croupier = new Jugador() { Nombre = "Croupier" };
    }




    class Program
    {
        static int PedirIntEnRango(string mensaje, int min, int max)
        {
            int respuesta;
            string respuestaStr;
            Console.Write($"{mensaje} ");
            respuestaStr = Console.ReadLine();

            while (!int.TryParse(respuestaStr, out respuesta) ||
                !(respuesta >= min && respuesta <= max))
            {
                Console.WriteLine();
                Console.WriteLine("Respuesta inválida");
                Console.Write($"{mensaje} ");
                respuestaStr = Console.ReadLine();
            }

            return respuesta;
        }



        static decimal PedirDecimalEnRango(string mensaje, decimal min, decimal max)
        {
            decimal respuesta;
            string respuestaStr;
            Console.Write($"{mensaje} ");
            respuestaStr = Console.ReadLine();

            while (!decimal.TryParse(respuestaStr, out respuesta) ||
                !(respuesta >= min && respuesta <= max))
            {
                Console.WriteLine();
                Console.WriteLine("Respuesta inválida");
                Console.Write($"{mensaje} ");
                respuestaStr = Console.ReadLine();
            }

            return respuesta;
        }



        static string PedirString(string mensaje)
        {
            string respuesta;
            Console.Write($"{mensaje} ");
            respuesta = Console.ReadLine();

            return respuesta;
        }



        static void PedirPresionDeTecla()
        {
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }



        static int ObtenerValor(Carta carta)
        {
            int valor = 0;
            switch (carta.Numero)
            {
                case Numero.NroA:
                    valor = 11;
                    break;
                case Numero.Nro2:
                    valor = 2;
                    break;
                case Numero.Nro3:
                    valor = 3;
                    break;
                case Numero.Nro4:
                    valor = 4;
                    break;
                case Numero.Nro5:
                    valor = 5;
                    break;
                case Numero.Nro6:
                    valor = 6;
                    break;
                case Numero.Nro7:
                    valor = 7;
                    break;
                case Numero.Nro8:
                    valor = 8;
                    break;
                case Numero.Nro9:
                    valor = 9;
                    break;
                case Numero.Nro10:
                    valor = 10;
                    break;
                case Numero.NroJ:
                    valor = 10;
                    break;
                case Numero.NroQ:
                    valor = 10;
                    break;
                case Numero.NroK:
                    valor = 10;
                    break;
            }

            return valor;
        }



        static void ReiniciarJugador(Jugador jugador)
        {
            jugador.Mano.Clear();
            jugador.SePlanto = false;
            jugador.Apuesta = 0;
        }



        static int CalcularPuntaje(Jugador jugador)
        {
            int puntaje = 0;

            for (int i = 0; i < jugador.Mano.Count; i++)
            {
                puntaje += ObtenerValor(jugador.Mano[i]);
            }

            return puntaje;
        }



        static bool GanaElJugador(Jugador jugador, Jugador croupier)
        {
            int puntajeJugador = CalcularPuntaje(jugador);
            int puntajeCroupier = CalcularPuntaje(croupier);

            return (puntajeJugador <= 21 && puntajeJugador >= puntajeCroupier);
        }



        static void IntentarPoblar(Mazo mazo)
        {
            if (mazo.Cartas.Count > 0)
                return;

            Palo[] palos = Enum.GetValues<Palo>();
            Numero[] numeros = Enum.GetValues<Numero>();

            foreach (Palo palo in palos)
            {
                foreach (Numero numero in numeros)
                {
                    mazo.Cartas.Add(new Carta() { Numero = numero, Palo = palo });
                }
            }
        }



        static void Mezclar(Mazo mazo)
        {
            Random random = new Random();
            List<Carta> listaTmp = new List<Carta>();

            IntentarPoblar(mazo);
            mazo.CartasMezcladas.Clear();
            listaTmp.AddRange(mazo.Cartas);

            while (listaTmp.Count > 0)
            {
                int indexAleatorio = random.Next(0, listaTmp.Count);
                mazo.CartasMezcladas.Add(listaTmp[indexAleatorio]);
                listaTmp.RemoveAt(indexAleatorio);
            }

        }



        static bool HayCartas(Mazo mazo)
        {
            return (mazo.CartasMezcladas.Count > 0);
        }



        static Carta TomarCarta(Mazo mazo)
        {
            int primerIndex = 0;
            Carta cartaTomada = mazo.CartasMezcladas[primerIndex];
            mazo.CartasMezcladas.RemoveAt(primerIndex);

            return cartaTomada;
        }



        static void ReiniciarMesa(Mesa mesa)
        {
            Console.Clear();

            for (int i = 0; i < mesa.Jugadores.Count; i++)
            {
                ReiniciarJugador(mesa.Jugadores[i]);
            }

            ReiniciarJugador(mesa.Croupier);

            Mezclar(mesa.Mazo);
        }



        static bool SePlantaronTodos(Mesa mesa)
        {
            for (int i = 0; i < mesa.Jugadores.Count; i++)
            {
                if (!mesa.Jugadores[i].SePlanto)
                    return false;
            }

            return mesa.Croupier.SePlanto;
        }



        static bool PuedeContinuarJugando(Mesa mesa)
        {
            return (!(SePlantaronTodos(mesa)) && HayCartas(mesa.Mazo));
        }



        static void RealizarJugadaDeCroupier(Mesa mesa)
        {
            Console.WriteLine("Turno del Croupier...");

            int puntajeCroupier = CalcularPuntaje(mesa.Croupier);
            if (puntajeCroupier <= 16)
            {
                mesa.Croupier.Mano.Add(TomarCarta(mesa.Mazo));
            }
            else
            {
                mesa.Croupier.SePlanto = true;
                Console.WriteLine("El Croupier se planta!");
            }

            PedirPresionDeTecla();
        }



        static char PaloComoChar(Palo palo)
        {
            switch (palo)
            {
                case Palo.Corazon:
                    return 'C';
                case Palo.Diamante:
                    return 'D';
                case Palo.Pica:
                    return 'P';
                case Palo.Trebol:
                    return 'T';
            }
            return ' ';
        }



        static string NumeroComoString(Numero nro)
        {
            switch (nro)
            {
                case Numero.NroA:
                    return "A";
                case Numero.Nro2:
                    return "2";
                case Numero.Nro3:
                    return "3";
                case Numero.Nro4:
                    return "4";
                case Numero.Nro5:
                    return "5";
                case Numero.Nro6:
                    return "6";
                case Numero.Nro7:
                    return "7";
                case Numero.Nro8:
                    return "8";
                case Numero.Nro9:
                    return "9";
                case Numero.Nro10:
                    return "10";
                case Numero.NroJ:
                    return "J";
                case Numero.NroQ:
                    return "Q";
                case Numero.NroK:
                    return "K";
            }
            return "";
        }



        static void DibujarMano(List<Carta> mano)
        {
            foreach (Carta carta in mano)
            {
                Console.Write("┌─────┐");
            }
            Console.WriteLine();
            foreach (Carta carta in mano)
            {
                string nro = NumeroComoString(carta.Numero);
                Console.Write($"│{nro.PadRight(2)}   │");
            }
            Console.WriteLine();
            foreach (Carta carta in mano)
            {
                char palo = PaloComoChar(carta.Palo);
                Console.Write($"│  {palo}  │");
            }
            Console.WriteLine();
            foreach (Carta carta in mano)
            {
                string nro = NumeroComoString(carta.Numero);
                Console.Write($"│   {nro.PadLeft(2)}│");
            }
            Console.WriteLine();
            foreach (Carta carta in mano)
            {
                Console.Write("└─────┘");
            }
            Console.WriteLine();
        }



        static void DibujarCarta(Carta carta)
        {
            string nro = NumeroComoString(carta.Numero);
            char palo = PaloComoChar(carta.Palo);
            Console.WriteLine("┌─────┐");
            Console.WriteLine($"│{nro.PadRight(2)}   │");
            Console.WriteLine($"│  {palo}  │");
            Console.WriteLine($"│   {nro.PadLeft(2)}│");
            Console.WriteLine("└─────┘");
        }



        static void CargarJugadores(Mesa mesa)
        {
            Console.WriteLine("===BLACKJACK===");
            int cantJugadores = PedirIntEnRango("Ingrese la cantidad de jugadores:", 1, int.MaxValue);
            mesa.Jugadores.Capacity = cantJugadores;

            Console.WriteLine();
            for (int i = 0; i < cantJugadores; i++)
            {
                Jugador nuevoJugador = new Jugador();
                nuevoJugador.Nombre = PedirString($"Indique nombre Jugador {i + 1}:");

                if (nuevoJugador.Nombre == "Jack Black")
                {
                    nuevoJugador.Dinero = decimal.MaxValue;
                }
                else
                {
                    nuevoJugador.Dinero = 10000;
                }

                mesa.Jugadores.Add(nuevoJugador);
            }

        }



        static void RealizarApuestas(Mesa mesa)
        {
            Console.WriteLine("Hagan sus apuestas!");
            for (int i = 0; i < mesa.Jugadores.Count; i++)
            {
                Console.WriteLine($"{mesa.Jugadores[i].Nombre} - Disponible ${mesa.Jugadores[i].Dinero}");
                if (mesa.Jugadores[i].Dinero > 0)
                {
                    mesa.Jugadores[i].Apuesta = PedirDecimalEnRango($"Su apuesta:", 1, mesa.Jugadores[i].Dinero);
                }
            }

            PedirPresionDeTecla();
        }



        static void MostrarEstadoMesa(Mesa mesa)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine($"{mesa.Croupier.Nombre} - Mano:");
            DibujarMano(mesa.Croupier.Mano);
            for (int i = 0; i < mesa.Jugadores.Count; i++)
            {
                Console.WriteLine($"{mesa.Jugadores[i].Nombre} - Apuesta: ${mesa.Jugadores[i].Apuesta} - " +
                    $"Mano:");
                DibujarMano(mesa.Jugadores[i].Mano);
            }

            Console.WriteLine("=============================================");
        }



        static int MostrarMenu(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.WriteLine("1. Pedir carta");
            Console.WriteLine("2. Plantarse");

            return PedirIntEnRango("Elija una opción:", 1, 2);
        }



        static void JugarTurno(Mesa mesa)
        {
            for (int i = 0; i < mesa.Jugadores.Count; i++)
            {
                if (!mesa.Jugadores[i].SePlanto)
                {
                    MostrarEstadoMesa(mesa);
                    int opcionElegida = MostrarMenu($"{mesa.Jugadores[i].Nombre} es su turno, ¿qué desea hacer?");
                    switch (opcionElegida)
                    {
                        case 1:
                            Carta cartaParaElJugador = TomarCarta(mesa.Mazo);
                            Console.WriteLine($"Usted Sacó:");
                            DibujarCarta(cartaParaElJugador);
                            mesa.Jugadores[i].Mano.Add(cartaParaElJugador);
                            int puntajeJugador = CalcularPuntaje(mesa.Jugadores[i]);
                            if (puntajeJugador > 21)
                            {
                                Console.WriteLine("Plantado!");
                                mesa.Jugadores[i].SePlanto = true;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Plantado!");
                            mesa.Jugadores[i].SePlanto = true;
                            break;

                    }

                    PedirPresionDeTecla();
                }

            }

            if (!mesa.Croupier.SePlanto)
            {
                RealizarJugadaDeCroupier(mesa);
            }

        }



        static void ActualizarSaldos(Mesa mesa)
        {
            int puntajeCroupier = CalcularPuntaje(mesa.Croupier);
            Console.WriteLine($"Croupier - Suma {puntajeCroupier}");

            for (int i = 0; i < mesa.Jugadores.Count; i++)
            {
                
                if (GanaElJugador(mesa.Jugadores[i], mesa.Croupier))
                {
                    mesa.Jugadores[i].Dinero += mesa.Jugadores[i].Apuesta;
                    int puntajeJugador = CalcularPuntaje(mesa.Jugadores[i]);
                    Console.WriteLine($"{mesa.Jugadores[i].Nombre} - Suma {puntajeJugador} - Gana ${mesa.Jugadores[i].Apuesta}");
                }
                else
                {
                    mesa.Jugadores[i].Dinero -= mesa.Jugadores[i].Apuesta;
                    int puntajeJugador = CalcularPuntaje(mesa.Jugadores[i]);
                    Console.WriteLine($"{mesa.Jugadores[i].Nombre} - Suma {puntajeJugador} - Pierde ${mesa.Jugadores[i].Apuesta}");
                }

            }

            PedirPresionDeTecla();

        }






        static void Main(string[] args)
        {
            bool jugando = true;
            Mesa mesa = new Mesa();

            CargarJugadores(mesa);
            while (jugando)
            {
                ReiniciarMesa(mesa);
                RealizarApuestas(mesa);
               
                while (PuedeContinuarJugando(mesa))
                {
                    JugarTurno(mesa);
                }

                Console.WriteLine("Fin de la ronda");
                ActualizarSaldos(mesa);

            }
        }
    }
}