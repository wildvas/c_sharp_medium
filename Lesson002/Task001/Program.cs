using System;

namespace Task001
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    interface IDamagiableObject
    {
        void TakeDamage(int damage);
        void IsAlive();
    }

    class Object : IDamagiableObject
    {
        public int Health;

        public void IsAlive()
        {
            if (Health <= 0)
            {
                Console.WriteLine("Я умер");
            }
        }

        public virtual void TakeDamage(int damage)
        {
            throw new NotImplementedException();
        }
    }

    class Wombat: Object
    {
        public int Armor;

        public override void TakeDamage(int damage)
        {
            Health -= damage - Armor;
            IsAlive();
        }
    }

    class Human: Object
    {
        public int Agility;

        public override void TakeDamage(int damage)
        {
            Health -= damage / Agility;
            IsAlive();
        }
    }
}
