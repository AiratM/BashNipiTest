using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCheckContracts.Interfaces
{
    /// <summary>
    /// Интерфейс для реализации прямоугольника
    /// </summary>
    public interface IRectangle
    {
        /// <summary>
        /// Создание прямоугольника по двум координатам противополоэных вершин
        /// </summary>
        /// <param name="x1">Координата Х первой точки</param>
        /// <param name="y1">Координата У первой точки</param>
        /// <param name="x2">Координата Х второй точки</param>
        /// <param name="y2">Координата У второй точки</param>
        /// <returns>true - создание прямоугольника прошло успешно, иначе false</returns>
        bool MakeRectangle(double x1, double y1, double x2, double y2);
    }
}
