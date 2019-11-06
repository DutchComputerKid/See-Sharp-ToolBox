using System;
using System.Collections.Generic;
using System.Linq;
using SpeedTest;
using SpeedTest.Models;
namespace See_Sharp_ToolBox
{
    public class SpeedTestClass
    {
        public static SpeedTestClient client;
        public static Settings settings;
        public static int forposition;
        public static double speeddata;
        public static double finalspeed;
        public static void TestIt()
        {
            Console.WriteLine("Getting speedtest.net settings and server list...");
            client = new SpeedTestClient();
            settings = client.GetSettings();

            double[] calucations = new double[3]; // create array for data
            settings.Download.ThreadsPerUrl = 5;
            var servers = SelectServers();
            var bestServer = SelectBestServer(servers);
            Console.WriteLine("Testing speed... ");

            // DOWNLOAD
            double[] DownloadSpeedArray = new double[] { client.TestDownloadSpeed(bestServer, settings.Download.ThreadsPerUrl), client.TestDownloadSpeed(bestServer, settings.Download.ThreadsPerUrl), client.TestDownloadSpeed(bestServer, settings.Download.ThreadsPerUrl) };            
            foreach (var item in DownloadSpeedArray.Select((value, i) => (value, i)))
            {
                forposition = forposition++; // Set foreach position as integer
                if (DownloadSpeedArray[item.i] > 1024) // check if bigger then 1 MB
                {
                    speeddata = Math.Round(DownloadSpeedArray[item.i] / 1024, 2); // Save speed as normal double
                }
                else // if not bigger
                {
                    speeddata = Math.Round(DownloadSpeedArray[item.i], 2); // Save speed as normal double
                }

                calucations[item.i] = speeddata; // Save speed in array
            }
            // Get average speed
            for (int i = 0; i < calucations.Length; i++)
            {
                finalspeed = finalspeed + calucations[i];
            }
            finalspeed = finalspeed / calucations.Length;
            // Get the speed!

            if (finalspeed > 1024) // check if bigger then 1 MB
            {
                Console.WriteLine("{0} speed: {1} Mbps", "Download", Math.Round(finalspeed, 2));

            }
            else // if not bigger
            {
                Console.WriteLine("{0} speed: {1} Mbps", "Download", Math.Round(finalspeed, 2));
            }

            // UPLOAD
            finalspeed = 0;
            double[] uploadarraypos = new double[3]; // create array for data
            double[] UploadSpeedArray = new double[] { client.TestUploadSpeed(bestServer, settings.Upload.ThreadsPerUrl), client.TestUploadSpeed(bestServer, settings.Upload.ThreadsPerUrl), client.TestUploadSpeed(bestServer, settings.Upload.ThreadsPerUrl) };            
            foreach (var item in UploadSpeedArray.Select((value, i) => (value, i)))
            {
                forposition = forposition++; // Set foreach position as integer
                if (UploadSpeedArray[item.i] > 1024) // check if bigger then 1 MB
                {
                    speeddata = Math.Round(UploadSpeedArray[item.i] / 1024, 2); // Save speed as normal double
                }
                else // if not bigger
                {
                    speeddata = Math.Round(UploadSpeedArray[item.i], 2); // Save speed as normal double
                }

                uploadarraypos[item.i] = speeddata; // Save speed in array
            }
            // Get average speed
            for (int i = 0; i < uploadarraypos.Length; i++)
            {
                finalspeed = finalspeed + uploadarraypos[i];
            }
            finalspeed = finalspeed / uploadarraypos.Length;
            // Get the speed!

            if (finalspeed > 1024) // check if bigger then 1 MB
            {
                Console.WriteLine("{0} speed: {1} Mbps", "Upload", Math.Round(finalspeed, 2));

            }
            else // if not bigger
            {
                Console.WriteLine("{0} speed: {1} Mbps", "Upload", Math.Round(finalspeed, 2));
            }


            // var uploadSpeed = client.TestUploadSpeed(bestServer, settings.Upload.ThreadsPerUrl);
            //("Upload", uploadSpeed);

            // Clear RAM usage
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();            
            //end
        }

        private static Server SelectBestServer(IEnumerable<Server> servers)
        {
            Console.WriteLine();
            Console.WriteLine("Best server by latency:");
            var bestServer = servers.OrderBy(x => x.Latency).First();
            PrintServerDetails(bestServer);
            Console.WriteLine();
            return bestServer;
        }

        private static IEnumerable<Server> SelectServers()
        {
            Console.WriteLine();
            Console.WriteLine("Selecting best server by distance...");
            var servers = settings.Servers.Take(10).ToList();

            foreach (var server in servers)
            {
                server.Latency = client.TestServerLatency(server);
                PrintServerDetails(server);
            }
            return servers;
        }

        private static void PrintServerDetails(Server server)
        {
            Console.WriteLine("Hosted by {0} ({1}/{2}), distance: {3}km, latency: {4}ms", server.Sponsor, server.Name,
                server.Country, (int)server.Distance / 1000, server.Latency);
        }

        private static void PrintSpeed(string type, double speed)
        {
            if (speed > 1024)
            {
                Console.WriteLine("{0} speed: {1} Mbps", type, Math.Round(speed / 1024, 2));
            }
            else
            {
                Console.WriteLine("{0} speed: {1} Kbps", type, Math.Round(speed, 2));
            }
        }

    }
}
