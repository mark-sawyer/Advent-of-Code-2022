using System.Collections.Generic;

namespace advent19 {
    public static class TurnsToBuyableList {
        private static List<TurnsToBuyable> turnsToBuyables = new List<TurnsToBuyable> {
            new TurnsToBuyable(Mineral.ORE),
            new TurnsToBuyable(Mineral.CLAY),
            new TurnsToBuyable(Mineral.OBSIDIAN),
            new TurnsToBuyable(Mineral.GEODE)
        };




        public static void updateTurns() {
            foreach (TurnsToBuyable turnsToBuyable in turnsToBuyables) turnsToBuyable.updateTurns();
        }
        public static TurnsToBuyable getTurnsToBuyable(Mineral mineral) {
            TurnsToBuyable turnsToBuyable = null;
            switch (mineral) {
                case Mineral.ORE:
                    turnsToBuyable = turnsToBuyables[0];
                    break;
                case Mineral.CLAY:
                    turnsToBuyable = turnsToBuyables[1];
                    break;
                case Mineral.OBSIDIAN:
                    turnsToBuyable = turnsToBuyables[2];
                    break;
                case Mineral.GEODE:
                    turnsToBuyable = turnsToBuyables[3];
                    break;
            }
            return turnsToBuyable;
        }
    }
}
