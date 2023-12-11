using System.Text;

namespace BOJ_20920
{
    class Program
    {
        static void Main()
        {
            using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
            
            Dictionary<string, int> dict = new Dictionary<string, int>();
            
            StringBuilder sb = new StringBuilder();

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int n = inputs[0];
            int m = inputs[1];

            for (int i = 0; i < n; i++)
            {
                string s = sr.ReadLine();
 
                if (s.Length < m) continue;

                dict.TryAdd(s, 0);

                dict[s]++;
            }

            var sorted = dict.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key.Length).ThenBy(x => x.Key).ToDictionary(x=>x.Key,x=>x.Value);

            foreach (var item in sorted)
            {
                sb.AppendLine(item.Key);
            }

            sw.Write(sb);
        }
    }
}
