﻿/*Hjälpkod för att komma igång
 * Notera att båda klasserna är i samma fil för att det ska underlätta.
 * Om programmet blir större bör man ha klasserna i separata filer såsom jag går genom i filmen
 * Då kan det vara läge att ställa in startvärden som jag gjort.
 * Man kan också skriva ut saker i konsollen i konstruktorn för att se att den "vaknar
 * Denna kod hjälper mest om du siktar mot betyget E och C
 * För högre betyg krävs mer självständigt arbete
 */
using System;
//Nedan är namnet på "namespace" - alltså projektet. 
//SKapa ett nytt konsollprojekt med namnet "Bussen" så kan ni kopiera över all koden rakt av från denna fil

namespace Bussen
{
	/*Börja längst ner i dokumentet och klassen "Program".
	Den klassen är liten och har i uppgiften att köra igång programmet genom att skapa en buss och sedan anropa metoden Run().
	I beskrivningen av projektet påpekas vikten av att koda stegvis. I detta fall kan det handla om att ni bara ska skriva
	ut en text i Run()-metoden.
	 */

	class Controls
	{
		static public string allowedStrings(string text)
		{
			while (text == "" || text == null)
			{
				Console.Clear();
				System.Console.WriteLine("Empty values not allowed! Try again:");
				text = Console.ReadLine();
			}
			return text;
		}

		static public int allowedInts(string strNumber)
		{
			if (int.TryParse(strNumber, out int okNumber) == true)
			{
				return okNumber;
			}
			else
			{
				System.Console.WriteLine("Faulty input, try again!: ");
				return allowedInts(Console.ReadLine());
			}
		}
	}

	class Passagerare
	{
		int ålder;
		string kön;

		public Passagerare (int a, string g)
		{
			ålder = a;
			kön = g;
		}
	}

	class Buss
	{
		object[] allaPassagerare = new object[25];
		int[] allSeats = new int[25];

		public void Run()
		{
			//Här ska menyn ligga för att göra saker
			//Jag rekommenderar switch och case här
			//I filmen nummer 1 för slutprojektet så skapar jag en meny på detta sätt.
			//Dessutom visar jag hur man anropar metoderna nedan via menyn
			//Börja nu med att köra koden för att se att det fungerar innan ni sätter igång med menyn.
			//Bygg sedan steg-för-steg och testkör koden.

			// Initialiasera menyväljaren
			int menuSelect = 0;

			// Initiera lista med platser

			// Initiera menyalternativ
			string[] menuOptions = new string[] 
			{
				"A1",
				"A2",
				"A3",
				"A4",
				"A5",
				"A6"
			};
			
			Console.WriteLine("Welcome to the awesome Buss-simulator");
			System.Console.WriteLine("Press any key to continue.");
			Console.ReadKey();
			

			// meny



			while (true)
			{
				// Dölj markören
				Console.CursorVisible = false;

				// Rensa skärmen
				Console.Clear();

				// Skriv ut menyn
				for (int i = 0; i < menuOptions.Length; i++)
				{
					if (menuSelect == i)
					{
						System.Console.WriteLine(menuOptions[i] + " <--");
					}
					else
					{
						System.Console.WriteLine(menuOptions[i]);
					}
				}

				// Läs tangent
				var keyPressed = Console.ReadKey();

				// Kontrollera tryckt tangent
				if (keyPressed.Key == ConsoleKey.DownArrow)
				{	
					if (menuSelect != (menuOptions.Length -1))
					{
						menuSelect++;
					}
				}
				else if (keyPressed.Key == ConsoleKey.UpArrow)
				{
					if (menuSelect != 0)
					{
						menuSelect--;
					}
				}
				else if (keyPressed.Key == ConsoleKey.Enter)
				{
					switch (menuSelect)
					{
						case 0:
							add_passenger();
							break;
						case 1:
							print_buss();
							break;
						case 2:
							System.Console.WriteLine("case 2");
							break;
						case 3:
							break;
						case 4:
							break;
						case 5:
							break;
					}
					Console.Read();
				}
			}
		}

