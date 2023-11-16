using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        string starter = "-1";
        Journal onProcess = new Journal();
        while (starter != "6")
        {
            Entry infoEntered = new Entry();
            Prompts thePrompt = new Prompts();


            Console.Write("\nPlease select one of the following choices:\n1.Write\n2.Display\n3.Load\n4.Save\n5.Delete Entry\n6.Quit\nWhat would you like to do? ");
            string selection = Console.ReadLine();
            if (selection == "1")
            {

                string theQuestion = thePrompt.blindQuestion();
                Console.Write($"\n{theQuestion}\n> ");

                infoEntered._answer = Console.ReadLine();
                infoEntered._prompt = theQuestion;

                DateTime theCurrentTime = DateTime.Now;
                infoEntered._todayDate = theCurrentTime.ToShortDateString();

                //We stopped sending strings and we pass all the "infoEntered objects"

                onProcess.addingEntries(infoEntered);

            }

            else if (selection == "2")
            {
                Console.WriteLine();
                onProcess.displayingJournal();
                Console.WriteLine();

            }
            else if (selection == "3")
            {
                string trying = "yes";
                while (trying != "no")
                {

                    string folderPath = @"Savedata\";
                    Console.Write("\nWhat file would you like to load? ");
                    string loadedFile = Console.ReadLine();

                    string folderFile = Path.Combine(folderPath, loadedFile);



                    if (File.Exists(folderFile))
                    {

                        onProcess._filename = folderFile;

                        Console.WriteLine($"\n\nLOADING {loadedFile}.... 0%\nLOADING {loadedFile}.... 25%\nLOADING {loadedFile}.... 50%");
                        Console.WriteLine($"\nLOADING {loadedFile}.... 75%\nLOADING {loadedFile}.... 99%\n{loadedFile} loaded successfully!");

                        onProcess.loading();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nWhoops! It looks like the file was not found!\nMaybe we could try another one? ");
                        int looping = -1;
                        while (looping != 1)
                        {


                            Console.Write("\nWould you like to try again? ");
                            string again = Console.ReadLine();
                            if (again == "yes")
                            {
                                trying = "yes";
                                break;
                            }
                            else if (again == "no")
                            {
                                trying = "no";
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nNot a valid input!");
                                looping = -1;
                            }

                        }
                    }

                }

            }
            else if (selection == "4")
            {
                string folderPath = @"Savedata\";
                Console.Write("\nWhere are you going to save the sacred words today? ");
                string file = Console.ReadLine();
                string theWholePath = Path.Combine(folderPath, file);

                Console.WriteLine($"\n\nSAVING {file}.... 0%\nSAVING {file}.... 25%\nSAVING {file}.... 50%");
                Console.WriteLine($"\nSAVING {file}.... 75%\nSAVING {file}.... 99%\n{file} saved successfully!");

                onProcess._filename = theWholePath;
                onProcess.saving();
            }
            else if (selection == "5")
            {
                Console.WriteLine("\n");
                onProcess.displayingJournal();
                Console.Write("\nPlease enter the number of the entry that you desired to delete: ");
                string killingNumber = Console.ReadLine();

                string entriesDestructor = "5";
                while (entriesDestructor == "5")
                {
                    Console.Write($"\nAre you sure you want to delete entry number {killingNumber}? It will be gone forever!(yes/no) ");
                    string finalDesicion = Console.ReadLine();

                    if (finalDesicion == "yes")
                    {

                        onProcess._deletingNumber = killingNumber;
                        onProcess.deleting();
                        Console.WriteLine("\nHere is how your Journal looks like!\n");
                        onProcess.displayingJournal();
                        onProcess.saving();
                        break;
                    }
                    else if (finalDesicion == "no")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nPlease try a valid a input");
                        entriesDestructor = "5";
                    }
                }
            }
            else if (selection == "6")
            {
                Console.WriteLine("Good bye!");
                break;
            }
            else
            {
                Console.WriteLine("\nWhoops! I think you need to select\none of the numbers seen in the menu my friend!\n");
            }
        }

    }
}