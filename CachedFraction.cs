using System;

namespace Lab6
{
    /// <summary>
    /// Дробь с кэшированием
    /// </summary>
    public class CachedFraction : Fraction, IMathOperation<CachedFraction>
    {
        private double cachedValue;
        private bool hasCache;

        /// <summary>
        /// Создает дробь с кэшированием
        /// </summary>
        /// <param name="num">Числитель</param>
        /// <param name="den">Знаменатель</param>
        public CachedFraction(int num, int den) : base(num, den)
        {
            hasCache = false;
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public CachedFraction() : base()
        {
            hasCache = false;
        }

        /// <summary>
        /// Получение значения с кэшированием
        /// </summary>
        public new double GetRealValue()
        {
            if (!hasCache)
            {
                cachedValue = base.GetRealValue();
                hasCache = true;
            }
            return cachedValue;
        }

        /// <summary>
        /// Установка числителя
        /// </summary>
        public void SetNumerator(int value)
        {
            base.Numerator = value;
            hasCache = false;
        }

        /// <summary>
        /// Установка знаменателя
        /// </summary>
        public void SetDenominator(int value)
        {
            base.Denominator = value;
            hasCache = false;
        }

        /// <summary>
        /// Получение информации о кэше
        /// </summary>
        public string GetCacheInfo()
        {
            return "Дробь: " + ToString() + ", Кэш: " + (hasCache ? "есть" : "нет");
        }

        /// <summary>
        /// Сложение дробей
        /// </summary>
        public CachedFraction Add(CachedFraction other)
        {
            Fraction result = base.Add(other);
            return new CachedFraction(result.Numerator, result.Denominator);
        }

        /// <summary>
        /// Вычитание дробей
        /// </summary>
        public CachedFraction Subtract(CachedFraction other)
        {
            Fraction result = base.Subtract(other);
            return new CachedFraction(result.Numerator, result.Denominator);
        }

        /// <summary>
        /// Умножение дробей
        /// </summary>
        public CachedFraction Multiply(CachedFraction other)
        {
            Fraction result = base.Multiply(other);
            return new CachedFraction(result.Numerator, result.Denominator);
        }

        /// <summary>
        /// Деление дробей
        /// </summary>
        public CachedFraction Divide(CachedFraction other)
        {
            Fraction result = base.Divide(other);
            return new CachedFraction(result.Numerator, result.Denominator);
        }

        /// <summary>
        /// Создает копию дроби
        /// </summary>
        public new CachedFraction Copy()
        {
            CachedFraction copy = new CachedFraction(base.Numerator, base.Denominator);
            if (hasCache)
            {
                copy.cachedValue = cachedValue;
                copy.hasCache = true;
            }
            return copy;
        }
    }
}