namespace SoloLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 0, 0, 0, 0 };

            int[,] mtx = new int[5,5];

            int count = 0;

            Console.WriteLine("Please, enter a numbers:");

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    mtx[i,j]=int.Parse(Console.ReadLine());
                }

            for (int i = 0; i < 5; i++)
            {
                int f = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (mtx[i, j] == 0)
                        f++;
                }
                if (f > 0)
                    arr[i]++;
            }

            for (int i = 0; i < 5; i++) {
                if (arr[i] == 0)
                    count++;
            }

            Console.WriteLine($"Yours answer:{count}");
        }
    }
}