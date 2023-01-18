using System;
using System.Collections.Generic;

namespace advent19 {
    public class TurnsToBuyable {
        private Mineral mineral;
        private bool hasNeededRobots(MineralCost mineralCost, List<int> robotCounts) {
            return !(mineralCost.oreCost > 0 && robotCounts[0] == 0) &&
                !(mineralCost.clayCost > 0 && robotCounts[1] == 0) &&
                !(mineralCost.obsidianCost > 0 && robotCounts[2] == 0);
        }
        private int countTurns(MineralCost mineralCost, List<int> robotCounts) {
            float oreRemaining = mineralCost.oreCost - MainInventory.inventory.getMineralCount(Mineral.ORE);
            float clayRemaining = mineralCost.clayCost - MainInventory.inventory.getMineralCount(Mineral.CLAY);
            float obsidianRemaining = mineralCost.obsidianCost - MainInventory.inventory.getMineralCount(Mineral.OBSIDIAN);
            int oreTurns = oreRemaining > 0 ? (int)Math.Ceiling(oreRemaining / robotCounts[0]) : 0;
            int clayTurns = clayRemaining > 0 ? (int)Math.Ceiling(clayRemaining / robotCounts[1]) : 0;
            int obsidianTurns = obsidianRemaining > 0 ? (int)Math.Ceiling(obsidianRemaining / robotCounts[2]) : 0;
            int maxTurns = Math.Max(Math.Max(oreTurns, clayTurns), obsidianTurns);
            return maxTurns;
        }




        public TurnsToBuyable(Mineral mineral) { this.mineral = mineral; }
        public bool willBeBuyable { get; private set; }
        public int turns { get; private set; }
        public string turnsString { get; private set; }
        public void updateTurns() {
            Blueprint currentBlueprint = CurrentBlueprint.currentBlueprint;
            MineralCostGroup mineralCostGroup = currentBlueprint.mineralCostGroup;
            MineralCost mineralCost = mineralCostGroup.getMineralCost(mineral);
            List<int> robotCounts = new List<int> {
                RobotList.getRobotTypeCount(Mineral.ORE),
                RobotList.getRobotTypeCount(Mineral.CLAY),
                RobotList.getRobotTypeCount(Mineral.OBSIDIAN)
            };

            willBeBuyable = hasNeededRobots(mineralCost, robotCounts);
            if (willBeBuyable) {
                turns = countTurns(mineralCost, robotCounts);
                turnsString = turns.ToString();
            }
            else turnsString = "NA";
        }
    }
}
