using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the sherlockAndAnagrams function below.
    static int sherlockAndAnagrams(string s) {
        int result = 0;
        Dictionary<string, int> dict = new Dictionary<string, int>();
        
        for(int i = 0; i < s.Length; ++i) {
            for(int j = 1; j <= (s.Length - i); ++j) {
                string substring = new String(s.Substring(i, j).OrderBy(c => c).ToArray());
                if(dict.ContainsKey(substring)) {
                    ++dict[substring];
                } else {
                    dict.Add(substring, 1);
                }
            }
        }

        foreach(int value in dict.Values.Where(v => v > 1)) {
            result += value * (value - 1) / 2;
        }

        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string s = Console.ReadLine();

            int result = sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
