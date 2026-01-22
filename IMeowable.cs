using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    /// <summary>
    /// Интерфейс для объектов, способных мяукать
    /// </summary>
    public interface IMeowable
    {
        /// <summary>
        /// Издает мяукающий звук
        /// </summary>
        void Meow();
    }
}
