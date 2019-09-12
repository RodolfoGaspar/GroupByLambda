using System.Collections.Generic;
using System.Linq;

namespace GroupByLambda
{
	class Program
	{
		static void Main(string[] args)
		{
			var contratos = new List<Contrato>();

			contratos.Add(new Contrato { Numero = 1, Agencia = 2, Conta = 3, Carteira = "A", Valor = 1.2 });
			contratos.Add(new Contrato { Numero = 2, Agencia = 2, Conta = 3, Carteira = "A", Valor = 3.3 });
			contratos.Add(new Contrato { Numero = 3, Agencia = 3, Conta = 4, Carteira = "B", Valor = 5.4 });
			contratos.Add(new Contrato { Numero = 4, Agencia = 3, Conta = 4, Carteira = "B", Valor = 7.1 });
			contratos.Add(new Contrato { Numero = 5, Agencia = 4, Conta = 5, Carteira = "C", Valor = 6.4 });
			contratos.Add(new Contrato { Numero = 6, Agencia = 4, Conta = 5, Carteira = "D", Valor = 1.7 });
			contratos.Add(new Contrato { Numero = 7, Agencia = 4, Conta = 5, Carteira = "D", Valor = 1.2 });
			contratos.Add(new Contrato { Numero = 8, Agencia = 5, Conta = 6, Carteira = "A", Valor = 1.2 });
			contratos.Add(new Contrato { Numero = 9, Agencia = 6, Conta = 7, Carteira = "B", Valor = 1.2 });
			contratos.Add(new Contrato { Numero = 10, Agencia = 7, Conta = 8, Carteira = "C", Valor = 1.2 });

			System.Console.ForegroundColor = System.ConsoleColor.Cyan;

			System.Console.WriteLine(" -------------------------------------");
			System.Console.WriteLine("|           Contratos                 |");
			System.Console.WriteLine(" -------------------------------------");
			System.Console.WriteLine("|Numero|Agencia|Conta|Carteira| Valor |");
			System.Console.WriteLine(" -------------------------------------");
			contratos.ForEach(c =>
			{
				System.Console.WriteLine($"|{c.Numero.ToString().PadLeft(6, ' ')}|{c.Agencia.ToString().PadLeft(7, ' ')}|{c.Conta.ToString().PadLeft(5, ' ')}|{c.Carteira.ToString().PadLeft(8, ' ')}|${c.Valor.ToString().PadLeft(6, ' ')}|");
			});
			System.Console.WriteLine(" -------------------------------------");

			System.Console.WriteLine(" ------------------------------");			
			System.Console.WriteLine("|    Soma de Contratos por     |");
			System.Console.WriteLine("|   Agencia, Conta e Valor     |");			
			System.Console.WriteLine(" ------------------------------");
			System.Console.WriteLine("|Agencia|Conta|Carteira| Valor |");
			System.Console.WriteLine(" ------------------------------");
			contratos.GroupBy(c => new
			{
				c.Agencia,
				c.Conta,
				c.Carteira,
				SomaValor = contratos.Where(co => co.Agencia == c.Agencia && co.Conta == c.Conta && co.Carteira == c.Carteira).Sum(co => co.Valor)
			}).AsEnumerable().ToList().
				ForEach(c =>
				{
					System.Console.WriteLine($"|{c.Key.Agencia.ToString().PadLeft(7, ' ')}|{c.Key.Conta.ToString().PadLeft(5, ' ')}|{c.Key.Carteira.ToString().PadLeft(8, ' ')}|${c.Key.SomaValor.ToString().PadLeft(6, ' ')}|");
				});
			System.Console.WriteLine(" ------------------------------");
		}


	}

	public class Contrato
	{
		public long Numero { get; set; }
		public int Agencia { get; set; }
		public int Conta { get; set; }
		public string Carteira { get; set; }
		public double Valor { get; set; }
	}
}
