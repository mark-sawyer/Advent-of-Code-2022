
namespace advent19 {
    public class MineralCost {
        public readonly int oreCost;
        public readonly int clayCost;
        public readonly int obsidianCost;
        public MineralCost(int oreCost, int clayCost, int obsidianCost) {
            this.oreCost = oreCost;
            this.clayCost = clayCost;
            this.obsidianCost = obsidianCost;
        }
        public string getCostString() {
            return "(" + oreCost + ", " + clayCost + ", " + obsidianCost + ")";
        }
        public int getAmountNeededOfMineral(Mineral mineral) {
            int cost = 0;
            switch (mineral) {
                case Mineral.ORE:
                    cost = oreCost;
                    break;
                case Mineral.CLAY:
                    cost = clayCost;
                    break;
                case Mineral.OBSIDIAN:
                    cost = obsidianCost;
                    break;
            }
            return cost;
        }
    }
}