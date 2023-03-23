namespace Biblioteca_Virtual.Models;
public class Livro
{
    // Atributos
    public int Numero { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Autor { get; set; }
    public List<string> Genero { get; set; }
    public int Paginas { get; set; }
    public string Imagem { get; set; }
    // Método Construtor
    public Livro()
    {
        
        Genero = new List<string>();
    }
}