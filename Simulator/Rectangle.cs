using System.Data;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Simulator
{
    internal class Rectangle
    {

        public int X1 { get; }
        public int X2 { get; }
        public int Y1 { get; }
        public int Y2 { get; }

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1)
            {
                (x2, x1) = (x1, x2);
                (y2, y1) = (y1, y2);
            }
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            if (Y1 > Y2)
            {
                throw new ArgumentException($"Cordinates (X1: {X1}, Y1: {Y1}, X2: {X2}, Y2: {Y2}) don't make rectangle");
            }
            if (X1 == X2 || Y1 == Y2)
            {
                throw new ArgumentException($"The rectangle with cordinates (X1: {x1}, Y1: {y1}, X2: {x2}, Y2: {y2}) is flat");
            }
        }
        public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y) { }
        public override string ToString()
        {
            return $"({X1}, {Y1}):({X2}, {Y2})";
        }
        public bool Contains(Point p)
        {
            return p.X >= X1 && p.X <= X2 && p.Y >= Y1 && p.Y <= Y2;
        }
    }
}
