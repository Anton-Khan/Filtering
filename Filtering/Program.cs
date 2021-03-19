using System;
using System.Collections.Generic;
using System.Linq;

namespace Filtering
{
    class Program
    {

        static List<double[]> _table;

        static void CreateTable(int users, int items, int minGrade, int maxGrade)
        {
            _table = new List<double[]>();
            Random rand = new Random();
            for (int i = 0; i < users; i++)
            {
                double[] i_items = new double[items]; 
                for (int j = 0; j < items; j++)
                {
                    i_items[j] = rand.Next(minGrade, maxGrade+1);
                }

                _table.Add(i_items);
            }
        }

        static void DisplayTable(List<double[]> table, string str, string col)
        {
            foreach (var item in table.First())
            {
                Console.Write("\t" + col );
            }
            Console.WriteLine();
            foreach (var user in table)
            {
                Console.Write(str + "\t");
                foreach (var grade in user)
                {
                    Console.Write(grade + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            CreateTable(10, 10, 0, 1);
            DisplayTable(_table, "user", "item");
            Console.WriteLine();
            JaccardIndex jc = new JaccardIndex(_table);
            DisplayTable(jc.FindSimilarUsers(), "user", "item");
            Console.WriteLine();
            DisplayTable(jc.FindSimilarItems(), "user", "item");
        }
    }
}
