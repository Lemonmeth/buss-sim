namespace Bussen;

// Class för passagerare
public class Passenger
	{

        // Håll koll på ålder
		public int age;

        // Håll koll på kön
		public string gender;

        // Construktor för passagerare-objekt
		public Passenger(int age, string gender)
		{
			this.age = age;
			this.gender = SetGender(gender);
        }

        // Metod för att endast tillåta viss input vid instansiering av passagerar-objekt
        public string SetGender(string input)
		{
            // Spara om input i små bokstaver, då resten av programmet jämför mot t.ex "male" och ej "Male".
            input = input.ToLower();
			while (true)
			{
                if (input == "male")
                {
                    return input;
                }
                else if (input == "female")
                {
                    return input;
                }
                else
				{
                    Console.WriteLine("Du kan endast välja mellan 'male' eller 'female'");
					input = SafeInput.Strings();
                }
            }
		}
	}