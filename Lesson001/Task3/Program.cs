using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Bag
    {
        private List<Item> _items;
        private int _maxWeidth;

        public Bag(List<Item> items, int maxWeidth)
        {
            _items = items;
            _maxWeidth = maxWeidth;
        }

        public void AddItem(string name, int count)
        {
            int currentWeidth = _items.Sum(item => item.Count);
            Item targetItem = _items.FirstOrDefault(item => item.Name == name);

            if (targetItem == null)
                throw new InvalidOperationException();

            if (currentWeidth + count > _maxWeidth)
                throw new InvalidOperationException();

            targetItem.AddCount(count);
        }

        public IReadOnlyList<Item> GetItems() => _items;

    }

    class Item
    {
        public int Count { get; private set; }
        public string Name { get; }

        public Item(string name)
        {
            Name = name;
            Count = 0;
        }

        public void AddCount(int count)
        {
            Count += count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            items.Add(new Item("Item 1"));
            items.Add(new Item("Item 2"));
            items.Add(new Item("Item 3"));
            items.Add(new Item("Item 4"));
            Bag bag = new Bag(items, 10);

            bag.AddItem("Item 1", 3);
            bag.AddItem("Item 4", 5);

            foreach (Item i in bag.GetItems())
            {
                Console.WriteLine($"{i.Name} - {i.Count}");
            }

            Console.ReadLine();
        }
    }
}
