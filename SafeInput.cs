namespace Bussen;

public class SafeInput
{
	static public string Strings(string text)
	{
		if (String.IsNullOrWhiteSpace(text) == false)
		{
			return text;
		}
		else
		{
			System.Console.WriteLine("Felaktig inmatning, försök igen: ");
			return Strings(Console.ReadLine());
		}
	}

	static public int Integers(string strNumber)
	{
		if (int.TryParse(strNumber, out int okNumber) == true)
		{
			return okNumber;
		}
		else
		{
			System.Console.WriteLine("Felaktig inmatning, försök igen: ");
			return Integers(Console.ReadLine());
		}
	}
}