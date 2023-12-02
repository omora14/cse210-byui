using System.Text;

public class Goal
{

    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;


    public Goal(string name, string description, int points, bool isComplete)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = isComplete;
    }

    //public virtual string getName()
    //{
    //    Console.Write("What is the name of your goal? ");
    //    return Console.ReadLine();
    //}
    //
    //public virtual string getDesc()
    //{
    //    Console.Write("What is a short description of it? ");
    //    return Console.ReadLine();
    //}
    //
    //public virtual string getPoint()
    //{
    //    Console.Write("What is the amount of point associated with this goal? ");
    //    return Console.ReadLine();
    //}

    //public string getCompleted(string _isComplete)
    //{
    //    return _isComplete;
    //}
    public virtual void genericInputs()
    {
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of point associated with this goal? ");
        string convertThis = Console.ReadLine();
        _points = int.TryParse(convertThis, out int points) ? points : 0;
    }

    public virtual string DisplayGoal(int index)
    {
        bool completed = IsComplete();
        string completionStatus = completed ? "[X]" : "[ ]";

        return $"{index + 1}. {completionStatus} {_name} ({_description})";
    }

    public virtual bool IsComplete()
    {
        return _isComplete;
    }
    public int getPoints()
    {
        return _points;
    }
    public virtual int markAsComplete()
    {
        _isComplete = true;
        return _points;
    }


    public void recordEvent()
    {
        return;
    }

    public virtual string serializedData(List<Goal> goals)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var goal in goals)
        {
            stringBuilder.AppendLine(goal.serializedString());

        }
        return stringBuilder.ToString();
    }
    public virtual string serializedString()
    {
        string isCompleteString = _isComplete ? "True" : "False";
        return $"{_name}|{_description}|{_points}|{isCompleteString}";
    }

}