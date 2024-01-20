namespace BOJ
{
    public class Input<T>
    {
        public static T GetInput() => ConvertStringToType(Console.ReadLine());
        public static T[] GetInputArray() => Array.ConvertAll(Console.ReadLine().Split(), Input<T>.ConvertStringToType);
        private static T ConvertStringToType(string input) => (T)Convert.ChangeType(input, typeof(T));
    }
    
    class No_1967
    {
        static void Main()
        {
            int nodeCount = Input<int>.GetInput();

            Dictionary<int, List<(int, int)>> graph = new Dictionary<int, List<(int, int)>>();

            for (int i = 0; i < nodeCount; i++)
            {
                graph[i] = new List<(int, int)>();
            }

            for (int i = 0; i < nodeCount - 1; i++)
            {
                int[] arr = Input<int>.GetInputArray();
                int parent = arr[0] - 1;
                int child = arr[1] - 1;
                int weight = arr[2];

                graph[parent].Add((child, weight));
                graph[child].Add((parent, weight));
            }

            int diameter = FindDiameter(graph, nodeCount);
            Console.WriteLine(diameter);
        }

        static int FindDiameter(Dictionary<int, List<(int, int)>> graph, int nodeCount)
        {
            int diameter = 0;

            for (int i = 0; i < nodeCount; i++)
            {
                int pathLength = GetPathLength(i, graph, nodeCount);
                diameter = Math.Max(diameter, pathLength);
            }

            return diameter;
        }

        static int GetPathLength(int startNode, Dictionary<int, List<(int, int)>> graph, int nodeCount)
        {
            int[] distance = new int[nodeCount];
            bool[] visited = new bool[nodeCount];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited[startNode] = true;

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                foreach ((int neighbor, int weight) in graph[current])
                {
                    if (!visited[neighbor])
                    {
                        queue.Enqueue(neighbor);
                        visited[neighbor] = true;
                        distance[neighbor] = distance[current] + weight;
                    }
                }
            }

            return distance.Max();
        }
    }
}