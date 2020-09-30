using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace KillProcessDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = null;

            while (input != "")
            {
                ListProcesses();
                ShowInstructions();
                input = Console.ReadLine();
                ProcessInput(input);
            }
        }

        static void ShowInstructions()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter a process ID to kill it or press Enter to stop");
        }

        static void ListProcesses()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                Console.WriteLine("{0}: {1}", process.Id, process.ProcessName);
            }
        }

        static void ProcessInput(string input)
        {
            int processId;

            if (int.TryParse(input, out processId))
            {
                KillProcessIfPresent(processId);
            }
            else if (input.Length != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
            }
        }

        static void KillProcessIfPresent(int processId)
        {
            try
            {
                Process toKill = Process.GetProcessById(processId);
                KillProcess(toKill);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Process not found");
            }
        }

        static void KillProcess(Process toKill)
        {
            try
            {
                toKill.Kill();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Process {0} killed", toKill.Id);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unable to kill process {0}", toKill.Id);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
