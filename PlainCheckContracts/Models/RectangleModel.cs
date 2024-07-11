using PlainCheckContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlainCheckContracts.Dto
{
    /// <summary>
    /// Модель прямоугольника
    /// </summary>
    public class RectangleModel
    {
        /// <summary>
        /// Левая верхняя вершина
        /// </summary>
        public DotModel TopLeftDot { get; set; }

        /// <summary>
        /// Правая верхняя вершина
        /// </summary>
        public DotModel TopRightDot { get; set; }

        /// <summary>
        /// Левая нижняя вершина
        /// </summary>
        public DotModel BottomLeftDot { get; set; }
        /// <summary>
        /// Правая нижнаяя вершина
        /// </summary>
        public DotModel BottomRightDot { get; set; }

        /// <summary>
        /// Является ли прямоугольником
        /// </summary>
        public bool IsRectangle { get; private set; }

        /// <summary>
        /// Является ли параллельным осям координат
        /// </summary>
        public bool IsNormalized { get; private set; }
        /// <summary>
        /// Конструктор модели прямоугольника
        /// </summary>
        /// <param name="dots">4 вершины</param>
        public RectangleModel(List<DotModel> dots)
        {
            if (!ValidateDots(dots))
            {
                throw new ArgumentException(nameof(dots));
            }
            SetVertex(dots.OrderBy(q => q.Y).ToList());

            IsRectangle = CheckIsRectangle();
        }

        /// <summary>
        /// Первичная проверка точек
        /// </summary>
        /// <param name="dots">Коллекция точек</param>
        /// <returns>true - валидация пройдена, иначе false</returns>
        private bool ValidateDots(List<DotModel> dots)
        {
            if (dots is null)
            {
                return false;
            }
            if (dots.Count != 4)
            {
                return false;
            }

            var comparer = new DotModelComparer();
            if (dots.Distinct(comparer).Count() != 4)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Определение положения вершин
        /// </summary>
        /// <param name="sortedDots">4 вершины, отсортированные по оси У</param>
        private void SetVertex(List<DotModel> sortedDots)
        {
            if (sortedDots[0].X < sortedDots[1].X)
            {
                BottomLeftDot = (DotModel)sortedDots[0].Clone();
                BottomRightDot = (DotModel)sortedDots[1].Clone();
            }
            else
            {
                BottomLeftDot = (DotModel)sortedDots[1].Clone();
                BottomRightDot = (DotModel)sortedDots[0].Clone();
            }

            if (sortedDots[2].X < sortedDots[3].X)
            {
                TopLeftDot = (DotModel)sortedDots[2].Clone();
                TopRightDot = (DotModel)sortedDots[3].Clone();
            }
            else
            {
                TopLeftDot = (DotModel)sortedDots[3].Clone();
                TopRightDot = (DotModel)sortedDots[2].Clone();
            }
        }

        /// <summary>
        /// Проверка, является ли фигура прямоугольником. 
        /// Условие соответствия: противоположные стороны и диагонали должны быть равны
        /// </summary>
        /// <returns>true - прямоугольник</returns>
        private bool CheckIsRectangle() =>
            (LineLength(BottomLeftDot, TopLeftDot) == LineLength(TopRightDot, BottomRightDot)) &&
                (LineLength(TopLeftDot, TopRightDot) == LineLength(BottomLeftDot, BottomRightDot)) &&
                    (LineLength(TopLeftDot, BottomRightDot) == LineLength(BottomLeftDot, TopRightDot));


        /// <summary>
        /// Вычисление длины отрезка по координатам двух точек
        /// </summary>
        /// <param name="dot1">Точка 1</param>
        /// <param name="dot2">Точка 2</param>
        /// <returns>Длина</returns>
        private double LineLength(DotModel dot1, DotModel dot2) => Math.Sqrt(Math.Pow((dot2.X - dot1.X), 2) + Math.Pow((dot2.Y - dot1.Y), 2));

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckIsNormalized()
        {
            return true;
        }
    }
}
