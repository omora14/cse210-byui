public class Breath : Activity
{

    private string _intro;

    private string _name;
    private string _in;
    private string _out;
    public Breath(int timer, string initialMessage, string lastMessage, string loadingAnimation)
    : base(timer, initialMessage, lastMessage, loadingAnimation)
    {
        _in = "Breathe In...";
        _out = "breathe Out...";
        _name = "Breathing Activity";
        _intro = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";

    }




    public string startActivity()
    {
        string initialMessage = begin();
        Console.WriteLine($"{initialMessage} {_name}\n\n{_intro}\n\n");

        int time = seconds(0);
        //string loading = animationTwo();

        Console.Clear();
        Console.WriteLine("Get ready...\n\n");


        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddMilliseconds(time);
        System.Threading.Thread.Sleep(1000);
        while (DateTime.Now < endTime)
        {
            Console.Write($"{_in}");
            animationTwo();
            Console.Write("\n");
            Console.Write($"Now {_out}");
            animationTwo();
            Console.Write("\n\n");
        }



        string lastMessage = endOne("");
        Console.WriteLine(lastMessage);
        animationFour();
        Console.WriteLine($"\n\nYou have completed another {time / 1000} seconds of the {_name}.");
        animationFour();
        Console.Clear();

        return "";
    }


}