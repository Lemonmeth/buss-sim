namespace Bussen;

// Class för reakationer
public static class Reaction
{
	// Skapa lista med reaktioner för male
	public static List<string> MaleReactions = new List<string>
	{
		"Aaaaaj",// 1-18 år
		"Vad kan jag hjälpa dig med?", // 18-40år
		"Försvinn!!" // 40 uppåt
	};

	// Skapa lista med reaktioner för female
	public static List<string> FemaleReactions = new List<string>
	{
		"Hjääälp!", // 1-18 år
	    "Jag har inte tid med dig.", // 18-40år
		"Jag har redan ett barnbarn" // 40 uppåt
	};

	// Metod för att reagera, kräver passagerar-objekt som argument i anrop
	public static void React(Passenger passenger)
	{
		// temporär lista för reaktioner
		var listOfReactions = new List<string>();

        // Kontrollera kön, om könet är male - spara malereactions i listofreactions
		if (passenger.gender == "male")
		{
			listOfReactions = MaleReactions;
        }
        if (passenger.gender == "female")
        {
            listOfReactions = FemaleReactions;
        }

        // Reagera baserat på ålder
        if (passenger.age <= 18)
        {
			System.Console.WriteLine("Passageraren säger:");
            Console.WriteLine(listOfReactions[0]);
			System.Console.WriteLine("");
        }
		if (passenger.age > 18 && passenger.age <= 40)
		{
			System.Console.WriteLine("Passageraren säger:");
			Console.WriteLine(listOfReactions[1]);
			System.Console.WriteLine("");
		}
		if (passenger.age > 40)
		{
			System.Console.WriteLine("Passageraren säger:");
			Console.WriteLine(listOfReactions[2]);
			System.Console.WriteLine("");
		}
    }
}