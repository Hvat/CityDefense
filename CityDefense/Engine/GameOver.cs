using System;
using System.Drawing;

namespace CityDefense.Engine
{
    /**
@brief Класс инициализации финальной заставки.
*/
    internal class GameOver
    {
        public static bool isGameOver = false;
        public static void DrawGameOverScreen(Graphics g)
        {
            g.DrawString($"GAME OVER \n Time: {Convert.ToInt32(Time.GetMinutes())}:{Time.GetSeconds()}", new Font("Stencil", 25),
                new SolidBrush(Color.Red), Render.Resolution.X / 2 - 100, Render.Resolution.Y / 2 - 100);
        }
    }
}
