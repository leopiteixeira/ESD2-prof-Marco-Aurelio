using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    internal class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
            this.exemplares = new List<Exemplar>();
        }

        public Livro() : this(-1, "", "", "") { }

        public Livro(int isbn) : this(isbn, "", "", "") { }

        public int Isbn { get => isbn; set => isbn = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Editora { get => editora; set => editora = value; }
        internal List<Exemplar> Exemplares { get => exemplares; set => exemplares = value; }

        public void adicionarExemplar(Exemplar ex)
        {
            bool existe = false;
            foreach(Exemplar exem in this.exemplares)
            {
                if (exem.Equals(ex))
                {
                    existe = true;
                    break;
                }
            }
            if (!existe)
            {
                exemplares.Add(ex);
            }
        }

        public int qtdeExemplares()
        {
            return exemplares.Count;
        }

        public int qtdeDisponiveis()
        {
            int res = 0;
            foreach(Exemplar ex in this.exemplares)
            {
                if (ex.disponivel())
                {
                    res++;
                }
            }
            return res;
        }

        public int qtdeEmprestimos()
        {
            int res = 0;
            foreach(Exemplar ex in this.exemplares)
            {
                res += ex.qtdeEmprestimos();
            }
            return res;
        }

        public double percDisponibilidade()
        {
            if(this.qtdeExemplares() == 0)
            {
                return 0;
            }
            return this.qtdeDisponiveis() / this.qtdeExemplares();
        }

        public Exemplar findExemplarDis()
        {
            foreach(Exemplar ex in this.exemplares ) 
            {
                if (ex.disponivel())
                {
                    return ex;
                }
            }
            return new Exemplar();
        }

        public Exemplar findExemplar(Exemplar exemplar)
        {
            foreach(Exemplar ex in this.exemplares)
            {
                if (ex.Equals(exemplar)) { return ex; }
            }
            return new Exemplar();
        }

        public override bool Equals(object obj)
        {
            return this.isbn.Equals(((Livro)obj).Isbn);
        }

        public string praString(bool sel=false)
        {
            string ret = String.Format("isbn: {0}, Titulo: {1}, Autor: {2}, Editora: {3}.\nTotal de exemplares: {4}\nExemplares disponiveis: {5}\nNumero de emprestimos: {6}\nPercentual de disponibilidade: {7:P2}",
                                        this.isbn, this.titulo, this.autor, this.editora, this.qtdeExemplares(), this.qtdeDisponiveis(), this.qtdeEmprestimos(), this.percDisponibilidade());
            if (!sel) { return ret; }

            ret += "\n";

            foreach(Exemplar ex in this.exemplares )
            {
                ret += "\n" + ex.ToString();
            }

            return ret;
        }
    }
}
