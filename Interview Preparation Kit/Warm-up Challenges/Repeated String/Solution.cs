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

    // Complete the repeatedString function below.
    static long repeatedString(string s, long n) {
        // Check edge case first
        if(s.Length == 1) {
            return (s[0] == 'a') ? n : 0;
        }

        long aCount = 0;
        long aRemainingCount = 0;
        long aMod = n % s.Length;

        for(int i = s.Length; i-- > 0;) {
            if(s[i] == 'a') {
                ++aCount;

                if(i < aMod) {
                    ++aRemainingCount;
                }
            }
        }

        return ((n - aMod) / s.Length * aCount) + aRemainingCount;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine());

        long result = repeatedString(s, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
