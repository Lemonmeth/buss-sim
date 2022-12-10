using System;
using System.Reflection;

/*
Todo:
- check null på sortlist eller occupied.
*/

namespace Bussen
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Denna del körs först! 
			//Denna del av koden kan upplevas väldigt förvirrande. Men i sådana fall är det bara att "skriva av".
			//Programmet skapar ett så kallat objekt av klassen "Buss". Det är det objekt vi kommer jobba med.
			//Följande rad skapar en buss:
			//SafeInput safeInput = new SafeInput();
			Buss MinBuss = new Buss();
			//Följande rad anropar metoden Run() som finns i vårt nya buss-objekt.
			MinBuss.Run();
			//När metoden Run() tar slut så kommer koden fortsätta här. Då är programmet slut
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}