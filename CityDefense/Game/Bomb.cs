using System;
using System.Drawing;

namespace CityDefense.Game
{
    /**
@brief Класс для работы с объектом Bomb.

Наследует классы IGameObject и Transform.
*/
    class Bomb : Transform, IGameObject
    {
        private readonly int speed;
        private readonly int speedOfset;
        private int curSpeed;
        private readonly Scene scene;
        private readonly Random random = new Random();
        /// <summary>
        /// Определяет позицию, размер и скорость движения объекта.
        /// </summary>
        /// <param name="sx">значение начальной координаты по Х</param>
        /// <param name="sy">значение начальной координаты по Y</param>
        /// <param name="speed">значение скорости движения объекта</param>
        /// <param name="offsetSpeed">значение приращения скорости объекта</param>
        /// <param name="scene">значение параметра сцены</param>
        public Bomb(int sx, int sy, int speed, int offsetSpeed, Scene scene)
        {
            this.scene = scene;
            SetSize(new Vector(sx, sy));
            this.speed = speed;
            this.speedOfset = offsetSpeed;
            NextPlane();
        }
        /// <summary>
        /// Рандомизация появления объекта
        /// </summary>
        public void NextPlane()
        {
            curSpeed = speed + random.Next(-speedOfset, speedOfset);
            SetPosition(scene.planes[random.Next(0, scene.planes.Count)].Position);
        }
        /// <summary>
        /// Отрисовка объекта
        /// </summary>
        /// <param name="g">передача параметров отрисовки</param>
        public void Draw(Graphics g)
        {
            AddPosition(new Vector(0, curSpeed));
            g.DrawImage(Resources.GetFrame("Bomb"),
            Position.X, Position.Y, Size.X, Size.Y);
            if (Position.Y > Render.Resolution.Y)
                NextPlane();
        }
        /// <summary>
        /// Удаление объекта
        /// </summary>
        public void Break()
        {
            scene.UseEffect(Position);
            NextPlane();
        }
    }
}
