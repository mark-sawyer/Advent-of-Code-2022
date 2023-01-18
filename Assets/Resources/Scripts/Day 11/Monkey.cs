using System;
using System.Collections.Generic;
using UnityEngine;

namespace advent11 {
    public class Monkey {
        public List<long> itemWorryLevels;
        public Func<long, long> operation;
        public Func<long, bool> test;
        public int trueMonkey;
        public int falseMonkey;
        public AoC11 advent;
        public int inspectionCount;
        public int divisor;

        public Monkey(
            List<long> itemWorryLevels, Func<long, long> operation,
            Func<long, bool> test, int trueMonkey, int falseMonkey,
            int divisor
        ) {
            this.itemWorryLevels = itemWorryLevels;
            this.operation = operation;
            this.test = test;
            this.trueMonkey = trueMonkey;
            this.falseMonkey = falseMonkey;
            this.divisor = divisor;
            advent = GameObject.Find("aoc").GetComponent<AoC11>();
        }

        public void inspectAndThrow() {
            long newWorryLevel;
            int receiveMonkeyIndex;
            Monkey receiveMonkey;
            foreach (long worryLevel in itemWorryLevels) {
                newWorryLevel = operation(worryLevel);
                newWorryLevel = newWorryLevel / 3;
                receiveMonkeyIndex = test(newWorryLevel) ? trueMonkey : falseMonkey;
                receiveMonkey = advent.getMonkeyFromIndex(receiveMonkeyIndex);
                receiveMonkey.catchItem(newWorryLevel);
                inspectionCount++;
            }
            itemWorryLevels.Clear();
        }

        public void inspectAndThrowWithExtraWorry() {
            long newWorryLevel;
            int receiveMonkeyIndex;
            Monkey receiveMonkey;
            foreach (long worryLevel in itemWorryLevels) {
                newWorryLevel = operation(worryLevel);
                newWorryLevel = newWorryLevel % 9699690;
                receiveMonkeyIndex = test(newWorryLevel) ? trueMonkey : falseMonkey;
                receiveMonkey = advent.getMonkeyFromIndex(receiveMonkeyIndex);
                receiveMonkey.catchItem(newWorryLevel);
                inspectionCount++;
            }
            itemWorryLevels.Clear();
        }

        public void catchItem(long worryLevel) {
            itemWorryLevels.Add(worryLevel);
        }
    }
}
