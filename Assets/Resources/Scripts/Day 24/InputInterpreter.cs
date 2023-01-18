using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace advent24 {
    public static class InputInterpreter {
        public static void exe(string[] input) {
            char c;
            for (int row = 0; row < input.Length; row++) {
                for (int col = 0; col < input[0].Length; col++) {
                    c = input[row][col];
                    if (c == '#') instantiateWall(row, col);
                    else if (c != '.') instantiateBlizzard(row, col, c);
                }
            }

            WallBounds.setBounds(input);
        }

        private static void instantiateWall(int row, int col) {
            GameObject.Instantiate(
                Resources.Load<GameObject>("Prefabs/wall"),
                new Vector2(col, -row),
                Quaternion.identity
            );
        }

        private static void instantiateBlizzard(int row, int col, char c) {
            GameObject blizzard = GameObject.Instantiate(
                Resources.Load<GameObject>("Prefabs/blizzard"),
                new Vector2(col, -row),
                Quaternion.identity
            );
            blizzard.GetComponent<Blizzard>().setType(c);
        }
    }
}
