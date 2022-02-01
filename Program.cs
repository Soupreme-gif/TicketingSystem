using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using System.Text;

namespace TicketingSystem;

public class Program
{
    static void Main(string[] args)
    {
        //this is an empty variable that will be used to store the value of who ever is watching
        var personWatching = "";

        StringBuilder watchers = new StringBuilder();

        string file = "tickets.txt";

        //this loop handles all menu interactions that the user will go through.
        for (int i = 0; i < Int32.MaxValue; i++)
        {
            //read in the file
            //skip the first row so the labels don't print
            StreamReader reader = new StreamReader(file);

            Console.WriteLine("Choose an option.");
            Console.WriteLine("1: add a ticket");
            Console.WriteLine("2: read all tickets");
            Console.WriteLine("3: exit");
            Console.WriteLine("Your choice?: ");

            var menuChoice = Console.ReadLine();

            //prompts the user with multiple questions to fill in the information of their ticket
            if(menuChoice == "1")
            {
                
                Console.WriteLine("What is your ticketID?: ");
                var ticketId = Console.ReadLine();
                
                Console.WriteLine("Summarize your ticket: ");
                var summary = Console.ReadLine();
                
                Console.WriteLine("What the status of your ticket?: ");
                var status = Console.ReadLine();
                
                Console.WriteLine("What is your tickets priority level?: ");
                var priority = Console.ReadLine();
                
                Console.WriteLine("Who submitted the ticket?: ");
                var personWhoSubmitted = Console.ReadLine();
                
                Console.WriteLine("Who is this ticket assigned to?: ");
                var ticketAssignedTo = Console.ReadLine();

                do
                {
                    Console.WriteLine("Who is watching? input 1 to stop adding people.");
                    personWatching = Console.ReadLine();
                    if (personWatching != "1")
                    {
                        watchers.Append(personWatching);
                    }
                } while (personWatching != "1");
                
                reader.Close();

                watchers.ToString();
                var rowEntry = $"{ticketId},{summary},{status},{priority},{personWhoSubmitted},{ticketAssignedTo},{watchers}";

                StreamWriter writer = new StreamWriter(file, true);

                writer.WriteLine(rowEntry);
                
                writer.Close();

            }
            //prints out all of the non header entries in the file
            else if (menuChoice == "2")
            {
                
                string entry = reader.ReadLine();
                Console.WriteLine(entry);
                
                while (!reader.EndOfStream)
                {
                    entry = reader.ReadLine();
                    
                    var row = entry.Split(",");
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                        row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
                }
                reader.Close();
                
            }

            else if(menuChoice == "3")
            {

                break;

            }

            else
            {
                Console.WriteLine("Invalid option please try again.");
            }

        }

    }
}