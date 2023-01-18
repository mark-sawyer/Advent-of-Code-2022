using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Data;

namespace advent21 {
    public class AoC21 : MonoBehaviour {
        private string[] input;
        private List<Monkey> monkeys;

        private void Start() {
            input = File.ReadAllLines("C:\\Documents\\R Files\\Advent of Code\\Inputs\\advent 21.txt");
            monkeys = InputInterpreter.exe(input);
            partTwo();
        }

        private void partOne() {
            while (!MonkeyFinder.exe(monkeys, "root").numberKnown) {
                foreach (Monkey m in monkeys) {
                    if (m.numberKnown) continue;
                    m.tryLearnNumber(monkeys);
                }
            }

            print(MonkeyFinder.exe(monkeys, "root").number);
        }

        private void partTwo() {
            bool numberLearned;
            do {
                numberLearned = false;
                foreach (Monkey m in monkeys) {
                    if (m.numberKnown) continue;
                    m.tryLearnNumber2(monkeys);
                    if (m.numberKnown) numberLearned = true;
                }
            } while (numberLearned);

            Monkey root = MonkeyFinder.exe(monkeys, "root");
            string monkeyName;
            bool changedSomething;
            do {
                changedSomething = false;
                for (int i = 0; i<root.expression.Length; i++) {
                    if (!CharIsAlphabet.exe(root.expression[i])) continue;
                    monkeyName = root.expression.Substring(i, 4);
                    if (monkeyName == "humn") {
                        i = i + 4;
                        continue;
                    }
                    Monkey m = MonkeyFinder.exe(monkeys, monkeyName);
                    if (int.TryParse(m.expression, out int num))
                        root.expression = root.expression.Substring(0, i) + num + root.expression.Substring(i + 4);
                    else
                        root.expression = root.expression.Substring(0, i) + "(" + m.expression + ")" + root.expression.Substring(i + 4);
                    changedSomething = true;
                    break;
                }
            } while (changedSomething) ;
            print(root.expression);
            // Paste into https://www.mathpapa.com/algebra-calculator.html
        }
    }
}
