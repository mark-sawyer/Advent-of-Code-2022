using System.Collections.Generic;
using System;

namespace advent16 {
    public static class ValveGetter {
        public static Valve exe(string name) {
            List<Valve> valves = StateInformation.getValves();
            foreach (Valve valve in valves) {
                if (valve.name == name) return valve;
            }
            throw new Exception("Valve not found");
        }
    }
}
