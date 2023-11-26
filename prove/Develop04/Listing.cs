using System.Diagnostics;

public class Listing : Activity
{

    private string _intro;

    private string _name;
    private List<string> promptsL = new List<string>();
    private string _prompt;


    public Listing(int timer, string initialMessage, string lastMessage, string loadingAnimation)
    : base(timer, initialMessage, lastMessage, loadingAnimation)
    {
        _name = "Listing Activity";
        _intro = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _prompt = randomPrompt();
    }

    public string randomPrompt()
    {
        string _thePath = @"txtfiles\";
        string filename = "listingP.txt";
        string file = Path.Combine(_thePath, filename);
        string[] lines = File.ReadAllLines(file);
        Random random = new Random();
        int randomIndex = random.Next(0, lines.Length);
        string selectedP = lines[randomIndex];
        return selectedP;
    }




    public string startActivity()
    {

        string initialMessage = begin();
        Console.WriteLine($"{initialMessage} {_name}\n\n{_intro}\n\n");
        int time = seconds(0);
        Console.Clear();
        
        Console.WriteLine("Get ready...\n\n");

        System.Threading.Thread.Sleep(1000);
        Console.Write($"List as many responses you can to the following prompt:\n---{_prompt}---");
        Console.Write("\nYou may begin in: ");
        animationTwo();
        Console.WriteLine("\n");
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddMilliseconds(time);
     
        int counter = 0;
        string response;

        while (DateTime.Now < endTime)
        {
            Console.Write($"> ");
            response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                counter += 1;
            }
        }
        Console.WriteLine($"You have listed {counter} items!\n");
        animationFour();
    
        string lastMessage = endOne("");
        Console.WriteLine(lastMessage);
        animationFour();
        Console.WriteLine($"\n\nYou have completed another {time / 1000} seconds of the {_name}.");
        animationFour();
        Console.Clear();

        return "";
    }
}