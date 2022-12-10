namespace Bussen;

public class Seat
{
	public bool Occupied { get; private set; }
	public Passenger Passenger { get; private set; }
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