using System.Drawing;
using System.Threading.Channels;

public class Checklist : Goal
{

    protected int _bonus;
    protected int _bonusCounter;
    protected int _timesDone;


    public Checklist(string name = "", string description = "", int points = 0, bool isComplete = false, int bonusCounter = 0, int bonus = 0, int timesDone = 0) : base(name, description, points, isComplete)
    {
        _bonus = bonus;
        _bonusCounter = bonusCounter;
        _timesDone = timesDone;
    }


    public override void genericInputs()
    {
        base.genericInputs();

        Console.Write("How many times does this goal need to be accomplised for a bonus? ");
        string convert2BN = Console.ReadLine();
        _bonusCounter = int.TryParse(convert2BN, out int counter) ? counter : 0;

        Console.Write("What is the bonus for accomplishing it that many times? ");
        string convert2B = Console.ReadLine();
        _bonus = int.TryParse(convert2B, out int bonus) ? bonus : 0;
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

    //public int getBonus()
    //{
    //    Console.Write("What is the bonus for accomplishing it that many times? ");
    //    _bonus = Console.Read();
    //    return _bonus;
    //}
    //public int BonusCounter()
    //{
    //    Console.Write("How many times does this goal need to be accomplised for a bonus? ");
    //    _bonusCounter = Console.Read();
    //    return _bonusCounter;
    //}

    public override int markAsComplete()
    {
        if (_timesDone < _bonusCounter)
        {
            _timesDone++;
            if (_timesDone == _bonusCounter)
            {
                _isComplete = true;
                return _points + _bonus;
            }
            return _points;
        }
        else if (_timesDone == _bonusCounter && _isComplete)
        {
            return _points + _bonus;
        }
        else
        {
            return 0;
        }
    }

    public override string DisplayGoal(int index)
    {
        return $"{base.DisplayGoal(index)} -- Currently completed: {_timesDone}/{_bonusCounter}";
    }

    public override string serializedString()
    {
        string baseSerial = base.serializedString();
        return $"Checklist:{baseSerial}|{_bonusCounter}|{_timesDone}|{_bonus}";
    }

}