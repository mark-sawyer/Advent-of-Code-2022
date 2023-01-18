using System.Collections.Generic;

namespace advent19 {
    public static class PossibleActionGetter {
        public static List<TurnAction> exe(BestAtLevelRecord bestAtLevelRecord, int currentMinute) {
            List<TurnAction> possibleActions = new List<TurnAction>();
            if (currentMinute == 1) {
                possibleActions.Add(new Pass());
                return possibleActions;
            }
            if (bestAtLevelRecord.testShouldStop(MainInventory.inventory.getMineralCount(Mineral.GEODE), currentMinute - 2)) {
                return possibleActions;
            }
            if (RobotBuyable.isBuyable(Mineral.GEODE)) {
                possibleActions.Add(new Buy(Mineral.GEODE));
                return possibleActions;
            }
            if (canAndShouldBuyObsidian()) {
                possibleActions.Add(new Buy(Mineral.OBSIDIAN));
                return possibleActions;
            }
            if (canAndShouldBuyMineral(Mineral.CLAY)) possibleActions.Add(new Buy(Mineral.CLAY));
            if (canAndShouldBuyMineral(Mineral.ORE)) possibleActions.Add(new Buy(Mineral.ORE));
            possibleActions.Add(new Pass());
            return possibleActions;
        }

        private static bool canAndShouldBuyMineral(Mineral mineral) {
            Blueprint currentBlueprint = CurrentBlueprint.currentBlueprint;
            MineralCostGroup mineralCostGroup = currentBlueprint.mineralCostGroup;
            
            return RobotBuyable.isBuyable(mineral) &&
                RobotList.getRobotTypeCount(mineral) < mineralCostGroup.getMaxOfMineral(mineral);
        }

        private static bool canAndShouldBuyObsidian() {
            if (!RobotBuyable.isBuyable(Mineral.OBSIDIAN)) return false;

            TurnsLeftComparer turnsLeftComparer = new TurnsLeftComparer(Mineral.OBSIDIAN, Mineral.GEODE);
            return turnsLeftComparer.reduction >= 0;
        }
    }
}
