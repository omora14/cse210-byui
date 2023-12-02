using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

public class UserInterface
{
    List<Goal> goals = new List<Goal>();
    LDS lds = new LDS();
    protected int totalPoints = 0;
    public void Menu()
    {
        string option = "";
        while (option != "7")
        {
            Console.WriteLine($"\nYou have {totalPoints} points\n");
            Console.Write("Menu Options:\n  1.Create New Goal\n  2.List Goals\n  3.Save Goals\n  4.Load Goals\n  5.Record Event\n  6.Delete Goal\n  7.Quit\nSelect a choice from the menu: ");
            option = Console.ReadLine();
            Console.Clear();
            if (option == "1")
            {
                Simple simple = new Simple();
                Eternal eternal = new Eternal();
                Checklist checklist = new Checklist();

                Console.Write("The types of goals are:\n  1.Simple Goal\n  2.Eternal Goal\n  3.Checklist Goal\nWhich type of goal would you like to create? ");
                string goalPicker = Console.ReadLine();
                //Goal goal = null;
                if (goalPicker == "1")
                {
                    simple.genericInputs();
                    goals.Add(simple);
                    //string nameS = simple.getName();
                    //string descriptionS = simple.getDesc();
                    //string pointsS = simple.getPoint();
                    //int points = int.Parse(pointsS);
                    //goal = new Goal(nameS, descriptionS, points, false);
                }
                else if (goalPicker == "2")
                {
                    eternal.genericInputs();
                    goals.Add(eternal);
                    //string nameE = eternal.getName();
                    //string descriptionE = eternal.getDesc();
                    //string pointsE = eternal.getPoint();
                    //int points = int.Parse(pointsE);
                    //goal = new Goal(nameE, descriptionE, points, false);
                }
                else if (goalPicker == "3")
                {
                    checklist.genericInputs();
                    goals.Add(checklist);
                    //string nameC = checklist.getName();
                    //string descriptionC = checklist.getDesc();
                    //string pointsC = checklist.getPoint();
                    //int points = int.Parse(pointsC);
                    //int bonusC = checklist.getBonus();
                    //int bonus = checklist.BonusCounter();
                    //goal = new Goal(nameC, descriptionC, points, false);
                }
                else
                {
                    Console.WriteLine("We haven't implement that option but maybe in the future!\nPlease, try again!");
                    continue;
                }
                Console.Write("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
            }
            else if (option == "2")
            {
                lds.displayer(goals);
                Console.Write("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
            }
            else if (option == "3")
            {
                Console.Write("ATTENTION!\nSaving to a file without LOADING IT first, will OVERWRITE your goals.\nPlease make sure to load your file first.\nPress 1 to continue to save or 2 to go back to the menu: ");
                string ready = Console.ReadLine();
                Console.Clear();
                if (ready == "1")
                {
                    lds.saver(goals, totalPoints, "goals.txt");
                    Console.Write("File saved successfully!\nPress enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (ready == "2")
                {
                    continue;
                }
                else
                {
                    Console.Write("Invalid option!\nPress enter to go back to the menu\n");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            else if (option == "4")
            {
                LDS lds = new LDS();
                (totalPoints, List<Goal> loadedGoals) = lds.loader("");
                goals = loadedGoals;
                Console.Write("File loaded successfully!\nPress enter to continue");
                Console.ReadLine();
                Console.Clear();
            }
            else if (option == "5")
            {
                lds.displayer(goals);
                Console.Write("What goal did you achieve? ");
                if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex >= 1 && goalIndex <= goals.Count)
                {
                    Goal selectedGoal = goals[goalIndex - 1];
                    if (!selectedGoal.IsComplete())
                    {
                        int pointsAdded = selectedGoal.markAsComplete();
                        totalPoints += pointsAdded;
                        Console.WriteLine($"Congratulations! You have earned {pointsAdded} points\nNow you have {pointsAdded} points");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Write("This goals was already completed\nPress enter to go back to the menu");
                        Console.ReadLine();

                    }
                }
                else
                {
                    Console.WriteLine("Whoops! Looks like that is not a goal... yet");
                }
                Console.Clear();
            }
            else if (option == "6")
            {
                Console.Write("Warning!\nDeleting a goal will cost you 50 points, do you want to proceed?\nPress 1 to continue or 2 to go back to the menu: ");
                string ready1 = Console.ReadLine();
                Console.Clear();
                if (ready1 == "1")
                {
                    lds.displayer(goals);
                    Console.Write("Enter the index of the goal you want to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int goalIndexToDelete))
                    {
                        lds.deleting(goals, goalIndexToDelete, ref totalPoints);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid goal index.");
                    }
                    Console.Write("Press Enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (ready1 == "2")
                {
                    continue;
                }
                else
                {
                    Console.Write("Invalid option!\nPress enter to go back to the menu\n");
                    Console.ReadLine();
                    Console.Clear();
                }

            }
            else if (option == "7")
            {
                Console.WriteLine("Good bye!");
                break;
            }
            else
            {
                Console.WriteLine("Whoops! Loos Like that is not an option!\nTry again!");
                continue;
            }


        }

    }
}