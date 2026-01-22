using lab6;
using System;
using System.Collections.Generic;

namespace Lab6
{
    class Program
    {
        /// <summary>
        /// Вызывает мяуканье у всех объектов в списке
        /// </summary>
        static void MakeAllMeow(List<IMeowable> list)
        {
            foreach (IMeowable item in list)
            {
                item.Meow();
            }
        }

        static void Main()
        {
            Console.WriteLine("=== ЗАДАНИЕ 1.1: Кот ===");
            Console.WriteLine("Введите имя котика:");
            string catname = Console.ReadLine();

            Cat cat = new Cat(catname);

            Console.WriteLine(cat.ToString());

            cat.Meow();
            cat.Meow(3);

            Console.WriteLine("\n=== ЗАДАНИЕ 1.2: Кот ===");

            List<IMeowable> list = new List<IMeowable>();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Введите имя котика:");
                string catname2 = Console.ReadLine();
                list.Add(new Cat(catname2));
            }
            MakeAllMeow(list);

            Console.WriteLine("Тест со своим классом");
            list.Add(new Sadcat("Депрессивный Боб"));
            MakeAllMeow(list);

            Console.WriteLine("\n=== ЗАДАНИЕ 1.3 ===");

            Console.WriteLine("Введите имя котика:");
            string catname3 = Console.ReadLine();
            Cat catForCounting = new Cat(catname3);

            Console.WriteLine("Создан кот: " + catForCounting);

            CatCounter counter = new CatCounter(catForCounting);

            List<IMeowable> countingList = new List<IMeowable>();
            countingList.Add(counter);

            Console.WriteLine("\nВызываем MakeAllMeow:");
            MakeAllMeow(countingList);

            Console.WriteLine("\nВызываем MakeAllMeow еще раз:");
            MakeAllMeow(countingList);

            Console.WriteLine("\nРезультат:");
            Console.WriteLine("Кот мяукал " + counter.MeowCount + " раз");
            Console.WriteLine("Информация о счетчике: " + counter);

            Console.WriteLine("\n\n=== ЗАДАНИЕ 2.1: Дроби с шаблонами ===");
            Console.WriteLine("\nСоздаем дроби:");
            Fraction f1 = new Fraction(1, 3);
            Fraction f2 = new Fraction(2, 3);
            Fraction f3 = new Fraction(3, 4);

            Console.WriteLine("f1 = " + f1.ToString() + ", вещественное: " + f1.GetRealValue());
            Console.WriteLine("f2 = " + f2.ToString() + ", вещественное: " + f2.GetRealValue());
            Console.WriteLine("f3 = " + f3.ToString() + ", вещественное: " + f3.GetRealValue());

            Console.WriteLine("\nИспользуем шаблонные методы MathHelper:");

            Fraction sum = MathHelper.Calculate(f1, f2, (a, b) => a.Add(b));
            Console.WriteLine("Сложение через MathHelper.Calculate: " + sum.ToString());

            Fraction product = MathHelper.Calculate(f1, f2, (a, b) => a.Multiply(b));
            Console.WriteLine("Умножение через MathHelper.Calculate: " + product.ToString());

            List<Fraction> fractionList = MathHelper.CreateCollection(f1, f2, f3);
            Console.WriteLine("\nСоздана коллекция из " + fractionList.Count + " дробей");

            Fraction maxFraction = MathHelper.FindMax(fractionList);
            Console.WriteLine("Максимальная дробь: " + maxFraction.ToString());

            Fraction totalSum = MathHelper.SumAll(fractionList);
            Console.WriteLine("Сумма всех дробей: " + totalSum.ToString());

            Console.WriteLine("\n=== ЗАДАНИЕ 2.2: Сравнение через шаблоны ===");

            Console.WriteLine("Сравнение дробей:");
            Console.WriteLine("f1.CompareTo(f2) = " + f1.CompareTo(f2));
            Console.WriteLine("f2.CompareTo(f1) = " + f2.CompareTo(f1));

            Console.WriteLine("\nПроверка равенства:");
            Console.WriteLine("f1 равен f2? -" + f1.Equals(f2));

            Console.WriteLine("\n=== ЗАДАНИЕ 2.3: Клонирование ===");

            Fraction original = new Fraction(3, 5);
            Fraction cloned = original.Copy();

            Console.WriteLine("Оригинал: " + original.ToString());
            Console.WriteLine("Копия: " + cloned.ToString());
            Console.WriteLine("Равны? " + original.Equals(cloned));

            Console.WriteLine("\nШаблонный конвертер значений:");
            double realValue = MathHelper.ConvertValue(original, f => f.GetRealValue());
            Console.WriteLine("Вещественное значение " + original.ToString() + " = " + realValue);

            Console.WriteLine("\n=== ЗАДАНИЕ 2.4: Дроби с кэшированием и шаблонами ===");

            CachedFraction cf = new CachedFraction(1, 3);
            Console.WriteLine("Создана дробь с кэшированием: " + cf.ToString());

            Console.WriteLine("Информация о кэше: " + cf.GetCacheInfo());

            Console.WriteLine("\nПолучаем вещественное значение (с кэшированием):");
            double val1 = cf.GetRealValue();
            Console.WriteLine("Первое получение: " + val1);
            double val2 = cf.GetRealValue();
            Console.WriteLine("Второе получение (должно быть из кэша): " + val2);

            Console.WriteLine("\nИспользуем шаблонные операции с CachedFraction:");
            CachedFraction cf2 = new CachedFraction(2, 3);
            CachedFraction cfSum = MathHelper.Calculate(cf, cf2, (a, b) => a.Add(b));
            Console.WriteLine(cf.ToString() + " + " + cf2.ToString() + " = " + cfSum.ToString());

            Console.WriteLine("\nМеняем числитель (сбрасывает кэш):");
            cf.SetNumerator(2);
            Console.WriteLine("Новая дробь: " + cf.ToString());
            Console.WriteLine("Информация о кэше: " + cf.GetCacheInfo());

            Console.WriteLine("\nСнова получаем значение:");
            double val3 = cf.GetRealValue();
            Console.WriteLine("Значение после изменения: " + val3);

            Console.WriteLine("\nСоздание копии CachedFraction:");
            CachedFraction cfCopy = cf.Copy();
            Console.WriteLine("Оригинал: " + cf.ToString());
            Console.WriteLine("Копия: " + cfCopy.ToString());
            Console.WriteLine("Кэш оригинала: " + cf.GetCacheInfo());
            Console.WriteLine("Кэш копии: " + cfCopy.GetCacheInfo());

            Console.WriteLine("\n=== ПРОГРАММА ЗАВЕРШЕНА ===");
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}