namespace BOJ
{    
    class No_16928
    {
        static void Main()
        {
            int[] inputs = InputArray();
            int n = inputs[0];
            int m = inputs[1];
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < n + m; i++)
            {
                inputs = InputArray();

                dict.TryAdd(inputs[0], inputs[1]);
            }

            int[] dist = new int[101];

            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            
            while (q.Count > 0)
            {
                var cur = q.Dequeue();

                if (cur == 100)
                {
                    break;
                }

                for (int dir = 1; dir < 7; dir++)
                {
                    var next = cur + dir;

                    if (dict.TryGetValue(next, out int value))
                    {
                        next = value;
                    }

                    if (next > 100 || dist[next] != 0) continue;

                    q.Enqueue(next);
                    dist[next] = dist[cur] + 1;
                }
            }
            
            Console.Write($"{dist[100]}");
        }
        
        static int[] InputArray() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    }
}
