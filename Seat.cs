namespace Bussen;

// Class för passagerarsäte
public class Seat
{
	// Håll koll på om sätet är upptaget. Får endast sättas via metoder nedan men kan hämtas/läsas publikt
	public bool Occupied { get; private set; }

	// Plats för passagerare. Får endast sättas via metoder nedan men kan hämtas/läsas publikt
	public Passenger Passenger { get; private set; }

	// Metoder för att instansiera eller ta bort passagerarobjekt i sätesobjektet och markera sätet som upptaget eller ledigt
	public void SitDown(Passenger newPassanger)
	{
		Occupied = true;
		Passenger = newPassanger;
	}
	public void GetUp()
	{
		Occupied = false;
		Passenger = null;
	}
}