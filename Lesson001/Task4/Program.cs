using System;

namespace Task4
{
    class Weapon
    {
        public float Cooldown { get; private set; }
        public int Damage { get; private set; }
        public bool IsReloading()
        {
            throw new NotImplementedException();
        }
    }

    class MovementParameters
    {
        public float MovementDirectionX { get; private set; }
        public float MovementDirectionY { get; private set; }
        public float MovementSpeed { get; private set; }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public MovementParameters MovementParameters { get; private set; }
        public Weapon Weapon { get; private set; }
        public void Move()
        {
            //Do move
        }

        public void Attack()
        {
            //attack
        }
    }
}
