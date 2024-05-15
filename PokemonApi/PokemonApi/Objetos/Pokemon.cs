using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokemonApi.Objetos
{
    public class Pokemon
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public int defensa { get; set; }
        public List<Attack>? attacks { get; set; }

        public Pokemon(string nombre, string tipo, int defensa, List<Attack> attacks)
        {

            this.nombre = nombre;
            this.tipo = tipo;
            this.defensa = defensa;
            this.attacks = attacks;
        }

    }
}
