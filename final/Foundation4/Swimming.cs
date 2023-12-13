public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int min, int laps, string title) : base(date, min, title)
    {
        _laps = laps;
    }

    public override double distance()
    {
        return Math.Round(_laps * 50 / 1000.0, 2);
    }

    public override double speed()
    {
        return Math.Round((distance() / (getMin() / 60)), 2);
    }

    public override double pace()
    {
        return Math.Round((getMin() / 60) / distance(), 2);
    }
}