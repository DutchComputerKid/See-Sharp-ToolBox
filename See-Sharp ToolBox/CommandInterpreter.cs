using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections;
using System.Net.NetworkInformation;

namespace AutiCLI
{
    public class CommandInterpreter
    {
        public static int getnumber = 0;
        public static string url = "";
        public static string[] words;
        public static bool kajface = true;
        public static void Command()
        {

            Console.Title = "AutismInterface";

            while (true)
            {
                Console.Out.Flush();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Autie:/");
                Console.ResetColor();
                String command = ReceiveInput();
                command.ToLower();
                String[] words = command.Split();
                switch (words[0])
                {
                    case "exit":
                        Environment.Exit(0);
                        return;
                    case "oof":
                        ASCII.DisplayBitMap("https://cdn.frankerfacez.com/emoticon/299190/4");
                        break;
                    case "bakvet":
                        BakVetZegt();
                        break;
                    case "candida":
                        KajZegt();
                        break;
                    case "strandoma":
                        StrandOma();
                        break;
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
                    case "owo":
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("WHAT'S THIS?");
                        Console.ResetColor();
                        break;
                    case "kees":
                        KeesInDeAuto();
                        break;
                    case "info":
                        SystemInfo si = new SystemInfo();       //Create an object of SystemInfo class.
                        si.getOperatingSystemInfo();            //Call get operating system info method which will display operating system information.
                        si.getProcessorInfo();                  //Call get  processor info method which will display processor info.  
                        si.NetworkInfo();                       //Get network information.
                        si.OutputApps();
                        break;
                    case "tinyurl":
                        TinyHell();
                        break;
                    case "racisme":
                        Racisme.RacismJokes();
                        break;
                    default:
                        Console.Beep();
                        Console.Write("Dat werkt dus niet.");
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
        static void KeesInDeAuto()
        {
            string[] KeesZegt = new string[10]
            {
                "VIEZE VUILE TERING MOF! SCHWEINHUND, ARSCHLOG!!",
                "GODVERDOMME, DIE ROT MOFFEN! ALTIJD MAAR WEER AGRESSIE!!",
                "WAS IK NOU MAAR MET DE TREIN GEGAAN!",
                "VIEZE MERCEDES DIESEL!",
                "MOET JE KIJKEN, HIER, VUILE ROTMOF",
                "DIE VUIL ROTMOFFEN MOETEN ZE EEN KEER AFSTRAFFEN!",
                "WATERSTOFBOMMEN, OP MOFRIKA GOOIEN",
                "ALS IK DIE NOG EEN KEER TEGEN OM IS HIJ NOG NIET JARIG",
                "IK HAD HEM OM ZIJN BEK GESLAGEN",
                "OH WAT HAAT IK DE SNELWEG",
            };
            Random rand = new Random();
            // Generate a random index less than the size of the array.  
            int index = rand.Next(KeesZegt.Length);
            // Display the result.  
            Console.WriteLine($"|Kees| {KeesZegt[index]}");

        }
        static void StrandOma()
        {
            string[] OmaZegt = new string[6] {
            "Kom naar centerparks met oma zwemmen!",
            "Oma is een beetje nat, help je even met drogen?",
            "Dag lieverdje, oma wilt dat jij nu dat jij gezellig thee komt drinken met oma.",
            "Oma heeft koekjes klaar liggen, kom je?",
            "Strandoma is altijd bruin en erg nat",
            "Kom maar mee op kamp, word vast gezellig!"};
            Random rand = new Random();
            // Generate a random index less than the size of the array.  
            int index = rand.Next(OmaZegt.Length);
            // Display the result.  
            Console.WriteLine($"|Oma| {OmaZegt[index]}");
        }
        static void BakVetZegt()
        {
            string[] BakVetZegt = new string[13] { "'Hee jij daar, ben je ook zo geil? Heb je ook zo'n zin in seks? Dan is camfappen misschien wel iets voor jou!",
            "Wat is dat voor ijs? Daar word je niet dik van!",
            "Een waterijsje?! Daar krijg je toch geen hangflappen van!?",
            "blblblblblbl *slurp*",
            "Ik heb een nieuwe broek gevonden in de vuilnisbak!",
            "Kijk die zwerver toch eens door het hele land, dat wil je niet weten!",
            "Lig jij ook zo te zweten in bed? dat hebben wij een speciaal ijsje voor je! KANKERIJS!",
            "Oranje en rood, lekker dichtbij de dood!",
            "Biertjuh?",
            "Kom dan even gezellig een biertje drinken!",
            "Ben jij ook zo stijf? Dan is er nu, de team bakvet massagestaaf!",
            "Grasetende honden en honden geven geven dus ook melk! Laten we robin even melken!",
            "Hondenmelk is lekker, maar dan moet je wel even kijken of het een vrouwtje is! *barf*"
            };
            Random rand = new Random();
            // Generate a random index less than the size of the array.  
            int index = rand.Next(BakVetZegt.Length);
            // Display the result.  
            Console.WriteLine($"|Bakvet| {BakVetZegt[index]}");
        }
        static void KajZegt()
        {
            if (kajface == true)
            {
                ASCII.DisplayBitMap("http://quinsoft.nl/other/kaj.png");
            }
            kajface = false;
            string[] KajZegt = new string[9] {"Wees gewaarschuwd: Ik zit vol met tegenstrijdigheden!",
                "What the fuck is dit man, dat mensen dit kopen",
                "Ik ben nog wel eens een eikeltje af en toe. Ja sorry kan het ook niet helpen.",
                "Autisme is een schimmel en kan verholpen worden, koop nu mijn grodijn voor maar 1600 euro!",
                "Ik heb stenen voor het inslaan van ruiten voor maar 10 euro per stuk!",
                "KOOP MIJN GODVERDOMME GORDIJN",
                "Water is nu maar 25 euro per fles!",
                "Opgelicht? Ik maak het erger!",
                "Zelfs een stopcontact is bij mijn vieze winkel te krijgen!",
            };
            Random rand = new Random();
            // Generate a random index less than the size of the array.  
            int index = rand.Next(KajZegt.Length);
            // Display the result.  
            Console.WriteLine($"|Kaj| {KajZegt[index]}");
        }
        static void TinyHell()
        {
            string[] TinyHellType = new string[4] { "dithebjijgedaan", // series opslaan
            "dithebjijgelikt",
            "dithebjijgeinstalleerd",
            "dithebjijgekeken",
            };
            Random rand = new Random();
            int index = rand.Next(TinyHellType.Length); // kies een serie
            switch ($"{TinyHellType[index]}") // maak de URL met het nummer en plak alles aan elkaar
            {
                case "dithebjijgedaan":
                    getnumber = rand.Next(1, 41);
                    url = ("https://tinyurl.com/" + $"{TinyHellType[index]}" + getnumber);
                    break;
                case "dithebjijgelikt":
                    getnumber = rand.Next(1, 3);
                    url = ("https://tinyurl.com/" + $"{TinyHellType[index]}" + getnumber);
                    break;
                case "dithebjijgeinstalleerd":
                    getnumber = rand.Next(1, 10);
                    url = ("https://tinyurl.com/" + $"{TinyHellType[index]}" + getnumber);
                    break;
                case "dithebjijgekeken":
                    getnumber = rand.Next(1, 29);
                    url = ("https://tinyurl.com/" + $"{TinyHellType[index]}" + getnumber);
                    break;
                default:
                    break;
            }
            Console.WriteLine("Opening: " + url);
            System.Diagnostics.Process.Start(url);
        }

        public class SystemInfo
        {
            public void getOperatingSystemInfo()
            {
                //Create an object of ManagementObjectSearcher class and pass query as parameter.
                ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                foreach (ManagementObject managementObject in mos.Get())
                {
                    if (managementObject["Caption"] != null)
                    {
                        Console.WriteLine("|Info| Operating System Name  :  " + managementObject["Caption"].ToString());   //Display operating system caption
                    }
                    if (managementObject["OSArchitecture"] != null)
                    {
                        Console.WriteLine("|Info| Operating System Architecture  :  " + managementObject["OSArchitecture"].ToString());   //Display operating system architecture.
                    }
                    if (managementObject["CSDVersion"] != null)
                    {
                        Console.WriteLine("|Info| Operating System Service Pack   :  " + managementObject["CSDVersion"].ToString());     //Display operating system version.
                    }
                }
            }

            public void getProcessorInfo()
            {
                RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

                if (processor_name != null)
                {
                    if (processor_name.GetValue("ProcessorNameString") != null)
                    {
                        Console.WriteLine("|Info| " + processor_name.GetValue("ProcessorNameString"));   //Display processor info.
                    }
                }
            }

            public void OutputApps()
            {
                ArrayList allapps = new ArrayList();
                string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
                {
                    foreach (string skName in rk.GetSubKeyNames())
                    {
                        using (RegistryKey sk = rk.OpenSubKey(skName))
                        {
                            try
                            {
                                allapps.Add(sk.GetValue("DisplayName"));
                            }
                            catch (Exception ex)
                            { Console.Write(ex); }
                        }
                    }
                    allapps.Sort();
                    if (File.Exists(@"./allapplications.txt"))
                    {
                        File.Delete(@"./allapplications.txt");
                    }
                    using (StreamWriter outputFile = new StreamWriter(@"./allapplications.txt"))
                    {
                        //string[] values = { "Test", "People", "Owls", "Bully" };
                        foreach (string line in allapps)
                            outputFile.WriteLine(line);
                    }
                    //Console.WriteLine(allapps.ToString());
                    Console.WriteLine("|Info| Total no. of installed applications: " + allapps.Count.ToString());
                }
            }

            public void NetworkInfo()
            {
                ManagementObjectSearcher mos =
                new ManagementObjectSearcher(@"root\CIMV2", @"SELECT * FROM Win32_ComputerSystem");
                foreach (ManagementObject mo in mos.Get())
                {
                    Console.WriteLine("|Info| Workgroup: " + mo["Workgroup"]);
                }
                Console.WriteLine("|Info| PC Hostname: " + Dns.GetHostName());
                try
                {
                    IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                    foreach (IPAddress addr in localIPs)
                    {
                        if (addr.AddressFamily == AddressFamily.InterNetwork)
                        {
                            Console.WriteLine("|Info| IP Adress(es) = " + addr);
                        }
                    }
                }
                catch (Exception)
                {
                    // oof!
                    Console.WriteLine("|Info| An error occoured while getting the IP adress(es)");
                }
                try
                {
                    var ping = new Ping();
                    var reply = ping.Send("icanhazip.com", 2 * 100); // set ping destination
                    if (reply.Status == IPStatus.Success) // ping it, see if it's not blocked.
                    {
                        // show external IP
                        string externalip = new WebClient().DownloadString("http://icanhazip.com");
                        Console.WriteLine("|Info| External IP: " + externalip);
                    }
                    else
                    {
                        // show error if the URL is not reachable.
                        Console.WriteLine("|Info| External IP not obtainable.");
                    }
                }
                catch (Exception)
                {
                    // oof!
                    Console.WriteLine("|Info| An error occoured while getting the external IP");
                    {

                    }
                }

            }
        }
    }
}
