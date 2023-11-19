public class Reference
{


    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    //setter
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    //Methods - Sharing the data "part" of the scripture by returning the value
    public string gettingBook()
    {
        return _book;
    }
    public int gettingChapter()
    {
        return _chapter;
    }
    public int gettingInitialVerse()
    {
        return _verseStart;
    }
    public int gettingFinalVerse()
    {
        return _verseEnd;
    }



}