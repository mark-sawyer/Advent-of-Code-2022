
namespace advent19 {
    public class Inventory {
        private int oreCount;
        private int clayCount;
        private int obsidianCount;
        private int geodeCount;




        public Inventory() {
            this.oreCount = 0;
            this.clayCount = 0;
            this.obsidianCount = 0;
            this.geodeCount = 0;
        }
        public Inventory(int oreCount, int clayCount, int obsidianCount, int geodeCount) {
            this.oreCount = oreCount;
            this.clayCount = clayCount;
            this.obsidianCount = obsidianCount;
            this.geodeCount = geodeCount;
        }
        public int getMineralCount(Mineral mineral) {
            int count = 0;
            switch (mineral) {
                case Mineral.ORE:
                    count = oreCount;
                    break;
                case Mineral.CLAY:
                    count = clayCount;
                    break;
                case Mineral.OBSIDIAN:
                    count = obsidianCount;
                    break;
                case Mineral.GEODE:
                    count = geodeCount;
                    break;
            }
            return count;
        }
        public void addMineral(Mineral mineral) {
            switch (mineral) {
                case Mineral.ORE:
                    oreCount++;
                    break;
                case Mineral.CLAY:
                    clayCount++;
                    break;
                case Mineral.OBSIDIAN:
                    obsidianCount++;
                    break;
                case Mineral.GEODE:
                    geodeCount++;
                    break;
            }
        }
        public void subtractRobotCost(MineralCost cost) {
            oreCount -= cost.oreCost;
            clayCount -= cost.clayCost;
            obsidianCount -= cost.obsidianCost;
        }
        public void addRobotCost(MineralCost cost) {
            oreCount += cost.oreCost;
            clayCount += cost.clayCost;
            obsidianCount += cost.obsidianCost;
        }
        public void resetInventory() {
            oreCount = 0;
            clayCount = 0;
            obsidianCount = 0;
            geodeCount = 0;
        }
        public Inventory createCopy() {
            Inventory copy = new Inventory(oreCount, clayCount, obsidianCount, geodeCount);
            return copy;
        }
    }
}