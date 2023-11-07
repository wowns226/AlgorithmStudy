namespace BOJ_2512
{ 
    class Program
    {
        private static int n, m;
        private static int[] provinces;
        
        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            provinces = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            m = int.Parse(Console.ReadLine());

            Array.Sort(provinces);
            
            int start = 1;
            int end = provinces[n-1];

            while (start <= end)
            {
                int mid = (start + end) / 2;
                int cost = GetTotalCost(mid);

                if (cost <= m)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            Console.WriteLine(end);
        }

        static int GetTotalCost(int num)
        {
            int ret = 0;
            
            for (int i = 0; i < n; i++)
            {
                if (provinces[i] <= num)
                {
                    ret += provinces[i];
                }
                else
                {
                    ret += num;
                }
            }

            return ret;
        }
    }
}
