namespace PokemonC;

public interface INTERFAZPokemon
{
    decimal Ataque();
    decimal Defender();
}


public class Pokemon : INTERFAZPokemon
{
    private string Nombre { get; set; }
    private string Tipo { get; set; }
    private decimal Vida { get; set; }
    private int[] Ataques { get; set; }
    private int[] Defensas { get; set; }

    
    public Pokemon()
    {

    }
   
    public Pokemon(string Nombre, string Tipo, decimal Vida, int[] Ataques, int[] Defensas)
    {
        this.Nombre = Nombre;
        this.Tipo = Tipo;
        this.Vida = Vida;
        this.Ataques = Ataques;
        this.Defensas = Defensas;
    }

    public decimal Ataque()
    {
        Random rnd = new Random();
        int RandomAtaque = rnd.Next(Ataques.Length);
        decimal [] Fuerza = new decimal[]{1, 0, 1.5m};
        int RandomFuerza = rnd.Next(Fuerza.Length);
        return this.Ataques[RandomAtaque] * Fuerza[RandomFuerza];

    }

    public decimal Defender()
    {
        Random rnd = new Random();
        int RandomDefense = rnd.Next(Defensas.Length);
        decimal [] Fuerza = new decimal[]{1, 0.5m};
        int RandomFuerza = rnd.Next(Fuerza.Length);
        return this.Defensas[RandomDefense] * Fuerza[RandomFuerza];
    }

    public void Daño(decimal Daño)
    {
        this.Vida -= Daño;
    }

    public decimal getVida()
    {
        return this.Vida;
    }

    public string getNombre()
    {
        return this.Nombre;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Nombre: {this.Nombre}");
        Console.WriteLine($"Tipo: {this.Tipo}");
        Console.WriteLine($"Vida: {this.Vida}");
        Console.WriteLine("Ataques:");
        foreach (int Atacar in this.Ataques){
            Console.WriteLine($"{Atacar}");
        }
        Console.WriteLine("Defensas:");
        foreach (int Defender in this.Defensas){
            Console.WriteLine($"{Defender}");
        }
        
    }
}