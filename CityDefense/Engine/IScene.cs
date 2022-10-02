using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CityDefense.Engine
{
    /**
@brief Интерфейс отрисовки сцены. 

Отрисовка бэкграунда.
*/
    interface IScene
    {
        void DrawBack(Graphics g, int x, int y);
        void DrawObjects(Graphics g);

    }
}
