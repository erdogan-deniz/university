namespace Program {
    class Program {
        static void Main(string[] args) {

            List<double> zxc= new List<double>();

            Console.WriteLine("Entering list:");
            for (int i = 0; i < 10; i++)
            {
                zxc.Add(Convert.ToInt32(Console.ReadLine()));
            }

            for (int i = 0; i < 10; i++)
            {
                if (Math.Sin(zxc[i]) > (0.5))
                    Console.WriteLine(zxc[i]);
            }
        }
    }
}