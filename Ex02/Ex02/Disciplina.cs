using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Disciplina
    {
        private int id;
        private string desc;
        private Aluno[] alunos;

        public int Id { get => id; }
        public string Desc { get => desc; set => desc = value; }
        internal Aluno[] Alunos { get => alunos; }

        public Disciplina(int id, string desc)
        {
            this.id = id;
            this.desc = desc;
            this.alunos = new Aluno[15];
            for (int i = 0; i < 15; i++)
            {
                this.alunos[i] = new Aluno();
            }
        }

        public Disciplina() : this(-1, " "){ }

        public bool matricularAluno(Aluno aluno)
        {
            int i = 0;
            while (i < 15 && !this.alunos[i].Equals(new Aluno()))
            {
                i++;
            }
            if (aluno.podeMatricular() && i < 15 && this.id != -1)
            {
                this.alunos[i] = aluno;
                this.alunos[i].QtdDisciplinas++;
                return true;
            }
            return false;
        }

        public bool desmatricularAluno(Aluno aluno)
        {
            bool podeRemover;

            int i = 0;
            while (i < 15 && !this.alunos[i].Equals(aluno))
            {
                i++;
            }
            podeRemover = i < 15;

            if (podeRemover)
            {
                while (i < 14)
                {
                    this.alunos[i] = this.alunos[i + 1];
                    i++;
                }
                this.alunos[i] = new Aluno();
            }
            return podeRemover;
        }

        public override bool Equals(object obj)
        {
            return this.id.Equals(((Disciplina)obj).Id);
        }

        public string paString(int i)
        {
            string res = string.Format("Disciplina: {0}, Descricão: {1}", this.id, this.desc);
            if (i == 1)
            {
                res += ", Alunos Matriculados: \n";
                for (int l = 0; l < this.alunos.Length; l++)
                {
                    if (!this.alunos[l].Equals(new Aluno()))
                    {
                        res += this.alunos[l].ToString() + "\n";
                    }
                }
            }
            return res;
        }
    }
}
