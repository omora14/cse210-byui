using System;

class Program
{
    static void Main(string[] args)
    {
        string starter = "quit";
        while (starter == "quit")
        {
            Activity activity = new Activity(0, "", "", "");
            Console.Write("Menu Options:\n  1.Start breathing Activity\n  2.Start reflecting Activity\n  3.Start listing activity\n  4.Quit\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.Clear();
            //string loadingAnimation = activity.loader();

            if (choice == "1")
            {
                Breath breath = new Breath(0, "Welcome to the", activity.endOne(""), "loadingAnimation");
                Console.WriteLine(breath.startActivity());
            }
            else if (choice == "2")
            {
                Reflection reflection = new Reflection(0, "Welcome to the ", activity.endOne(""), "loadingAnimation");
                Console.WriteLine(reflection.startActivity());
            }
            else if (choice == "3")
            {
                Listing listing = new Listing(0, "Welcome to the ", activity.endOne(""), "loadingAnimation");
                Console.WriteLine(listing.startActivity());
            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                continue;
            }

        }
    }
}