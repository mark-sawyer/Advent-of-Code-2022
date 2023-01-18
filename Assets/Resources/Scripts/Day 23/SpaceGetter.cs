using UnityEngine;

namespace advent23 {
    public static class SpaceGetter {
        public static Space exe(int row, int col) {
            Space[,] spaces = GameObject.Find("aoc").GetComponent<AoC23>().spaces;
            return spaces[row, col];
        }
    }
}
