using System.Drawing;
using CityDefense.Engine;

namespace CityDefense.Game
{
    /**
@brief Класс создания эффектов.

Наследует классы IGameObject и Transform.
*/
    class Effect : Transform, IGameObject
    {
        readonly int countTiles = 5;
        private int curTile = 0;
        readonly Scene scene;
        /// <summary>
        /// Комбинация эффектов позиции, состояния и звука.
        /// </summary>
        /// <param name="position">изменение позиции объекта</param>
        /// <param name="sx">начальная позиция по Х</param>
        /// <param name="sy">начальная позиция по Y</param>
        /// <param name="scene">параметры сцены</param>
        public Effect(Vector position, int sx, int sy, Scene scene)
        {
            Sound.Play("Exp");
            SetPosition(position);
            SetSize(new Vector(sx, sy));
            this.scene = scene;
        }
        /// <summary>
        /// Реализация эффекта взрыва.
        /// </summary>
        /// <param name="g">передача параметров отрисовки</param>
        public void Draw(Graphics g)
        {
            if (curTile == countTiles)
                scene.effects.Remove(this);
            g.DrawImage(Resources.GetFrame("Exp" + curTile.ToString()),
            Position.X, Position.Y, Size.X, Size.Y);
            curTile++;
        }
    }
}
