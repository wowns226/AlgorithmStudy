namespace BOJ_2169
{
    class Program
    {
        static void Main()
        {
            using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
            
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int n = inputs[0];
            int m = inputs[1];

            int[,] board = new int[n, m];
            int[,] dp = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int j = 0; j < m; j++)
                {
                    board[i, j] = inputs[j];
                }
            }

            dp[0, 0] = board[0, 0];
            for (int i = 1; i < m; i++)
            {
                dp[0, i] = dp[0, i - 1] + board[0, i];
            }

            for (int i = 1; i < n; i++)
            {
                int[] left = new int[m];
                int[] right = new int[m];
                
                // 왼쪽에서 오른쪽
                left[0] = dp[i - 1, 0] + board[i, 0];
                for (int j = 1; j < m; j++)
                {
                    left[j] = board[i, j] + Math.Max(left[j - 1], dp[i - 1, j]);
                }
                
                // 오른쪽에서 왼쪽
                right[m - 1] = dp[i - 1, m - 1] + board[i, m - 1];
                for (int j = m - 2; j >= 0; j--)
                {
                    right[j] = board[i, j] + Math.Max(right[j + 1], dp[i - 1, j]);
                }

                for (int j = 0; j < m; j++)
                {
                    dp[i, j] = Math.Max(left[j], right[j]);
                }
            }

            Console.WriteLine(dp[n - 1, m - 1]);
        }
    }
}
