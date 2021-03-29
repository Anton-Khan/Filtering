using Accord.Math.Decompositions;
using Accord.Math;
using System;
using System.Collections.Generic;

namespace ModelBasedMethods
{
    class SVDAlgo
    {
        private double[,] _matrix;
        private string[] names = {"Roma", "Vitya", "Vova" };
        private string[] music = {"classic", "jazz", "reggae", "rock" };
        private string[] func = { "f1", "f2"};

        public SVDAlgo()
        {
            LoadData();
            Console.WriteLine("________________Start Matrix_________________");
            Console.WriteLine();
            DisplayMatrix(_matrix, 3, 4, false, names, music);
        }

        private void LoadData()
        {
            _matrix = new double[3, 4];

            _matrix[0, 0] = 1;  
            _matrix[0, 1] = 1;
            _matrix[0, 2] = 0;
            _matrix[0, 3] = 1;

            _matrix[1, 0] = 0;
            _matrix[1, 1] = 1;
            _matrix[1, 2] = 1;
            _matrix[1, 3] = 1;

            _matrix[2, 0] = 0;
            _matrix[2, 1] = 0;
            _matrix[2, 2] = 0;
            _matrix[2, 3] = 1;
        }

        private void DisplayMatrix(double[,] matrix, int _i, int _j, bool _isRounded, string[] row=null, string[] col = null)
        {
            for (int i = 0; i < _j; i++)
            {
                Console.Write( col!=null ?"\t" + col[i] : "\t" + $"[{i}]");
            }

            Console.WriteLine();
            for (int i = 0; i < _i; i++)
            {   
                Console.Write(row!=null ? row[i] + "\t" : $"[{i}]" + "\t");
                for (int j = 0; j < _j; j++)
                {
                    System.Console.Write(_isRounded ? Math.Round(matrix[i, j], 3) + "\t" : matrix[i, j] + "\t");
                }
                System.Console.WriteLine();
            }
        }

        private double[,] SelectDMatrix(double[,] matrix, int k, int l)
        {
            double[,] nmatrix = new double[k, l];
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    nmatrix[i, j] = matrix[i, j];
                }
            }
            return nmatrix;
        }

        public void ComputeSVD()
        {
            var svd = new SingularValueDecomposition(_matrix);
            Console.WriteLine();
            Console.WriteLine("________________D-full-Matrix________________");
            Console.WriteLine();
            DisplayMatrix(svd.DiagonalMatrix, 3, 4, true);
            int k = 2;
            Console.WriteLine();
            Console.WriteLine("________________Vt-Matrix___________________");
            Console.WriteLine();
            DisplayMatrix(svd.RightSingularVectors.Transpose(), 4, 4, true);
            var diag = SelectDMatrix(svd.DiagonalMatrix, k, k);
            Console.WriteLine();
            Console.WriteLine("________________Vt2-Matrix___________________");
            Console.WriteLine();
            DisplayMatrix(svd.RightSingularVectors.Transpose(), k, 4, true, func, music);
            var v = SelectDMatrix(svd.RightSingularVectors.Transpose(), k, 4);
            Console.WriteLine();
            Console.WriteLine("_________________U2-Matrix___________________");
            Console.WriteLine();
            DisplayMatrix(svd.LeftSingularVectors, 3, k, true, names, func);
            var u = SelectDMatrix(svd.LeftSingularVectors, 3, k);
            
            Console.WriteLine();
            Console.WriteLine("__________Matrix of Purposefulness__________");
            Console.WriteLine();
            var a = CalculatePurposefulness(u, v);
            DisplayMatrix(a, 3, 4, true, names, music);

        }

        private double ProductionOfVectors(double[] f, double[] n)
        {
            if (f.Length != n.Length)
                throw new Exception("Different lenght vect");
            double sum = 0;
            for (int i = 0; i < f.Length; i++)
            {
                sum += f[i] * n[i];
            }
            return sum;
        }

        private double[,] CalculatePurposefulness(double[,] _u, double[,] _v)
        {
            var u = _u.ToJagged();
            var v = _v.ToJagged().Transpose();
            double[,] result = new double[u.Length, v.Length];

            for (int i = 0; i < u.Length; i++)
            {
                for (int j = 0; j < v.Length; j++)
                {
                    result[i,j] = ProductionOfVectors(u[i], v[j]);
                }
            }
            return result;
        }


    }
}
