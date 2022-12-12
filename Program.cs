using System;
using System.Reflection;

namespace Bussen
{
// Huvudclass för projekt/program
	class Program
	{
		public static void Main(string[] args)
		{
			// Instansiera nytt buss-objekt
			Buss MinBuss = new Buss();

			// anropa metoden run i det instansierade buss-objektet minbuss
			MinBuss.Run();

			// Programslut
			System.Console.WriteLine("Programmet slut!");
			System.Console.WriteLine("");
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}