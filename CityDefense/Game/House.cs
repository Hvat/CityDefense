using System.Drawing;

namespace CityDefense.Game
{
    /**
@brief Класс для работы с объектом House.

Наследует классы IGameObject и Transform.
*/
    class House : Transform, IGameObject
    {
        /// <summary>
        /// Определяет размер и позицию объекта House.
        /// </summary>
        /// <param name="x">текущая позиция по X</param>
        /// <param name="y">текущая позиция по Y</param>
        /// <param name="sx">начальная позиция по Х</param>
        /// <param name="sy">начальная позиция по Y</param>
        public House(int x, int y, int sx, int sy)
        {
            SetPosition(new Vector(x, y));
            SetSize(new Vector(sx, sy));
        }
        public void Break() => IsBreak = true;
        public bool IsBreak { get; private set; } = false; //!<Проверка состояния объекта House.
        /// <summary>
        /// Изменение состояния объекта House.
        /// </summary>
        /// <param name="g">передача параметров отрисовки</param>
        public void Draw(Graphics g) => g.DrawImage(IsBreak ? Resources.GetFrame("HouseBreak") : Resources.GetFrame("House"),
            Position.X, Position.Y, Size.X, Size.Y);
    }
}
