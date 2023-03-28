using Biblioteca_Virtual.Models;
namespace Biblioteca_Virtual.services; 

public interface IBilbiService
{
    public class IBilbiService
    {
        List<Livro> GetLivros(); 
        List<Genero> GetGeneros();
        Livro GetPokemon(int Numero);
        bibliotecaDto GetBibliotecaDto(); 

        DetailsDto GetDetailedLivro(int Numero); 

        Genero GetGenero(string Nome);  

    }
}


