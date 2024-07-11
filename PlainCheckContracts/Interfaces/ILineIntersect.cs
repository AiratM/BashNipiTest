using PlainCheckContracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainCheckContracts.Interfaces
{
    public interface ILineIntersect
    {
        /// <summary>
        /// Проверка пересечения двух отрезков AB и CD
        /// Отрезок представлен двумя точками: начало и конец. Порядок указания двух точек (выровненность по какой-либо оси) не важен
        /// </summary>
        /// <param name="dot1">Точка А отрезка АВ </param>
        /// <param name="dot2">Точка В отрезка АВ</param>
        /// <param name="dot3">Точка C отрезка CD</param>
        /// <param name="dot4">Точка D отрезка CD</param>
        /// <returns>true, если линии пересекаются</returns>
        bool LineIntersectCheck(DotModel dot1, DotModel dot2, DotModel dot3, DotModel dot4);
    }
}
