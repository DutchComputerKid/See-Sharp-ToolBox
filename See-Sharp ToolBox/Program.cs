using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace See_Sharp_ToolBox
{
    public class ConsoleSpinner
    {
        static string[,] sequence = null;

        public int Delay = 200;

        int totalSequences = 0;
        int counter;
        public static int totalRuns;
        public ConsoleSpinner()
        {
            counter = 0;
            sequence = new string[,] {
            { "/", "-", "\\", "|" },
            { ".", "o", "0", "o" },
            { "+", "x","+","x" },
            { "V", "<", "^", ">" },
            { ".   ", "..  ", "... ", "...." },
            { "=>   ", "==>  ", "===> ", "====>" },
           // ADD YOUR OWN CREATIVE SEQUENCE HERE IF YOU LIKE
        };

            totalSequences = sequence.GetLength(0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sequenceCode"> 0 | 1 | 2 |3 | 4 | 5 </param>
        public void Turn(string displayMsg = "", int sequenceCode = 0)
        {
            counter++;

            Thread.Sleep(Delay);

            sequenceCode = sequenceCode > totalSequences - 1 ? 0 : sequenceCode;

            int counterValue = counter % 4;

            string fullMessage = displayMsg + sequence[sequenceCode, counterValue];
            int msglength = fullMessage.Length;

            WriteOnBottomLine(fullMessage);

            //Console.SetCursorPosition(Console.CursorLeft - msglength, Console.CursorTop);
        }
        static void WriteOnBottomLine(string text)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.CursorTop = Console.WindowTop + Console.WindowHeight - 1;
            Console.Write(text);
            // Restore previous position
            Console.SetCursorPosition(x, y);
           
        }  
    }

    class Program
    {     
        public static bool loadme = true;
        [STAThread]
        static void Main(string[] args)
        {
            Console.Clear();
            new Thread(() =>
            {
                ConsoleSpinner spinner = new ConsoleSpinner();
                spinner.Delay = 300;
                Thread.CurrentThread.IsBackground = false;
                while (loadme == true)
                {
                    //int num = RandomNumber(1, 5);
                    spinner.Turn(displayMsg: "", sequenceCode: 5);
                } 
            }).Start();
            Console.Title = "See-Sharp ToolBox";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("+-----------------------------------------------------------------------------+");
            Console.WriteLine("| ToolBox                                                                     |");
            Console.WriteLine("+-----------------------------------------------------------------------------+");
            string[] InfoArray = new string[] { "ToolBox Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString(), "Today is " + DateTime.Now };
            foreach (var item in InfoArray)
            {
                Console.WriteLine("|                                                                             |");
            }
            for (int b = 0; b < InfoArray.Length; b++)
            {
                Console.SetCursorPosition(1, 3 + b);

                Console.WriteLine(InfoArray[b]);
            }
            Console.WriteLine("+-----------------------------------------------------------------------------+");
            int menuLength = 79;
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name; // Get user name
            string WelcomeMessage = ("Welcome " + userName); // Set welcome message as String
            int welcomePosition = menuLength - WelcomeMessage.Length - 1; // Calulatate new string position
            Console.SetCursorPosition(welcomePosition, 1); // Set new position
            Console.WriteLine("Welcome " + userName); // Print greeting on screen at position

            Console.SetCursorPosition(0, InfoArray.Length + 4);
            Console.BackgroundColor = ConsoleColor.Black;

            SystemInfo.GenerateInfoArray(false); // Generate your system's information

            Console.WriteLine("Current directory: " + Directory.GetCurrentDirectory());
            loadme = false; // Stop loading animation               
            Console.ForegroundColor = ConsoleColor.White;
            WriteOnBottomLine("\r" + new string(' ', Console.WindowWidth - 1) + "\r"); // Clear bottom line
            CommandLineInterpreter.CLI();
        }
        static void WriteOnBottomLine(string text)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.CursorTop = Console.WindowTop + Console.WindowHeight - 1;
            Console.Write(text);
            // Restore previous position
            Console.SetCursorPosition(x, y);
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

    }
}