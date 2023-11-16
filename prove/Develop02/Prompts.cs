using System;
using System.Collections.Generic;

public class Prompts
{

    List<string> questionList;
    Random random;


    public Prompts()

    {
        questionList = new List<string>
        {
            "If I had one thing I could do over today, what would it be?",
            "Having a good day? Tell me about it!",
            "Have you finish your duties? How was that day of yours?",
            "Let's add an entry to the journal!",
            "What are you grateful for today?",
            "What was your favorite part of the day?",
            "This program was challenging to code, what was your hardest part of the day today?",
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?"

        };

        random = new Random();
    }
    public string blindQuestion()
    {
        int selected = random.Next(questionList.Count);
        return questionList[selected];
    }


}