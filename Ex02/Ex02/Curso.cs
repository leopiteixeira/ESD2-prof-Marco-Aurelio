using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Curso
    {
        private int id;
        private string desc;
        private Disciplina[] disciplinas;

        public Curso(int id, string desc) 
        { 
            this.id = id;
            this.desc = desc;   
            this.disciplinas = new Disciplina[12];
            for(int i = 0; i < 12; i++)
            {
                this.disciplinas[i] = new Disciplina();
            }
        }

        public Curso() : this(-1, " ") { }

        public int Id { get => id; }
        public string Desc { get => desc; set => desc = value; }

        public bool adicionarDisciplina(Disciplina dis)
        {
            int i = 0;
            while (i < 12 && !this.disciplinas[i].Equals(new Disciplina()))
            {
                i++;
            }
            if (i != 12 && this.id != -1)
            {
                this.disciplinas[i] = dis;
                return true;
            }
            return false;
        }

        public bool removerDisciplina(Disciplina dis)
        {
            bool podeRemover;

            int i = 0;
            while (i < 12 && !this.disciplinas[i].Equals(dis))
            {
                i++;
            }
            podeRemover = i < 12 && dis.Alunos[0].Equals(new Aluno());

            if (podeRemover)
            {
                while (i < 11)
                {
                    this.disciplinas[i] = this.disciplinas[i + 1];
                    i++;
                }
                this.disciplinas[i] = new Disciplina();
            }
            return podeRemover;
        }

        public Disciplina pesquisarDisciplina(Disciplina dis)
        {
            int i = 0;
            while (i < 12 && !this.disciplinas[i].Equals(dis))
            {
                i++;
            }

            if (i == 12)
            {
                return new Disciplina();
            }
            return this.disciplinas[i];
        }

        public bool podeDeletar() 
        {
            return this.disciplinas[0].Equals(new Disciplina());
        }

        public override bool Equals(object obj)
        {
            return this.id.Equals(((Curso)obj).Id);
        }

        public override string ToString()
        {
            string res = string.Format("Curso: {0}, Descricão: {1}, Disciplinas Associadas: \n", this.id, this.desc);
            for (int i = 0; i < this.disciplinas.Length; i++)
            {
                if (!this.disciplinas[i].Equals(new Disciplina()))
                {
                    res += this.disciplinas[i].paString(0) + "\n";
                }
            }
            return res;
        }
    }
}
