using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCheckContracts.Interfaces
{
    /// <summary>
    /// Интерфейс для реализации линий
    /// </summary>
    public interface ILine
    {
        /// <summary>
        ///  Установка цвета линии в палитре RGBA в диапазоне 0-255
        /// </summary>
        /// <param name="red">Значение красного</param>
        /// <param name="green">Значение зеленого</param>
        /// <param name="blue">Значение синего</param>
        /// <param name="alpha">Значение прозрачности (альфа-канал)</param>
        void SetColor(byte red, byte green, byte blue, byte alpha);
    }
}
