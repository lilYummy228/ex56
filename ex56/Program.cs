using System;
using System.Collections.Generic;
using System.Linq;

namespace ex56
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            shop.FindOutDelay();
        }
    }

    class Shop
    {
        private List<Stew> _stews = new List<Stew>();
        private int _currentYear = 2023;

        public Shop()
        {
            AddStew();
        }

        public void FindOutDelay()
        {
            var delayedStews = _stews.Where(stew => _currentYear - stew.ShelfLife > stew.ManufactureYear).ToList();

            ShowDelayedStews(delayedStews);
        }

        private void ShowDelayedStews(List<Stew> delayedStews)
        {
            Console.WriteLine("Банки просроченных тушенок: ");

            foreach (Stew stew in delayedStews)
            {
                stew.ShowInfo();
            }
        }

        private void AddStew()
        {
            Random random = new Random();
            int minYear = 2016;
            int stewCount = 20;
            int minShelfLife = 1;
            int maxShelfLife = 3;

            for (int i = 0; i < stewCount; i++)
                _stews.Add(new Stew("Тушенка", random.Next(minYear, _currentYear), random.Next(minShelfLife, maxShelfLife)));
        }
    }

    class Stew
    {
        public Stew(string name, int manufactureYear, int shelfLife)
        {
            Name = name;
            ManufactureYear = manufactureYear;
            ShelfLife = shelfLife;
        }

        public string Name { get; private set; }
        public int ManufactureYear { get; private set; }
        public int ShelfLife { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}. Год производства: {ManufactureYear}. Срок годности: {ShelfLife} года");
        }
    }
}
