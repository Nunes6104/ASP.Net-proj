using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class Aluno
	{
        [NumUnico(ErrorMessage = "Já existe esse aluno")]
        public int Num { get; set; }

        [MinLength(4,ErrorMessage ="Tamanho minimo de 4 caracteres")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Só letras")]
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
            carregar();
            exames = new List<Exam>()
            {
                new Exam() { Num = 1, Disciplina = "Programação II", Nota = 10 },
                new Exam() { Num = 2, Disciplina = "TI II", Nota = 16 },
                new Exam() { Num = 1, Disciplina = "Redes", Nota = 15 },
                new Exam() { Num = 1, Disciplina = "Historia", Nota = 10 },
                new Exam() { Num = 2, Disciplina = "Ciencia de Dados", Nota = 10 }
            };
        }

        public List<Aluno> GetAlunos()
        {
            return alunos;
        }
        public List<Exam> GetExames()
        {
            return exames;
        }
    }
}