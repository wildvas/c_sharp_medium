using System;
using System.Collections.Generic;
using System.Drawing;

namespace Task
{
    class Object
    {
        private int _x;
        private int _y;
        private char _symbol;
        private bool _isAlive;

        public Object(int x, int y, char symbol)
        {
            _x = x;
            _y = y;
            _symbol = symbol;
            _isAlive = true;
        }

        public void Move(int stepX, int stepY)
        {
            _x += stepX;
            _y += stepY;
            if (_x < 0)
                _x = 0;
            if (_y < 0)
                _y = 0;
        }

        public bool СollisionСheck(Object o)
        {
            return o._x == _x && o._y == _y;
        }

        public void Die()
        {
            _isAlive = false;
        }

        public void Show()
        {
            if (_isAlive)
            {
                Console.SetCursorPosition(_x, _y);
                Console.Write(_symbol);
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();

            Object[] objects = new Object[]
            {
                new Object(5, 5, '1'),
                new Object(10, 10, '2'),
                new Object(15, 15, '3')
            };

            while (true)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    for (int j = i + 1; j < objects.Length; j++)
                    {
                        if (objects[i].СollisionСheck(objects[j]))
                        {
                            objects[i].Die();
                            objects[j].Die();
                        }
                    }
                    objects[i].Move(random.Next(-1, 1), random.Next(-1, 1));
                    objects[i].Show();
                }
            }
        }
    }
}