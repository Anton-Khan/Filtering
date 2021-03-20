using Filtering.Environment;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Filtering.Algoritms
{
    class L_TwoAlgo : Algoritm
    {
        

        public override Algoritm Create()
        {
            return new L_TwoAlgo();
        }

        public override List<double[]> FindSimilarUsers()
        {
            return FindSimilar(_table);
        }

        private List<double[]> FindSimilar(List<double[]> table)
        {
            List<double[]> similarities = new List<double[]>();
            for (int i = 0; i < table.Count - 1; i++)
            {
                double[] relations = new double[table.Count];
                for (int j = i + 1; j < table.Count; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < table.First().Length; k++)
                    {
                        sum += Math.Pow(table[i][k] - table[j][k], 2);
                    }
                    relations[j] = Math.Round(Math.Sqrt(sum), 2);
                }
                similarities.Add(relations);
            }
            return similarities;
        }

    }
}
