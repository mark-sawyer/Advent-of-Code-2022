using System.Collections.Generic;

namespace advent21 {
    public static class MonkeyFinder {
        public static Monkey exe(List<Monkey> monkeys, string name) {
            Monkey monkey = null;

            foreach (Monkey m in monkeys) {
                if (m.name == name) {
                    monkey = m;
                    break;
                }
            }

            return monkey;
        }
    }
}
