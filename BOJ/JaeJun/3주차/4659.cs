using System.Text;

namespace BOJ_4659
{
    class Program
    {
        static void Main()
        {
            char[] vowel = { 'a', 'e', 'i', 'o', 'u' };
            bool flag = true;

            string s = string.Empty;
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                s = Console.ReadLine();
                bool[] word = new bool[s.Length]; // true : 모음, false : 자음 
                flag = true;
                
                if (s == "end")
                {
                    break;
                }

                for (int i = 0; i < s.Length; i++)
                {
                    for (int v = 0; v < vowel.Length; v++)
                    {
                        if (s[i] == vowel[v])
                        {
                            word[i] = true;
                        }
                    }
                }

                for (int i = 0; i < word.Length; i++)
                {
                    //같은 글자가 연속적으로 두번 오면 안되나, ee 와 oo는 허용한다.
                    if (word.Length >= 2 && i < s.Length - 1)
                    {
                        if (s[i] == s[i + 1])
                        {
                            if(s[i] == 'e' || s[i] == 'o') continue;
                            
                            flag = false;
                        }
                    }
                    
                    //모음이 3개 혹은 자음이 3개 연속으로 오면 안 된다.
                    if (word.Length >= 3 && i < s.Length - 2)
                    {
                        if (word[i] == word[i + 1] && word[i + 1] == word[i + 2])
                        {
                            flag = false;
                        }
                    }
                }

                //모음(a,e,i,o,u) 하나를 반드시 포함하여야 한다. => 전부 자음인 경우
                if (word.All(x => x == false))
                {
                    flag = false;
                }

                sb.AppendLine(flag ? $"<{s}> is acceptable." : $"<{s}> is not acceptable.");
            }

            Console.Write(sb);
        }
    }
}
