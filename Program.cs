using System;
using System.Collections.Generic;

namespace SistemaDeGerenciamentoDeBiblioteca
{
    public abstract class ItemBiblioteca
    {
        protected string DescricaoInterna { get; set; }
        public int Id { get; set; }
        public string Titulo { get; set; }

        public ItemBiblioteca(int id, string titulo)
        {
            Id = id;
            Titulo = titulo;
            DescricaoInterna = "Este item faz parte da nossa biblioteca.";
        }
    }

    public class Livro : ItemBiblioteca
    {
        public string Autor { get; set; }

        public Livro(int id, string titulo, string autor) : base(id, titulo)
        {
            Autor = autor;
            DescricaoInterna += $" Escrito por {Autor}.";
        }

        public void ExibirDescricaoInterna()
        {
            Console.WriteLine(DescricaoInterna);
        }
    }

    public class Biblioteca
    {
        private List<ItemBiblioteca> items;

        public Biblioteca()
        {
            items = new List<ItemBiblioteca>();
        }

        public void AdicionarItem(ItemBiblioteca item)
        {
            items.Add(item);
        }

        public void RemoverItem(int id)
        {
            ItemBiblioteca item = items.Find(x => x.Id == id);
            if (item != null)
            {
                items.Remove(item);
            }
        }

        public ItemBiblioteca BuscarItemPorTitulo(string titulo)
        {
            return items.Find(x => x.Titulo == titulo);
        }

        public ItemBiblioteca BuscarItemPorId(int id)
        {
            return items.Find(x => x.Id == id);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            Livro livro1 = new Livro(1, "Harry Potter", "J.K. Rowling");
            Livro livro2 = new Livro(2, "The Lord of the Rings", "J.R.R. Tolkien");

            biblioteca.AdicionarItem(livro1);
            biblioteca.AdicionarItem(livro2);

            Livro buscado = (Livro)biblioteca.BuscarItemPorTitulo("Harry Potter");
            if (buscado != null)
            {
                Console.WriteLine($"Livro encontrado: {buscado.Titulo}");
            }

            biblioteca.RemoverItem(livro1.Id);

            buscado = (Livro)biblioteca.BuscarItemPorTitulo("Harry Potter");
            if (buscado == null)
            {
                Console.WriteLine("Livro removido com sucesso.");
            }

            livro1.ExibirDescricaoInterna();
        }
    }
}