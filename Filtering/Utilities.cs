using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filtering
{
    public static class Utilities
    {
        public static List<double[]> _table;

        public static void CreateTable(int users, int items, int minGrade, int maxGrade)
        {
            _table = new List<double[]>();
            Random rand = new Random();
            for (int i = 0; i < users; i++)
            {
                double[] i_items = new double[items];
                for (int j = 0; j < items; j++)
                {
                    i_items[j] = rand.Next(minGrade, maxGrade + 1);
                }

                _table.Add(i_items);
            }
        }

        public static void DisplayTable(List<double[]> table, string str, string col, bool replaceZeroes=false)
        {
            if (table == null)
            {
                table = _table;
            }

            int counter = 0;
            foreach (var item in table.First())
            {
                Console.Write("\t" + col + counter);
                counter++;
            }
            counter = 0;
            Console.WriteLine();
            foreach (var user in table)
            {
                Console.Write(str + counter + "\t");
                foreach (var grade in user)
                {
                    Console.Write( (replaceZeroes ? (grade>0 ? grade + "" : " ") : grade + "")  + "\t");
                }
                counter++;
                Console.WriteLine();
            }
        }

    }
}
