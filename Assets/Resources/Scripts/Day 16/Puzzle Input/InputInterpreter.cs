using System.Collections.Generic;
using System.Linq;
using System;

namespace advent16 {
    public static class InputInterpreter {
        private static int getFlowRate(string s) {
            int length = 0;
            foreach (char c in s) {
                if (c != ';') length++;
                else break;
            }
            string numString = s.Substring(0, length);
            return int.Parse(numString);
        }
        private static string[] getConnectionStrings(string s) {
            int length = s.Length;
            int index = 0;
            for (int i = length - 1; i > 0; i--) {
                if (s[i] == 's' | s[i] == 'e') {
                    index = i + 2;
                    break;
                }
            }

            string connections = s.Substring(index);
            return connections.Split(", ");
        }
        private static List<Valve> getValves(string[] input) {
            List<Valve> valves = new List<Valve>();
            string s;
            for (int i = 0; i < input.Length; i++) {
                s = input[i];
                string name = s.Substring(6, 2);
                int flowRate = getFlowRate(s.Substring(23));
                valves.Add(new Valve(name, flowRate, i));
            }
            return valves;
        }
        private static List<string[]> getConnectionStringArrays(string[] input) {
            List<string[]> connectionStringsList = new List<string[]>();
            foreach (string s in input) {
                connectionStringsList.Add(getConnectionStrings(s));
            }
            return connectionStringsList;
        }
        private static void connectValves(List<Valve> valves, List<string[]> connectionStringArrays) {
            Valve valve;
            for (int i = 0; i < valves.Count; i++) {
                valve = valves[i];
                valve.populateConnections(valves, connectionStringArrays[i]);
            }
        }
        private static int getStartingIndex(List<Valve> valves) {
            for (int i = 0; i < valves.Count; i++) {
                if (valves[i].name == Constants.STARTING_NAME) return i;
            }
            throw new Exception(Constants.STARTING_NAME + " not found.");
        }




        public static void exe(string[] input) {
            List<Valve> valves = getValves(input);
            List<string[]> connectionStringArrays = getConnectionStringArrays(input);
            connectValves(valves, connectionStringArrays);
            GraphInformation graphInformation = new GraphInformation(valves);
            int startingIndex = getStartingIndex(valves);
            StateInformation.setup(graphInformation, startingIndex);
        }
    }
}
