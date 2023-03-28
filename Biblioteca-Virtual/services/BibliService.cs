using System.Text.Json; 
using Biblioteca_Virtual.Models; 

namespace Biblioteca_Virtual.services;

public class BibliService : IBilbiService
{
    private readonly IHttpContextAccessor _session; 
    private readonly string LivroFile = @"Data\Livros.json"; 
    private readonly string GenerosFile = @"Data\generos.json"; 
    public class BibliService(IHttpContextAccessor session)
    {
        _session = session; 
        PopularSessao(); 
    }
}