using System.Text;
using SourceCodeAnalysisSpike.SubSystem;
using System.Collections.Generic;
using System;

namespace SourceCodeAnalysisSpike
{
    class Program
    {
        static int Main()
        {
            // warning IDE0059: Unnecessary assignment of a value to 'unused'
            // warning CS0219: The variable 'unused' is assigned but its value is never used
            //int unused = 0;

            var sb = new StringBuilder();
            sb.Append("Hello World");
            Console.WriteLine(sb);

            var list = new List<int> { 0, sb.ToString().LengthOf() };

            return list[0];
        }
    }
}
