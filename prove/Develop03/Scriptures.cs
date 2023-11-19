using System.Text;

public class Scripture
{

    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private List<int> _hidingIndices = new List<int>(); //tracks hidden words
    private Random _random = new Random();

    //setter
    public Scripture(Reference reference, List<Word> words)
    {
        _reference = reference;
        _words = words;
    }


    //methods


    public void HideLastThreeWords()
    {
        Random random = new Random();
        //loops 3 times
        for (int indexNumber = 0; indexNumber < 3; indexNumber++)
        {
            int randomIndexNumber;
            do
            {//gets a random index
                randomIndexNumber = random.Next(0, _words.Count);
            } while (_hidingIndices.Contains(randomIndexNumber)); 

            _hidingIndices.Add(randomIndexNumber); //added to hidingIndices list
            _words[randomIndexNumber].Hide(); //hiding the words
        }
    }
    public void hiding(List<int> alreadyHiddenIndices)
    {
        List<int> availableIndices = _words
            .Select((word, index) => new { Word = word, Index = index }) //selects a new object
            .Where(item => !item.Word.IsHidden() && !alreadyHiddenIndices.Contains(item.Index))
            .Select(item => item.Index) //selects indices
            .ToList(); //converts to a list


        int hideCount = Math.Min(3, availableIndices.Count); //words to hide

        for (int counter = 0; counter < hideCount; counter++) //loop to hide words
        {
            int randomIndex = _random.Next(availableIndices.Count); //generates a random index
            _words[availableIndices[randomIndex]].Hide(); //hides our lucky generated index
            alreadyHiddenIndices.Add(availableIndices[randomIndex]); //we add it to the "hidden" list
            availableIndices.RemoveAt(randomIndex); //and make sure not to repeat that index by removing it form the rest
        }
    }



    public bool AllWordsHidden()
    {
        return _words.TrueForAll(word => word.IsHidden()); 
    }

    public string getRenderedText()
    {

        //used to efficiently concatenate strings in situations where you're doing a lot of string manipulations.
        //I must study it more

        StringBuilder renderedText = new StringBuilder();

        renderedText.Append($"{_reference.gettingBook()} {_reference.gettingChapter()}:{_reference.gettingInitialVerse()}-{_reference.gettingFinalVerse()} ");

        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                renderedText.Append(new string('_', word.GetText().Length) + " ");
                //if hidden, display it with _
            }
            else
            {
                renderedText.Append($"{word.GetText()} ");
                //if not, use the word
            }
        }

        return renderedText.ToString().Trim();
        //// Convert StringBuilder to string and trim trailing whitespace
    }
}