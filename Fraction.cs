using System;

namespace Lab6
{
    /// <summary>
    /// Интерфейс для математических операций
    /// </summary>
    /// <typeparam name="T">Тип данных</typeparam>
    public interface IMathOperation<T>
    {
        /// <summary>
        /// Сложение
        /// </summary>
        T Add(T other);

        /// <summary>
        /// Вычитание
        /// </summary>
        T Subtract(T other);

        /// <summary>
        /// Умножение
        /// </summary>
        T Multiply(T other);

        /// <summary>
        /// Деление
        /// </summary>
        T Divide(T other);

        /// <summary>
        /// Получение вещественного значения
        /// </summary>
        double GetRealValue();
    }

    /// <summary>
    /// Класс, представляющий дробь
    /// </summary>
    public class Fraction : IMathOperation<Fraction>, IComparable<Fraction>
    {
        /// <summary>
        /// Числитель дроби
        /// </summary>
        public int Numerator { get; set; }

        /// <summary>
        /// Знаменатель дроби
        /// </summary>
        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Ошибка: знаменатель не может быть 0");
                    return;
                }
                denominator = value;
                FixSign();
            }
        }
        private int denominator;

        /// <summary>
        /// Создает новую дробь
        /// </summary>
        /// <param name="num">Числитель</param>
        /// <param name="den">Знаменатель</param>
        public Fraction(int num, int den)
        {
            if (den == 0)
            {
                Console.WriteLine("Ошибка: знаменатель не может быть 0");
                den = 1;
            }

            Numerator = num;
            denominator = den;
            FixSign();
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Fraction()
        {
            Numerator = 0;
            denominator = 1;
        }

        /// <summary>
        /// Исправляет знак дроби
        /// </summary>
        private void FixSign()
        {
            if (denominator < 0)
            {
                Numerator = -Numerator;
                denominator = -denominator;
            }
        }

        /// <summary>
        /// Возвращает строковое представление дроби
        /// </summary>
        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }

        /// <summary>
        /// Сложение дробей
        /// </summary>
        public Fraction Add(Fraction other)
        {
            int newNum = Numerator * other.Denominator + other.Numerator * Denominator;
            int newDen = Denominator * other.Denominator;
            return new Fraction(newNum, newDen);
        }

        /// <summary>
        /// Вычитание дробей
        /// </summary>
        public Fraction Subtract(Fraction other)
        {
            int newNum = Numerator * other.Denominator - other.Numerator * Denominator;
            int newDen = Denominator * other.Denominator;
            return new Fraction(newNum, newDen);
        }

        /// <summary>
        /// Умножение дробей
        /// </summary>
        public Fraction Multiply(Fraction other)
        {
            int newNum = Numerator * other.Numerator;
            int newDen = Denominator * other.Denominator;
            return new Fraction(newNum, newDen);
        }

        /// <summary>
        /// Деление дробей
        /// </summary>
        public Fraction Divide(Fraction other)
        {
            if (other.Numerator == 0)
            {
                Console.WriteLine("Ошибка: деление на ноль");
                return new Fraction(0, 1);
            }

            int newNum = Numerator * other.Denominator;
            int newDen = Denominator * other.Numerator;
            return new Fraction(newNum, newDen);
        }

        /// <summary>
        /// Сравнение дробей
        /// </summary>
        public int CompareTo(Fraction other)
        {
            double thisValue = GetRealValue();
            double otherValue = other.GetRealValue();
            return thisValue.CompareTo(otherValue);
        }

        /// <summary>
        /// Получение вещественного значения
        /// </summary>
        public double GetRealValue()
        {
            return (double)Numerator / Denominator;
        }

        /// <summary>
        /// Проверка равенства дробей
        /// </summary>
        public bool Equals(Fraction other)
        {
            return Numerator * other.Denominator == other.Numerator * Denominator;
        }

        /// <summary>
        /// Создает копию дроби
        /// </summary>
        public Fraction Copy()
        {
            return new Fraction(Numerator, Denominator);
        }

        /// <summary>
        /// Шаблонный метод для выполнения операции
        /// </summary>
        public static T ExecuteOperation<T>(T a, T b, Func<T, T, T> operation) where T : IMathOperation<T>
        {
            return operation(a, b);
        }
    }
}