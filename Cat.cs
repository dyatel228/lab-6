using lab6;
using System;
using System.Text;

namespace Lab6
{
    /// <summary>
    /// Класс, представляющий кота
    /// </summary>
    public class Cat : IMeowable
    {
        /// <summary>
        /// Имя кота
        /// </summary>
        public string name;

        /// <summary>
        /// Создает нового кота с указанным именем
        /// </summary>
        public Cat(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Возвращает строковое представление кота
        /// </summary>
        public override string ToString()
        {
            return "кот: " + name;
        }

        /// <summary>
        /// Кот мяукает один раз
        /// </summary>
        public void Meow()
        {
            Console.WriteLine(name + ": мяу!");
        }

        /// <summary>
        /// Кот мяукает указанное количество раз
        /// </summary>
        public void Meow(int count)
        {
            string result = name + ": ";
            for (int i = 0; i < count; i++)
            {
                result += "мяу";
                if (i < count - 1) result += "-";
            }
            result += "!";
           Console.WriteLine(result);
        }
    }
}