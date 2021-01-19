using System.Text;
using SourceCodeAnalysisSpike.SubSystem;
using System.Collections.Generic;
using System;
using System.Globalization;
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
            var x = 0;
            var age = 51;
            var name = "Morten Maxild";


#pragma warning disable IDE0037 // Use inferred member name
            _ = (age: age, name: name);
#pragma warning restore IDE0037 // Use inferred member name

            // TODO: Should give warning...
            // IDE0100: Remove unnecessary equality operator
            if (IsWin() == true) { }
            if (IsWin() != false) { }

            var obj = new object();

            // TODO: Should give warning...
            // IDE0110: Remove unnecessary discard
            switch (obj)
            {
                case int _:
                    Console.WriteLine("Value was an int");
                    break;
                case string _:
                    Console.WriteLine("Value was a string");
                    break;
                default:
                    break;
            }

#pragma warning disable IDE0080 // Remove unnecessary suppression operator
            _ = obj! is string;
#pragma warning restore IDE0080 // Remove unnecessary suppression operator

#pragma warning disable IDE0078 // Use pattern matching
#pragma warning disable IDE0083 // Use pattern matching
            _ = !(obj is C c2);
#pragma warning restore IDE0083 // Use pattern matching
#pragma warning restore IDE0078 // Use pattern matching

            var pt3 = new Point3 { X = 1, Y = 2, Z = 3 };

            // pt3 is not Point2
#pragma warning disable IDE0078 // Use pattern matching
            _ = !(pt3 is Point);
#pragma warning restore IDE0078 // Use pattern matching

            Console.WriteLine(int.Parse("3", CultureInfo.InvariantCulture));

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

            // IDE0050: Convert to tuple
#pragma warning disable IDE0050 // Convert to tuple
            _ = new { a = 1, b = 2 };
#pragma warning restore IDE0050 // Convert to tuple

            // object initializers formatting
            _ = new Point { X = 1, Y = 2 };
            _ = new Point
            {
                X = 1,
                Y = 2
            };
#pragma warning disable IDE0050 // Convert to tuple
            _ = new { X = 1, Y = 2 };
#pragma warning restore IDE0050 // Convert to tuple

            var sb = new StringBuilder();
#pragma warning disable IDE0082 // 'typeof' can be converted  to 'nameof'
            _ = sb.AppendFormat(CultureInfo.InvariantCulture, "Hello {0}", typeof(int).Name);
#pragma warning restore IDE0082 // 'typeof' can be converted  to 'nameof'
            Console.WriteLine(sb);

            SayHello("Morten");

            var s = SayHelloTo(name => name);
            s = "Some other value";


            // TODO: IDE0059 does not work
            var unused = Compute(); // IDE0059: value written to 'v' is never read, so assignment to 'v' is unnecessary.
            unused = Compute2();

            var list = new List<int> { 0, sb.ToString().LengthOf() };

            return Convert(list[x]);
        }

        private static bool IsWin() => DateTime.Today.IsDaylightSavingTime();

        private static int Compute() => 0;

        private static int Compute2() => 0;

        private static string SayHelloTo(Func<string, string> func) =>
          func?.Invoke("Morten") ?? "Morten";

        private static void SayHello(string? s)
        {
#pragma warning disable IDE0041 // Use 'is null' check
            if (ReferenceEquals(s, null))
#pragma warning restore IDE0041 // Use 'is null' check
                throw new ArgumentNullException(nameof(s));

            Hello(s);
#pragma warning disable IDE0062 // Make local function 'static'
            void Hello(string s)
#pragma warning restore IDE0062 // Make local function 'static'
            {
                // IDE0041: this is okay?
                if (s == null) throw new ArgumentNullException(nameof(s));
                Console.WriteLine("Hello " + s);
            }
        }

        private static int Convert(int x)
        {
#pragma warning disable IDE0066 // Convert switch statement to expression
            switch (x)
#pragma warning restore IDE0066 // Convert switch statement to expression
            {
                case 1:
                    return 1 * 1;
                case 2:
                    return 2 * 2;
                default:
                    return 0;
            }
        }

        public void M(DateTime dateTime)
        {
            //  Starting in .NET 5 we will warn about this case with CS8073
#pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (dateTime == null)
#pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            {
                return;
            }
        }

        public void TestMethod(string str)
        {
            ReadOnlySpan<char> slice = str[1..3]; // CA1831 that is downgraded to suggestion in .editorconfig
        }

    }

