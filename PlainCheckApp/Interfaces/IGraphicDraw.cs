using PlainCheckContracts.Dto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainCheckApp.Interfaces
{
    /// <summary>
    /// Отрисовка изображения 
    /// </summary>
    public interface IGraphicDraw
    {
        /// <summary>
        /// Создание изображения по заданным точкам линии
        /// </summary>
        /// <param name="lines">Массив линий</param>
        /// <returns>Имя файла с изображением</returns>
        public Task<string> CreateImageAsync(HashSet<LineModel> lines);

        /// <summary>
        /// Создание изображения по заданным точкам и отрисовка указанного прямоугольника
        /// </summary>
        /// <param name="lines">Массив линий</param>
        /// <param name="rectangle">Модель прямоугольника</param>
        /// <returns>Имя файла с изображением</returns>
        public Task<string> CreateImageAsync(HashSet<LineModel> lines, RectangleModel rectangle);
    }
}
