namespace Biblioteca_Virtual.Models;

    public class DetailsDto
    {
        public Livro Prior { get; set; }
        public Livro Current { get; set; }
        public Livro Next { get; set; }
    }
