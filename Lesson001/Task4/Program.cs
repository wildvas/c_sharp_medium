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

    class Movement
    {
        public float DirectionX { get; private set; }
        public float DirectionY { get; private set; }
        public float Speed { get; private set; }

        public void Move()
        {
            //Do move
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Movement MovementParameters { get; private set; }
        public Weapon Weapon { get; private set; }

        public void Attack()
        {
            //attack
        }
    }
}
