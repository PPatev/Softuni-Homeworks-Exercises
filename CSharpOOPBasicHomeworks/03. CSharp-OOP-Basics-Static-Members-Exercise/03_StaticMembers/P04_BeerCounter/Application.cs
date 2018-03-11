namespace P04_BeerCounter
{
    using System;
    using System.Linq;

    public class Application
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            while (!line.Equals("End"))
            {
                int[] beers = line.Split().Select(int.Parse).ToArray();
                BeerCounter.BuyBeer(beers[0]);
                BeerCounter.DrinkBeer(beers[1]);

                line = Console.ReadLine();
            }

            Console.WriteLine("{0} {1}", BeerCounter.BeerInStock, BeerCounter.BeersDrankCount);
        }
    }

    public static class BeerCounter
    {
        private static int beerInStock = 0;
        private static int beersDrankCount = 0;

        public static int BeerInStock
        {
            get
            {
                return beerInStock;
            }
        }

        public static int BeersDrankCount
        {
            get
            {
                return beersDrankCount;
            }
        }

        public static void BuyBeer(int bottlesCount)
        {
            beerInStock += bottlesCount;
        }

        public static void DrinkBeer(int bottlesCount)
        {
            if (beerInStock - bottlesCount < 0)
            {
                beersDrankCount += beerInStock;
                beerInStock = 0;
            }
            else
            {
                beersDrankCount += bottlesCount;
                beerInStock -= bottlesCount;
            }
        }
    }
}