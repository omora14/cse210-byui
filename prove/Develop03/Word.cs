public class Word
{

    private string _word;
    private bool _hidden;

    //setter
    public Word(string word)
    {
        _word = word;
        _hidden = false;
    }

    //methods
    public void Hide()
    {
        _hidden = true; //word is hidden
    }
    public bool IsHidden()
    {
        return _hidden;// returns it hidden
    }
    public string GetText()
    {
        return _hidden ? new string('_', _word.Length) : _word;// how text will be shown
    }

}