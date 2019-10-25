using System;

namespace Module2_4
{
    internal class MathOperations
    {
        public static double CirclePerimetr(double radius)
        {
            double perimetr = 2 * Math.PI * radius;
            return perimetr;
        }

        public static double InverseCirclePerimetr(double perimetr)
        {
            double radius = perimetr / (2 * Math.PI);
            return radius;
        }

        public static double CircleArea(double radius)
        {
            double area = Math.PI * Math.Pow(radius, 2);
            return area;
        }

        public static double InverseCircleArea(double area)
        {
            double radius = Math.Sqrt(area / Math.PI);
            return radius;
        }

        public static double RectanglePerimetr(double side1, double side2)
        {
            double perimetr = 2 * (side1 + side2);
            return perimetr;
        }

        public static double InverseRectanglePerimetr(double perimetr)
        {
            double side = perimetr / 4;
            return side;
        }

        public static double RectangleArea(double side1, double side2)
        {
            double area = side1 * side2;
            return area;
        }

        public static double InverseRectangleArea(double area)
        {
            double side = Math.Sqrt(area);
            return side;
        }

        public static double TrianglePerimetr(double side1, double side2, double side3)
        {
            double perimetr = side1 + side2 + side3;
            return perimetr;
        }

        public static double InverseTrianglePerimetr(double perimetr)
        {
            double side = perimetr / 3;
            return side;
        }

        public static double TriangleArea(double side1, double side2, double side3)
        {
            double halfPerimetr = TrianglePerimetr(side1, side2, side3) / 2;
            double area = Math.Sqrt(halfPerimetr * (halfPerimetr - side1) * (halfPerimetr - side2) * (halfPerimetr - side3));
            return area;
        }

        public static double InverseTriangleArea(double area)
        {
            double side = Math.Sqrt(4 * area / Math.Sqrt(3));
            return side;
        }
    }
}