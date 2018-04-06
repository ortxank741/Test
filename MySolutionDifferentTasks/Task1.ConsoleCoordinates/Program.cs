using System;
using System.Collections.Generic;
using System.IO;
using Task1.BLL.Services;

namespace Task1.ConsoleCoordinates
{
    internal class Program
    {
        private static List<Coordinate> _coordinates;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Coordinates from file:");
                _coordinates = ReaderWriter.CoordinatesFromFile();

                Display();

                ReaderWriter.CoordinateBenaryWriter(_coordinates);

                Console.WriteLine("Coordintes from binary file:");
                _coordinates = ReaderWriter.CoordinateBinaryReader();

                Display();

                CoordinetesFromConsole();

                Display();

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private static void CoordinetesFromConsole()
        {
            _coordinates = new List<Coordinate>();
            string line;

            Console.WriteLine("\nEnter Coordinates:");

            while (!string.IsNullOrEmpty((line = Console.ReadLine())))
            {
                _coordinates.Add(Coordinate.Parse(line));
            }
        }

        public static void Display()
        {
            foreach (var coordinate in _coordinates)
            {
                Console.WriteLine(coordinate);
            }
        }
    }
}