using System.Text;

namespace BOJ_1244
{ 
    class Program
    {
        private static int[] switches;
        
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            switches = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                switches[i] = inputs[i-1];
            }
            
            int studentCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < studentCount; i++)
            {
                inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                if (inputs[0] == 1)
                {
                    Male(inputs[1]);
                }
                else
                {
                    Female(inputs[1]);
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                sb.Append($"{switches[i]} ");

                if (i % 20 == 0)
                {
                    sb.AppendLine();
                }
            }

            Console.WriteLine(sb.ToString());
        }

        static void Change(int index)
        {
            if (switches[index] == 1)
            {
                switches[index] = 0;
            }
            else
            {
                switches[index] = 1;   
            }
        }
                        
        static void Male(int num)
        {
            int index = num;

            for (int i = index; i < switches.Length; i += num)
            {
                Change(i);
            }
        }

        static void Female(int num)
        {
            int index = num;

            int right = index + 1;
            int left = index - 1;

            while (right < switches.Length && left >= 1)
            {
                if (switches[left] != switches[right]) break;
                
                Change(left);
                Change(right);

                right += 1;
                left -= 1;
            }

            Change(index);
        }
    }
}
