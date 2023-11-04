namespace BOJ_2195
{
    class Program
    {
        static void Main()
        {
            string s = Console.ReadLine();
            string p = Console.ReadLine();

            int answer = 0;

            for(int i = 0 ; i < p.Length ;)
            {
                int maxLength = 0;
                for(int j = 0 ; j < s.Length ; j++)
                {
                    int temp = 0;
                    while(j + temp<s.Length && i + temp < p.Length && s[j + temp] == p[i + temp])
                    {
                        temp++;
                    }
                    maxLength = Math.Max(maxLength, temp);
                }

                i += maxLength;
                answer++;
            }

            Console.WriteLine(answer);
        }
    }
}
