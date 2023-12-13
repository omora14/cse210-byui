using Microsoft.Win32.SafeHandles;

public abstract class Activity
{

    private DateTime _date;
    private int _min;
    private string _title;

    public Activity(DateTime date, int min, string title)
    {
        _date = date;
        _min = min;
        _title = title;
    }

    public abstract double distance();
    public abstract double speed();
    public abstract double pace();

    public virtual double getMin()
    {
        return _min;
    }

    public virtual string summary()
    {
        return $"{_date.ToShortDateString()} {_title} ({_min} min): Distance: {distance()} km, Speed: {speed()} kph, Pace: {pace()} min per km";
    }
}