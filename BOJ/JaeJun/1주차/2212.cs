namespace BOJ_2212
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Array.Sort(inputs);
            List<int> list = new List<int>();
            for (int i = 0; i < n - 1; i++)
            {
                list.Add(Math.Abs(inputs[i] - inputs[i + 1]));
            }
            var answer = list.OrderBy(x => x).Take(n - k).Sum();
            Console.WriteLine(answer);
        }
    }
}
