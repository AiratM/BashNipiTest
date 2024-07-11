using PlainCheckContracts.Dto;
using PlainCheckContracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainCheckContracts.Interfaces
{
    /// <summary>
    /// Основная проверка
    /// </summary>
    public interface IRectangleIntersect
    {
        /// <summary>
        /// Проверка на пересечение отрезка с прямоугольником
        /// </summary>
        /// <param name="rectangleModel">Модель прямоугольника</param>
        /// <param name="dot1">Первая точка отрезка</param>
        /// <param name="dot2">Вторая точка отрезка</param>
        /// <returns>true - если хотя бы 1 точка отрезка совпадает с прямоугольником</returns>
        Task<bool> CheckLineRectangleIntersectAsync(RectangleModel rectangleModel, DotModel dot1, DotModel dot2);
    }
}
