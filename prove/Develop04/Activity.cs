public class Activity
{

    private int _timer;
    private string _initialMessage;
    private string _lastMessage;
    private string _loadingAnimation;


    public Activity(int timer, string initialMessage, string lastMessage, string loadingAnimation)
    {
        _timer = timer;
        _initialMessage = initialMessage;
        _lastMessage = lastMessage;
        _loadingAnimation = loadingAnimation;
    }

    public string endOne(string lastMessage)
    {
        Random random = new Random();
        lastMessage = "";
        List<string> randomEndings = new List<string>() { "Well Done!!", "Good Job", "Yes! You got it!", "Good! Have a nice day!", "How about keep trying a different activuty?" };
        int randomIndex = random.Next(randomEndings.Count);
        lastMessage = randomEndings[randomIndex];
        return lastMessage;
    }

    public int seconds(int timer)
    {
        Console.Write("How long (in seconds) would you like for your session? ");
        string counting1 = Console.ReadLine();
        int counting = int.Parse(counting1);
        timer = counting * 1000;

        Console.Clear();
        Console.WriteLine("Get ready!!");
        Console.WriteLine(animationFour());
        return timer;
    }

    //
    public string begin()
    {

        return _initialMessage;
    }



 
    public string animationTwo()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(5);
        while (DateTime.Now < endTime)
        {
            for (int i = 5; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }

        }
        return "";
    }

    public string animationFour()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(5);
        List<string> clock = new List<string> { "|", "/", "-", "\\", "|", "/", "-", "\\" };

        while (DateTime.Now < endTime)
        {
            foreach (string s in clock)
            {
                Console.Write(s);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
        return "";
    }

}