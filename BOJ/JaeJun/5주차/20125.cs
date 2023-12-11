namespace BOJ_20125
{
    class Program
    {
        static void Main()
        {
            using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int n = int.Parse(Console.ReadLine());

            char[,] board = new char[n,n];

            (int, int) heart = (0, 0);
            int leftArm = 0;
            int rightArm = 0;
            int waist = 0;
            int leftLeg = 0;
            int rightLeg = 0;
            
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = s[j];
                }
            }
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i, j] != '*') continue;
                    
                    heart = (i+1, j);

                    break;
                }

                if (heart != (0, 0)) break;
            }

            for (int i = heart.Item2-1; i >= 0; i--)
            {
                if (board[heart.Item1, i] == '*')
                {
                    leftArm++;
                }
            }

            for (int i = heart.Item2+1; i < n; i++)
            {
                if (board[heart.Item1, i] == '*')
                {
                    rightArm++;
                }
            }

            for (int i = heart.Item1+1; i < n; i++)
            {
                if (board[i, heart.Item2] == '*')
                {
                    waist++;
                }
            }

            for (int i = heart.Item1 + waist; i < n; i++)
            {
                if (board[i, heart.Item2 - 1] == '*')
                {
                    leftLeg++;
                }
                
                if (board[i, heart.Item2 + 1] == '*')
                {
                    rightLeg++;
                }
            }
            
            sw.WriteLine($"{heart.Item1+1} {heart.Item2+1}");
            sw.WriteLine($"{leftArm} {rightArm} {waist} {leftLeg} {rightLeg}");
        }
    }
}
