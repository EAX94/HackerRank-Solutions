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
    // Complete the countTriplets function below.
    static long countTriplets(List<long> arr, long r) {
        long result = 0;

        Dictionary<long, long> dict1 = arr.Distinct().ToDictionary(Key => Key, Value => 0L);
        Dictionary<long, long> dict2 = new Dictionary<long, long>(dict1);

        foreach(int item in arr.Reverse<long>()) {
            long itemValue = item * r;

            if (dict2.TryGetValue(itemValue, out long dict2ItemValue)) {
                result += dict2ItemValue;
            }

            if (dict1.TryGetValue(itemValue, out long dict1ItemValue)) {
                dict2[item] += dict1ItemValue;
            }

            ++dict1[item];
        }

        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nr = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
