namespace Bussen;

class Buss
	{
		// Initiera vektor för alla säten
		Seat[] allSeats = new Seat[25];
		
		// Initiera menyalternativ
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
			// Skapa upp alla seat-objekt
			for (int i = 0; i < allSeats.Length; i++)
			{
				allSeats[i] = new Seat();
			}

			// testmetod för att fylla bussen med lite folk
			OpenDoors();

			// Initialiasera menyväljaren
			int menuSelect = 0;			

			// Menyloop
			while (true)
			{
				// Dölj markören, snyggare
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


				// Läs in tangenttryckning
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

		public void OpenDoors() // Metod att generera lite passagerare
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

		public void add_passenger() // Metod för att stiga på en passagerare
		{
			Console.Clear();
			System.Console.WriteLine("Buss OS - " + menuOptions[0]);
			System.Console.WriteLine("----------------------------");

			// Be om inmatning
			Console.WriteLine("Ange ålder: ");
			int age = SafeInput.Integers();

			Console.WriteLine("Ange kön('male' eller 'female'): ");
			string gender = SafeInput.Strings();
			
			for (int i = 0; i < allSeats.Length; i++)
			{
				// Om det finns en plats ledig i vektorn, skapa en ny passagerare
				if (allSeats[i].Occupied == false)
				{
					// Lägg till en ny passagerare
					allSeats[i].SitDown(new Passenger(age, gender));

					//Informera om vilken plats den fått
					System.Console.WriteLine("");
					System.Console.WriteLine("Passagerare fick platsen: " + (i + 1));
					break;
				}
            }

			// Kontrollera om alla säten är upptagna och informera
			bool allOccupied = true;
			foreach (var seat in allSeats)
			{
				if (seat.Occupied == false)
				{
					allOccupied = false;
                }
			}
			if (allOccupied == true)
			{
				Console.WriteLine("Inga säten lediga! Någon behöver gå av.");
			}
		}
		
		public void print_buss() // Metod för att skriva ut alla passagerare
		{
			//Skriv ut alla värden ur vektorn. Alltså - skriv ut alla passagerare
			Console.Clear();
			System.Console.WriteLine("BussOS - " + menuOptions[1]);
			System.Console.WriteLine("-----------------------------------");
			for (int i = 0; i < allSeats.Length; i++)
			{
				// Nullchecka så det finns en passagerare i sätet
				if (allSeats[i].Occupied == true)
				{
					if ((i + 1) <= 9)
					{
						// Lägg till mellan slag efter indexnummer om värdet är mindre än 10 (för att snygga till kolumnerna)
						System.Console.WriteLine("| Plats: " + (i + 1) + "  | Upptagen: " + allSeats[i].Occupied + " | Ålder: " + allSeats[i].Passenger.age + " | Kön: " + allSeats[i].Passenger.gender + " |");
					}
					else
					{
						
						System.Console.WriteLine("| Plats: " + (i + 1) + " | Upptagen: " + allSeats[i].Occupied + " | Ålder: " + allSeats[i].Passenger.age + " | Kön: " + allSeats[i].Passenger.gender + " |");
					}
				}
			}
		}
		
		public int calc_total_age(bool withText) // Metod för att beräkra total ålder för alla passagerare, möjlighet till argument i anrop
		{
			// initiera variabel för att hålla koll på total ålder
			int total = 0;
			for (int i = 0; i < allSeats.Length; i++)
			{
				if (allSeats[i].Occupied == true)
				{
					// Plussa på varje passagerares ålder på totalen
					total += allSeats[i].Passenger.age;
				}
			}

			// om true skickas med som argument i metodanropet, skriv också ut följande
			if (withText == true)
			{
				Console.Clear();
				System.Console.WriteLine("Buss OS - " + menuOptions[2]);
				System.Console.WriteLine("-----------------------------");
				System.Console.WriteLine("Den totala åldern för alla passagerare är " + total + " år.");
			}
			return total;
		}
		
		public void calc_average_age() // Metod för att beräkna snittåldern för alla passagerare
		{

			Console.Clear();
			System.Console.WriteLine("BussOS - " + menuOptions[3]);
			System.Console.WriteLine("----------------------------");

			// Initiera variabel för att antalet upptagna säten
			int seatsOccupied = 0;
			for (int i = 0; i < allSeats.Length; i++)
			{
				// Nullcheck, om sätet är upptaget - plussa på seatsOccupied
				if (allSeats[i].Occupied == true)
				{
					seatsOccupied++;
				}
			}

			// Skriv ut resultat
			System.Console.WriteLine("Den genomsnittliga åldern för alla passagerare är: " + Convert.ToDouble(calc_total_age(false) / seatsOccupied) + " år.");

		}
		
		public void max_age() // Metod för att hitta äldsta passageraren
		{
			
			// Initiera variabel för att hålla koll på högsta åldern.
			int maxAge = 0;

			// Initiera variabel för att hålla koll på aktuell person med högst ålder
			int personIndex = 0;
			for (int i = 0; i < allSeats.Length; i++)
			{
				if (allSeats[i].Occupied == true)
				{
					// Om passageraren har högre ålder än tidigare passagerar-ålder satt i maxAge, ersätt maxAge med ny högre ålder
					if (allSeats[i].Passenger.age > maxAge)
					{
						maxAge = allSeats[i].Passenger.age;

						// Uppdatera personIndex när loopen hittar ny person med högre ålder
						personIndex = i;
					}
				}
			}

			Console.Clear();
			System.Console.WriteLine("BussOS - " + menuOptions[4]);
			System.Console.WriteLine("-------------------------------------");

			// Skriv ut resultatet
			Console.WriteLine("Äldsta passageraren är passagerare nr: " + (personIndex + 1) + " Ålder: " + allSeats[personIndex].Passenger.age + " Kön: " + allSeats[personIndex].Passenger.gender);
		}
		
		public void find_age() // Metod för att hitta passagerare i åldersspann
		{
			System.Console.WriteLine("BussOS - " + menuOptions[5]);
			System.Console.WriteLine("---------------------------");

			// Be om inmatning
			System.Console.WriteLine("Ange min ålder: ");
			int lowAge = SafeInput.Integers();

			System.Console.WriteLine("Ange max ålder: ");
			int highAge = SafeInput.Integers();

			for (int i = 0; i < allSeats.Length; i++)
			{
				// Nullcheck, skriv bara ut om det finns en passagerare på platsen
				if (allSeats[i].Occupied == true)
				{
					// Skriv endast ut om passagerarens ålder befinner sig i angivet spann
					if (allSeats[i].Passenger.age > lowAge && allSeats[i].Passenger.age < highAge)
					{
						System.Console.WriteLine("Plats: " + i + "Upptagen: " + allSeats[i].Occupied + " Ålder: " + allSeats[i].Passenger.age + " Kön: " + allSeats[i].Passenger.gender);
					}
				}
			}
		}
	
		public void sort_buss() // Metod för att bubbelsortera bussen
		{
			// Initiera variabel för temporär passagerare
			Passenger tempPassanger;

			// Knuffa fram alla passagerare så de sitter i så längt fram det går.
			front_passengers();

			// Bubbelsortera passagerarna
            for (int write = 0; write < allSeats.Length; write++)
            {
				for (int sort = 0; sort < allSeats.Length - 1; sort++)
      	        {
					// Nullcheck, utför endast flytt om det finns en passagerare i båda sätena
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
		
		public void front_passengers() // Metod för att knuffa fram alla passagerare i främre delen av bussen
		{
			// Knuffa fram alla passagerare
			for (int i = 0; i < allSeats.Length; i++)
			{
				for (int j = 0; j < allSeats.Length - 1; j++)
				{
					// Om ett säte är fritt och sätet bakom är upptaget, flytta fram passagerare
					if (allSeats[j].Occupied == false && allSeats[j + 1].Occupied == true)
					{
						allSeats[j].SitDown(allSeats[j + 1].Passenger);
						allSeats[j + 1].GetUp();
					}
				}
			}
		}
		
		public void print_sex() // Metod för att skriva ut passagerarnas kön
		{
			System.Console.WriteLine("BussOS - " + menuOptions[6]);
			System.Console.WriteLine("--------------------------");

			for (int i = 0; i < allSeats.Length; i++)
			{
				// Nullchec, skriv bara ut om det finns en passagerare på platsen
				if (allSeats[i].Occupied == true)
				{
					System.Console.WriteLine("| Plats: " + (i + 1) + " | Kön: " + allSeats[i].Passenger.gender + " |");
				}
			}

		}	
		
		public void poke() // Metod för att peta på en passagerare
		{
			Console.Clear();
			System.Console.WriteLine("BussOS - " + menuOptions[7]);
			System.Console.WriteLine("--------------------------");
			
			// Skriv ut passagerarna
			print_buss();

			// Be om inmatning
			System.Console.WriteLine("");
			System.Console.WriteLine("Peta på en passagerare, ange nummer mellan 1 - " + allSeats.Length);
			int nr = SafeInput.Integers();

			// Nullcheck, passagerare reagerar om det finns en passagerare i sätet
			if (allSeats[(nr -1)].Occupied == true)
			{
				// Anropa reaktions-metod och skicka in vald passagerare som argument
				Reaction.React(allSeats[(nr - 1)].Passenger);
			}
			else
			{
				Console.WriteLine("Ingen person i sätet.");
			}
		}	
		
		public void getting_off() // Metod för att stiga av en passagerare
		{
			System.Console.WriteLine("BussOS - " + menuOptions[8]);
			System.Console.WriteLine("--------------------------");

			// Skriv ut alla passagerare
			print_buss();

			// Be om inmatning
			System.Console.WriteLine("");
			System.Console.WriteLine("Vilken passagerare ska gå av? Ange ett platsnummer i listan: ");
			int nr = SafeInput.Integers();

			// Nullcheck, om sätet är uppaget - stig av passageraren
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