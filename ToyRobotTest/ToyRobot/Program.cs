using System;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input commands");

            ToyRobot toyRobot = new ToyRobot();

            while (true)
            {
                // Read input commands. (Case insensitive)
                string command = Console.ReadLine()?.ToUpper();

                // Process toy robot commands
                string message = toyRobot.Process(command);
                if (!string.IsNullOrWhiteSpace(message))
                {
                    Console.WriteLine(message);
                }

                // If not REPORT command, expect next command, otherwise print report and check whether to exit
                if (command != ToyRobotConstants.Report) continue;

                Console.WriteLine("Do you want to exit? [Y/N]");
                string processExitCommand = Console.ReadLine();
                if (processExitCommand?.ToUpper() == "Y")
                {
                    break;
                }
                else if (processExitCommand?.ToUpper() == "N")
                {
                    Console.WriteLine("Enter input commands to proceed!");
                }
                else
                {
                    Console.WriteLine("Incorrect input is entered. This command will be ignored. Enter REPORT command to exit.");
                }
            }
        }
    }
}
