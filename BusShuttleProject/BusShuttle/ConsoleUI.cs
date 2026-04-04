namespace BusShuttle;

using Spectre.Console;

public class ConsoleUI
{
    DataManager dataManger;
    public ConsoleUI()
    {

        dataManger = new DataManager();
    }

    public void Show()
    {
        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select mode")
            .AddChoices(new[]
            {
                "driver", "manager"
            })
        );

        if (mode == "driver")
        {
            var selectedDriver = AnsiConsole.Prompt(
                new SelectionPrompt<Driver>()
                .Title("Select driver")
                .AddChoices(dataManger.Drivers)
            );
            Console.WriteLine("You are driving as " + selectedDriver.Name);
            Loop selectedLoop = AnsiConsole.Prompt(
                new SelectionPrompt<Loop>()
                .Title("Select mode")
                .AddChoices(dataManger.Loops)
            );
            Console.WriteLine("You selected " + selectedLoop.Name + " loop!");
            string command;

            do
            {
                Stop selectedStop = AnsiConsole.Prompt(
                new SelectionPrompt<Stop>()
                .Title("Select stop")
                .AddChoices(selectedLoop.Stops)
                 );

                Console.WriteLine("You selected " + selectedStop.Name + " stop!");

                int boarded = AnsiConsole.Prompt(new TextPrompt<int>("Enter number of boarded passengers: "));

                PassengerData data = new PassengerData(boarded, selectedStop, selectedLoop, selectedDriver);

                dataManger.AddNewPassengerData(data);

                command = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select mode")
                .AddChoices(new[]
                {
                "continue", "end"
                })
                );

            } while (command != "end");
        }
    }

    public static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}