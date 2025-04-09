using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WebApplication1.Models
{
	public class Aluno
	{
        public int Num { get; set; }
        public string Nome { get; set; }
        public string Turma { get; set; }
    }

    public class Exam
    {
        public int Num { get; set; }
        public string Disciplina { get; set; }
        public int Nota { get; set; }
    }

    public class BD
    {
        List<Aluno>alunos;
        List<Exam>exames;
        public void gravar()
        {
            HttpServerUtility server = HttpContext.Current.Server;
            String path = server.MapPath(@"~/App_Data/dados.json");
            DataContractJsonSerializer dc = new DataContractJsonSerializer(typeof(List<Aluno>));
            FileStream fs = new FileStream(path,FileMode.Create,FileAccess.Write);
            dc.WriteObject(fs, alunos);
            fs.Close();
        }

        public void carregar()
        {
            HttpServerUtility server = HttpContext.Current.Server;
            String path = server.MapPath(@"~/App_Data/dados.json");
            if (File.Exists(path))
            {
                DataContractJsonSerializer dc = new DataContractJsonSerializer(typeof(List<Aluno>));
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                alunos = (List<Aluno>)dc.ReadObject(fs);
                fs.Close();
            }
            else
            {
                alunos = new List<Aluno>();
            }

        }

        public BD()
        {
            //alunos = new List<Aluno>
            //{
            //    new Aluno {Num =1, Nome="João", Turma="A" },
            //    new Aluno {Num =2, Nome="Mira", Turma="A" },
            //    new Aluno {Num =3, Nome="Leandro", Turma="B" },
            //    new Aluno {Num =4, Nome="Francisco", Turma="A" },
            //    new Aluno {Num =1, Nome="Diogo", Turma="B" }
            //};
            carregar();
        }

        public List<Aluno> GetAlunos()
        {
            return alunos;
        }
    }
}