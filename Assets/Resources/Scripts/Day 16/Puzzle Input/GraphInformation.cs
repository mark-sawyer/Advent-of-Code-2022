using System.Collections.Generic;

namespace advent16 {
    public class GraphInformation {
        public List<Valve> valves { get; private set; }
        public Distances distances { get; private set; }
        public GraphInformation(List<Valve> valves) {
            this.valves = valves;
            distances = new Distances(valves);
        }
    }
}
