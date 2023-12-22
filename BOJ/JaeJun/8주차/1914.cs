using System.Numerics;
using System.Text;

namespace BOJ
{
    class No_1914
    {
        static StringBuilder sb = new StringBuilder();
        
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger count = BigInteger.Pow(2, n) - 1;

            sb.AppendLine(count.ToString());

            if (n > 20)
            {
                Console.WriteLine(sb);
                return;
            }
            
            Hanoi(n, 1, 2, 3);
            
            Console.WriteLine(sb);
        }

        static void Move(int from, int to)
        {
            sb.AppendLine($"{from} {to}");
        }

        static void Hanoi(int n, int from, int by, int to)
        {
            if (n == 0) return;

            Hanoi(n - 1, from, to, by);
            Move(from, to);
            Hanoi(n - 1, by, from, to);
        }
    }   
}
