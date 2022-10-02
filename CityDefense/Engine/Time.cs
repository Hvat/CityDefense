using System;

namespace CityDefense.Engine
{
    /**
@brief Класс обработки тайминга.

Обработка частоты кадров, интервал приращения колличества объектов.
*/
    class Time
    {
        static int frames = 0;
        static int interval;
        static public void SetInterval(int value) => interval = value;
        static public void Frame_Tick(object sender, EventArgs e) => frames++;
        static public int GetMiliSeconds() => frames * interval;
        static public double GetSeconds() => GetMiliSeconds() / 1000;
        static public double GetMinutes() => GetSeconds() / 60;
        static public int deltaTime => interval;
    }
}