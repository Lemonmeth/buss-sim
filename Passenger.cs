namespace Bussen;

public class Passenger
	{

		public int age;
		public string gender;

		public Passenger(int age, string gender)
		{
			this.age = age;
			this.gender = SetGender(gender);
        }


        public string SetGender(string input)
		{
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
                    Console.WriteLine("Faulty input, try again!");
					input = SafeInput.Strings(Console.ReadLine());
                }
            }
		}
	}