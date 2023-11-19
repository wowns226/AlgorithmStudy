using System.Text;

namespace BOJ_5073
{
    class Program
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                Array.Sort(inputs);
                
                int a = inputs[0];
                int b = inputs[1];
                int c = inputs[2];
                
                if (inputs.All(x => x == 0))
                {
                    break;
                }

                if (IsTriangle(a, b, c))
                {
                    if (a == b && b == c)
                    {
                        sb.AppendLine("Equilateral");
                    }
                
                    else if (a == b || b == c || c == a)
                    {
                        sb.AppendLine("Isosceles");
                    }

                    else
                    {
                        sb.AppendLine("Scalene");
                    }
                }
                else
                {
                    sb.AppendLine("Invalid");
                }
            }

            Console.Write(sb);
        }

        static bool IsTriangle(int a, int b, int c) => a + b > c;
    }
}
