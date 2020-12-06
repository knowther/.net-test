using System;

namespace revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            
            string opcaoUsuario = ObterOpcaoUser();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    Console.WriteLine("Informe o nome do aluno:");
                    Aluno aluno = new Aluno();
                    aluno.Nome = Console.ReadLine();
                    Console.WriteLine("Informe a nota do aluno:");

                  if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                  {
                      aluno.Nota = nota;
                  }else{
                      throw new ArgumentException("O valor da nota deve ser decimal.");
                  }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                     Console.WriteLine("Deseja registrar outro aluno? S/N?");
                     string refazerCad = Console.ReadLine();
                    if(refazerCad.ToUpper() != "S"){
                       break;
                    }else{
                        continue;
                    }

                    case "2":
                    foreach(var student in alunos){
                        if(!string.IsNullOrEmpty(student.Nome)){
                            Console.WriteLine($"ALUNO: {student.Nome} - NOTA: {student.Nota}" );
                        }
                        
                    }

                        break;

                    case "3":
                    decimal notaTotal = 0;
                    var nAlunos = 0;
                    for(int i=0; i < alunos.Length; i++){
                        if(!string.IsNullOrEmpty(alunos[i].Nome)){
                            notaTotal = notaTotal + alunos[i].Nota;
                            nAlunos++;
                    }
                    }
                        var mediaGeral  = notaTotal / nAlunos;
                        ConceitoEnum conceitoGeral;
                        if(mediaGeral < 2){
                            conceitoGeral = ConceitoEnum.E;
                        }else if(mediaGeral < 4){
                            conceitoGeral = ConceitoEnum.D;
                        } else if(mediaGeral < 6){
                            conceitoGeral = ConceitoEnum.C;
                        } else if(mediaGeral < 8){
                            conceitoGeral = ConceitoEnum.B;
                        }else{
                            conceitoGeral = ConceitoEnum.A;
                        }
                        Console.WriteLine($"Média Geral: {mediaGeral} CONCEITO - {conceitoGeral}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUser();
            }
        }

        private static string ObterOpcaoUser()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