		//Metoder för betyget E
		
		public void add_passenger()
		{
			//Lägg till passagerare. Här skriver man då in ålder men eventuell annan information.
			//Om bussen är full kan inte någon passagerare stiga på
			Console.CursorVisible = true;

			Console.WriteLine("Ange ålder: ");
			int age = Convert.ToInt32((Console.ReadLine()));
			Console.WriteLine("Ange kön: ");
			string gender = Controls.allowedStrings(Console.ReadLine());
			
			allaPassagerare.Append(new Passagerare(age,gender));
		}
		
		public void print_buss()
		{
			//Skriv ut alla värden ur vektorn. Alltså - skriv ut alla passagerare

			for (int i = 0; i < allaPassagerare.Length; i++)
			{
				System.Console.WriteLine(allaPassagerare[i]);
			}
		}
		/*
		public int calc_total_age()
		{
			//Beräkna den totala åldern. 
			//För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
		}
		
		//Metoder för betyget C
		/*
		public double calc_average_age()
		{
			//Betyg C
			//Beräkna den genomsnittliga åldern. Kanske kan man tänka sig att denna metod ska returnera något annat värde än heltal?
			//För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
		}
		
		public int max_age()
		{
			//Betyg C
			//ta fram den passagerare med högst ålder. Detta ska ske med egen kod och är rätt klurigt.
			//För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
		}
		
		public void find_age()
		{
			//Visa alla positioner med passagerare med en viss ålder
			//Man kan också söka efter åldersgränser - exempelvis 55 till 67
			//Betyg C
			//Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 149)

		}
		
		public void sort_buss()
		{
			//Sortera bussen efter ålder. Tänk på att du inte kan ha tomma positioner "mitt i" vektorn.
			//Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 159)
			//Man ska kunna sortera vektorn med bubble sort
		}
		
		//Metoder för betyget A
		//NOTERA! För betyget A ska du inte jobba med heltal i vektorn utan objekt av klassen passagerare (som du skapar)
		
		
		public void print_sex()
		{
			//Betyg A
			//Denna metod är nödvändigtvis inte svårare än andra metoder men kräver att man skapar en klass för passagerare.
			//Skriv ut vilka positioner som har manliga respektive kvinnliga passagerare.
		}	
		public void poke()
		{
			//Betyg A
			//Vilken passagerare ska vi peta på?
			//Denna metod är valfri om man vill skoja till det lite, men är också bra ur lärosynpunkt.
			//Denna metod ska anropa en passagerares metod för hur de reagerar om man petar på dom (eng: poke)
			//Som ni kan läsa i projektbeskrivningen så får detta beteende baseras på ålder och kön.
		}	
		
		public void getting_off()
		{
			//Betyg A
			//En passagerare kan stiga av
			//Detta gör det svårare vid inmatning av nya passagerare (som sätter sig på första lediga plats)
			//Sortering blir också klurigare
			//Den mest lämpliga lösningen (men kanske inte mest realistisk) är att passagerare bakom den plats..
			//.. som tillhörde den som lämnade bussen, får flytta fram en plats.
			//Då finns aldrig någon tom plats mellan passagerare.
		}	

		*/
	}
	
	class Program
	{
		public static void Main(string[] args)
		{
			//Denna del körs först! 
			//Denna del av koden kan upplevas väldigt förvirrande. Men i sådana fall är det bara att "skriva av".
			//Programmet skapar ett så kallat objekt av klassen "Buss". Det är det objekt vi kommer jobba med.
			//Följande rad skapar en buss:
			Buss MinBuss = new Buss();
			//Följande rad anropar metoden Run() som finns i vårt nya buss-objekt.
			MinBuss.Run();
			//När metoden Run() tar slut så kommer koden fortsätta här. Då är programmet slut
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}