public class Receptions : Event
{
    private string _rsvp;
    public Receptions(string title, string descrip, string date, string time, Address address, string rsvp) : base(title, descrip, date, time, address)
    {
        _rsvp = rsvp;

    }

    public override string detailedInfo()
    {
        return base.detailedInfo() + $"Type: Reception\nRSVP: {_rsvp}";
    }

    public override string shortDescription()
    {
        return $"Type: Reception\n" + base.shortDescription();
    }


}