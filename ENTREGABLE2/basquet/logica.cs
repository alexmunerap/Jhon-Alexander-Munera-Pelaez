using System;
using System.Collections.Generic;

namespace Basket3vs3
{
    public interface IJugador
    {
        string ObtenerNombre();
        int ObtenerRendimiento();
    }

    public class Jugador : IJugador
    {
        private readonly string nombre;
        private readonly int rendimiento;

        public Jugador(string nombre, int rendimiento)
        {
            this.nombre = nombre;
            this.rendimiento = rendimiento;
        }

        public string ObtenerNombre()
        {
            return nombre;
        }

        public int ObtenerRendimiento()
        {
            return rendimiento;
        }
    }

    public class Equipo
    {
        private string nombre;
        private List<IJugador> jugadores;

        public Equipo(string nombre)
        {
            this.nombre = nombre;
            jugadores = new List<IJugador>();
        }

        public void AgregarJugador(IJugador jugador)
        {
            jugadores.Add(jugador);
        }

        public int CalcularRendimientoTotal()
        {
            int rendimientoTotal = 0;
            foreach (var jugador in jugadores)
            {
                rendimientoTotal += jugador.ObtenerRendimiento();
            }
            return rendimientoTotal;
        }

        public void MostrarJugadores()
        {
            Console.WriteLine($"Jugadores de {nombre}:");
            foreach (var jugador in jugadores)
            {
                Console.WriteLine(jugador.ObtenerNombre());
            }
        }
    }

    public class Basquet
    {
        private List<IJugador> jugadoresDisponibles;
        private Equipo equipoLocal;
        private Equipo equipoVisitante;

        public Basquet()
        {
            jugadoresDisponibles = new List<IJugador>
            {
                new Jugador("Lebron James", 90),
                new Jugador("Stephen Curry", 85),
                new Jugador("Kevin Durant", 88),
                new Jugador("Michael Jordan", 95),
                new Jugador("Jason Tatum", 86),
                new Jugador("James Harden", 87),
                new Jugador("Luka Doncic", 88),
                new Jugador("Anthony Davis", 89),
                new Jugador("Joel Embiid", 87),
                new Jugador("Nikola Jokic", 88)
            };

            equipoLocal = new Equipo("Local");
            equipoVisitante = new Equipo("Visitante");
        }

        public void RepartirJugadores()
        {
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                int indice = random.Next(jugadoresDisponibles.Count);
                IJugador jugador = jugadoresDisponibles[indice];
                jugadoresDisponibles.RemoveAt(indice);

                if (i % 2 == 0)
                {
                    equipoLocal.AgregarJugador(jugador);
                }
                else
                {
                    equipoVisitante.AgregarJugador(jugador);
                }
            }
            Console.WriteLine("Jugadores repartidos correctamente");
        }

        public void DecidirGanador()
        {
            Console.WriteLine("===================Resultados====================");
            Console.WriteLine("");
            int rendimientoLocal = equipoLocal.CalcularRendimientoTotal();
            int rendimientoVisitante = equipoVisitante.CalcularRendimientoTotal();

            Console.WriteLine($"Rendimiento total del equipo local: {rendimientoLocal}");
            Console.WriteLine($"Rendimiento total del equipo visitante: {rendimientoVisitante}");

            if (rendimientoLocal > rendimientoVisitante)
            {
                Console.WriteLine($"El equipo local gana con un rendimiento total de: {rendimientoLocal}");
            }
            else if (rendimientoVisitante > rendimientoLocal)
            {
                Console.WriteLine($"El equipo visitante gana con un rendimiento total de: {rendimientoVisitante}");
            }
            else
            {
                Console.WriteLine("El partido quedó empatado");
            }
        }

        public void AgregarJugador()
        {
            Console.WriteLine("Ingrese el nombre del jugador a agregar:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el rendimiento del jugador:");
            int rendimiento = int.Parse(Console.ReadLine());
            jugadoresDisponibles.Add(new Jugador(nombre, rendimiento));
            Console.WriteLine($"Jugador {nombre} agregado a la lista");
        }

        public void MostrarJugadoresDisponibles()
        {
            Console.WriteLine("_________________________");
            Console.WriteLine("Jugadores disponibles:");
            Console.WriteLine("_________________________");
            foreach (var jugador in jugadoresDisponibles)
            {
                Console.WriteLine(jugador.ObtenerNombre());
            }
        }

        public void MostrarJugadoresSeleccionados()
        {
            Console.WriteLine("");
            Console.WriteLine("=====================Local==================");
            Console.WriteLine("");
            equipoLocal.MostrarJugadores();
            Console.WriteLine("");
            Console.WriteLine("===================Visitante================");
            Console.WriteLine("");
            equipoVisitante.MostrarJugadores();
            Console.WriteLine("");
        }

        public void MenuPartido()
        {
            int opcion;
            do
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1 --> Repartir jugadores");
                Console.WriteLine("2 --> Ver jugadores seleccionados ");
                Console.WriteLine("3 --> Ver jugadores disponibles");
                Console.WriteLine("4 --> Agregar un nuevo jugador a la lista");
                Console.WriteLine("5 --> Decidir ganador");
                Console.WriteLine("6 --> Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RepartirJugadores();
                        break;
                    case 2:
                        MostrarJugadoresSeleccionados();
                        break;
                    case 3:
                        MostrarJugadoresDisponibles();
                        break;
                    case 4:
                        AgregarJugador();
                        break;
                    case 5:
                        DecidirGanador();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo....");
                        break;

                    default:
                        Console.WriteLine("Opción no válida, por favor seleccione una opción válida");
                        break;
                }
            } while (opcion != 6);
        }
    }

    class Programa
    {
        static void Main(string[] args)
        {
            Basquet basquet = new Basquet();
            basquet.MenuPartido();
        }
    }
}
