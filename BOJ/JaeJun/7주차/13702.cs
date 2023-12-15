namespace BOJ_13702
{
    class Program
    {
        static void Main()
        {
            using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int[] inputs = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int n = inputs[0];
            int k = inputs[1];

            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(sr.ReadLine()));
            }

            if (n == k)
            {
                sw.Write(list.Min());
            }
            else
            {
                int start = 0;
                int end = list.Max();

                while (start <= end)
                {
                    int mid = (start + end) >> 1;

                    int sum = 0;
                    for (int i = 0; i < n; i++)
                    {
                        int temp = list[i] / mid;
                        sum += temp;
                    }

                    if (sum >= k)
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
                
                sw.Write(end);
            }
            
            sw.Flush(); sw.Close(); sr.Close();
        }
    }
}
