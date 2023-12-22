using System.Collections;

namespace BOJ_1303
{
    class Program
    {
        static void Main()
        {
            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int m = inputs[0];
            int n = inputs[1];

            char[,] board = new char[n, m];
            
            int white = 0;
            int black = 0;

            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    board[i, j] = s[j];
                }
            }
            
            bool[,] visited = new bool[n, m];
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (visited[i, j] != false) continue;
                    
                    if (board[i, j] == 'B')
                    {
                        black += BFS(i, j, board, visited);
                    }
                    else
                    {
                        white += BFS(i, j, board, visited);
                    }
                }
            }
            
            Console.WriteLine($"{white} {black}");
        }

        static int BFS(int a, int b, char[,] board, bool[,] visited)
        {
            int count = 1;
            
            Queue<(int, int)> q = new Queue<(int, int)>();
            int[] dx = { 1, 0, -1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            q.Enqueue((a, b));
            visited[a, b] = true;

            while (q.Count > 0)
            {
                var cur = q.Dequeue();
                int x = cur.Item1;
                int y = cur.Item2;

                for (int dir = 0; dir < 4; dir++)
                {
                    int nx = x + dx[dir];
                    int ny = y + dy[dir];
                    
                    if(nx<0||ny<0||nx>=board.GetLength(0)|| ny>=board.GetLength(1)) continue;
                    if (board[x, y] != board[nx, ny]) continue;
                    if (visited[nx, ny] == true) continue;

                    count++;

                    q.Enqueue((nx, ny));
                    visited[nx, ny] = true;
                }
            }

            return (int)Math.Pow(count, 2);
        }
    }
}
