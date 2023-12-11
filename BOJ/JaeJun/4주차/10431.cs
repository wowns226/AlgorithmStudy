using System.Text;

namespace BOJ_10431
{
    class Program
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            int answer = 0;
            List<int> list = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                list.Clear();
                answer = 0;
                
                int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                
                for (int j = 1; j <= 20; j++)
                {
                    answer += list.Count(x => x > inputs[j]);
                    
                    list.Add(inputs[j]);
                }

                sb.AppendLine($"{i} {answer}");
            }

            Console.Write(sb);
        }
    }
}
