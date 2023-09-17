using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    internal class Program
    {
        static Livro criaLivro(bool sel=false)
        {
            int isbn;
            string titulo, autor, editora;

            Console.WriteLine("Digite o isbn do livro: ");
            isbn = Convert.ToInt32(Console.ReadLine());

            if (sel) { return new Livro(isbn); }

            Console.WriteLine("Digite o titulo do livro: ");
            titulo = Console.ReadLine();

            Console.WriteLine("Digite o autor do livro: ");
            autor = Console.ReadLine();

            Console.WriteLine("Digite o editora do livro: ");
            editora = Console.ReadLine();

            return new Livro(isbn, titulo, autor, editora);

        }
        static Exemplar criaExemplar()
        {
            int tombo;

            Console.WriteLine("Digite o tombo do exemplar: ");
            tombo = Convert.ToInt32(Console.ReadLine());

            return new Exemplar(tombo);
        }
        static void Main(string[] args)
        {
            int sel = 1;
            Livros biblio = new Livros();

            while (sel != 0)
            {
                Console.WriteLine("0. Sair\n1. Adicionar livro\n2. Pesquisar livro (sintético)\n3. Pesquisar livro (analítico)**\n4. Adicionar exemplar\n5. Registrar empréstimo\n6. Registrar devolução");
                sel = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (sel)
                {
                    case 1: biblio.adicionar(criaLivro());
                        break;

                    case 2: Console.WriteLine(biblio.pesquisar(criaLivro(true)).praString());
                        break;

                    case 3: Console.WriteLine(biblio.pesquisar(criaLivro(true)).praString(true)); 
                        break;

                    case 4: biblio.pesquisar(criaLivro(true)).adicionarExemplar(criaExemplar());
                        Console.WriteLine("Exemplar adicionado");
                        break;  

                    case 5: Console.WriteLine(biblio.pesquisar(criaLivro(true)).findExemplarDis().emprestar() ? "Exemplar emprestado!" : "Falha no emprestimo!");
                        break;

                    case 6: Console.WriteLine(biblio.pesquisar(criaLivro(true)).findExemplar(criaExemplar()).devolver() ? "Exemplar devolvido!" : "Falha ao devolver!");
                        break;
                }

                Console.WriteLine("digite enter para prosseguir...");
                Console.ReadLine();
                Console.Clear();

            }


        }
    }
}
