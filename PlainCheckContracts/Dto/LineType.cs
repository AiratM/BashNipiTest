using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCheckContracts.Dto
{
    /// <summary>
    /// DTO линии
    /// </summary>
    public class LineType
    {
        /// <summary>
        /// Id линии
        /// </summary>
        public long LineId { get; set; }

        /// <summary>
        /// Координата Х первой точки
        /// </summary>
        public double X1 { get; set; }

        /// <summary>
        /// Координата У первой точки
        /// </summary>
        public double Y1 { get; set; }

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
