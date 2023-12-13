public class Event
{
    protected string _title;

    private string _descrip;
    protected string _date;
    private string _time;
    private Address _address;

    public Event(string title, string descrip, string date, string time, Address address)
    {
        _title = title;
        _descrip = descrip;
        _date = date;
        _time = time;
        _address = address;
    }

    //TDDTA = Title, description, Date, Time, Address 
    public string TDDTA()//standard
    {
        return $"Title: {_title}\nDescription: {_descrip}\nDate: {_date}\nTime: {_time}\nAddress: " + _address.fullAddress();
    }

    public virtual string detailedInfo()
    {
        return TDDTA();
    }


    public virtual string shortDescription()
    {
        return $"Title: {_title}\nDate: {_date}";
    }

}