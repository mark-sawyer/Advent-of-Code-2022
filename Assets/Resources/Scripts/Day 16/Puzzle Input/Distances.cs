using System.Collections.Generic;

namespace advent16 {
    public class Distances {
        private int[,] initializeDistances(List<Valve> valves) {
            int[,] distances = new int[valves.Count, valves.Count];
            for (int row = 0; row < distances.GetLength(0); row++) {
                for (int col = 0; col < distances.GetLength(1); col++) {
                    distances[row, col] = Constants.FLAG_NUM;
                }
            }
            return distances;
        }
        private void findDistance(int row, int col, int[,] distances, List<Valve> valves) {
            Valve currentValve = valves[row];
            Valve compareValve = valves[col];

            if (currentValve == compareValve) distances[row, col] = 0;
            else if (currentValve.hasConnection(compareValve)) distances[row, col] = 1;
            else {
                // Check each connection for its distance to the node.
                // Use that plus one, if it's lower than what we already have.

                int currentMin = distances[row, col];
                foreach (Valve connectionValve in currentValve.connections) {
                    int connectIndex = connectionValve.index;
                    int distanceThroughThisNode = distances[connectIndex, col] + 1;
                    if (distanceThroughThisNode < currentMin) currentMin = distanceThroughThisNode;
                }
                distances[row, col] = currentMin;
            }
        }
        private void findDistancesLoop(int[,] distances, List<Valve> valves) {
            for (int row = 0; row < valves.Count; row++) {
                for (int col = 0; col < valves.Count; col++) {
                    findDistance(row, col, distances, valves);
                }
            }
        }
        private bool atLeastOneFlag(int[,] distances) {
            for (int row = 0; row < distances.GetLength(0); row++) {
                for (int col = 0; col < distances.GetLength(1); col++) {
                    if (distances[row, col] == Constants.FLAG_NUM) return true;
                }
            }
            return false;
        }
        private int[,] d;




        public Distances(List<Valve> valves) {
            int[,] distances = initializeDistances(valves);
            while (atLeastOneFlag(distances)) findDistancesLoop(distances, valves);
            findDistancesLoop(distances, valves);  // One final loop through might be necessary.
            d = distances;
        }
        public string getDistanceString(int row, int col) {
            return d[row, col].ToString();
        }
        public int getDistance(int row, int col) {
            return d[row, col];
        }
    }
}