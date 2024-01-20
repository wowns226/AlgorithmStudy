namespace BOJ
{
    static class Input<T>  
    {
        public static T[] GetInputArray() => Array.ConvertAll(Console.ReadLine().Split(), ConvertStringToType);
        private static T ConvertStringToType(string input) => (T)Convert.ChangeType(input, typeof(T));
    }
    
    class FireBall
    {
        public int row, col, mass, speed, direction;

        public FireBall(int r, int c, int m, int s, int d)
        {
            row = r;
            col = c;
            mass = m;
            speed = s;
            direction = d;
        }
    }
    
    class Point
    {
        public List<FireBall> fireballs;
        
        public Point()
        {
            fireballs = new List<FireBall>();
        }

        public void AddFireBall(FireBall fireBall)
        {
            fireballs.Add(fireBall);
        }
    }

    class No_20056
    {
        static int N, M, K;
        static Point[,] board;
        static int[] dx = { -1, -1, 0, 1, 1, 1, 0, -1 };
        static int[] dy = { 0, 1, 1, 1, 0, -1, -1, -1 };

        static void Main()
        {
            var inputs = Input<int>.GetInputArray();

            N = inputs[0];
            M = inputs[1];
            K = inputs[2];

            board = new Point[N + 1, N + 1];

            for (int i = 0; i < M; i++)
            {
                inputs = Input<int>.GetInputArray();
                int r = inputs[0];
                int c = inputs[1];
                int m = inputs[2];
                int s = inputs[3];
                int d = inputs[4];

                FireBall fireBall = new FireBall(r, c, m, s, d);
                if (board[r, c] == null)
                    board[r, c] = new Point();
                board[r, c].AddFireBall(fireBall);
            }

            // K번 이동
            for (int i = 0; i < K; i++)
            {
                MoveFireBalls();
                MergeFireBalls();
            }

            // 남아있는 파이어볼 질량의 합 출력
            int result = GetRemainingMass();
            Console.WriteLine(result);
        }    
        static void MoveFireBalls()
        {
            // 이동한 위치에 새로 파이어볼 추가
            Point[,] newBoard = new Point[N + 1, N + 1];

            for (int r = 1; r <= N; r++)
            {
                for (int c = 1; c <= N; c++)
                {
                    if (board[r, c] != null)
                    {
                        foreach (FireBall fireBall in board[r, c].fireballs)
                        {
                            int nr = (r + (fireBall.speed % N) * dx[fireBall.direction] + N - 1) % N + 1;
                            int nc = (c + (fireBall.speed % N) * dy[fireBall.direction] + N - 1) % N + 1;

                            if (newBoard[nr, nc] == null)
                                newBoard[nr, nc] = new Point();

                            newBoard[nr, nc].AddFireBall(fireBall);
                        }
                    }
                }
            }

            board = newBoard;
        }

        static void MergeFireBalls()
        {
            // 2개 이상의 파이어볼이 있는 칸에서 합치기
            for (int r = 1; r <= N; r++)
            {
                for (int c = 1; c <= N; c++)
                {
                    if (board[r, c] == null || board[r, c].fireballs.Count < 2) continue;
                    
                    List<FireBall> mergedFireBalls = new List<FireBall>();
                    int totalMass = 0, totalSpeed = 0, oddCount = 0, evenCount = 0;

                    foreach (FireBall fireBall in board[r, c].fireballs)
                    {
                        totalMass += fireBall.mass;
                        totalSpeed += fireBall.speed;

                        if (fireBall.direction % 2 == 0)
                            evenCount++;
                        else
                            oddCount++;
                    }

                    int newMass = totalMass / 5;
                    int newSpeed = totalSpeed / board[r, c].fireballs.Count;

                    if (newMass > 0)
                    {
                        if (oddCount == 0 || evenCount == 0)
                        {
                            for (int d = 0; d < 4; d++)
                            {
                                mergedFireBalls.Add(new FireBall(r, c, newMass, newSpeed, d * 2));
                            }
                        }
                        else
                        {
                            for (int d = 1; d < 8; d += 2)
                            {
                                mergedFireBalls.Add(new FireBall(r, c, newMass, newSpeed, d));
                            }
                        }
                    }

                    board[r, c].fireballs = mergedFireBalls;
                }
            }
        }

        static int GetRemainingMass()
        {
            int result = 0;
            for (int r = 1; r <= N; r++)
            {
                for (int c = 1; c <= N; c++)
                {
                    if (board[r, c] != null)
                    {
                        result += board[r, c].fireballs.Sum(fireBall => fireBall.mass);
                    }
                }
            }
            return result;
        }
    }
}