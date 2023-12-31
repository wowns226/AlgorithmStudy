using System.Text;

namespace BOJ
{
    public class PriorityQueue<T>
    {
        private List<T> data;
        private Func<T, T, int> comparer;

        public int Count => data.Count;
        public T Peek() => data[0];

        public bool IsEmpty() => data.Count == 0;

        public PriorityQueue()
        {
            data = new List<T>();
            comparer = Comparer<T>.Default.Compare;
        }

        public PriorityQueue(Func<T, T, int> customComparer)
        {
            data = new List<T>();
            comparer = customComparer;
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            int currentIndex = data.Count - 1;

            while (currentIndex > 0)
            {
                int parentIndex = (currentIndex - 1) / 2;
                if (comparer(data[currentIndex], data[parentIndex]) >= 0)
                    break;

                SwapElements(currentIndex, parentIndex);
                currentIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            int lastIndex = data.Count - 1;
            T frontItem = data[0];
            data[0] = data[lastIndex];
            data.RemoveAt(lastIndex);

            lastIndex--;
            int parentIndex = 0;

            while (true)
            {
                int leftChildIndex = parentIndex * 2 + 1;

                if (leftChildIndex > lastIndex)
                    break;

                int rightChildIndex = leftChildIndex + 1;
                if (rightChildIndex <= lastIndex && comparer(data[rightChildIndex], data[leftChildIndex]) < 0)
                    leftChildIndex = rightChildIndex;

                if (comparer(data[parentIndex], data[leftChildIndex]) <= 0)
                    break;

                SwapElements(parentIndex, leftChildIndex);
                parentIndex = leftChildIndex;
            }

            return frontItem;
        }

        private void SwapElements(int index1, int index2) => (data[index1], data[index2]) = (data[index2], data[index1]);
    }
    
    class No_11286
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            int N = int.Parse(Console.ReadLine());
            
            // 1. 0이 아닌 숫자를 입력받으면 container에 넣는다.
            // 2. 0을 입력받으면
            // 2-1. 현재 container 내부의 수 들중에서 절댓값이 가장 작은 값을 꺼낸다.
            // 2-2. 절댓값이 가장 작은 값이 여러개일 경우, 값이 작은 값을 출력
            var absHeap = new PriorityQueue<int>((x, y) => Math.Abs(x) == Math.Abs(y) ? x.CompareTo(y) : Math.Abs(x).CompareTo(Math.Abs(y)));

            for (int i = 0; i < N; i++)
            {
                int x = int.Parse(Console.ReadLine());

                if (x != 0)
                {
                    // x가 0이 아니라면 배열에 x를 추가
                    absHeap.Enqueue(x);
                }
                else
                {
                    // x가 0이라면 절댓값이 가장 작은 값을 출력하고 배열에서 제거
                    if (absHeap.IsEmpty())
                    {
                        sb.AppendLine("0");
                    }
                    else
                    {
                        int minValue = absHeap.Dequeue();
                        sb.AppendLine($"{minValue}");
                    }
                }
            }

            Console.Write(sb);
        }
    }
    
    
}