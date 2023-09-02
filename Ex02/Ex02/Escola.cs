using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Escola
    {
        private Curso[] cursos;

        public Escola() 
        { 
            cursos = new Curso[5];
            for (int i = 0; i < 5; i++)
            {
                this.cursos[i] = new Curso();
            }
        }

        public bool adicionarCurso(Curso cur)
        {
            int i = 0;
            while (i < 5 && !this.cursos[i].Equals(new Curso()))
            {
                i++;
            }
            if (i != 5)
            {
                this.cursos[i] = cur;
                return true;
            }
            return false;
        }

        public bool removerCurso(Curso cur)
        {
            bool podeRemover;

            int i = 0;
            while (i < 5 && !this.cursos[i].Equals(cur))
            {
                i++;
            }
            podeRemover = i < 5 && this.cursos[i].podeDeletar();

            if (podeRemover)
            {
                while (i < 4)
                {
                    this.cursos[i] = this.cursos[i + 1];
                    i++;
                }
                this.cursos[i] = new Curso();
            }
            return podeRemover;
        }

        public Curso pesquisarCurso(Curso cur)
        {
            int i = 0;
            while (i < 5 && !this.cursos[i].Equals(cur))
            {
                i++;
            }

            if (i == 5)
            {
                return new Curso();
            }
            return this.cursos[i];
        }
    }
}
