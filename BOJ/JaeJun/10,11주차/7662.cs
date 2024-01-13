using System.Text;

namespace BOJ
{
    class No_7662
    {
        public class DoublePriorityQueue
        {
            private PriorityQueue<int, int> minQueue;
            private PriorityQueue<int, int> maxQueue;
            private Dictionary<int, int> entries;
            public DoublePriorityQueue()
            {
                minQueue = new PriorityQueue<int, int>();
                maxQueue = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
                entries = new Dictionary<int, int>();
            }

            public bool IsEmpty() => entries.Count == 0;
            
            public int? GetMin()
            {
                while (minQueue.Count > 0 && !entries.ContainsKey(minQueue.Peek()))
                {
                    minQueue.Dequeue();
                }
                return minQueue.Count > 0 ? minQueue.Peek() : null;
            }
    
            public int? GetMax()
            {
                while (maxQueue.Count > 0 && !entries.ContainsKey(maxQueue.Peek()))
                {
                    maxQueue.Dequeue();
                }
                return maxQueue.Count > 0 ? maxQueue.Peek() : null;
            }
    
            public void DequeueMin()
            {
                if (IsEmpty()) return;
                int? value = GetMin();
                removeFromEntry(value);
            }
            
            public void DequeueMax()
            {
                if (IsEmpty()) return;
                int? value = GetMax();
                removeFromEntry(value);
            }
    
            private void removeFromEntry(int? element)
            {
                if (!element.HasValue) return;
                
                int elementI = element.Value;
                if (entries[elementI] > 1)
                {
                    entries[elementI]--;
                }
                else
                {
                    entries.Remove(elementI);
                }
            }
            public void Enqueue(int x)
            {
                if (entries.ContainsKey(x))
                {
                    entries[x]++;
                }
                else
                {
                    entries.Add(x, 1);
                    minQueue.Enqueue(x, x);
                    maxQueue.Enqueue(x, x);
                }
            }
        }
        
        static void Main()
        {
            int testCaseNum = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
    
            for (int i = 0; i < testCaseNum; i++)
            {
                DoublePriorityQueue pq = new DoublePriorityQueue();
                int operationNum = int.Parse(Console.ReadLine());
                for (int j = 0; j < operationNum; j++)
                {
                    string[] inputs = Console.ReadLine().Split();
                    string operation = inputs[0];
                    if (operation == "I")
                    {
                        int x = int.Parse(inputs[1]);
                        pq.Enqueue(x);
                    }
                    else if (operation == "D")
                    {
                        int x = int.Parse(inputs[1]);
                        if (x == 1)
                        {
                            pq.DequeueMax();
                        }
                        else if (x == -1)
                        {
                            pq.DequeueMin();
                        }
                    }
                }
    
                int? max = pq.GetMax();
                int? min = pq.GetMin();
    
                if (max.HasValue && min.HasValue)
                {
                    sb.AppendLine($"{max.Value} {min.Value}");
                }
                else
                {
                    sb.AppendLine("EMPTY");
                }
            }
            
            Console.Write(sb);
        }
    }
}