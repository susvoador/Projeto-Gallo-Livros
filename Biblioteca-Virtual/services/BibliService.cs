using System.Text.Json; 
using Biblioteca_Virtual.Models; 

namespace Biblioteca_Virtual.services;

public class BibliService : IBibliService
{
    private readonly IHttpContextAccessor _session; 
    private readonly string LivroFile = @"Data\Livros.json"; 
    private readonly string GenerosFile = @"Data\generos.json"; 
    public BibliService(IHttpContextAccessor session)
    {
        _session = session; 
        PopularSessao(); 
    }
    
    public List<Livro> GetLivros()
    {
        PopularSessao(); 
        var Livros = JsonSerializer.Deserialize<List<Livro>>
            (_session.HttpContext.Session.GetString("Livros")); 
        return  Livros; 
    }

    public List<Genero> GetGeneros()
    {
        PopularSessao(); 
        var Generos = JsonSerializer.Deserialize<List<Genero>>
            (_session.HttpContext.Session.GetString("Generos"));
        return Generos; 
    }

    public Livro GetLivro(int Numero)
    {
      var Livro = GetLivros(); 
      return Livro.Where(p => p.Numero == Numero).FirstOrDefault(); 
    }

    public bibliotecaDto GetBibliotecaDto()
    {
        var Liv = new bibliotecaDto()
        {
            Livros = GetLivros(), 
            Generos = GetGeneros()
        }; 
        return Liv; 
    }

    public DetailsDto GetDetailedLivro(int Numero)
    {
        var Livros = GetLivros(); 
        var Liv = new DetailsDto()
        {
            Current = Livros.Where(p => p.Numero == Numero).FirstOrDefault(), 
            Prior = Livros.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < Numero), 
            Next = Livros.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > Numero), 
        }; 
        return Liv;     
    }
    
    public Genero GetGenero(string Nome)
    {
        var generos = GetGeneros(); 
        return generos.Where(t => t.Nome == Nome).FirstOrDefault();  
    }

    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Generos")))
        {
            _session.HttpContext.Session
              .SetString("Livros", LerArquivo(LivroFile));
            _session.HttpContext.Session
              .SetString("Generos", LerArquivo(GenerosFile));
        }
    }

    private string LerArquivo(string filename)
    {
        using (StreamReader leitor = new StreamReader (filename))
        {
            string dados = leitor.ReadToEnd(); 
            return dados; 
        }
    }
}