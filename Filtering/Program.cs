using Filtering.Environment;
using Filtering.Tasks;


namespace Filtering
{
    class Program
    {
        static void Main(string[] args)
        {
            JaccardTask jcIndex = new JaccardTask();
            jcIndex.Run();

            TaskCreator task2 = new TaskCreator("L_1 Algoritm", new TableArgs(10,4,0,10), false, "L_1");
            task2.Run();

            TaskCreator task3 = new TaskCreator("L_2 Algoritm", new TableArgs(10, 2, 0, 10), false, "L_2");
            task3.Run();
            
            TaskCreator task4 = new TaskCreator("Cosine Similarity Algoritm", new TableArgs(5, 10, 0, 5), false, "Cosine");
            task4.Run();

            TaskCreator task5 = new TaskCreator("Pearson Correlation Coefficient Algoritm", new TableArgs(5, 6, 0, 5), false, "Pearson");
            task5.Run();



        }
    }
}
