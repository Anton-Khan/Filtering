using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filtering.Algoritms
{
    class PearsonCorrelationCoefficientAlgo
    {

        private List<double[]> _table;

        public PearsonCorrelationCoefficientAlgo(List<double[]> table)
        {
            _table = table;
        }

        public List<double[]> FindSimilarUsers()
        {
            return FindSimilar(_table);
        }

        private List<double[]> FindSimilar(List<double[]> table)
        {
            List<double[]> similarities = new List<double[]>();
            ModifyTableWithMean(table, 0);
            for (int i = 0; i < table.Count - 1; i++)
            {
                double[] relations = new double[table.Count];

                for (int j = i + 1; j < table.Count; j++)
                {
                    ModifyTableWithMean(table, j);

                    relations[j] = Math.Round(FindCorrelationCoefficient(table, i, j), 2);
                }
                similarities.Add(relations);
            }
            return similarities;
        }

        private void ModifyTableWithMean(List<double[]> table, int str_index)
        {
            double mean_a = 0;
            for (int k = 0; k < table[str_index].Length; k++)
            {
                mean_a += table[str_index][k];
            }
            mean_a = mean_a / table[str_index].Length;

            for (int k = 0; k < table[str_index].Length; k++)
            {
                table[str_index][k] = table[str_index][k] - mean_a;
            }
            
        }

        private double FindCorrelationCoefficient(List<double[]> table, int u_i, int u_j)
        {
            double numerator = 0;
            double denominator_a = 0;
            double denominator_b = 0;
            
            for (int k = 0; k < table.First().Length; k++)
            {
                numerator += table[u_i][k] * table[u_j][k];
                denominator_a += Math.Pow(table[u_i][k], 2);
                denominator_b += Math.Pow(table[u_j][k], 2);
            }

            return numerator / (Math.Sqrt(denominator_a) * Math.Sqrt(denominator_b));
        }

    }
}
