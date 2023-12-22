using System.Text;

namespace BOJ
{
    class No_2580
    {
        const int MAX_BOARD_COUNT = 9;
        const int SUM_FROM_ONE_TO_NINE = 45;

        static bool flag = false;
        
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            List<(int, int)> list = new List<(int, int)>();

            int[,] board = new int[MAX_BOARD_COUNT, MAX_BOARD_COUNT];

            for (int i = 0; i < MAX_BOARD_COUNT; i++)
            {
                int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (int j = 0; j < MAX_BOARD_COUNT; j++)
                {
                    board[i, j] = inputs[j];

                    if (board[i, j] == 0)
                    {
                        list.Add((i, j));
                    }
                }
            }
            
            FindBlank(0, board, list);

            for (int i = 0; i < MAX_BOARD_COUNT; i++)
            {
                for (int j = 0; j < MAX_BOARD_COUNT; j++)
                {
                    sb.Append($"{board[i, j]} ");
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb);
        }

        static void FindBlank(int depth, int[,] board, List<(int, int)> list)
        {
            if (depth == list.Count)
            {
                flag = true;
                return;
            }
            
            var cur = list[depth];

            for (int num = 1; num <= MAX_BOARD_COUNT; num++)
            {
                if (IsExistInRow(num, cur.Item1, board)
                    || IsExistInCol(num, cur.Item2, board)
                    || IsExistInBox(num, cur.Item1, cur.Item2, board))
                {
                    continue;
                }
                
                board[cur.Item1, cur.Item2] = num;
                FindBlank(depth + 1, board, list);

                if (flag == true)
                {
                    return;
                }
            }

            board[cur.Item1, cur.Item2] = 0;
        }

        static bool IsExistInRow(int num, int line, int[,] board)
        {
            for (int i = 0; i < MAX_BOARD_COUNT; i++)
            {
                if(num == board[line, i])
                {
                    return true;
                }
            }

            return false;
        }

        static bool IsExistInCol(int num, int line, int[,] board)
        {
            for (int i = 0; i < MAX_BOARD_COUNT; i++)
            {
                if (num == board[i, line])
                {
                    return true;
                }
            }

            return false;
        }

        static bool IsExistInBox(int num, int x, int y, int[,] board)
        {
            int tx = (x / 3) * 3;
            int ty = (y / 3) * 3;

            for (int i = tx; i < tx + 3; i++)
            {
                for (int j = ty; j < ty + 3; j++)
                {
                    if (num == board[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }   
}