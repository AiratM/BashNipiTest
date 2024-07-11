using PlainCheckApp.Interfaces;
using PlainCheckContracts.Dto;
using PlainCheckContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace PlainCheckApp.Services
{
    public class PngGraphicDraw : IGraphicDraw
    {
        private List<Color> _lineColors;
        private int _currentColorIndex = 0;
        private const int MAX_COLORS = 8;
        private const int BITMAP_HEIGHT = 1000;
        private const int BITMAP_WIDTH = 1000;
        private Pen _lineIntersectPen = new Pen(Color.Black, 2);
        private Pen _rectanglePen = new Pen(Color.OrangeRed, 1);
        private readonly ILineIntersect _lineIntersect;

        public PngGraphicDraw(ILineIntersect lineIntersect)
        {
            _lineIntersect = lineIntersect ?? throw new ArgumentNullException();
            _lineColors = new List<Color> { Color.BlueViolet, Color.DarkKhaki, Color.DeepPink, Color.Brown, Color.Black, Color.DarkSeaGreen, Color.DeepPink, Color.DimGray };

        }
        public async Task<string> CreateImageAsync(HashSet<LineModel> lines) => await Task.Run(() => CreateImage(lines));

        public async Task<string> CreateImageAsync(HashSet<LineModel> lines, RectangleModel rectangle) => await Task.Run(() => CreateImage(lines, rectangle));

        public string CreateImage(HashSet<LineModel> lines, RectangleModel rectangle)
        {
            _currentColorIndex = 0;
            Bitmap bitmap = new Bitmap(BITMAP_WIDTH, BITMAP_HEIGHT, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            var first = lines.First();
            long currentPolygon = first.PolygonId;
            var firstDot = first.Dot;
            var prevDot = first.Dot;
            Pen pen = new Pen(GetNextColor(), 1);
            foreach (var line in lines.Skip(1))
            {
                if (line.PolygonId != currentPolygon)
                {
                    currentPolygon = line.PolygonId;
                    graphics.DrawLine(pen, prevDot.X, prevDot.Y, firstDot.X, firstDot.Y);
                    firstDot = line.Dot;
                    prevDot = line.Dot;
                    
                    pen = new Pen(GetNextColor(), 1);
                }

                graphics.DrawLine(pen, prevDot.X, prevDot.Y, line.Dot.X, line.Dot.Y );
                prevDot = line.Dot;
                //x1 = line.Dot.X * SCALE;
                //y1 = line.Dot.Y * SCALE;
            }
            graphics.DrawLine(pen, prevDot.X, prevDot.Y, firstDot.X, firstDot.Y);

            graphics.DrawLine(_rectanglePen, rectangle.BottomLeftDot.X, rectangle.BottomLeftDot.Y, rectangle.BottomRightDot.X, rectangle.BottomRightDot.Y);
            graphics.DrawLine(_rectanglePen, rectangle.BottomRightDot.X, rectangle.BottomRightDot.Y, rectangle.TopRightDot.X, rectangle.TopRightDot.Y);
            graphics.DrawLine(_rectanglePen, rectangle.TopRightDot.X, rectangle.TopRightDot.Y, rectangle.TopLeftDot.X, rectangle.TopLeftDot.Y);
            graphics.DrawLine(_rectanglePen, rectangle.BottomLeftDot.X, rectangle.BottomLeftDot.Y, rectangle.TopLeftDot.X, rectangle.TopLeftDot.Y);

            string fileName = Environment.CurrentDirectory + "\\DrawCalculatedLines.png";
            bitmap.Save(fileName);
            return fileName;
        }
        public string CreateImage(HashSet<LineModel> lines)
        {
            _currentColorIndex = 0;
            Bitmap bitmap = new Bitmap(BITMAP_WIDTH , BITMAP_HEIGHT, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.BlanchedAlmond);
            var first = lines.First();
            long currentPolygon = first.PolygonId;
            float x1 = first.Dot.X;
            float y1 = first.Dot.Y ;
            float firstX1 = x1;
            float firstY1 = y1;
            Pen pen = new Pen(GetNextColor(), 1);
            foreach (var line in lines.Skip(1))
            {
                if (line.PolygonId != currentPolygon)
                {
                    currentPolygon = line.PolygonId;
                    graphics.DrawLine(pen, x1, y1, firstX1, firstY1);
                    firstX1 = line.Dot.X;
                    firstY1 = line.Dot.Y ;
                    x1 = firstX1;
                    y1 = firstY1;
                    pen = new Pen(GetNextColor(), 1);
                }
                graphics.DrawLine(pen, x1, y1, line.Dot.X, line.Dot.Y);
                x1 = line.Dot.X;
                y1 = line.Dot.Y;
            }
            graphics.DrawLine(pen, x1, y1, firstX1, firstY1);

            string fileName = Environment.CurrentDirectory + "\\DrawLoadedLines.png";
            bitmap.Save(fileName);
            return fileName;
        }

        private Color GetNextColor()
        {
            _currentColorIndex++;
            if (_currentColorIndex < MAX_COLORS)
            {
                return _lineColors[_currentColorIndex];
            }
            _currentColorIndex = 0;
            return _lineColors[_currentColorIndex];
        }
    }
}
