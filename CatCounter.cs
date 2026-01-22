using Lab6;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Счетчик мяуканий для кота
/// </summary>
namespace lab6
{
    public class CatCounter : IMeowable
    {
        private Cat catt;
        private int meowCount;

        /// <summary>
        /// Количество выполненных мяуканий
        /// </summary>
        public int MeowCount
        {
            get { return meowCount; }
        }

        /// <summary>
        /// Кот, за которым ведется подсчет
        /// </summary>
        public Cat CounterCat
        {
            get { return catt; }
        }


        /// <summary>
        /// Создает счетчик для указанного кота
        /// </summary>
        public CatCounter(Cat cat)
        {
            catt = cat;
            meowCount = 0;
        }

        /// <summary>
        /// Вызывает мяуканье у кота и увеличивает счетчик
        /// </summary>
        public void Meow()
        {

            catt.Meow();

            meowCount++;
        }
        /// <summary>
        /// Возвращает информацию о счетчике
        /// </summary>
        public override string ToString()
        {
            return $"Счетчик для кота: {catt.name}, мяуканий: {meowCount}";
        }
    }
}
