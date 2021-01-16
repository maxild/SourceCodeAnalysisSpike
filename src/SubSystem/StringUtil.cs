using System.Collections.Generic;

namespace SourceCodeAnalysisSpike.SubSystem
{
    public static class StringUtil
    {
        public static int LengthOf(this string s) => s.Length;

        public static int GetCount(Dictionary<string, int> wordCount, string searchWord)
        {
            // Fix by use discard
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            var unused = wordCount.TryGetValue(searchWord, out var count);
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            return count;
        }

#pragma warning disable IDE0060 // Remove unused parameter
        public static int GetNum1(int unusedParam) => 1;
#pragma warning restore IDE0060 // Remove unused parameter
    }
}
