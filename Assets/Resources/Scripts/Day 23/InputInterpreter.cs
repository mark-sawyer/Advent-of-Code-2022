
using UnityEngine;

namespace advent23 {
    public static class InputInterpreter {
        public static Space[,] exe(string[] input) {
            int rows = input[1].Length;
            int cols = input.Length;
            Space[,] spaces = new Space[3 * rows, 3 * cols];

            for (int row = 0; row < spaces.GetLength(0); row++) {
                for (int col = 0; col < spaces.GetLength(1); col++) {
                    spaces[row, col] = new Space(row, col);
                    if (inCentre(row, col, rows, cols) && hasElf(row, col, rows, cols, input))
                        spaces[row, col].addElf();
                }
            }

            return spaces;
        }

        private static bool inCentre(int row, int col, int rows, int cols) {
            return row >= rows && row < 2 * rows &&
                col >= cols && col < 2 * cols;
        }

        private static bool hasElf(int row, int col, int rows, int cols, string[] input) {
            int inputRow = row - rows;
            int inputCol = col - cols;
            char c = input[inputRow][inputCol];
            return c == '#';
        }
    }
}
