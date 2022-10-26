using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyInferenceAlgorithm
{
    public class Function
    {
        public double A { get; set; }
        public double B { get; set; }

        public Point P1 { get; set; }//точка начала функции
        public Point P2 { get; set; }//точка конца функции

        public Function(Point p1, Point p2) //
        {
            P1 = p1;
            P2 = p2;
            A = (p2.Y - p1.Y) / (p2.X - p1.X);
            B = p2.Y - A * p2.X;
        }
        //Y - x1, X - x0

        /// <summary>
        /// Находит, в каком месте функция, к которой обращаются, пересчет высоту y
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        /// 
        public double GetValueX(double y)
        {
            return (y - this.B) / this.A;
        }
    }
}