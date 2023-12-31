using System.Text;

namespace BOJ
{
    class No_6064
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            int t = int.Parse(Console.ReadLine());

            while (t-- > 0)
            {
                int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                int m = inputs[0];
                int n = inputs[1];
                int x = inputs[2];
                int y = inputs[3];

                int count = x % (m + 1);
                int tempY = x;

                for (int i = 0; i < n; i++)
                {
                    int ty = tempY % n == 0 ? n : tempY % n;
                    if (ty == y)
                    {
                        break;
                    }

                    tempY = ty + m;
                    count += m;
                }

                int answer = count > LCM(m, n) ? -1 : count;
                sb.AppendLine($"{answer}");
            }

            Console.WriteLine(sb);
        }

        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }

            return a;
        }

        static int LCM(int a, int b)
        {
            return a * b / GCD(a, b);
        }
    }   
}
