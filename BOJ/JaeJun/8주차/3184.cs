namespace BOJ_3184
{
    class Program
    {
        static Queue<(int, int)> q = new Queue<(int, int)>();
        static int[] dx = { 1, 0, -1, 0 };
        static int[] dy = { 0, 1, 0, -1 };
        static int sheepCount = 0;
        static int wolfCount = 0;
        
        static void Main()
        {
            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int R = inputs[0];
            int C = inputs[1];

            char[,] board = new char[R, C];

            for (int i = 0; i < R; i++)
            {
                string s = Console.ReadLine();
                for (int j = 0; j < C; j++)
                {
                    board[i, j] = s[j];
                }
            }
            
            bool[,] visited = new bool[R, C];
            
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if(visited[i,j] == true) continue;
                    
                    BFS(i, j, board, visited);
                }
            }
            
            Console.Write($"{sheepCount} {wolfCount}");
        }

        static void BFS(int a, int b, char[,] board, bool[,] visited)
        {
            int sheep = 0;
            int wolf = 0;

            q.Enqueue((a, b));
            visited[a, b] = true;

            while (q.Count > 0)
            {
                var cur = q.Dequeue();
                int x = cur.Item1;
                int y = cur.Item2;

                if (board[x, y] == 'v') wolf++;
                else if (board[x, y] == 'o') sheep++;

                for (int dir = 0; dir < 4; dir++)
                {
                    int nx = x + dx[dir];
                    int ny = y + dy[dir];

                    if (nx < 0 || ny < 0 || nx >= board.GetLength(0) || ny >= board.GetLength(1)) continue;
                    if (visited[nx, ny] == true) continue;
                    if (board[nx, ny] == '#') continue;

                    q.Enqueue((nx, ny));
                    visited[nx, ny] = true;
                }
            }

            if (wolf >= sheep) wolfCount += wolf;
            else sheepCount += sheep;
        }
    }
}
