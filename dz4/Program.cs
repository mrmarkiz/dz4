using System.Threading.Tasks;

namespace dz4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            Console.Write("Enter task to run: ");
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error collapsed: {ex.Message}");
                return;
            }
            switch (choice)
            {
                case 1:
                    Task1_2.Run1();
                    break;
                case 2:
                    Task1_2.Run2();
                    break;
                case 3:
                    Task3_4.Run3();
                    break;
                case 4:
                    Task3_4.Run4();
                    break;
            }
        }
    }
}