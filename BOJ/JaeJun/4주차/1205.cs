using System.Text;

namespace BOJ_1205
{
    class Program
    {
        static void Main()
        {
            int rank = 1;
            int count = 0;
            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = inputs[0];
            int score = inputs[1];
            int p = inputs[2];

            if (n == 0)
            {
                Console.WriteLine("1");

                return;
            }

            List<int> scores = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToList();

            for (int i = 0; i < scores.Count; i++)
            {
                if (scores[i] > score)
                {
                    rank++;
                    count++;
                }
                else if (scores[i] == score)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(count >= p ? -1 : rank);
        }
    }
}
