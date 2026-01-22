using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    /// <summary>
    /// Грустный кот, способный мяукать
    /// </summary>
    public class Sadcat : IMeowable
    {
        /// <summary>
        /// Название кота
        /// </summary>
        public string name;

        /// <summary>
        /// Создает нового грустного кота
        /// </summary>
        public Sadcat(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Кот издает звук
        /// </summary>
        public void Meow()
        {
            System.Console.WriteLine(name + ": мяу.. :_(");
        }
    }

}
