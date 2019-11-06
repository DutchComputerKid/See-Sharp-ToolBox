using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace See_Sharp_ToolBox
{
    class MIPSSharp
    {
        public long basenum = 0;
        public long test1 = 0;
        public static int score1;
        public static int score2;   
        public static List<int> list = new List<int>();
        public static int[] intargs;       
        
        public static void MIPSTest(int totalRuns)
        {
            Console.WriteLine("Determining/benchmarking...");
            Stopwatch sw = new Stopwatch(); // Main timer
            Stopwatch sw2 = new Stopwatch(); // Run-dependant stopwatch. get a reset every run.            
            int totalInstructionsToRun = 1000000; // Having 1 million instructions to run keeps the math simple.
            if (totalRuns <= 0)
            {
                totalRuns = 10; // Run the benchmark 10 times to average timestamps.
                Console.WriteLine("Note: The amount of runs was not specified. Using the default of 10!");
            }

            sw.Start(); // begin timer.          
            for (int p = 0; p < totalRuns; p++) // Start over and over again to assert better scores.
            {
                Console.WriteLine("Run: " + p); // Show which run of 10 this is.
                sw2.Start();
                // the main event.
                for (int i = 0; i < totalInstructionsToRun; i++) // Run the function 1 million times. This will be easier to convert later on.
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Benchmark)); // Run the thread as much and as fast as possible.
                }

                sw2.Stop(); // stop timer.
                score2 = (int)(sw2.ElapsedMilliseconds); // set the new timer value in a variable
                Console.WriteLine("Time of last run: = " + score2 + "ms"); // print current score

                // Append new value to list for getting the average
                list.Add(score2);

                // reset for new run
                sw2.Reset();
            }

            sw.Stop(); // stop timer for full run.
            score1 = (int)(sw.ElapsedMilliseconds);

            // calculate average from all 10 runs:
            double average = list.Average();

            // Print scores
            Console.WriteLine("Total time = {0}", sw.Elapsed);
            Console.WriteLine("Time average = " + Math.Ceiling(average) + "ms");
            Console.WriteLine("Time total (ms) = " + score1);
            Console.WriteLine("");
            // Retrieve MIPS value of all cores           
            double MIPSMultiCoreValue = (totalInstructionsToRun * totalRuns) / (sw.ElapsedMilliseconds * 0.001);
            // 1 million multiplied by the amount of meassurements taken, then divided by the total amount it took in seconds.
            
            Console.WriteLine(".NET Multicore MIPS score: " + Math.Ceiling(MIPSMultiCoreValue));           
            //Fallback to the CLI
        }

        static void Benchmark(object callback) // This counts as the instruction. That being, calling a function and checking it 1 million times.
        {
        }  

        public static void WriteToConsole(IEnumerable items) // For debugging lists and arrays.
        {
            foreach (object o in items)
            {
                Console.WriteLine(o);
            }
        }
    }
}
