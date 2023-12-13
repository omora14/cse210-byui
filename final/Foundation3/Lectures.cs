public class Lectures : Event
{
    //have a speaker and limited capacity

    private string _speaker;
    private int _capacity;


    public Lectures(string title, string descrip, string date, string time, Address address, string speaker, int capacity) : base(title, descrip, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public override string detailedInfo()
    {
        return base.detailedInfo() + $"\nType: Lecture:\nSpeakerL: {_speaker}\nCapacity: {_capacity}";
    }

    public override string shortDescription()
    {
        return $"Type: Lecture\nT" + base.shortDescription();
    }
}