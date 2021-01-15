using System.Text;
using SourceCodeAnalysisSpike.SubSystem;
using System.Collections.Generic;
using System;
// IDE0005: Using directive is unnecessary.
//using System.Threading;

namespace SourceCodeAnalysisSpike
{
    internal class Program
    {
        private static int Main()
        {
            // warning IDE0059: Unnecessary assignment of a value to 'unused'
            // warning CS0219: The variable 'unused' is assigned but its value is never used
            int x = 0;

            Console.WriteLine(int.Parse("3"));

            // IDE0004: remove unnecesary cast should not be enforved on build. but it is here??? remove suppresion to see...
#pragma warning disable IDE0004 // Remove Unnecessary Cast
            var c = (Color)Color.Green;
#pragma warning restore IDE0004 // Remove Unnecessary Cast


            if (((int)c % 2) == 0)
                throw new InvalidOperationException();

            switch (c)
            {
                case Color.Red:
                    {
                        Console.WriteLine("The color is red");
                        break;
                    }
                case Color.Blue:
                    Console.WriteLine("The color is blue");
                    break;
                case Color.Green:
                    Console.WriteLine("The color is green");
                    break;
                default:
                    Console.WriteLine("The color is unknown.");
                    break;
            }

            // object initializers formatting
            var pt = new Point { X = 1, Y = 2 };
            _ = new Point
            {
                X = 1,
                Y = 2
            };
#pragma warning disable IDE0050 // Convert to tuple
            _ = new { X = 1, Y = 2 };
#pragma warning restore IDE0050 // Convert to tuple

            var sb = new StringBuilder();
            _ = sb.AppendFormat("Hello {0}", pt);
            Console.WriteLine(sb);

            var list = new List<int> { 0, sb.ToString().LengthOf() };

            return list[x];
        }
    }

    internal enum Color
    {
        Red,
        Blue,
        Green
    }

    public class Person
    {
        // IDE0032: Use auto property
        private readonly string _name;

        public Person(string name)
        {
            // TODO: Verify this via GH-issue
            // ID0003 cannot be enforced on build in .NET 5
#pragma warning disable IDE0003
            this._name = name;
#pragma warning restore IDE0003
        }

        // IDE0032: Use auto property
        public string Name => _name;
    }

    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    internal class Point3 : Point
    {
        public int Z { get; set; }
    }

}
