using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SPO4
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            while (true)
            {
                Console.WriteLine("Введите комманду");
                s = Console.ReadLine();
                bool option_n = false;
                bool option_E = false;
                bool option_b = false;
                bool option_s = false;
                bool option_T = false;
                string[] str = s.Split(' ');
                bool isCat = str.Contains("cat");
                if (isCat)
                {
                    foreach (var options in str)
                    {
                        if (options.Equals("-n"))
                            option_n = true;
                        if (options.Equals("-E"))
                            option_E = true;
                        if (options.Equals("-b"))
                            option_b = true;
                        if (options.Equals("-s"))
                            option_s = true;
                        if (options.Equals("-T"))
                            option_T = true;
                    }

                    //System.Console.WriteLine(isCat);
                    string fileName = str[(str.Length - 1)];
                    //System.Console.WriteLine(fileName);
                    if (File.Exists(fileName))
                    {
                        string[] filestrings = File.ReadAllLines(@fileName);
                        List<string> stroki = filestrings.ToList();
                        if (option_s)
                        {
                            for (int j = 0; j < stroki.Count; j++)
                            {
                                if (j > 0 && stroki[j] == "" && stroki[j - 1] == "")
                                {
                                    stroki.RemoveAt(j);
                                }
                            }
                        }
                        int i = 1;
                        foreach (var stroka in stroki)
                        {
                            string output = stroka;
                            if (option_n)
                                System.Console.Write(i.ToString() + "  ");
                            if (option_T)
                                output = output.Replace("\t", "^I");
                            if (option_E)
                                output = output + "$";
                            if (option_b)
                            {
                                if (stroka != "")
                                    System.Console.Write(i.ToString() + "  ");
                            }
                            System.Console.WriteLine(output);
                            i++;
                        }
                    }
                }
                //System.Console.ReadKey();
            }
        }
    }
}
