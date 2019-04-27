using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainAir
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<int>> rainAir = new Dictionary<string, List<int>>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "I believe I can fly!")
            {
                //If inputline contains '=' then we need to merge flights between customers. 
                if (input.Contains("="))
                {
                    string[] r = input.Split(new[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = r[0];
                    string name1 = r[1];

                    //We took List of second customer.
                    var cust2 = rainAir[name1];

                    //We make new List to first customer.
                    rainAir[name] = new List<int>();
                    //Beware of reference.
                    rainAir[name] = cust2.ToList();

                }
                else
                {
                    //populating the main dicitonary.
                    string[] m = input.Split();
                    string name = m[0];
                    List<int> flights = new List<int>();

                    //Populating flight list.
                    for (int i = 1; i < m.Length; i++)
                    {
                        flights.Add(int.Parse(m[i]));
                    }

                    if (!rainAir.ContainsKey(name))
                    {
                        rainAir.Add(name, new List<int>());
                    }
                    rainAir[name].AddRange(flights);
                }
            }

            //The ordering.
            var ordered = rainAir.
                OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key);


            foreach (var user in ordered)
            {
                Console.WriteLine($"#{user.Key} ::: {string.Join(", ", user.Value.OrderBy(x => x))}");

            }
        }
    }
}
