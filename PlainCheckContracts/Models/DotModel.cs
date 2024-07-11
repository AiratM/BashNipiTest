using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCheckContracts.Models
{
    public class DotModel : ICloneable, IEquatable<DotModel>
    {
        public float X { get; set; }
        public float Y { get; set; }

        public DotModel() { }

        public DotModel(float x, float y) { X = x; Y = y; }

        public object Clone()
        {
            return new DotModel(X, Y);
        }

        public bool Equals(DotModel other) => this.X == other.X && this.Y == other.Y;
    }
}
