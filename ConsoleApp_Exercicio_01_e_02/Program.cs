using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp_Exercicio_01_e_02
{
	class Program
	{
		static void Main(string[] args)
		{
			// Exercicio 1
			Console.Clear();

			string nomeDisciplina = string.Empty;
			string aluno = string.Empty;
			string nota = string.Empty;
			const double limiteNota = 10;
			const string ESPACO = "\t";
			double[] notas = new double[3];
			string[] disciplinas = new string[10];
			string[] alunos = new string[40];
			int contador = 0;
			int contadorNotas = 0;
			var lista = new List<string>();
			double somaNotas = 0;
			double media = 0;
			string situacaoAluno = "";
			bool aprovado = true;
			var formatoNumeroDecimal = new CultureInfo("pt-BR");

			formatoNumeroDecimal.NumberFormat.NumberDecimalDigits = 2;
			Calendar calendario = CultureInfo.InvariantCulture.Calendar;

			DateTime data = DateTime.Now;
			//Alguns métodos caso queira alterar informações atuais:
			//			data = calendario.AddYears(data, 5);
			//			data = calendario.AddMonths(data, 5);
			//			data = calendario.AddWeeks(data, 5);
			//			data = calendario.AddDays(data, 5);
			//			data = calendario.AddHours(data, 5);
			//			data = calendario.AddMinutes(data, 5);
			//			data = calendario.AddSeconds(data, 5);
			//			data = calendario.AddMilliseconds(data, 5);

			Console.WriteLine("\nData atual {0:d} at {0:T}.", data);
			Console.WriteLine("Ano Letivo: {0}", calendario.GetYear(data));

			do
			{
				Console.Write("Informe uma disciplina ('FIM' para finalizar): ");
				nomeDisciplina = Console.ReadLine();
				if (nomeDisciplina.ToUpper() == "FIM")
				{
					break;
				}
				disciplinas[contador] = nomeDisciplina;
				contador++;

			} while (contador < disciplinas.Length);
			int i = 0;
			foreach (string disciplina in disciplinas)
			{
				if (disciplina == null)
				{
					break;
				}
				i = 0;
				Console.WriteLine("Informe alunos da Disciplina: {0}", disciplina);
				// Para cada disciplina, solicitar nome dos alunos
				while (i < 40)
				{
					i++;
					Console.Write("Aluno {0} ('FIM' para finalizar): ", i);
					aluno = Console.ReadLine();
					if (aluno.ToUpper() == "FIM")
					{
						break;
					}
					alunos[contador] = aluno;
					contador++;
					//Para cada aluno, solicitar as 3 notas do trimestre
					contadorNotas = 0;
					somaNotas = 0;
					Console.WriteLine("Informe as 3 Notas do Aluno: {0} ", aluno);
					for (int index = 0; index < notas.Length; index++)
					{
						contadorNotas++;
						Console.Write("Informe a Nota {0}: ", contadorNotas);
						nota = Console.ReadLine().Replace(".", ",");
						while (Double.Parse(nota) > limiteNota)
						{
							Console.WriteLine("Nota deve ser entre 0 e 10");
							Console.Write("Informe a Nota {0}: ", contadorNotas);
							nota = Console.ReadLine().Replace(".", ",");
						}
						notas[index] = Convert.ToDouble(nota);

						//      notas[index] = Convert.ToInt32(nota);
						//		notas[index] = (int)Console.Read();
						//      notas[index] = Int32.Parse(nota);
						somaNotas = somaNotas + notas[index];
					}
					media = somaNotas / notas.Length;
					//			if (media >= 7)
					//			{
					//				aprovado = true;
					//			}
					//			else
					//			{
					//				aprovado = false;
					//			}
					//			switch (aprovado)
					//			{
					//				case true:
					//					situacaoAluno = "Aprovado";
					//					break;
					//				case false:
					//					situacaoAluno = "Reprovado";
					//					break;
					//			}

					situacaoAluno = media >= 7 ? "Aprovado" : "Reprovado";

					lista.Add(disciplina + ESPACO + aluno + ESPACO + notas[0] + ESPACO + notas[1] + ESPACO + notas[2] + ESPACO + string.Format(formatoNumeroDecimal, "{0:N}", media) + ESPACO + situacaoAluno);
				}
			}
			ExibirRelatorioEmTela(lista);
		}

		/// <summary>
		/// Esta funcao exibe 
		/// </summary>
		/// <param name="lista">Recebe lista das disciplinas</param>
		private static void ExibirRelatorioEmTela(List<string> lista)
		{
			Console.WriteLine("-----------------------------------------------------------------------");
			Console.WriteLine("Disciplina	Aluno	Nota1	Nota2	Nota3	Média	Situação");
			lista.Sort();
			foreach (string relatorio in lista)
				Console.WriteLine(relatorio);
			Console.ReadKey();
		}
	}
}
