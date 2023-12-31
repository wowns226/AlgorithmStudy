namespace BOJ
{
    class No_1389
    {
        static void Main()
        {
            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int n = inputs[0];
            int m = inputs[1];
            
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            for (int i = 0; i < m; i++)
            {
                inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int a = inputs[0]-1;
                int b = inputs[1]-1;

                AddFriend(a, b, dict);
            }

            int answer = 0;
            int count = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                int cnt = CalculateFriendDistance(i, n, dict);

                if (count <= cnt) continue;
                
                count = cnt;
                answer = i + 1;
            }

            Console.WriteLine(answer);
        }

        static int CalculateFriendDistance(int task, int n, Dictionary<int, List<int>> dict)
        {
            int[] array = new int[n];

            if (dict.ContainsKey(task) != true) return 0;
            
            foreach (var item in dict[task])
            {
                array[item] = 1;

                UpdateChildDistances(task, item, array, dict, 2);
            }

            return array.Sum();
        }

        static void UpdateChildDistances(int parent, int task, int[] array, Dictionary<int, List<int>> dict, int depth)
        {
            foreach (var item in dict[task])
            {
                if (item == parent)
                {
                    continue;
                }
                
                if (array[item] != 0 && array[item] <= depth)
                {
                    continue;
                }

                array[item] = depth;

                UpdateChildDistances(parent, item, array, dict, depth + 1);
            }
        }

        static void AddFriend(int a, int b, Dictionary<int, List<int>> dict)
        {
            dict.TryAdd(a, new List<int>());
            dict.TryAdd(b, new List<int>());

            dict[a].Add(b);
            dict[b].Add(a);
        }
    }   
}