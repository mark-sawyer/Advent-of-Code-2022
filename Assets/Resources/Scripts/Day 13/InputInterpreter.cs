using System.Collections.Generic;

namespace advent13 {
    public static class InputInterpreter {
        public static List<NumListPair> getNumListPairsListFromInput(string[] input) {
            int len = input.Length;
            int pairs = (len + 1) / 3;
            List<NumListPair> numListPairs = new List<NumListPair>(pairs);
            populateList(numListPairs, input, pairs);
            return numListPairs;
        }

        public static List<NumList> getNumListsFromInput(string[] input) {
            List<NumList> numLists = new List<NumList>();

            foreach (string numListString in input) {
                if (numListString.Length != 0) numLists.Add(NumListInterpreter.interpretString(numListString));
            }

            numLists.Add(NumListInterpreter.interpretString("[[2]]"));
            numLists.Add(NumListInterpreter.interpretString("[[6]]"));

            return numLists;
        }

        private static void populateList(List<NumListPair> numListPairList, string[] input, int pairs) {
            int inputIndex = 0;
            string stringOne;
            string stringTwo;

            while (numListPairList.Count < pairs) {
                stringOne = input[inputIndex];
                stringTwo = input[inputIndex + 1];
                numListPairList.Add(new NumListPair(stringOne, stringTwo));
                inputIndex += 3;
            }
        }
    }
}
