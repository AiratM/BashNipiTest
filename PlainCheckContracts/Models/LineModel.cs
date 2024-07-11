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
        /// Координата Х первой точки
        /// </summary>
        public float X1 { get; set; }

        /// <summary>
        /// Координата У первой точки
        /// </summary>
        public float Y1 { get; set; }

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
