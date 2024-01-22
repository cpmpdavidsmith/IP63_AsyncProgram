using System;
using System.IO;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            Task task = new Task(ProcesstheDataAsync);
            task.Start();
            task.Wait();
            Console.ReadLine();
        }
        static async void ProcesstheDataAsync()
        {
            Task<int> task = HandleFileAsync("c:\\enablel.txt");

            Console.WriteLine("wait " + "while I carry out some vital. ");

            int x = await task;
            Console.WriteLine("count: " + x);
        }
        static async Task<int> HandleFileAsync(string file)
        {
            Console.WriteLine("HandleFile enter");
            int count = 0;

            using (StreamReader reader = new StreamReader(file))
            {
                string v = await reader.ReadToEndAsync();

                count += v.Length;
                for(int i = 0; i < 10000; i++)
                {
                    int x = v.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
                }
            }
            Console.WriteLine("HandleFile exit");
            return count;
         
        }
        
    }
    
}