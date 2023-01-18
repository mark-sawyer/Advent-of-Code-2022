using System.Collections.Generic;

namespace advent16 {
    public static class StateInformation {
        private static GraphInformation graphInformation;

        public static List<Valve> onValves { get; private set; }
        public static int points { get; set; }
        public static Valve at { get; set; }
        public static Valve target { get; set; }
        public static int timeLeft { get; set; }




        public static void setup(GraphInformation info, int startingIndex) {
            timeLeft = Constants.TOTAL_TIME;
            graphInformation = info;
            at = graphInformation.valves[startingIndex];
            target = graphInformation.valves[startingIndex];
            onValves = new List<Valve>();
        }
        public static List<Valve> getValves() {
            return graphInformation.valves;
        }
        public static Distances getDistances() {
            return graphInformation.distances;
        }
        public static int distanceWouldMove() {
            int atIndex = at.index;
            int targetIndex = target.index;
            return graphInformation.distances.getDistance(atIndex, targetIndex);
        }
        public static void getPoints(int turns) {
            foreach (Valve valve in onValves) {
                points += (valve.flowRate * turns);
            }
        }
        public static void reset() {
            timeLeft = Constants.TOTAL_TIME;
            points = 0;
            onValves.Clear();
            List<Valve> valves = graphInformation.valves;
            foreach (Valve valve in valves) valve.open = false;
            at = ValveGetter.exe(Constants.STARTING_NAME);
            Events.updateVisuals.Invoke();
        }
    }
}
