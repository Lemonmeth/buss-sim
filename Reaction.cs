namespace Bussen;

// Class för reakationer
public static class Reaction
{
	public static List<string> MaleReactions = new List<string>
	{
		"Aaaaaj",// 40-100år
		"Vad kan jag hjälpa dig med?", // 18-40år
		"Försvinn!!" // 1-18år
	};
	public static List<string> FemaleReactions = new List<string>
	{
		"Hjääälp!",
	    "Jag har inte tid med dig.",
		"Nej tack, jag har redan ett barnbarn"
	};
	public static void React(Passenger passenger)
	{
        
		var listOfReactions = new List<string>();

        // Kontrollera kön
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