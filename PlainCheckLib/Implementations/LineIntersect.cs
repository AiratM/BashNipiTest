using PlainCheckContracts.Dto;
using PlainCheckContracts.Interfaces;
using PlainCheckContracts.Models;
using System;
using System.Threading.Tasks;

namespace PlainCheckLib.Implementations
{
    public class LineIntersect : ILineIntersect
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dot1"></param>
        /// <param name="dot2"></param>
        /// <param name="dot3"></param>
        /// <returns>true - положительное значение</returns>
        private bool Area(DotModel dot1, DotModel dot2, DotModel dot3)
        {
            return (dot2.X - dot1.X) * (dot3.Y - dot1.Y) - (dot2.Y - dot1.Y) * (dot3.X - dot1.X) > 0;
        }

        private bool Intersect(float x1, float x2, float x3, float x4)
        {
            if (x1 > x2)
            {
                float tmp = x1;
                x1 = x2;
                x2 = tmp;
            }
            if (x3 > x4)
            {
                float tmp = x3;
                x3 = x4;
                x4 = tmp;
            }
            return (x1 > x3 ? x1 : x3) <= (x2 < x4 ? x2 : x4);

        }
        public bool LineIntersectCheck(DotModel dot1, DotModel dot2, DotModel dot3, DotModel dot4)
        {
            if (dot1.Equals(dot3) || dot2.Equals(dot4))
            {
                return true;
            }
            return Intersect(dot1.X, dot2.X, dot3.X, dot4.X) && Intersect(dot1.Y, dot2.Y, dot3.Y, dot4.Y) &&
            (Area(dot1, dot2, dot3) != Area(dot1, dot2, dot4)) &&
            (Area(dot3, dot4, dot1) != Area(dot3, dot4, dot2));
        }
    }
}
