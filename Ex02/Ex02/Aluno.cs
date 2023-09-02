using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Aluno
    {
        private int id;
        private string nome;
        private int qtdDisciplinas;

        public Aluno(int id, string nome) 
        {
            this.id = id;
            this.nome = nome;  
            this.qtdDisciplinas = 0;
        }

        public Aluno() : this(-1, " ") { }

        public int QtdDisciplinas { get => qtdDisciplinas; set => qtdDisciplinas = value; }
        public int Id { get => id; }
        public string Nome { get => nome; set => nome = value; }

        public bool podeMatricular()
        {
            return this.qtdDisciplinas < 6;
        }

        public override bool Equals(object obj)
        {
            return this.id.Equals(((Aluno)obj).Id);
        }

        public override string ToString()
        {
            return string.Format("Aluno: {0}, id: {1}, {2} disciplinas", this.nome, this.id, this.qtdDisciplinas);
        }
    }
}
