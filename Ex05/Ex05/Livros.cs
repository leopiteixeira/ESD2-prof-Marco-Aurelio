using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    internal class Livros
    {
        private List<Livro> acervo;

        internal List<Livro> Acervo { get => acervo; set => acervo = value; }

        public Livros() { this.acervo = new List<Livro>(); }

        public void adicionar(Livro livro)
        {
            acervo.Add(livro);
        }

        public Livro pesquisar(Livro livro)
        {
            foreach (Livro l in acervo)
            {
                if (l.Equals(livro))
                {
                    return l;
                }
            }
            return new Livro();
        }
    }
}
