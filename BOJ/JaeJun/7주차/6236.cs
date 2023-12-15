using System.Text;

namespace BOJ_6236
{
    class Program
    {
        static void Main()
        {
            using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            StringBuilder sb = new StringBuilder();

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0];
            int M = inputs[1];

            List<int> payTodayList = new List<int>();

            for (int i = 0; i < N; i++)
            {
                int pay = int.Parse(sr.ReadLine());
                
                payTodayList.Add(pay);
            }
            
            sw.Write(BinarySearch(M, payTodayList));
            
            sr.Close(); sw.Flush(); sw.Close();
        }

        static int BinarySearch(int maxCount, List<int> list)
        {
            int start = 0;
            int end = int.MaxValue;
            int answer = 0;

            while (start <= end)
            {
                int mid = (start + end) >> 1;
                
                int leftMoney = 0;
                int count = 0;
                bool can = true;
                for (int j = 0; j < list.Count; j++)
                {
                    // list[j] : j날 사용하는 금액 (일일 금액)
                    
                    // 일일 금액이 mid보다 크다면
                    if (list[j] > mid)
                    {
                        // 절대 인출할 수 없는 금액이기 때문에
                        // start값을 증가시켜야함
                        can = false;
                        break;
                    }
                    
                    // 일일금액보다 소지량이 적다면
                    if (leftMoney < list[j])
                    {
                        // 소지량은 입금 mid만큼 출금
                        leftMoney = mid;
                        count++;
                    }

                    leftMoney -= list[j];
                }

                if (can == true)
                {
                    // 출금횟수가 M보다 작거나 같으면
                    if (count <= maxCount)
                    {
                        answer = mid;
                        end = mid - 1;
                    }
                    // 출금횟수가 M보다 크면
                    else
                    {
                        start = mid + 1;
                    }
                }
                else
                {
                    // 출금횟수가 M보다 작은 경우
                    
                    start = mid + 1;
                }
            }

            return answer;
        }
    }
}

