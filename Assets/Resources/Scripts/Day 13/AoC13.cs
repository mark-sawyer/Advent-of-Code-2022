using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace advent13 {
    public class AoC13 : MonoBehaviour {
        private string[] input = File.ReadAllLines("C:\\Documents\\R Files\\Advent of Code\\Inputs\\advent 13.txt");


        private void Start() {
            partOne();
            partTwo();
        }

        private void partOne() {
            List<NumListPair> numListPairs = InputInterpreter.getNumListPairsListFromInput(input);
            foreach (NumListPair numListPair in numListPairs) numListPair.determineCorrectOrder();
            List<int> correctIndices = new List<int>();
            for (int i = 0; i < numListPairs.Count; i++) {
                if (numListPairs[i].correctOrder) correctIndices.Add(i + 1);
            }

            int sum = 0;
            foreach (int i in correctIndices) sum += i;
            print(sum);
        }

        private void partTwo() {
            List<string> simpleInput = new List<string>();
            foreach (string inputString in input) {
                if (inputString.Length != 0) simpleInput.Add(inputString);
            }
            simpleInput.Add("[[2]]");
            simpleInput.Add("[[6]]");

            List<NumList> numLists = InputInterpreter.getNumListsFromInput(input);
            int length = numLists.Count;
            int swaps = 0;
            string oneString;
            string twoString;
            NumList one;
            NumList two;
            NumListPair numListPair;
            do {
                swaps = 0;
                for (int i = 0; i < length - 1; i++) {
                    one = numLists[i];
                    two = numLists[i + 1];
                    oneString = simpleInput[i];
                    twoString = simpleInput[i + 1];
                    numListPair = new NumListPair(one, two);
                    numListPair.determineCorrectOrder();
                    if (!numListPair.correctOrder) {
                        numLists[i] = two;
                        numLists[i + 1] = one;
                        simpleInput[i] = twoString;
                        simpleInput[i + 1] = oneString;
                        swaps++;
                    }
                }
            } while (swaps != 0);


            int[] indices = new int[2];
            for (int i = 0; i < simpleInput.Count; i++) {
                if (simpleInput[i] == "[[2]]") indices[0] = i + 1;
                if (simpleInput[i] == "[[6]]") indices[1] = i + 1;
            }

            print(indices[0] * indices[1]);
        }
    }
}
