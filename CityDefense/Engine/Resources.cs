using System.Collections.Generic;
using System.Drawing;
using System.Media;
using CityDefense.Engine;

namespace CityDefense
{
    /**
@brief Класс хранения объектов.
    
Хранит все графические и звуковые обьекты.
*/
    class Resources
    {
        static Dictionary<string, Image> frames = new Dictionary<string, Image>();

        static Dictionary<string, SoundPlayer> sounds = new Dictionary<string, SoundPlayer>();
        /// <summary>
        /// Инициализация объектов
        /// </summary>
        static public void InitializationResources()
        {
            frames = FileSystem.LoadFrames("Res.int");
            sounds = FileSystem.LoadSound("Sound.int");
        }
        /// <summary>
        /// Передача Графических объектов в тиковую обработку.
        /// </summary>
        /// <param name="key">передача ссылки на графический элемент</param>
        /// <returns></returns>
        static public Image GetFrame(string key) => frames[key];
        /// <summary>
        /// Передача звуковых эффектов в тиковую обработку.
        /// </summary>
        /// <param name="key">передача ссылки на звуковой файл</param>
        /// <returns></returns>
        static public SoundPlayer GetSound(string key) => sounds[key];
    }
}