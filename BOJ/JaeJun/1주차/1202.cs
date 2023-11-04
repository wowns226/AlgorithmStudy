using System;
using System.Collections.Generic;

class Jewel : IComparable<Jewel>
{
    public int M { get; set; }
    public int V { get; set; }

    public Jewel(int m, int v)
    {
        M = m;
        V = v;
    }

    public int CompareTo(Jewel other)
    {
        return M - other.M;
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int K = int.Parse(input[1]);

        List<Jewel> jewels = new List<Jewel>();
        for(int i = 0 ; i < N ; i++)
        {
            input = Console.ReadLine().Split();
            jewels.Add(new Jewel(int.Parse(input[0]), int.Parse(input[1])));
        }

        List<int> bag = new List<int>();
        for(int i = 0 ; i < K ; i++)
        {
            bag.Add(int.Parse(Console.ReadLine()));
        }

        jewels.Sort();
        bag.Sort();

        PriorityQueue<int> pq = new PriorityQueue<int>();

        long sum = 0;
        int temp = 0;
        for(int i = 0 ; i < K ; i++)
        {
            for(int j = temp ; j < N ; j++)
            {
                if(jewels[j].M <= bag[i])
                {
                    pq.Enqueue(-jewels[j].V);
                    temp++;
                }
                else
                {
                    break;
                }
            }
            if(!pq.IsEmpty())
            {
                sum += Math.Abs(pq.Dequeue());
            }
        }
        Console.WriteLine(sum);
    }
}

public class PriorityQueue<T>
{
    private List<T> data;
    private Func<T, T, int> comparer;

    public PriorityQueue()
    {
        this.data = new List<T>();
        this.comparer = Comparer<T>.Default.Compare;
    }

    public PriorityQueue(Func<T, T, int> comparer)
    {
        this.data = new List<T>();
        this.comparer = comparer;
    }

    public void Enqueue(T item)
    {
        data.Add(item);
        int ci = data.Count - 1;
        while(ci > 0)
        {
            int pi = (ci - 1) / 2;
            if(comparer(data[ci], data[pi]) >= 0)
                break;
            T tmp = data[ci];
            data[ci] = data[pi];
            data[pi] = tmp;
            ci = pi;
        }
    }

    public T Dequeue()
    {
        if(data.Count == 0)
            throw new InvalidOperationException("Priority queue is empty.");
        int li = data.Count - 1;
        T frontItem = data[0];
        data[0] = data[li];
        data.RemoveAt(li);

        --li;
        int pi = 0;
        while(true)
        {
            int ci = pi * 2 + 1;
            if(ci > li) break;
            int rc = ci + 1;
            if(rc <= li && comparer(data[rc], data[ci]) < 0)
                ci = rc;
            if(comparer(data[pi], data[ci]) <= 0)
                break;
            T tmp = data[pi];
            data[pi] = data[ci];
            data[ci] = tmp;
            pi = ci;
        }
        return frontItem;
    }

    public T Peek()
    {
        if(data.Count == 0)
            throw new InvalidOperationException("Priority queue is empty.");
        return data[0];
    }

    public int Count
    {
        get { return data.Count; }
    }

    public bool IsEmpty()
    {
        return data.Count == 0;
    }
}
