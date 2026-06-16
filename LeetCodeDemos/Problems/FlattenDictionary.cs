namespace LeetCodeDemos.Problems
{
    //var input = new Dictionary<string, object>
    // {
    //     { "a", "sample" },
    //     { "b", new Dictionary<string, object>
    //         {
    //             { "c", "sample c" }
    //         }
    //     },
    //     { "d", new Dictionary<string, object>
    //         {
    //             { "e", new Dictionary<string, object>
    //                 {
    //                     { "f", "sample f" }
    //                 }
    //             }
    //         }
    //     }
    // };
    // Expected output
    // var output = new Dictionary<string, string>
    // {
    //     { "a", "sample" },
    //     { "b.c", "sample c" },
    //     { "d.e.f", "sample f" }
    // };
    // Two solutions - with and without linq
    internal class FlattenDictionary : ISolutionClass
    {
        public Dictionary<string, string> Solution(Dictionary<string, object> input)
        {
            var output = new Dictionary<string, string>();
            foreach (var pair in input)
            {
                var (key, value) = FlattenDictionaryRecurrence(pair);
                output.Add(key, value);
            }
            return output;
        }

        private (string, string) FlattenDictionaryRecurrence(KeyValuePair<string, object> input)
        {
            if (input.Value is string)
            {
                return (input.Key, (string)input.Value);
            }
            else // (input.Value is Dictionary<string, object>)
            {
                foreach(var pair in (input.Value as Dictionary<string, object>)!)
                {
                    var (key, value) = FlattenDictionaryRecurrence(pair);
                    return (input.Key + "." + key, value);
                }
            }

            return ("", "");
        }

        public Dictionary<string, string> SolutionWithLinq(Dictionary<string, object> input)
        {
            return FlattenDictionaryRecurrenceWithLinq(input);
        }

        static Dictionary<string, string> FlattenDictionaryRecurrenceWithLinq(Dictionary<string, object> dict, string prefix = "")
        {
            return dict.SelectMany(kv =>
            {
                string key = string.IsNullOrEmpty(prefix) ? kv.Key : $"{prefix}.{kv.Key}";

                if (kv.Value is Dictionary<string, object> nestedDict)
                {
                    return FlattenDictionaryRecurrenceWithLinq(nestedDict, key);
                }
                else
                {
                    return (new Dictionary<string, string> { { key, (kv.Value as string)! } });
                }
            }).ToDictionary(k => k.Key, v => v.Value);
        }

        public void TestSolution()
        {
            var solution = Solution(new Dictionary<string, object>
                 {
                     { "a", "sample" },
                     { "b", new Dictionary<string, object>
                         {
                             { "c", "sample c" }
                         }
                     },
                     { "d", new Dictionary<string, object>
                         {
                             { "e", new Dictionary<string, object>
                                 {
                                     { "f", "sample f" }
                                 }
                             }
                         }
                     }
                 });
            foreach (var pair in solution)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }

            solution = SolutionWithLinq(new Dictionary<string, object>
                 {
                     { "a", "sample" },
                     { "b", new Dictionary<string, object>
                         {
                             { "c", "sample c" }
                         }
                     },
                     { "d", new Dictionary<string, object>
                         {
                             { "e", new Dictionary<string, object>
                                 {
                                     { "f", "sample f" }
                                 }
                             }
                         }
                     }
                 });
            foreach (var pair in solution)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }
        }
    }
}
