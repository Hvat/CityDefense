namespace CityDefense.Engine
{
    /**
@brief Класс звуковых эффектов.
*/
    class Sound
    {
        public static void Play(string key) => Resources.GetSound(key).Play();
    }
}