using System.Collections.Generic;
using System;

namespace advent19 {
    public class MineralCostGroup {
        public MineralCost oreRobotCost { get; private set; }
        public MineralCost clayRobotCost { get; private set; }
        public MineralCost obsidianRobotCost { get; private set; }
        public MineralCost geodeRobotCost { get; private set; }
        public MineralCostGroup(List<MineralCost> mineralCosts) {
            oreRobotCost = mineralCosts[0];
            clayRobotCost = mineralCosts[1];
            obsidianRobotCost = mineralCosts[2];
            geodeRobotCost = mineralCosts[3];
        }
        public MineralCost getMineralCost(Mineral mineral) {
            MineralCost mineralCost = null;
            switch (mineral) {
                case Mineral.ORE:
                    mineralCost = oreRobotCost;
                    break;
                case Mineral.CLAY:
                    mineralCost = clayRobotCost;
                    break;
                case Mineral.OBSIDIAN:
                    mineralCost = obsidianRobotCost;
                    break;
                case Mineral.GEODE:
                    mineralCost = geodeRobotCost;
                    break;
            }
            return mineralCost;
        }
        public int getMaxOfMineral(Mineral mineral) {
            int oreRobotAmount = oreRobotCost.getAmountNeededOfMineral(mineral);
            int clayRobotAmount = clayRobotCost.getAmountNeededOfMineral(mineral);
            int obsidianRobotAmount = obsidianRobotCost.getAmountNeededOfMineral(mineral);
            int geodeRobotAmount = geodeRobotCost.getAmountNeededOfMineral(mineral);
            int max = Math.Max(oreRobotAmount, Math.Max(clayRobotAmount, Math.Max(obsidianRobotAmount, geodeRobotAmount)));
            return max;
        }
    }
}
