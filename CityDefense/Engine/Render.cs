using System.Drawing;
using CityDefense.Engine;

namespace CityDefense
{
    /**
@brief Основной класс графического движка.

Содержит методы настройки разрешения окна, интерфейс сцены,
отрисовка кадров.
*/
    class Render
    {
        static Vector resolution;
        static IScene scene;
        /// <summary>
        /// Установка разрешение окна.
        /// </summary>
        /// <param name="x">значение координаты по Х</param>
        /// <param name="y">значение координаты по Y</param>
        public static void SetResolution(int x, int y) => resolution = new Vector(x, y);
        /// <summary>
        /// Настройка сцены.
        /// </summary>
        /// <param name="customScene">объект класса IScene</param>
        public static void SetScene(IScene customScene) => scene = customScene;
        /// <summary>
        /// Отрисовка кадров по каждому тику таймера.
        /// </summary>
        /// <returns>Параметры разрешения окна</returns>
        public static Image DrawFrame()
        {
            Bitmap bitmap = new Bitmap(resolution.X, resolution.Y);
            Graphics g = Graphics.FromImage(bitmap);
            scene.DrawBack(g, resolution.X, resolution.Y);
            scene.DrawObjects(g);
            if (GameOver.isGameOver)
                GameOver.DrawGameOverScreen(g);
            return bitmap;
        }
        public static Vector Resolution => resolution;
    }
}
