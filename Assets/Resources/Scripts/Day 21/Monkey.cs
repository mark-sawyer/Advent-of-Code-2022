using System;
using System.Collections.Generic;

namespace advent21 {
    public class Monkey {
        public string name { get; private set; }
        public bool numberKnown { get; private set; }
        public long number { get; private set; }
        public string aMonkeyName { get; private set; }
        public string bMonkeyName { get; private set; }
        public string expression { get; set; }
        private Func<long, long, long> operation;

        public Monkey(string name, long number) {
            this.name = name;
            this.number = number;
            numberKnown = true;
            expression = number.ToString();
        }
        public Monkey(string name, string expression) {
            this.name = name;
            this.expression = expression;
            char symbol = expression[5];
            switch (symbol) {
                case '+':
                    operation = (a, b) => a + b;
                    break;
                case '-':
                    operation = (a, b) => a - b;
                    break;
                case '*':
                    operation = (a, b) => a * b;
                    break;
                case '/':
                    operation = (a, b) => a / b;
                    break;
            }
            aMonkeyName = expression.Substring(0, 4);
            bMonkeyName = expression.Substring(7, 4);
            if (name == "root") {
                this.expression = expression.Replace('+', '=');
            }
        }

        public void tryLearnNumber(List<Monkey> monkeys) {
            Monkey aMonkey = MonkeyFinder.exe(monkeys, aMonkeyName);
            Monkey bMonkey = MonkeyFinder.exe(monkeys, bMonkeyName);

            if (aMonkey.numberKnown && bMonkey.numberKnown) {
                number = operation(aMonkey.number, bMonkey.number);
                numberKnown = true;
            }
        }

        public void tryLearnNumber2(List<Monkey> monkeys) {
            Monkey aMonkey = MonkeyFinder.exe(monkeys, aMonkeyName);
            Monkey bMonkey = MonkeyFinder.exe(monkeys, bMonkeyName);

            if (aMonkey.name == "humn" || bMonkey.name == "humn") return;

            if (aMonkey.numberKnown && bMonkey.numberKnown) {
                number = operation(aMonkey.number, bMonkey.number);
                numberKnown = true;
                expression = number.ToString();
            }
        }
    }
}
