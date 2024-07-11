﻿using PlainCheckApp.Interfaces;
using PlainCheckContracts.Dto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlainCheckApp.Services
{
    public class PngGraphicDraw : IGraphicDraw
    {
        private List<Color> _lineColors;
        private int _currentColorIndex = 0;
        private const int MAX_COLORS = 8;
        private const int SCALE = 2;
        private const int BITMAP_HEIGHT = 1000;
        private const int BITMAP_WIDTH = 1000;

        public PngGraphicDraw()
        {
            _lineColors = new List<Color> { Color.BlueViolet, Color.DarkKhaki, Color.DeepPink, Color.Brown, Color.Black, Color.DarkSeaGreen, Color.DeepPink, Color.DimGray };

        }
        public async Task<string> CreateImageAsync(HashSet<LineModel> lines) => await Task.Run(() => CreateImage(lines));

        public async Task<string> CreateImageAsync(HashSet<LineModel> lines, RectangleModel rectangle) => await Task.Run(() => CreateImage(lines, rectangle));

        public string CreateImage(HashSet<LineModel> lines, RectangleModel rectangle)
        {
        }
        public string CreateImage(HashSet<LineModel> lines)
        {
            Bitmap bitmap = new Bitmap(BITMAP_WIDTH * SCALE, BITMAP_HEIGHT * SCALE, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.BlanchedAlmond);
            var first = lines.First();
            long currentPolygon = first.PolygonId;
            float x1 = first.Dot.X * SCALE;
            float y1 = first.Dot.Y * SCALE;
            float firstX1 = x1;
            float firstY1 = y1;
            Pen pen = new Pen(GetNextColor(), 1);
            foreach (var line in lines.Skip(1))
            {
                if (line.PolygonId != currentPolygon)
                {
                    currentPolygon = line.PolygonId;
                    graphics.DrawLine(pen, x1, y1, firstX1, firstY1);
                    firstX1 = line.Dot.X * SCALE;
                    firstY1 = line.Dot.Y * SCALE;
                    x1 = firstX1;
                    y1 = firstY1;
                    pen = new Pen(GetNextColor(), 1);
                }
                graphics.DrawLine(pen, x1, y1, line.Dot.X * SCALE, line.Dot.Y * SCALE);
                x1 = line.Dot.X * SCALE;
                y1 = line.Dot.Y * SCALE;
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
