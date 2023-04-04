using Biblioteca_Virtual.Models;
namespace Biblioteca_Virtual.services; 

public interface IBibliService
{
        List<Livro> GetLivros(); 
        List<Genero> GetGeneros();
        Livro GetLivro(int Numero);
        bibliotecaDto GetBibliotecaDto(); 

        DetailsDto GetDetailedLivro(int Numero); 

        Genero GetGenero(string Nome);  
}


