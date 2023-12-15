namespace BOJ_1072
{
    class Program
    {
        static void Main()
        {
            using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            var inputs = sr.ReadLine().Split().Select(long.Parse).ToArray();

            long x = inputs[0];
            long y = inputs[1];

            int probability = GetProbability(x,y);

            if (IsNeverChange(probability))
            {
                sw.Write("-1");
            }
            else
            {
                int answer = BinarySearch(x, y, probability);
                
                sw.Write(answer);
            }
            
            sw.Flush(); sw.Close(); sr.Close();
        }

        static int BinarySearch(long x, long y, int curProbability)
        {
            long start = 0;
            long end = 1_000_000_000;

            while (start <= end)
            {
                long mid = (start + end) >> 1;
                long newProbability = ((y + mid) * 100) / (x + mid);

                if (curProbability >= newProbability)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return (int)start;
        }

        static int GetProbability(long x, long y) => (int)(y * 100 / x);
        static bool IsNeverChange(int probability) => probability > 98;
    }
}

