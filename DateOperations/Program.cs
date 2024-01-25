namespace DateOperations
{
    /// <summary>
    /// Класс, представляющий пользовательскую дату с днем, месяцем и годом.
    /// </summary>
    public class CustomDate
    {
        /// <summary>
        /// Получает или устанавливает значение дня.
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Получает или устанавливает значение месяца.
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Получает или устанавливает значение года.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CustomDate"/>.
        /// </summary>
        /// <param name="day">День.</param>
        /// <param name="month">Месяц.</param>
        /// <param name="year">Год.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если дата недействительна.</exception>
        public CustomDate(int day, int month, int year)
        {
            if (!IsValidDate(day, month, year))
            {
                throw new ArgumentException("Invalid date.");
            }

            Day = day;
            Month = month;
            Year = year;
        }

        /// <summary>
        /// Перегруженный оператор сложения для добавления указанного количества дней к дате.
        /// </summary>
        /// <param name="date">Исходная дата.</param>
        /// <param name="days">Количество дней для добавления.</param>
        /// <returns>Новый объект <see cref="CustomDate"/> после добавления дней.</returns>
        public static CustomDate operator +(CustomDate date, int days)
        {
            return date.AddDays(days);
        }

        /// <summary>
        /// Перегруженный оператор вычитания для вычитания указанного количества дней из даты.
        /// </summary>
        /// <param name="date">Исходная дата.</param>
        /// <param name="days">Количество дней для вычитания.</param>
        /// <returns>Новый объект <see cref="CustomDate"/> после вычитания дней.</returns>
        public static CustomDate operator -(CustomDate date, int days)
        {
            return date.AddDays(-days);
        }

        /// <summary>
        /// Перегруженный оператор сравнения на равенство для объектов дат.
        /// </summary>
        /// <param name="date1">Первая дата для сравнения.</param>
        /// <param name="date2">Вторая дата для сравнения.</param>
        /// <returns>True, если даты равны, иначе False.</returns>
        public static bool operator ==(CustomDate date1, CustomDate date2)
        {
            return date1.Equals(date2);
        }

        /// <summary>
        /// Перегруженный оператор сравнения на неравенство для объектов дат.
        /// </summary>
        /// <param name="date1">Первая дата для сравнения.</param>
        /// <param name="date2">Вторая дата для сравнения.</param>
        /// <returns>True, если даты не равны, иначе False.</returns>
        public static bool operator !=(CustomDate date1, CustomDate date2)
        {
            return !date1.Equals(date2);
        }

        /// <summary>
        /// Переопределение метода Equals для сравнения объектов дат.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>True, если объекты равны, иначе False.</returns>
        public override bool Equals(object obj)
        {
            if (obj is CustomDate otherDate)
            {
                return Day == otherDate.Day && Month == otherDate.Month && Year == otherDate.Year;
            }

            return false;
        }

        /// <summary>
        /// Переопределение метода GetHashCode для использования в хэш-функциях.
        /// </summary>
        /// <returns>Хэш-код объекта.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Day, Month, Year);
        }

        /// <summary>
        /// Переопределение метода ToString для вывода даты в формате "день/месяц/год".
        /// </summary>
        /// <returns>Строковое представление даты.</returns>
        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year:D4}";
        }

        /// <summary>
        /// Метод для вывода даты в длинном формате, например, "7 декабря 2022 г.".
        /// </summary>
        /// <returns>Длинное строковое представление даты.</returns>
        public string ToLongDateString()
        {
            return $"{Day:D2} {GetMonthName(Month)} {Year:D4}";
        }

        /// <summary>
        /// Приватный метод для добавления дней к текущей дате.
        /// </summary>
        /// <param name="days">Дни</param>
        /// <returns></returns>
        private CustomDate AddDays(int days)
        {
            DateTime dateTime = new DateTime(Year, Month, Day);
            DateTime newDateTime = dateTime.AddDays(days);

            return new CustomDate(newDateTime.Day, newDateTime.Month, newDateTime.Year);
        }

        /// <summary>
        ///  Приватный метод для проверки допустимости даты.
        /// </summary>
        /// <param name="day">День</param>
        /// <param name="month">Месяц</param>
        /// <param name="year">Год</param>
        /// <returns></returns>
        private static bool IsValidDate(int day, int month, int year)
        {
            try
            {
                DateTime date = new DateTime(year, month, day);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        /// <summary>
        /// Приватный метод для получения названия месяца по его номеру.
        /// </summary>
        private string GetMonthName(int month)
        {
            return new DateTime(Year, month, 1).ToString("MMMM");
        }
    }

    class Program
    {
        static void Main()
        {
            CustomDate currentDate = new CustomDate(7, 12, 2022);
            Console.WriteLine($"Current Date: {currentDate}");

            CustomDate newDate = currentDate + 5;
            Console.WriteLine($"New Date (currentDate + 5 days): {newDate}");

            Console.WriteLine($"Are current date and new date equal? {currentDate == newDate}");

            Console.WriteLine($"Long date format: {currentDate.ToLongDateString()}");
        }
    }
}
