
namespace advent19 {
    public static class RobotBuyable {
        public static bool isBuyable(Mineral mineral) {
            Blueprint currentBlueprint = CurrentBlueprint.currentBlueprint;
            MineralCostGroup mineralCostGroup = currentBlueprint.mineralCostGroup;
            MineralCost mineralCost = mineralCostGroup.getMineralCost(mineral);
            return MainInventory.inventory.getMineralCount(Mineral.ORE) >= mineralCost.oreCost &&
                MainInventory.inventory.getMineralCount(Mineral.CLAY) >= mineralCost.clayCost &&
                MainInventory.inventory.getMineralCount(Mineral.OBSIDIAN) >= mineralCost.obsidianCost;
        }
    }
}
