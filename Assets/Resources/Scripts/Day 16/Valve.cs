
using System.Collections.Generic;

namespace advent16 {
    public class Valve {
        public string name { get; private set; }
        public int flowRate { get; private set; }
        public List<Valve> connections { get; private set; }
        public int index { get; private set; }
        public bool open { get; set; }



        public Valve(string name, int flowRate, int index) {
            this.name = name;
            this.flowRate = flowRate;
            this.index = index;
        }
        public void populateConnections(List<Valve> otherValves, string[] connectionStrings) {
            connections = new List<Valve>();
            foreach (Valve valve in otherValves) {
                foreach (string cs in connectionStrings) {
                    if (valve.name == cs) connections.Add(valve);
                }
            }
        }
        public bool hasConnection(Valve otherValve) {
            return connections.Contains(otherValve);
        }
    }
}
