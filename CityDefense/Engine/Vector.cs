namespace CityDefense
{
    /**
@brief Пользовательский класс. 
*/
    class Vector
    {
        readonly int x;
        readonly int y;
        /// <summary>
        /// Инициализация
        /// </summary>
        public Vector()
        {
            this.x = 0;
            this.y = 0;
        }
        /// <summary>
        /// Перегрузка инициализации
        /// </summary>
        /// <param name="x">значение координаты по Х</param>
        /// <param name="y">значение координаты по Y</param>
        public Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X => x; //!<Получаем координату Х
        public int Y => y; //!<Получаем координату Y 

        public static Vector operator +(Vector a, Vector b) => new Vector(a.x + b.x, a.y + b.y);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.x - b.x, a.y - b.y);

    }
}
