using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCheckContracts.Models
{
    public class DotModelComparer : IEqualityComparer<DotModel>
    {
        public bool Equals(DotModel x, DotModel y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }
            return x.X == y.X && x.Y == y.Y;
        }

        public int GetHashCode(DotModel obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 0;
            }
            return obj.GetHashCode() ^ obj.GetHashCode();
        }
    }
}
