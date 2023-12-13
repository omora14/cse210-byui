public class Running : Activity
{
    private double _distance;
    public Running(DateTime date, int min, double distance, string title) : base(date, min, title)
    {
        _distance = distance;
    }

    public override double distance()
    {
        return _distance;
    }
    public override double speed()
    {
        return Math.Round((_distance / getMin()) * 60, 2);
    }

    public override double pace()
    {
        return Math.Round(getMin() / _distance, 2);
    }
}