#pragma warning disable IDE0040 // Add accessibility modifiers
    enum Color
#pragma warning restore IDE0040 // Add accessibility modifiers
    {
        Red,
        Blue,
        Green
    }

    internal class Car
    {
        public Car(string? make, int age)
        {
            if (!(make is null))
                (Make, Age) = (make, age);
            else
                (Make, Age) = ("<nil>", 0);
        }

        public string Make { get; }

        public int Age { get; }
    }

    public class Person
    {
        // IDE0032: Use auto property
#pragma warning disable IDE0032 // Use auto property
        private readonly string _name;
#pragma warning restore IDE0032 // Use auto property

        public Person(string name)
        {
            // BUG: if using 'name is null' is doesn't work
#pragma warning disable IDE0016 // Use 'throw' expression
            if (name == null) throw new ArgumentNullException(nameof(name));
#pragma warning restore IDE0016 // Use 'throw' expression

            // TODO: Verify this via GH-issue
            // ID0003 cannot be enforced on build in .NET 5
#pragma warning disable IDE0003
            this._name = name;
#pragma warning restore IDE0003
        }

        // IDE0032: Use auto property
#pragma warning disable IDE0032 // Use auto property
        public string Name => _name;
#pragma warning restore IDE0032 // Use auto property
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

    internal class B
    {
        public override int GetHashCode() => 0;
    }

    internal class C : B
    {
        public static int Value => 0;

#pragma warning disable IDE0070 // Use 'System.HashCode'
        public override int GetHashCode()
#pragma warning restore IDE0070 // Use 'System.HashCode'
        {
            // IDE0070: GetHashCode can be simplified.
            var hashCode = 339610899;
            hashCode = (hashCode * -1521134295) + base.GetHashCode();
            hashCode = (hashCode * -1521134295) + Value.GetHashCode();
            return hashCode;
        }

        // Fixed code
        // public override int GetHashCode() => System.HashCode.Combine(base.GetHashCode(), j);
    }

#pragma warning disable IDE0064 // Make readonly fields writable
    internal struct MyStruct
#pragma warning restore IDE0064 // Make readonly fields writable
    {
        public readonly int Value;

        public MyStruct(int value) => Value = value;

        public void TestAgain() // TODO: Name Violation
        {
            this =
                new MyStruct(5);
        }
    }



    public readonly struct ComplexNumber
    {
#pragma warning disable IDE0032 // Use auto property
        private readonly double _real;
#pragma warning restore IDE0032 // Use auto property

        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2) =>
            new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);

        public ComplexNumber(double real, double imaginary)
        {
            _real = real;
            Imaginary = imaginary;
        }

#pragma warning disable IDE0032 // Use auto property
        public double Real
        {
            get
            {
#pragma warning disable IDE0025 // Use expression body for properties
                return _real;
#pragma warning restore IDE0025 // Use expression body for properties
            }
        }
#pragma warning restore IDE0032 // Use auto property

        public double Imaginary { get; }
    }

    public class GenericSomething<T>
    {
        // CA1000: Do not declare static members on generic types? Cannot be set in .editorconfig via UI

        public static GenericSomething<TAnother> Empty<TAnother>() => new GenericSomething<TAnother>(default);

        public T? Name { get; }

        public GenericSomething(T? name) => Name = name;
    }
}
