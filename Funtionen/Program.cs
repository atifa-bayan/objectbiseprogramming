using System.Security.Cryptography.X509Certificates;

namespace Funtionen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("It is our FirstDay in Code_Academy");
            Console.WriteLine("IT is intresting");
            int[] arr = { 1, 2,5 };
            string[] persons = { "Atifa", "Nadja", "Maren" };
            int[] arr2 = new int[3];
            Console.WriteLine(persons[1]);
            Console.WriteLine(arr.Length);
            for( int i=0; i<arr.Length; i++)
            {
              
                if (arr[i] == 2)
                {
                    return;
                    
                }
                Console.WriteLine(arr[i]);
            }
            foreach(string person in persons)
            {
                Console.WriteLine(person);
            }

        }
    }
}
