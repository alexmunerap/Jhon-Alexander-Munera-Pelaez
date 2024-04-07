namespace PokemonC;
class Program
{
    static Pokemon Pokemon1 = new Pokemon();
    static Pokemon Pokemon2 = new Pokemon();
     static void Main(string[] args)
     {
        bool salir = false;
        int opcion;
        bool establecerP = false;

        do
        {

            Console.WriteLine("Bienvenido al mundo de Pokemon");
            Console.WriteLine("1. Establecer Pokemon");
            Console.WriteLine("2.Combate");
            Console.WriteLine("3.Mostrar informacion");
            Console.WriteLine("4.Salir");
            Console.WriteLine("Opcion: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            
            {
                case 1:
                    String Nombre = "";
                    String Tipo = "";
                    decimal Vida = 0;
                    Random rnd = new Random();
                    Console.WriteLine("----- POKEMON 1 -----");
                    Console.WriteLine("Ingresar el nombre del pokemon: ");
                    Nombre = Console.ReadLine();
                    Console.WriteLine("Ingresar el tipo del pokemon: ");
                    Tipo = Console.ReadLine();
                    Console.WriteLine("Ingresar la vida del pokemon: ");
                    Vida = int.Parse(Console.ReadLine());
                    Pokemon1 = new Pokemon(Nombre, Tipo, Vida, new int[] { rnd.Next(0, 40), rnd.Next(0, 40), rnd.Next(0, 40) }, new int[] { rnd.Next(10, 35), rnd.Next(10, 35) });

                    Console.WriteLine("----- POKEMON 2 -----");
                    Console.WriteLine("Ingresar el nombre del pokemon2: ");
                    Nombre = Console.ReadLine();
                    Console.WriteLine("Ingresar el tipo del pokemon2: ");
                    Tipo = Console.ReadLine();
                    Console.WriteLine("Ingresar la vida del pokemon2: ");
                    Vida = int.Parse(Console.ReadLine());;

                    Pokemon2 = new Pokemon(Nombre, Tipo, Vida, new int[] { rnd.Next(0, 40), rnd.Next(0, 40), rnd.Next(0, 40) }, new int[] { rnd.Next(10, 35), rnd.Next(10, 35) });

                    break;
                case 2:
                    
                    for (int i = 0; i < 3; i++){

                    decimal APokemon1 = Pokemon1.Ataque();
                    decimal DPokemon1 = Pokemon1.Defender();

                    decimal APokemon2 = Pokemon2.Ataque();
                    decimal DPokemon2 = Pokemon2.Defender();

                    if (DPokemon2 > APokemon1)
                        Pokemon1.Daño(DPokemon2 - APokemon1);
                    if (DPokemon2 < APokemon1)
                        Pokemon2.Daño(APokemon1 - DPokemon2);

                    if (DPokemon1 > APokemon2)
                        Pokemon2.Daño(APokemon1 - APokemon2);
                    if (DPokemon1 < APokemon2)
                        Pokemon1.Daño(APokemon2 - DPokemon1);

                    if (Pokemon1.getVida() < 0 || Pokemon2.getVida() < 0) 
                    {
                        break;
                    }
                    else 
                    {
                        Console.WriteLine($"Ronda {i + 1} ");
                        Console.WriteLine("POKEMON 1-POKEMON 2");
                        Console.WriteLine($"Ataque: {APokemon1}  | {APokemon2}");
                        Console.WriteLine($"Defensa: {DPokemon1} | {DPokemon2}");
                        Console.WriteLine($"Vida: {Pokemon1.getVida()} | {Pokemon2.getVida()}");
                    }
                }

                Console.WriteLine("Pelea final");
                if (Pokemon1.getVida() < Pokemon2.getVida())
                    Console.WriteLine($"Pokemon {Pokemon2.getNombre()} Ganó");
                else if (Pokemon2.getVida() < Pokemon1.getVida())
                    Console.WriteLine($"Pokemon {Pokemon1.getNombre()} Ganó");
                    
                    break;
                case 3:
                    Console.WriteLine("---- POKEMON 1 ----");
                    Pokemon1.ShowInfo();
                    Console.WriteLine("---- POKEMON 2 ----");
                     Pokemon2.ShowInfo();
                    
                    break;
                    
                case 4:
                    salir = true;
                    break;
                    default:
                    Console.WriteLine("Opcion incorrecta, porfavor volver a seleccionar");
                    break;
            }
        } while (!salir);
    }
}
            
                
            

            
        
