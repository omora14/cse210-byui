using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
//LDS stands for Loader, Displayer and Saver... at least this time (yeah, thought it would be funny)
public class LDS
{
    private string _filename = "";
    private string _folderPath = @"goalsfolder";



    public (int totalPoints, List<Goal>) loader(string filename)


    {
        List<Goal> loadedGoals = new List<Goal>();
        int loadedTotalPoints = 0;

        Console.Write("What is the filename for the goal file? ");
        _filename = Console.ReadLine();
        string fullPath = Path.Combine(_folderPath, _filename);

        if (File.Exists(fullPath))
        {
            using (StreamReader reader = new StreamReader(fullPath))
            {
                if (int.TryParse(reader.ReadLine(), out loadedTotalPoints))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Goal goal = reconstructGoal(line);
                        if (goal != null)
                        {
                            loadedGoals.Add(goal);
                        }
                    }
                }
            }
        }
        else
        {
            Console.Write("File does not exist or invalid path!\nPress enter to continue");
            Console.ReadLine();
        }
        return (loadedTotalPoints, loadedGoals);
    }

    private Goal reconstructGoal(string serializedData)
    {
        string[] parts = serializedData.Split(':');
        if (parts.Length >= 2)
        {
            string[] typeDetails = parts[1].Split('|');
            if (typeDetails.Length >= 4)
            {
                string type = parts[0];
                string name = typeDetails[0];
                string description = typeDetails[1];
                int points = int.Parse(typeDetails[2]);
                bool isComplete = bool.Parse(typeDetails[3]);

                switch (type)
                {
                    case "Checklist":
                        if (typeDetails.Length >= 7)
                        {
                            int bonusCounter = int.Parse(typeDetails[4]);
                            int timesDone = int.Parse(typeDetails[5]);
                            int bonus = int.Parse(typeDetails[6]);
                            return new Checklist(name, description, points, isComplete, bonusCounter, bonus, timesDone);
                        }
                        break;

                    case "Simple":
                        return new Simple(name, description, points, isComplete);

                    case "Eternal":

                        return new Eternal(name, description, points, isComplete);


                    default:
                        break;
                }
            }
        }
        return null;
    }

    public void displayer(List<Goal> goals)
    {
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < goals.Count; index++)
            {

                string toPrint = goals[index].DisplayGoal(index);
                stringBuilder.AppendLine(toPrint);
            }
            Console.WriteLine("The goals are:");
            Console.WriteLine(stringBuilder);
        }
    }

    public void saver(List<Goal> goals, int totalPoints, string filename)
    {
        Console.Write("What is the filename for the goal file? ");
        _filename = Console.ReadLine();
        string fullPath = Path.Combine(_folderPath, _filename);

        using (StreamWriter streamWriter = new StreamWriter(fullPath))
        {
            streamWriter.WriteLine(totalPoints);
            foreach (Goal goal in goals)
            {
                string serializedGoal;
                if (goal is Checklist checklist)
                {
                    serializedGoal = checklist.serializedString();
                }
                else if (goal is Simple simple)
                {
                    serializedGoal = simple.serializedString();
                }
                else if (goal is Eternal eternal)
                {
                    serializedGoal = eternal.serializedString();
                }
                else
                {
                    serializedGoal = goal.serializedString();
                }
                streamWriter.WriteLine(serializedGoal);
            }
        }


    }


    //xxxxxxxxxxxxxxxxxxxxxxxx EXTRA xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx


    public void deleting(List<Goal> goals, int goalIndex, ref int totalPoints)
    {
        if (goalIndex >= 1 && goalIndex <= goals.Count)
        {
            Goal selectedGoal = goals[goalIndex - 1];
            Console.WriteLine($"Warning! Deleting goal number {goalIndex} will cost you 50 points.");

            Console.Write("Press 1 to confirm and delete or any other key to cancel: ");
            string confirmDelete = Console.ReadLine();

            if (confirmDelete == "1")
            {
                totalPoints -= 50;
                goals.RemoveAt(goalIndex - 1);
                Console.WriteLine($"Goal number {goalIndex} has been deleted. 50 points deducted.");
            }
            else
            {
                Console.WriteLine("Deletion canceled.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index provided.");
        }
    }
}