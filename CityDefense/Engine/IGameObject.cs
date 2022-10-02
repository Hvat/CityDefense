using System.Collections.Generic;
using System.Drawing;

namespace CityDefense
{
    /**
@brief Интерфейс отрисовки объектов. 

Отрисовка объектов и проверка коллизии.
*/
    interface IGameObject
    {
        void Draw(Graphics g);
        bool Colision(int x, int y);
    }
}
