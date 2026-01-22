using System;
using System.Collections.Generic;

namespace Lab6
{
    /// <summary>
    /// Помощник для работы с математическими объектами
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// Выполняет операцию над двумя объектами
        /// </summary>
        public static TResult Calculate<T, TResult>(
            T a,
            T b,
            Func<T, T, TResult> operation)
            where T : IMathOperation<T>
        {
            return operation(a, b);
        }

        /// <summary>
        /// Создает коллекцию объектов
        /// </summary>
        public static List<T> CreateCollection<T>(params T[] items) where T : IMathOperation<T>
        {
            List<T> collection = new List<T>();
            for (int i = 0; i < items.Length; i++)
            {
                collection.Add(items[i]);
            }
            return collection;
        }

        /// <summary>
        /// Находит максимальный объект в коллекции
        /// </summary>
        public static T FindMax<T>(List<T> collection) where T : IMathOperation<T>, IComparable<T>
        {
            if (collection.Count == 0)
                return default(T);

            T max = collection[0];
            for (int i = 1; i < collection.Count; i++)
            {
                T current = collection[i];
                if (current.CompareTo(max) > 0)
                    max = current;
            }
            return max;
        }

        /// <summary>
        /// Суммирует все объекты в коллекции
        /// </summary>
        public static T SumAll<T>(List<T> collection) where T : IMathOperation<T>, new()
        {
            if (collection.Count == 0)
                return new T();

            T sum = collection[0];
            for (int i = 1; i < collection.Count; i++)
            {
                sum = sum.Add(collection[i]);
            }
            return sum;
        }

        /// <summary>
        /// Конвертер значений
        /// </summary>
        public static U ConvertValue<T, U>(T value, Func<T, U> converter)
        {
            return converter(value);
        }
    }
}