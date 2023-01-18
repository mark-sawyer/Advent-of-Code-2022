using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace advent11 {
    public class AoC11 : MonoBehaviour {
        private List<Monkey> monkeys;
        private string[] input;
        private int i;

        private void Start() {
            input = File.ReadAllLines("C:\\Documents\\R Files\\Advent of Code\\Inputs\\advent 11.txt");
            monkeys = InputInterpreter.interpretInputMonkeys(input);

            partTwo();
        }

        public Monkey getMonkeyFromIndex(int i) {
            return monkeys[i];
        }

        public void partOne() {
            for (int i = 0; i < 20; i++) {
                foreach (Monkey monkey in monkeys) monkey.inspectAndThrow();
            }

            foreach (Monkey monkey in monkeys) print(monkey.inspectionCount);
        }

        public void partTwo() {
            for (int i = 0; i < 10000; i++) {
                foreach (Monkey monkey in monkeys) monkey.inspectAndThrowWithExtraWorry();
            }

            foreach (Monkey monkey in monkeys) print(monkey.inspectionCount);
        }
    }
}
