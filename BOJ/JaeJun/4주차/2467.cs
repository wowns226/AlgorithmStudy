namespace BOJ_2467
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            var answer = FindClosestToZero(inputs);

            Console.WriteLine($"{answer.Item1} {answer.Item2}");
        }

        static (int, int) FindClosestToZero(int[] inputs)
        {
            int left = 0;
            int right = inputs.Length - 1;

            int closestSum = int.MaxValue;
            int resultLeft = 0;
            int resultRight = 0;

            while (left < right)
            {
                int sum = inputs[left] + inputs[right];

                // 현재 합의 절대값이 이전까지의 최솟값보다 작으면 갱신
                if (Math.Abs(sum) < closestSum)
                {
                    closestSum = Math.Abs(sum);
                    resultLeft = inputs[left];
                    resultRight = inputs[right];
                }

                // 합이 0보다 작으면 왼쪽 인덱스를 증가, 크면 오른쪽 인덱스를 감소
                if (sum < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            
            return (resultLeft, resultRight);
        }
    }
}
