using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonApi.ControllerDB;
using PokemonApi.Objetos;

namespace PokemonApi.Controllers
{

    [Route("API/[controller]")]
    [ApiController]
    public class ControllerPokemon : ControllerBase
    {
        
        
            private readonly MongoSc items;
            public ControllerPokemon(MongoSc mongoDbService) => items = mongoDbService;

            [HttpPost("Ataque/{id}")]
            public async Task<IActionResult> Ataque(string id, [FromBody] List<string> nombres)
            {

                Pokemon pokemon = await items.GetAsyncById(id);
                Random random = new();
                List<Attack> attacks = new List<Attack>();

            for (int i = 0; i < nombres.Count; i++)
                {
                    var x = random.Next(0, 40);
                    attacks.Add(new Attack { nombre = nombres[i], cantidad = x });
                }
            pokemon.attacks = attacks;
            await items.UpdateAsync(id, pokemon);

                return Ok(pokemon);
            }

            [HttpGet("Pokemon1")]
            public async Task<Pokemon?> Pokemon1()
            {
                var pokemon = await items.GetFirstAsync();

            if (pokemon == null)
            {
                return null;
            }    

                return pokemon;
            }

            [HttpGet("Tipo/{tipo}")]

            public async Task<List<Pokemon>> Tipo(string tipo)
            {
                return await items.GetAllByTypeAsync(tipo);
            }

            [HttpPost("CrearPokemon")]
            public async Task<IActionResult> CrearPokemon([FromBody] Pokemon pokemon)
            {                
                await items.CreateAsync(pokemon);
                return Ok(pokemon);
            }

            [HttpPost("VariosPokemon")]

            public async Task<IActionResult> VariosPokemon([FromBody] List<Pokemon> pokemons)
            {
                
                
                    
                await items.CreateManyAsync(pokemons);
                return Ok(pokemons);
            }

            [HttpPut("Editar/{id}")]
            public async Task<IActionResult> Editar(string id, [FromBody] Pokemon pokemon)
            {
                var pokemonToUpdate = await items.GetAsyncById(id);
                if (pokemonToUpdate == null)
                {
                    return NotFound();
                }
                pokemon.id = pokemonToUpdate.id;
                await items.UpdateAsync(id, pokemon);
                return NoContent();
            }

            [HttpDelete("BorrarPokemon/{id}")]
            public async Task<IActionResult> BorrarPokemon(string id)
            {
                var pokemon = await items.GetAsyncById(id);
                if (pokemon == null)
                {
                    return NotFound();
                }
                await items.DeleteAsync(id);
                return NoContent();
            }

        }

    
}
