using Filtering.Algoritms;
using Filtering.Environment;
using System;
using System.Collections.Generic;


namespace Filtering.Tasks
{
    class TaskCreator
    {
        private List<double[]> _table;
        private bool _displayZeroes;
        private string _name;
        private Algoritm _algo;

        public TaskCreator(string name, TableArgs args, bool displayZeroes, string algo)
        {
            _table = Utilities.CreateTable(args.MaxUsers, args.MaxItems, args.MinGrade, args.MaxGrade);
            _algo = SelectAlgoritm(algo);
            _algo.SetTable(_table);
            _displayZeroes = displayZeroes;
            _name = name;
            
        }
        private Algoritm SelectAlgoritm(string AlgoName)
        {
            switch (AlgoName)
            {
                case "L_1": return new L_OneAlgo(); 
                case "L_2": return new L_TwoAlgo(); 
                case "Cosine": return new CosineSimilarityAlgo(); 
                case "Pearson": return new PearsonCorrelationCoefficientAlgo(); 
                default: throw new Exception($"Can't find {AlgoName} algoritm ");
                    
            }
        }
        
        public void Run()
        {
            Console.WriteLine($"\n\t\t\t\t{_name}");
            Console.WriteLine("\tDatabase");
            Utilities.DisplayTable(_table, "user", "item");
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\tSim(user, user)\n");
            Utilities.DisplayTable(_algo.FindSimilarUsers(), "user", "user", _displayZeroes);
            Console.WriteLine("____________________________________________________________________________________");
        }


    }
}
