using PlainCheckContracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCheckContracts.Dto
{
    /// <summary>
    /// Модель линии
    /// </summary>
    public class LineModel
    {
        /// <summary>
        /// Id линии
        /// </summary>
        public long LineId { get; set; }

        /// <summary>
        /// Координата следующей точки
        /// </summary>
        public DotModel Dot { get; set; }

        /// <summary>
        /// Id полигона, к которому относятся линии
        /// </summary>
        public long PolygonId { get; set; }

        /// <summary>
        /// Флаг пересечения с прямоугольником
        /// </summary>
        public bool IsInRectangle { get; set; } = false;
    }
}
