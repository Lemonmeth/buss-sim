namespace Bussen;

class Buss
	{
		Seat[] allSeats = new Seat[25];
		
		string[] menuOptions = new string[] 
			{
				"Addera passagerare",
				"Skriv ut alla passagerare",
				"Summera åldern för alla passagerare",
				"Beräkna passaregarnas snittålder",
				"Skriv ut äldsta passageraren",
				"Skriv ut passagerare i åldersspann",
				"Sortera bussen",
				"Skriv ut passagerarnas kön",
				"Peta på en passagerare",
				"Ta bort passagerare"
			};

		public void Run()
		{
			
			//Här ska menyn ligga för att göra saker
			//Jag rekommenderar switch och case här
			//I filmen nummer 1 för slutprojektet så skapar jag en meny på detta sätt.
			//Dessutom visar jag hur man anropar metoderna nedan via menyn
			//Börja nu med att köra koden för att se att det fungerar innan ni sätter igång med menyn.
			//Bygg sedan steg-för-steg och testkör koden.

			//Fyll vektor med seat-objekt
			for (int i = 0; i < allSeats.Length; i++)
			{
				allSeats[i] = new Seat();
			}

			// test
			OpenDoors();

			// Initialiasera menyväljaren
			int menuSelect = 0;

			// Initiera menyalternativ
			
			
			Console.WriteLine("Welcome to the awesome Buss-simulator");
			System.Console.WriteLine("Press any key to continue.");
			Console.Read();

			// meny
			while (true)
			{
				// Dölj markören
				Console.CursorVisible = false;

				// Rensa skärmen och skriv ut menyn med marketat alternativ
				Console.Clear();
				System.Console.WriteLine("Buss OS - Använd 🠕, 🠗 och Enter");
				System.Console.WriteLine("-------------------------------");
				for (int i = 0; i < menuOptions.Length; i++)
				{
					if (menuSelect == i)
					{
						System.Console.WriteLine("[" + menuOptions[i] + "]");
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
							calc_total_age(true);
							break;
						case 3:
							calc_average_age();
							break;
						case 4:
							max_age();
							break;
						case 5:
							find_age();
							break;
						case 6:
							sort_buss();
							break;
						case 7:
							print_sex();
							break;
						case 8:
							poke();
							break;
						case 9:
							getting_off();
							break;
					}
					System.Console.WriteLine("");
					System.Console.WriteLine("menyval klart, enter för att gå tillbaka!");
					Console.Read();
				}
			}
		}

		public void OpenDoors()
		{

            Random rnd = new Random();
            for (int i = 0; i < allSeats.Length; i++)
			{
                int rand = rnd.Next(1, 3);
                int age = rnd.Next(1, 100);
                string gender = "male";
				if (rand == 1)
                {
                    allSeats[i].SitDown(new Passenger(age, gender));
                }
			}
		}

		public void add_passenger()
		{
			//Lägg till passagerare. Här skriver man då in ålder men eventuell annan information.
			//Om bussen är full kan inte någon passagerare stiga på.
			Console.CursorVisible = true;

			Console.Clear();
			System.Console.WriteLine("Buss OS - " + menuOptions[0]);
			System.Console.WriteLine("----------------------------");

			Console.WriteLine("Ange ålder: ");
			int age = SafeInput.Integers(Console.ReadLine());
			System.Console.WriteLine("");
			Console.WriteLine("Ange kön('male' eller 'female'): ");
			string gender = SafeInput.Strings(Console.ReadLine());
			
			for (int i = 0; i < allSeats.Length; i++)
			{
				if (allSeats[i].Occupied == false)
				{
					// Lägg till en ny passagerare
					allSeats[i].SitDown(new Passenger(age, gender));

					//Informera om vilken plats 
					System.Console.WriteLine("");
					System.Console.WriteLine("Passagerare fick platsen: " + (i + 1));
					break;
				}
                
                bool allOccupied = true;
				foreach (var seat in allSeats)
				{
					if (seat.Occupied == false)
					{
						allOccupied = false;
                    }
				}
				if (allOccupied)
				{
					Console.WriteLine("Inga säten lediga!");
				}
                // if no free seats, print message
            }
		}
		
		public void print_buss()
		{
			//Skriv ut alla värden ur vektorn. Alltså - skriv ut alla passagerare
			Console.Clear();
			System.Console.WriteLine("BussOS - " + menuOptions[1]);
			System.Console.WriteLine("-----------------------------------");
			for (int i = 0; i < allSeats.Length; i++)
			{
				if (allSeats[i].Occupied == true)
				{
					if ((i + 1) <= 9)
					{
						// Korrigera kolumner
						System.Console.WriteLine("| Plats: " + (i + 1) + "  | Upptagen: " + allSeats[i].Occupied + " | Ålder: " + allSeats[i].Passenger.age + " | Kön: " + allSeats[i].Passenger.gender + " |");
					}
					else
					{
						
						System.Console.WriteLine("| Plats: " + (i + 1) + " | Upptagen: " + allSeats[i].Occupied + " | Ålder: " + allSeats[i].Passenger.age + " | Kön: " + allSeats[i].Passenger.gender + " |");
					}
				}
			}
		}
		
		public int calc_total_age(bool withText)
		{
			//Beräkna den totala åldern. 
			//För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
			int total = 0;
			for (int i = 0; i < allSeats.Length; i++)
			{
				if (allSeats[i].Occupied == true)
				{
					total += allSeats[i].Passenger.age;
				}
			}
			if (withText == true)
			{
				Console.Clear();
				System.Console.WriteLine("Buss OS - " + menuOptions[2]);
				System.Console.WriteLine("-----------------------------");
				System.Console.WriteLine("Den totala åldern för alla passagerare är " + total + " år.");
			}
			return total;
		}
		
		public void calc_average_age()
		{
			//Betyg C
			//Beräkna den genomsnittliga åldern. Kanske kan man tänka sig att denna metod ska returnera något annat värde än heltal?
			//För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void

			Console.Clear();
			System.Console.WriteLine("BussOS - " + menuOptions[3]);
			System.Console.WriteLine("----------------------------");

			int seatsOccupied = 0;
			for (int i = 0; i < allSeats.Length; i++)
			{
				if (allSeats[i].Occupied == true)
				{
					seatsOccupied++;
				}
			}

			System.Console.WriteLine("Den genomsnittliga åldern för alla passagerare är: " + Convert.ToDouble(calc_total_age(false) / seatsOccupied) + " år.");

		}
		
		public void max_age()
		{
			//Betyg C
			//ta fram den passagerare med högst ålder. Detta ska ske med egen kod och är rätt klurigt.
			//För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
			int maxAge = 0;
			int personIndex = 0;
			for (int i = 0; i < allSeats.Length; i++)
			{
				if (allSeats[i].Occupied == true)
				{
					if (allSeats[i].Passenger.age > maxAge)
					{
						maxAge = allSeats[i].Passenger.age;
						personIndex = i;
					}
				}
				
			}

			Console.Clear();
			System.Console.WriteLine("BussOS - " + menuOptions[4]);
			System.Console.WriteLine("-------------------------------------");
			Console.WriteLine("Äldsta passageraren är passagerare nr: " + (personIndex + 1) + " Ålder: " + allSeats[personIndex].Passenger.age + " Kön: " + allSeats[personIndex].Passenger.gender);
		}
		
		public void find_age()
		{
			//Visa alla positioner med passagerare med en viss ålder
			//Man kan också söka efter åldersgränser - exempelvis 55 till 67
			//Betyg C
			//Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 149)

			System.Console.WriteLine("BussOS - " + menuOptions[5]);
			System.Console.WriteLine("---------------------------");

			System.Console.WriteLine("Ange min ålder: ");
			int lowAge = SafeInput.Integers(Console.ReadLine());

			System.Console.WriteLine("Ange max ålder: ");
			int highAge = SafeInput.Integers(Console.ReadLine());

			for (int i = 0; i < allSeats.Length; i++)
			{
				// Skriv bara ut om det finns en passagerare på platsen
				if (allSeats[i].Occupied == true)
				{
					if (allSeats[i].Passenger.age > lowAge && allSeats[i].Passenger.age < highAge)
					{
						System.Console.WriteLine("Plats: " + i + "Upptagen: " + allSeats[i].Occupied + " Ålder: " + allSeats[i].Passenger.age + " Kön: " + allSeats[i].Passenger.gender);
					}
				}
			}
		}
	
		public void sort_buss()
		{
			//Sortera bussen efter ålder. Tänk på att du inte kan ha tomma positioner "mitt i" vektorn.
			//Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 159)
			//Man ska kunna sortera vektorn med bubble sort

			// Skapa plats för temporär passagerare
			Passenger tempPassanger = null;

			// Knuffa fram alla passagerare så de sitter i så längt fram det går.
			for (int i = 0; i < allSeats.Length; i++)
			{
				for (int j = 0; j < allSeats.Length - 1; j++)
				{
					if (allSeats[j].Occupied == false && allSeats[j + 1].Occupied == true)
					{
						allSeats[j].SitDown(allSeats[j + 1].Passenger);
						allSeats[j + 1].GetUp();

					}
				}
			}

			// Bubbelsortera passagerarna
            for (int write = 0; write < allSeats.Length; write++)
            {
				for (int sort = 0; sort < allSeats.Length - 1; sort++)
      	        {
					if (allSeats[sort].Occupied == true && allSeats[sort +1].Occupied == true)
					{
						if (allSeats[sort].Passenger.age > allSeats[sort + 1].Passenger.age)
     	        		{
    	        			tempPassanger = allSeats[sort + 1].Passenger;
   	            			allSeats[sort + 1].SitDown(allSeats[sort].Passenger);
  	            			allSeats[sort].SitDown(tempPassanger);
 	            		}
					} 	
	            }            
            }

			print_buss();
			System.Console.WriteLine("");
			Console.WriteLine("Bussen har sorterats!");
            Console.ReadKey();

        }
		
		public void print_sex()
		{
			//Betyg A
			//Denna metod är nödvändigtvis inte svårare än andra metoder men kräver att man skapar en klass för passagerare.
			//Skriv ut vilka positioner som har manliga respektive kvinnliga passagerare.

			System.Console.WriteLine("BussOS - " + menuOptions[6]);
			System.Console.WriteLine("--------------------------");
			for (int i = 0; i < allSeats.Length; i++)
			{
				// Skriv bara ut om det finns en passagerare på platsen
				if (allSeats[i].Occupied == true)
				{
					System.Console.WriteLine("| Plats: " + (i + 1) + " | Kön: " + allSeats[i].Passenger.gender + " |");
				}
			}

		}	
		public void poke()
		{
			//Betyg A
			//Vilken passagerare ska vi peta på?
			//Denna metod är valfri om man vill skoja till det lite, men är också bra ur lärosynpunkt.
			//Denna metod ska anropa en passagerares metod för hur de reagerar om man petar på dom (eng: poke)
			//Som ni kan läsa i projektbeskrivningen så får detta beteende baseras på ålder och kön.


			Console.Clear();
			System.Console.WriteLine("BussOS - " + menuOptions[7]);
			System.Console.WriteLine("--------------------------");
			
			print_buss();

			System.Console.WriteLine("");
			System.Console.WriteLine("Peta på en passagerare, ange nummer mellan 1 - " + allSeats.Length);
			int nr = SafeInput.Integers(Console.ReadLine());
			if (allSeats[(nr -1)].Occupied == true)
			{
				Reaction.React(allSeats[(nr - 1)].Passenger);
			}
			else
			{
				Console.WriteLine("Ingen person i sätet.");
			}

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

			System.Console.WriteLine("BussOS - " + menuOptions[8]);
			System.Console.WriteLine("--------------------------");

			print_buss();

			System.Console.WriteLine("");
			System.Console.WriteLine("Vilken passagerare ska gå av? Ange ett platsnummer i listan: ");
			int nr = SafeInput.Integers(Console.ReadLine());

			if (allSeats[(nr - 1)].Occupied == true)
			{
				allSeats[(nr - 1)].GetUp();

				System.Console.WriteLine("Passagerare på plats " + nr + " gick av.");
			}
			else
			{
				System.Console.WriteLine("Ingen person i sätet!");
			}


		}	
	}