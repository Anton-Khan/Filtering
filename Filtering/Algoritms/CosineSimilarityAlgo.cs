using Filtering.Environment;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Filtering.Algoritms
{
    class CosineSimilarityAlgo : Algoritm
    {
        private List<double[]> _table;

        public override Algoritm Create()
        {
            return new CosineSimilarityAlgo();
        }

        public override List<double[]> FindSimilarUsers()
        {
            return FindSimilar(_table);
        }

        public override void SetTable(List<double[]> table)
        {
            _table = table;
        }

        private List<double[]> FindSimilar(List<double[]> table)
        {
            List<double[]> similarities = new List<double[]>();
            for (int i = 0; i < table.Count - 1; i++)
            {
                double[] relations = new double[table.Count];
                for (int j = i + 1; j < table.Count; j++)
                {
                    double a_mult_b = 0;
                    double abs_a = 0;
                    double abs_b = 0;
                    
                    for (int k = 0; k < table.First().Length; k++)
                    {
                        a_mult_b += table[i][k] * table[j][k];
                        abs_a += Math.Pow(table[i][k], 2);
                        abs_b += Math.Pow(table[j][k], 2);
                    }
                    relations[j] = Math.Round(a_mult_b /(Math.Sqrt(abs_a) * Math.Sqrt(abs_b)), 2);
                }
                similarities.Add(relations);
            }
            return similarities;
        }
    }
}
