namespace Bussen;

// Class för säker inmatning och felhantering
public class SafeInput
{
	static public string Strings() // Metod för säker inmatning av strings
	{
		Console.CursorVisible = true;
		string text = Console.ReadLine();

		// Kontrollera om text innehåller null eller whitepace
		if (String.IsNullOrWhiteSpace(text) == false)
		{
			return text;
		}
		else
		{
			System.Console.WriteLine("Felaktig inmatning, försök igen: ");
			return Strings();
		}
	}

	static public string Strings(string text) // Overflow-metod för säker inmatning av strings, med input-parameter
	{
		// Kontrollera om text innehåller null eller whitepace
		if (String.IsNullOrWhiteSpace(text) == false)
		{
			return text;
		}
		else
		{
			System.Console.WriteLine("Felaktig inmatning, försök igen: ");

			// Testar rekursion, hoppar till första strings-medoten där den ber om ny inmatning.
			return Strings();
		}
	}

	static public int Integers() // Metod för säker inmatning av integers
	{
		string strNumber = Console.ReadLine();

		// Om det går att parsa input till helta, skapa ny variabel med heltalet och returnera den
		if (int.TryParse(strNumber, out int okNumber) == true)
		{
			return okNumber;
		}
		else
		{
			System.Console.WriteLine("Felaktig inmatning, försök igen: ");
			return Integers();
		}
	}

	static public int Integers(string strNumber) // Overflow-metod för säker inmatning av integers, med input-parameter
	{
		// Om det går att parsa input till helta, skapa ny variabel med heltalet och returnera den
		if (int.TryParse(strNumber, out int okNumber) == true)
		{
			return okNumber;
		}
		else
		{
			System.Console.WriteLine("Felaktig inmatning, försök igen: ");

			// Testar rekursion, hoppar till första integers-medoten där den ber om ny inmatning.
			return Integers();
		}
	}
}