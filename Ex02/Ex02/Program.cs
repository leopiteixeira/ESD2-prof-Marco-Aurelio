using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Program
    {
        static Curso criarCurso()
        {
            int id;
            string desc;
            Console.WriteLine("Digite o Id do curso:");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a descricão do Curso");
            desc = Console.ReadLine();

            return new Curso(id, desc);
        }

        static Curso criarCursoId()
        {
            int id;
            Console.WriteLine("Digite o Id do curso:");
            id = Convert.ToInt32(Console.ReadLine());

            return new Curso(id, " ");
        }

        static Disciplina criarDisciplina()
        {
            int id;
            string desc;
            Console.WriteLine("Digite o Id da disciplina:");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a descricão da disciplina");
            desc = Console.ReadLine();

            return new Disciplina(id, desc);
        }

        static Disciplina criarDisciplinaId()
        {
            int id;
            Console.WriteLine("Digite o Id da disciplina:");
            id = Convert.ToInt32(Console.ReadLine());

            return new Disciplina(id, " ");
        }

        static Curso pesqCurso(Escola e)
        {
            return e.pesquisarCurso(criarCursoId());
        }

        static Disciplina pesqDisciplina(Escola e)
        {
            return pesqCurso(e).pesquisarDisciplina(criarDisciplinaId());
        }

        static Aluno criarAluno()
        {
            int id;
            string nome;
            Console.WriteLine("Digite o Id do aluno:");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o nome do aluno");
            nome = Console.ReadLine();

            return new Aluno(id, nome);
        }

        static Aluno criarAlunoId()
        {
            int id;
            Console.WriteLine("Digite o Id do aluno:");
            id = Convert.ToInt32(Console.ReadLine());

            return new Aluno(id, " ");
        }

        static void Main(string[] args)
        {
            int sel = 1;
            Escola e1 = new Escola();

            while (sel !=0) 
            {
                Console.WriteLine("0.Sair\n" +
                    "1.Adicionar curso\n" +
                    "2.Pesquisar curso\n" +
                    "3.Remover curso\n" +
                    "4.Adicionar disciplina no curso\n" +
                    "5.Pesquisar disciplina\n" +
                    "6.Remover disciplina do curso\n" +
                    "7.Matricular aluno na disciplina\n" +
                    "8.Remover aluno da disciplina");
                sel = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (sel)
                {
                    case 1: Console.WriteLine(e1.adicionarCurso(criarCurso()) ? "Curso Adicionado!" : "Falha ao adicionar curso!");
                        break;

                    case 2: Console.WriteLine(pesqCurso(e1).ToString());
                        break;

                    case 3: Console.WriteLine(e1.removerCurso(criarCursoId()) ? "Curso removido!" : "Falha ao remover curso!");
                        break;

                    case 4: Console.WriteLine(pesqCurso(e1).adicionarDisciplina(criarDisciplina()) ? "Disciplina adicionada!" : "Falha ao adicionar a disciplina!"); 
                        break;

                    case 5: Console.WriteLine(pesqDisciplina(e1).paString(1));
                        break;

                    case 6: Console.WriteLine(pesqCurso(e1).removerDisciplina(criarDisciplinaId()) ? "Disciplina removida!" : "Falha ao remover a disciplina");
                        break;

                    case 7: Console.WriteLine(pesqDisciplina(e1).matricularAluno(criarAluno()) ? "Aluno matriculado!" : "Falha ao matricular aluno!");
                        break; 

                    case 8: Console.WriteLine(pesqDisciplina(e1).desmatricularAluno(criarAlunoId()) ? "Aluno removido!" : "Falha ao remover o aluno!");
                        break;
                }
                
            }

        }
    }
}
