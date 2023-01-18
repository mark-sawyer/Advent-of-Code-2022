using UnityEngine;
using System.IO;

namespace advent19 {
    public class InputReader : MonoBehaviour {
        private void Awake() {
            string[] input = File.ReadAllLines("C:\\Documents\\R Files\\Advent of Code\\Inputs\\advent 19.txt");
            InputInterpreter.exe(input);
        }
    }
}
