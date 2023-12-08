public class Event
{
    private string _title;

    private string _descrip;
    private DateTime _date;
    private DateTime _time;
    private Address _address;

    public Event(string title, string descrip, DateTime date, DateTime time, Address address)
    {
        _title = title;
        _descrip = descrip;
        _date = date;
        _time = time;
        _address = address;
    }


    public virtual string TDDTA()
    {
        return $"Title: {_title}\nDescription: {_descrip}\nDate: {_date}\nTime: {_time}\nAddress: {_address}";
    }



}