//OG = Outdoor Gatherings
using System.Diagnostics;

public class OG : Event
{

    private string _weather;

    public OG(string title, string descrip, string date, string time, Address address, string weather) : base(title, descrip, date, time, address)
    {
        _weather = weather;
    }

    public override string detailedInfo()
    {
        return base.detailedInfo() + $"\nType: Lecture:\nWeather Forecast: {_weather}";
    }

    public override string shortDescription()
    {
        return $"Type: Outdoor Gathering\n" + base.shortDescription();
    }



}