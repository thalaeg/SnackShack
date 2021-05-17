using System;

namespace SnackShack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many sandwhiches do you want to make?");
            GetUserInputAndWriteSchedule();
        }

        private static void GetUserInputAndWriteSchedule()
        {
            var numberOfSandwhichesString = Console.ReadLine();
            if (int.TryParse(numberOfSandwhichesString, out var numberOfSandwhiches) && numberOfSandwhiches >= 0)
            {
                WriteSandwhichSchedule(numberOfSandwhiches);
            }
            else
            {
                Console.WriteLine("Please enter a whole number");
                GetUserInputAndWriteSchedule();
            }
        }

        private static void WriteSandwhichSchedule(int numberOfSandwhiches)
        {
            var orderText = new OrderTimer(numberOfSandwhiches).MakeSchedule();
            Console.WriteLine(orderText);
        }
    }
}
