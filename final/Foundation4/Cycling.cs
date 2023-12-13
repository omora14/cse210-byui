public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int min, double speed, string title) : base(date, min, title)
    {
        _speed = speed;
    }

    public override double distance()
    {
        return Math.Round(_speed * (getMin() / 60), 2);
    }

    public override double speed()
    {
        return _speed;
    }

    public override double pace()
    {
        return Math.Round(getMin() / _speed, 2);
    }

}