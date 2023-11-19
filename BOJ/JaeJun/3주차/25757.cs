namespace BOJ_25757
{
    class Program
    {
        static void Main()
        {
            string[] inputs = Console.ReadLine().Split();
            int n = int.Parse(inputs[0]);
            string gameMode = inputs[1];
            int answer = 0;

            HashSet<string> participantList = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string participant = Console.ReadLine();

                participantList.Add(participant);
            }

            switch (gameMode)
            {
                case "Y":
                    answer = participantList.Count;

                    break;
                case "F":
                    answer = (int)Math.Floor((double)participantList.Count/2);
                    
                    break;
                
                case "O":
                    answer = (int)Math.Floor((double)participantList.Count/3);

                    break;
            }

            Console.WriteLine(answer);
        }
    }
}
