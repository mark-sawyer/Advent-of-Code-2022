using System.Collections.Generic;

namespace advent21 {
    public static class InputInterpreter {
        public static List<Monkey> exe(string[] input) {
            List<Monkey> monkeys = new List<Monkey>();
            string name;
            string expression;
            foreach (string s in input) {
                name = s.Substring(0, 4);
                expression = s.Substring(6);
                if (int.TryParse(expression, out int i)) monkeys.Add(new Monkey(name, i));
                else monkeys.Add(new Monkey(name, expression));
            }

            return monkeys;
        }
    }
}
