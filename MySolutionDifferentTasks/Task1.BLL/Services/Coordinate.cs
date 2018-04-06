using System;

namespace Task1.BLL.Services
{
    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }

        public static Coordinate Parse(string data)
        {
            var split = data.Split(',');
            if (split.Length != 2)
            {
                throw new Exception("ERROR: Wrong number of parameters.");
            }

            double.TryParse(split[0], out var x);
            double.TryParse(split[1], out var y);

            return new Coordinate { X = x, Y = y };
        }

        public override string ToString()
        {
            return $"X: {X:0.00} Y: {Y:0.00}";
        }
    }
}
