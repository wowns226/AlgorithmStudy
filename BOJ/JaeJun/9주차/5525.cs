namespace BOJ
{
    class No_5525
    {
        const char CHAR_I = 'I';
        const char CHAR_O = 'O';
        
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            
            int answer = 0;
            for (int i = 0; i < m - 2 * n; i++)
            {
                if(s[i] == CHAR_O) continue;

                int cnt = 0;
                while (i < m - 2 && s[i + 1] == CHAR_O && s[i + 2] == CHAR_I)
                {
                    cnt++;
                    if (cnt == n)
                    {
                        answer++;
                        cnt--;
                    }

                    i += 2;
                }
            }

            Console.WriteLine(answer);
        }
    }   
}
