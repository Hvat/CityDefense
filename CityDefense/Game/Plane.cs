using System;
using System.Drawing;

namespace CityDefense.Game
{
    /**
@brief Класс для работы с объектом Plane.

Наследует классы IGameObject и Transform.
*/
    class Plane : Transform, IGameObject
    {
        private int speed;
        /// <summary>
        /// Определяет позицию, размер и скорость движения объекта.
        /// </summary>
        /// <param name="x">текущая позиция по X</param>
        /// <param name="y">текущая позиция по Y</param>
        /// <param name="sx">начальная позиция по Х</param>
        /// <param name="sy">начальная позиция по Y</param>
        /// <param name="speed">скорость движения объекта</param>
        /// <param name="offsetSpeed">приращение скорости</param>
        public Plane(int x, int y, int sx, int sy, int speed, int offsetSpeed)
        {
            Random random = new Random();
            SetPosition(new Vector(x, y + random.Next(-sy, sy)));
            SetSize(new Vector(sx, sy));
            this.speed = speed + random.Next(-offsetSpeed, offsetSpeed);
        }
        /// <summary>
        /// Отрисовка объекта
        /// </summary>
        /// <param name="g">передача параметров отрисовки</param>
        public void Draw(Graphics g)
        {
            AddPosition(new Vector(speed, 0));
            if (Position.X > Render.Resolution.X - Size.X)
                speed *= -1;
            if (Position.X < 0)
                speed *= -1;
            g.DrawImage(speed > 0 ? Resources.GetFrame("PlaneRight") : Resources.GetFrame("PlaneLeft"),
            Position.X, Position.Y, Size.X, Size.Y);
        }
    }
}
