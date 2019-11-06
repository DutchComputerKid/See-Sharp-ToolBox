using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using Microsoft.Win32;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using SpeedTest;

namespace See_Sharp_ToolBox
{
    class CommandLineInterpreter
    {
        public static int getnumber = 0;
        public static string url = "";        
        public static bool loadme = true;        
        static bool IsNullOrEmpty(string[] myStringArray)
        {
            return myStringArray == null || myStringArray.Length < 1;
        }
        public static void CLI()
        {
           
            while (true)
            {
                Console.Out.Flush();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;                   
                Console.Write("ToolBox:/");
                Console.ResetColor();
                String command = ReceiveInput();
                command.ToLower();
                String[] words = command.Split();
                switch (words[0])
                {
                    case "help":
                        Console.WriteLine("ToolBox (See-Sharp Toolbox) v" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " help:");                      
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green; // This is here otherwise the info word wont get its color.
                        //1
                        Console.Write("info: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Displays collected information about this system. Useful for sysadmins.");
                        Console.ForegroundColor = ConsoleColor.Green;                                          
                        Console.WriteLine("");
                        //2
                        Console.Write("speedtest: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Performs a basic internet speed test by contacting the OOKLA registered servers.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("");
                        //3
                        Console.Write("mips: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Benchmarks and calculates your MIPS value on .NET code. (Millions of Instructions per Second)");                        
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("");
                        //4
                        Console.Write("exit: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Close the program.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("");
                        break;
                    case "exit":
                        Environment.Exit(0);
                        return;                    
                    case "clear":
                        Console.Clear();
                        break;
                    case "echo":
                        Echo(words);
                        break;
                    case "total":
                        int total = Total(words);
                        Console.WriteLine(total);
                        break;
                    case "average":
                        int average = Average(words);
                        Console.WriteLine(average);
                        break;             
                    case "info":
                        //if (IsNullOrEmpty(SystemInfo.SystemArray)) // Check if the info has been generated yet
                        // {
                        //    SystemInfo.GenerateInfoArray(); // Generate array              
                        // }                      
                        SystemInfo.GenerateInfoArray(true);                       
                        break;                         
                    case "speedtest":
                        SpeedTestClass.TestIt();
                        break;
                    case "mips":
                        //Start new consolespinner instant.
                        loadme = true;
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
                        // start the benchmark and perform checks about the input                     
                        try
                        {
                            int numVal = Convert.ToInt32(words[1]);
                            MIPSSharp.MIPSTest(numVal); // launch benchmark
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("ERROR: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("You must add how many time you want to run the test. The more you run the more accurate the result. ");
                            Console.WriteLine("Usage: mips [amount] ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("");                                                      
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("ERROR: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("That did not seem like a number!");
                            Console.WriteLine("Usage: mips [amount] ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("");
                        }
                        catch (Exception)
                        {

                        }
                        //when that ends, stop the animation.
                        loadme = false;
                        break;
                    default:
                        Console.Beep();
                        Console.Write("That didn't work. Try looking at 'help'");
                        break;

                }
            }
        }

        static String ReceiveInput()
        {
            Console.ForegroundColor = ConsoleColor.White;
            String command = Console.ReadLine();
            Console.ResetColor();
            return command;
        }

        static void Echo(String[] words)
        {
            for (int i = 1; i < words.Length; i++)
            {
                if (i > 1)
                    Console.Write(' ');
                Console.Write(words[i]);
            }
            Console.WriteLine();
        }

        static int Total(String[] words)
        {
            int total = 0;
            try
            {
                for (int i = 1; i < words.Length; i++)
                    total += Convert.ToInt32(words[i]);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
            }

            return total;
        }

        static int Average(String[] words)
        {
            int total = Total(words);
            int average = total / (words.Length - 1);
            return average;
        }        
    }
}

