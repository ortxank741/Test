using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.BLL.Services
{
    public class ReaderWriter
    {
        private const string FileNameOrdinary = "Data.txt";
        private const string FileNameBinary = "BinaryData.dat";
        private static readonly string FilePath =
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName + "/";

        public static List<Coordinate> CoordinatesFromFile()
        {
            var coordinates = new List<Coordinate>();

            using (var sr = new StreamReader(FilePath + FileNameOrdinary))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        coordinates.Add(Coordinate.Parse(line));
                    }
                }
            }
            return coordinates;
        }

        public static void CoordinateBenaryWriter(List<Coordinate> coordinates)
        {
            if (coordinates == null)
            {
                throw new Exception("ERROR: List of coordinates is empty");
            }

            using (var bw = new BinaryWriter(File.Open(FilePath + FileNameBinary, FileMode.OpenOrCreate)))
            {
                foreach (var coordinate in coordinates)
                {
                    bw.Write(coordinate.X);
                    bw.Write(coordinate.Y);
                }
            }
        }

        public static List<Coordinate> CoordinateBinaryReader()
        {
            using (var br = new BinaryReader(File.Open(FilePath + FileNameBinary, FileMode.Open)))
            {
                var coordinates = new List<Coordinate>();
                Console.WriteLine("\nCoordinates from binary file:");
                while (br.PeekChar() > -1)
                {
                    var x = br.ReadDouble();
                    var y = br.ReadDouble();
                    coordinates.Add(new Coordinate { X = x, Y = y });
                }

                return coordinates;
            }
        }
    }
}
