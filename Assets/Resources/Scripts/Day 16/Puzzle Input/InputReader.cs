using System.IO;
using UnityEngine;

namespace advent16 {
    public class InputReader : MonoBehaviour {
        private void Awake() {
            string[] input = File.ReadAllLines("C:\\Documents\\R Files\\Advent of Code\\Inputs\\advent 16.txt");
            InputInterpreter.exe(input);
        }
    }
}
