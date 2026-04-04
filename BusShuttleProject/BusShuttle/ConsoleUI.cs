namespace BusShuttle;

public class ConsoleUI
{
    FileSaver fileSaver;

    public ConsoleUI()
    {
        fileSaver = new FileSaver("passenger-data.txt");
    }

    public void Show()
    {
        string mode = AskForInput("Select mode (driver || manager): ");

        if (mode == "driver")
        {

            string command;

            do
            {
                string stopName = AskForInput("Enter stop name: ");

                int boarded = int.Parse(AskForInput("Enter number of boarded passengers: "));

                fileSaver.AppendLine(stopName + ":" + boarded);

                command = AskForInput("end || continue: ");

            } while (command != "end");
        }
    }

    public static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}