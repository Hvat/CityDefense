using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Media;

/**
namespace CityDefense.Engine
@brief Пространство имен CityDefense.Engine
*/
namespace CityDefense.Engine
{
    /**
@brief Класс для работы с файловой системой программы.
*/
    class FileSystem
    {
    /**
@brief Реализация потока чтения графических файлов. 
*/
        public static Dictionary<string, Image> LoadFrames(string path)
        {
            Dictionary<string, Image> res = new Dictionary<string, Image>();
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                string[] lines = sr.ReadLine().Split('|');
                res.Add(lines[0], Image.FromFile(lines[1]));
            }
            sr.Close();
            return res;
        }
    /**
@brief Реализация потока чтения звуковых файлов. 
*/
        public static Dictionary<string, SoundPlayer> LoadSound(string path)
        {
            Dictionary<string, SoundPlayer> res = new Dictionary<string, SoundPlayer>();
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                string[] lines = sr.ReadLine().Split('|');
                res.Add(lines[0], new SoundPlayer(lines[1]));
            }
            sr.Close();
            return res;
        }
    }
}
