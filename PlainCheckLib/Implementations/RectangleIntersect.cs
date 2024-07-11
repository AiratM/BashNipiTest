using PlainCheckContracts.Dto;
using PlainCheckContracts.Interfaces;
using PlainCheckContracts.Models;
using System;
using System.Threading.Tasks;

namespace PlainCheckLib.Implementations
{
    public class RectangleIntersect : IRectangleIntersect
    {
        private readonly ILineIntersect _lineIntersect;

        public RectangleIntersect(ILineIntersect lineIntersect)
        {
            _lineIntersect = lineIntersect ?? throw new ArgumentNullException(nameof(lineIntersect));
        }
        public async Task<bool> CheckLineRectangleIntersectAsync(RectangleModel rectangleModel, DotModel dot1, DotModel dot2)
        {
            if (CheckLineInRectangle(rectangleModel, dot1, dot2))
                return true;

            // проверяем на пересечение с гранями прямоугольника
            var tasks = new[] {
                Task.Run(() => _lineIntersect.LineIntersectCheck(dot1,dot2, rectangleModel.TopLeftDot, rectangleModel.TopRightDot)),
                Task.Run(() => _lineIntersect.LineIntersectCheck(dot1,dot2, rectangleModel.TopLeftDot, rectangleModel.BottomLeftDot)),
                Task.Run(() => _lineIntersect.LineIntersectCheck(dot1,dot2, rectangleModel.BottomLeftDot, rectangleModel.BottomRightDot)),
                Task.Run(() => _lineIntersect.LineIntersectCheck(dot1,dot2, rectangleModel.BottomRightDot, rectangleModel.TopRightDot)),
            };
            await Task.WhenAll(tasks);
            return tasks[0].Result || tasks[1].Result || tasks[2].Result || tasks[3].Result;
        }

        /// <summary>
        /// Проверка на нахождение отрезка в прямоугольнике
        /// </summary>
        /// <returns>true, если отрезок находится полностью в прямоугольнике</returns>
        private bool CheckLineInRectangle(RectangleModel rectangleModel, DotModel dot1, DotModel dot2) =>
            dot1.X >= rectangleModel.LeftX && dot1.X <= rectangleModel.RightX && dot2.X >= rectangleModel.LeftX && dot2.X <= rectangleModel.RightX &&
            dot1.Y >= rectangleModel.BottomY && dot1.Y <= rectangleModel.TopY && dot2.Y >= rectangleModel.BottomY && dot2.Y <= rectangleModel.TopY;

    }
}
