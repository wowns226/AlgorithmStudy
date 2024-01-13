using System.Text;

namespace BOJ
{
    class No_5430
    {        
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            int testCase = InputToInt();

            while (testCase-- > 0)
            {
                bool reverse = false;
                
                bool flag = true;
                string s = Input();
                int n = InputToInt();
                string temp = Input();
                temp = temp.Substring(1, temp.Length - 2);
                var list = n == 0 ? new List<int>() : Array.ConvertAll(temp.Split(','), int.Parse).ToList();

                int dequeCount = 0;
                int start = 0;
                int end = list.Count - 1;

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == 'R')
                    {
                        reverse = !reverse;
                    }
                    else
                    {
                        dequeCount++;
                        
                        if (dequeCount > list.Count)
                        {
                            flag = false;
                            
                            break;
                        }

                        if (reverse == true)
                        {
                            end--;
                        }
                        else
                        {
                            start++;
                        }
                    }
                }

                if (flag == true)
                {
                    sb.Append('[');
                    if (reverse == true)
                    {
                        for (int i = end; i >= start; i--)
                        {
                            if (i == start)
                            {
                                sb.Append($"{list[i]}");   
                            }
                            else
                            {
                                sb.Append($"{list[i]},");    
                            }
                        }
                    }
                    else
                    {
                        for (int i = start; i <= end; i++)
                        {
                            if (i == end)
                            {
                                sb.Append($"{list[i]}");   
                            }
                            else
                            {
                                sb.Append($"{list[i]},");    
                            }
                        }
                    }
                    sb.Append(']');
                    sb.AppendLine();
                }
                else
                {
                    sb.AppendLine("error");
                }
            }

            Console.Write(sb);
        }
        
        static int InputToInt() => int.Parse(Console.ReadLine());
        static string Input() => Console.ReadLine();
    }
}