using System.Collections;
using System.Collections.Generic;

namespace ExercicioDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                using (StreamReader FileReader = File.OpenText(path))
                {
                    Dictionary<string, int> Dict = new Dictionary<string, int>();

                    while (!FileReader.EndOfStream)
                    {
                        string[] VotingRecord = FileReader.ReadLine().Split(',');
                        
                        string Name = VotingRecord[0];
                        
                        int Votes = int.Parse(VotingRecord[1]);

                        if (Dict.ContainsKey(Name))
                        {
                            Dict[Name] += Votes;
                        }
                        else
                        {
                            Dict[Name] = Votes;
                        }
                    }

                    foreach (var item in Dict)
                    {
                        Console.WriteLine(item.Key + ": " + item.Value);
                    }
                }
                Console.ReadKey();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
