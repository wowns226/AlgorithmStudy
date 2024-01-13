namespace BOJ
{    
    class No_1107
    {
        static void Main()
        {
            int curChannel = 100;
            int n = InputInt();
            
            int m =  InputInt();
            // 고장난 버튼이 없을 경우
            // 타겟채널의 길이와 현재 채널의 차이 중 작은 것을 출력
            if (m == 0)
            {
                Console.WriteLine($"{Math.Min(n.ToString().Length, Math.Abs(n - curChannel))}");

                return;
            }

            List<int> buttonList = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var errorButtons = InputArray();
            
            // 타겟채널이 현재채널일 경우
            // 0을 출력
            if (n == curChannel)
            {
                Console.WriteLine("0");

                return;
            }
            
            for (int i = 0; i < m; i++)
            {
                buttonList[errorButtons[i]] = 1;
            }

            int minPressCount = GetMinPressCount(n, curChannel, buttonList);

            Console.WriteLine(minPressCount);
        }

        static int GetMinPressCount(int n, int curChannel, List<int> buttonList)
        {
            int minPressCount = Math.Abs(n - curChannel);

            for (int i = 0; i <= 1_000_000; i++)
            {
                if (IsNotErrorButton(i, buttonList) == false) continue;

                int pressCount = Math.Abs(n - i) + i.ToString().Length;
                minPressCount = Math.Min(pressCount, minPressCount);
            }

            return minPressCount;
        }

        static bool IsNotErrorButton(int channel, List<int> buttonList) => channel.ToString().All(t => buttonList[t - '0'] != 1);
        static int InputInt() => int.Parse(Console.ReadLine());
        static int[] InputArray() => Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    }
}
