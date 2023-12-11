using System.Text;

namespace BOJ_19637
{
    class Program
    {
        static void Main()
        {
            using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            StringBuilder sb = new StringBuilder();

            List<(string, int)> list = new List<(string, int)>();

            string[] inputs = sr.ReadLine().Split();
            int n = int.Parse(inputs[0]);
            int m = int.Parse(inputs[1]);

            for (int i = 0; i < n; i++)
            {
                inputs = sr.ReadLine().Split();

                list.Add((inputs[0], int.Parse(inputs[1])));
            }

            for (int i = 0; i < m; i++)
            {
                int att = int.Parse(sr.ReadLine());

                sb.AppendLine(BinarySearch(att, list));
            }

            sw.Write(sb);
        }

        static string BinarySearch(int target, List<(string, int)> list)
        {
            int start = 0;
            int end = list.Count - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (list[mid].Item2 < target)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return list[start].Item1;
        }
    }
}
