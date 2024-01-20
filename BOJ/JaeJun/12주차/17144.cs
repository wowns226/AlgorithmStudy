using System.Text;  
  
namespace BOJ  
{  
    static class Input<T>  
    {  
        public static T GetInput() => ConvertStringToType(Console.ReadLine());
        public static T[] GetInputArray() => Array.ConvertAll(Console.ReadLine().Split(), Input<T>.ConvertStringToType);

        public static T[,] GetInput2DArray(int r, int c)
        {
            var result = new T[r, c];

            for (int i = 0; i < r; i++)
            {
                var inputs = Input<T>.GetInputArray();
                for (int j = 0; j < c; j++)
                {
                    result[i, j] = inputs[j];
                }
            }
            
            return result;
        }
        
        private static T ConvertStringToType(string input) => (T)Convert.ChangeType(input, typeof(T));  
    }  
      
    class No_17144
    {
        static int R, C;
        static int[,] grid;
        static (int x, int y) airCleanerUp, airCleanerDown;

        static void Main()
        {
            // 입력 처리
            var inputs = Input<int>.GetInputArray();
            R = inputs[0];
            C = inputs[1];
            int T = inputs[2];

            grid = Input<int>.GetInput2DArray(R, C);

            bool isFirstAirCleanerFound = false;
            bool isSecondAirCleanerFound = false;
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (grid[i, j] != -1) continue;
                    
                    if (!isFirstAirCleanerFound)
                    {
                        airCleanerUp = (i, j);
                        isFirstAirCleanerFound = true;
                    }
                    else if (!isSecondAirCleanerFound)
                    {
                        airCleanerDown = (i, j);
                        isSecondAirCleanerFound = true;
                        break;
                    }
                }

                if (isSecondAirCleanerFound)
                    break;
            }
            
            // T번 시뮬레이션 수행
            while (T-- > 0)
            {
                SpreadDust();
                RunAirCleaner();
            }

            // 결과 출력
            int result = CalculateTotalDust();
            Console.WriteLine(result);
        }

        // 미세먼지 확산
        static void SpreadDust()
        {
            int[,] tempGrid = new int[R, C];

            Array.Copy(grid, tempGrid, grid.Length);

            int[] dr = { 1, 0, -1, 0 };
            int[] dc = { 0, 1, 0, -1 };

            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (grid[r, c] <= 0) continue;
                    
                    int spreadAmount = grid[r, c] / 5;

                    for (int i = 0; i < 4; i++)
                    {
                        int nr = r + dr[i];
                        int nc = c + dc[i];

                        if (nr < 0 || nr >= R || nc < 0 || nc >= C) continue;
                        if (grid[nr, nc] == -1) continue;
                        
                        tempGrid[nr, nc] += spreadAmount;
                        tempGrid[r, c] -= spreadAmount;
                    }
                }
            }

            Array.Copy(tempGrid, grid, tempGrid.Length);
        }

        // 공기청정기 작동
        static void RunAirCleaner()
        {
            // 위쪽 공기청정기
            // 왼쪽
            for (int i = airCleanerUp.x - 1; i > 0; i--)
            {
                grid[i, 0] = grid[i - 1, 0];
            }
            // 위
            for (int i = 0; i < C - 1; i++)
            {
                grid[0, i] = grid[0, i + 1];
            }
            // 오른쪽
            for (int i = 1; i <= airCleanerUp.x; i++)
            {
                grid[i - 1, C - 1] = grid[i, C - 1];
            }
            // 아래
            for (int i = C - 1; i > 1; i--)
            {
                grid[airCleanerUp.x, i] = grid[airCleanerUp.x, i - 1];
            }

            grid[airCleanerUp.x, 1] = 0;

            // 아래쪽 공기청정기
            // 왼쪽
            for (int i = airCleanerDown.x + 1; i < R - 1; i++)
            {
                grid[i, 0] = grid[i + 1, 0];
            }
            // 아래
            for (int i = 0; i < C - 1; i++)
            {
                grid[R - 1, i] = grid[R - 1, i + 1];
            }
            // 오른쪽
            for (int i = R - 1; i >= airCleanerDown.x; i--)
            {
                grid[i, C - 1] = grid[i - 1, C - 1];
            }
            // 위
            for (int i = C - 1; i > 1; i--)
            {
                grid[airCleanerDown.x, i] = grid[airCleanerDown.x, i - 1];
            }

            grid[airCleanerDown.x, 1] = 0;
        }

        // 총 미세먼지 양 계산
        static int CalculateTotalDust()
        {
            int totalDust = 0;

            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (grid[r, c] > 0)
                    {
                        totalDust += grid[r, c];
                    }
                }
            }

            return totalDust;
        }
    }
}