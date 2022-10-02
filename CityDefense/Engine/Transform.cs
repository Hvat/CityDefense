namespace CityDefense
{
    /**
@brief Класс хранения позиции размера и коллизии на объект. 
*/
    class Transform
    {
        Vector position;
        Vector size;
        public Vector Position => position;
        public Vector Size => size;
        public void SetPosition(Vector vector) => position = vector; //!<Устанавливаем позицию

        public void AddPosition(Vector vector) => position += vector;//!<Добавляем позицию
        public void SetSize(Vector vector) => size = vector; //!<Устанавливаем размер
        /// <summary>
        /// Проверяем коллизию на объект
        /// </summary>
        /// <param name="x">значение координаты по Х</param>
        /// <param name="y">значение координаты по Y</param>
        /// <returns></returns>
        public bool Colision(int x, int y) => x > position.X && x < position.X + size.X && y > position.Y && y < position.Y + size.Y;
    }
}
