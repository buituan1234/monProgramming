using System;

namespace SE07301ASM1
{
    internal class monProgramming
    {
        private static readonly double[] HouseholdPrices = { 5973, 7052, 8699, 15929 };
        private static readonly double[] HouseholdEnvFees = { 597.3, 705.2, 869.9, 1592.9 };
        private static readonly double AdminPrice = 9955;
        private static readonly double AdminEnvFee = 995.5;
        private static readonly double ProductionPrice = 11615;
        private static readonly double ProductionEnvFee = 1161.5;
        private static readonly double BusinessPrice = 22068;
        private static readonly double BusinessEnvFee = 2206.8;

        static void Main(string[] args)
        {
            // Get customer information
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();
            Console.Write("Last month's water: ");
            double lastWater = double.Parse(Console.ReadLine());
            Console.Write("This month's water: ");
            double thisWater = double.Parse(Console.ReadLine());
            Console.Write("Customer type (household/administrative/production/business): ");
            string type = Console.ReadLine().ToLower();

            // Calculate water consumption
            double consumption = thisWater - lastWater;

            // Calculate the bill based on customer type
            double bill = CalculateBill(type, consumption);

            // Display the results
            Console.WriteLine("Customer name: " + name);
            Console.WriteLine("Last month's water: " + lastWater);
            Console.WriteLine("This month's water: " + thisWater);
            Console.WriteLine("Amount of consumption: " + consumption);
            Console.WriteLine("Total Bill: " + bill);
            Console.ReadLine();
        }

        static double CalculateBill(string type, double consumption)
        {
            switch (type)
            {
                case "household":
                    Console.Write("Enter number of people: ");
                    int people = int.Parse(Console.ReadLine());
                    double consumptionPerPerson = consumption / people;

                    // Determine the index based on consumption per person
                    int index;
                    if (consumptionPerPerson < 10)
                    {
                        index = 0; // First price tier
                    }
                    else if (consumptionPerPerson < 20)
                    {
                        index = 1; // Second price tier
                    }
                    else if (consumptionPerPerson < 30)
                    {
                        index = 2; // Third price tier
                    }
                    else
                    {
                        index = 3; // Fourth price tier
                    }

                    // Calculate and return the bill
                    return (consumptionPerPerson * (HouseholdPrices[index] + HouseholdEnvFees[index]));

                case "administrative":
                    return consumption * (AdminPrice + AdminEnvFee);
                case "production":
                    return consumption * (ProductionPrice + ProductionEnvFee);
                case "business":
                    return consumption * (BusinessPrice + BusinessEnvFee);
                default:
                    throw new ArgumentException("Invalid customer type");
            }
           
        }

    }
    
}
