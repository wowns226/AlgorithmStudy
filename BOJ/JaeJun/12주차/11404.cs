using System.Text;

namespace BOJ
{
    static class Input<T>
    {
        public static T GetInput() => ConvertStringToType(Console.ReadLine());
        public static T[] GetInputArray() => Array.ConvertAll(Console.ReadLine().Split(), ConvertStringToType);
        private static T ConvertStringToType(string input) => (T)Convert.ChangeType(input, typeof(T));
    }

    class No_11404
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            
            int n = Input<int>.GetInput();

            int[,] board = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = i == j ? 0 : int.MaxValue;
                }
            }

            int t = Input<int>.GetInput();

            for (int i = 0; i < t; i++)
            {
                var inputs = Input<int>.GetInputArray();
                var a = inputs[0]-1;
                var b = inputs[1]-1;
                var c = inputs[2];
                
                board[a,b] = Math.Min(board[a,b], c);
            }

            Floyd_Warshall(n, board);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i, j] == int.MaxValue)
                    {
                        sb.Append($"0 ");
                    }
                    else
                    {
                        sb.Append($"{board[i, j]} ");    
                    }
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb);
        }
        
        static void Floyd_Warshall(int length, int[,] board) {
            for (int m = 0; m < length; m++)
            {
                for (int s = 0; s < length; s++)
                {
                    for (int e = 0; e < length; e++)
                    {
                        if (board[s, m] != int.MaxValue && board[m, e] != int.MaxValue)
                        {
                            board[s, e] = Math.Min(board[s, e], board[s, m] + board[m, e]);    
                        }
                    }
                }
            }
        }
    }
}