public class Eternal : Goal
{



    public Eternal(string name = "", string description = "", int points = 0, bool isComplete = false) : base(name, description, points, isComplete)
    {

    }
    public override void genericInputs()
    {
        base.genericInputs();
    }

    //public override string getName()
    //{
    //    return base.getName();
    //}
    //
    //public override string getDesc()
    //{
    //    return base.getDesc();
    //}
    //public override string getPoint()
    //{
    //    return base.getPoint();
    //}

    //public override string DisplayGoal(int index)
    //{
    //    return base.DisplayGoal(index);
    //}
    public override string DisplayGoal(int index)
    {
        string completionStatus = _isComplete ? "[ ]" : "[ ]";
        return $"{index + 1}. {completionStatus} {_name} ({_description})";
    }

    public override int markAsComplete()
    {
        return _points;
    }

    public override string serializedString()
    {
        return "Eternal:" + base.serializedString();
    }
}