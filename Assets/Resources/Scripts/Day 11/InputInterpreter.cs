using System;
using System.Collections.Generic;

namespace advent11 {
    public static class InputInterpreter {
        public static int LINES_PER_MONKEY = 6;

        public static List<Monkey> interpretInputMonkeys(string[] input) {
            int length = input.Length;
            string[] s;
            List<Monkey> monkeys = new List<Monkey>();

            for (int i = 0; i < length; i += 7) {
                s = input[i..(i + 6)];
                monkeys.Add(createMonkey(s));
            }

            return monkeys;
        }

        private static Monkey createMonkey(string[] s) {
            List<long> startingItems = interpretStartingItems(s[1]);
            Func<long, long> operation = interpretOperation(s[2]);
            Func<long, bool> test = interpretTest(s[3]);
            int divisor = getDivisor(s[3]);
            int trueMonkey = interpretBoolMonkey(s[4], 29);
            int falseMonkey = interpretBoolMonkey(s[5], 30);

            return new Monkey(startingItems, operation, test, trueMonkey, falseMonkey, divisor);
        }

        private static List<long> interpretStartingItems(string s) {
            string numbersString = s.Substring(18);
            string[] numberStringArray = numbersString.Split(", ");
            List<long> nums = new List<long>();
            foreach (string numberString in numberStringArray)
                nums.Add(long.Parse(numberString));

            return nums;
        }

        private static Func<long, long> interpretOperation(string s) {
            string operationString = s.Substring(23);

            char operator_;
            string afterOperator = operationString.Substring(2);

            if (afterOperator == "old") operator_ = '^';
            else operator_ = operationString[0];

            if (operator_ == '^') return (old) => (long)Math.Pow(old, 2);
            else {
                int num = int.Parse(afterOperator);
                if (operator_ == '+') return (old) => old + num;
                else if (operator_ == '*') return (old) => old * num;
            }

            throw new Exception("Couldn't interpret operation.");
        }

        private static Func<long, bool> interpretTest(string s) {
            long divisor = long.Parse(s.Substring(21));
            return (x) => x % divisor == 0;
        }

        private static int getDivisor(string s) {
            return int.Parse(s.Substring(21));
        }

        private static int interpretBoolMonkey(string s, int index) {
            return int.Parse(s.Substring(index));
        }
    }
}
