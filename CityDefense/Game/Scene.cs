using System.Collections.Generic;
using System.Drawing;
using CityDefense.Engine;

/**
namespace CityDefense.Game
@brief Пространство имен CityDefense.Game
*/
namespace CityDefense.Game
{
    /**
@brief Класс сцены

Здесь реалировано создание общей сцены, а именно отрисовка
    статических и динамических элементов игрового мира на каждом кадре
*/
    class Scene : IScene
    {
        readonly Image backGround;
        readonly int houseOffset = 100;
        readonly int planeAddTime = 10;
        private int planeTimer;
        readonly int maxPlanes = 7;
        public List<House> houses = new List<House>();
        public List<Plane> planes = new List<Plane>();
        public List<Bomb> bombs = new List<Bomb>();
        public List<Effect> effects = new List<Effect>();
        /// <summary>
        /// Инициализация общей сцены
        /// </summary>
        public Scene()
        {

            Resources.InitializationResources();
            backGround = Resources.GetFrame("Back");
            for (int i = 0; i < Render.Resolution.X / houseOffset; i++)
                houses.Add(new House(25 + i * houseOffset, 280, 70, 70));
            Sound.Play("Siren");
        }
        /// <summary>
        /// Отрисовка backGround сцены
        /// </summary>
        /// <param name="g">передача параметров отрисовки</param>
        /// <param name="x">значение координаты по Х</param>
        /// <param name="y">значение координаты по Y</param>
        public void DrawBack(Graphics g, int x, int y) => g.DrawImage(backGround, 0, 0, x, y);
        /// <summary>
        /// Отрисовка динамических объектов сцены
        /// </summary>
        /// <param name="g"></param>
        public void DrawObjects(Graphics g)
        {
            if ((planeTimer -= Time.deltaTime) <= 0 && planes.Count < maxPlanes)
            {
                planeTimer = planeAddTime * 1000;
                planes.Add(new Plane(0, 70, 70, 40, 7, 2));
                bombs.Add(new Bomb(40, 40, 7, 2, this));
            }
            List<IGameObject> objects = new List<IGameObject>();
            objects.AddRange(planes);
            objects.AddRange(houses);
            objects.AddRange(bombs);
            objects.AddRange(effects);
            foreach (var i in objects)
                i.Draw(g);
            CheckBreak();
        }
        /// <summary>
        /// Отрисовка эффекта взрыва
        /// </summary>
        /// <param name="pos">передает экземпляр обьекта взрыв</param>
        public void UseEffect(Vector pos) => effects.Add(new Effect(pos, 60, 60, this));
        /// <summary>
        /// Удаление бомб при наступлении события
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void BreakBomb(int x, int y)
        {
            foreach (var i in bombs)
                if (i.Colision(x, y))
                    i.Break();
        }
        /// <summary>
        /// Контроль завершения игры
        /// </summary>
        public void CheckBreak()
        {

            foreach (var bomb in bombs)
            {
                int breakCount = 0;
                foreach (var i in houses)
                {
                    if (i.IsBreak)
                    {
                        breakCount++;
                        continue;
                    }
                    if (i.Colision(bomb.Position.X + bomb.Size.X / 2, bomb.Position.Y + bomb.Size.Y / 2))
                    {
                        bomb.Break();
                        i.Break();
                    }

                }
                if (breakCount == houses.Count)
                    GameOver.isGameOver = true;
            }
        }
    }
}
