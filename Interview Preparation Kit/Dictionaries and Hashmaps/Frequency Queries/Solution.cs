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

    // Complete the freqQuery function below.
    static List<int> freqQuery(List<List<int>> queries) {
        List<int> result = new List<int>();
        Dictionary<int, int> dict1 = new Dictionary<int, int>();
        Dictionary<int, int> dict2 = new Dictionary<int, int>();

        dict2[0] = 0;

        foreach (var query in queries) {
            switch(query[0]) {
                case 1: {
                    if(!dict1.ContainsKey(query[1])) {
                        dict1[query[1]] = 0;
                        ++dict2[0];
                    }

                    --dict2[dict1[query[1]]];
                    ++dict1[query[1]];

                    if(!dict2.ContainsKey(dict1[query[1]])) {
                        dict2[dict1[query[1]]] = 0;
                    }

                    ++dict2[dict1[query[1]]];

                    break;
                } case 2: {
                    if(dict1.ContainsKey(query[1])) {
                        if(dict1[query[1]] > 0) {
                            --dict1[query[1]];
                            --dict2[dict1[query[1]] + 1];

                            if(dict1[query[1]] >= 0) {
                                if(!dict2.ContainsKey(dict1[query[1]])) {
                                    dict2[dict1[query[1]]] = 0;
                                }

                                ++dict2[dict1[query[1]]];
                            }
                        }
                    }
                    break;
                } case 3: {
                    result.Add((dict2.ContainsKey(query[1]) && dict2[query[1]] > 0) ? 1 : 0);
                    break;
                }
            }
        }

        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++) {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> ans = freqQuery(queries);

        textWriter.WriteLine(String.Join("\n", ans));

        textWriter.Flush();
        textWriter.Close();
    }
}
