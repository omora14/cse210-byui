using System.Runtime.CompilerServices;

public class Reflection : Activity
{

    private string _intro;

    private string _name;
    private string _promptR;

    private List<string> picked = new List<string>();


    public Reflection(int timer, string initialMessage, string lastMessage, string loadingAnimation)
    : base(timer, initialMessage, lastMessage, loadingAnimation)
    {
        _name = "Reflection Activity";
        _intro = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _promptR = randomPrompt();

    }
    public string randomPrompt()
    {
        string _thePath = @"txtfiles\";
        string filename = "reflectionP.txt";
        string file = Path.Combine(_thePath, filename);
        string[] lines = File.ReadAllLines(file);
        Random random = new Random();
        int randomIndex = random.Next(0, lines.Length);
        string selectedP = lines[randomIndex];
        return selectedP;
    }

    public string questions()
    {
        string _thePath = @"txtfiles\";
        string filename = "reflectionQ.txt";
        string file = Path.Combine(_thePath, filename);
        string[] lines = File.ReadAllLines(file);
        //List<string> picked = new List<string>();
        Random random = new Random();
        int randomIndex;
        do
        {

            randomIndex = random.Next(0, lines.Length);
        }
        while (picked.Contains(lines[randomIndex]));
        string selectedQ = lines[randomIndex];
        picked.Add(selectedQ);
        if (picked.Count == lines.Length)
        {
            picked.Clear();
        }
        return selectedQ;
    }

    public string startActivity()
    {
        string initialMessage = begin();
        Console.WriteLine($"{initialMessage} {_name}\n\n{_intro}\n\n");

        int time = seconds(0);
        //string loading = animationTwo();

        Console.Clear();
        Console.WriteLine("Get ready...\n\n");



        System.Threading.Thread.Sleep(1000);
        Console.Write($"Consider the following prompt:\n---{_promptR}---");
        Console.Write("\n\nWhen You have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Write("\nNow ponder on each of the following questions as they realated to this experience.\nYou may begin in: ");
        animationTwo();
        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddMilliseconds(time);
        while (DateTime.Now < endTime)
        {
            Console.Write($"> {questions()} ");
            animationFour();
            Console.Write("\n\n");
        }


        // Display the last message
        string lastMessage = endOne("");
        Console.WriteLine(lastMessage);
        animationFour();
        Console.WriteLine($"\n\nYou have completed another {time / 1000} seconds of the {_name}.");
        animationFour();
        Console.Clear();

        return "";
    }









}