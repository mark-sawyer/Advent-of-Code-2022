
namespace advent19 {
    public abstract class Robot {
        public Mineral mineral { get; private set; }
        public abstract void mine();
        protected void setMineral(Mineral mineral) {
            this.mineral = mineral;
        }
    }

    public class OreRobot : Robot {
        public OreRobot() {
            setMineral(Mineral.ORE);
        }
        public override void mine() {
            MainInventory.inventory.addMineral(Mineral.ORE);
        }
    }

    public class ClayRobot : Robot {
        public ClayRobot() {
            setMineral(Mineral.CLAY);
        }
        public override void mine() {
            MainInventory.inventory.addMineral(Mineral.CLAY);
        }
    }

    public class ObsidianRobot : Robot {
        public ObsidianRobot() {
            setMineral(Mineral.OBSIDIAN);
        }
        public override void mine() {
            MainInventory.inventory.addMineral(Mineral.OBSIDIAN);
        }
    }

    public class GeodeRobot : Robot {
        public GeodeRobot() {
            setMineral(Mineral.GEODE);
        }
        public override void mine() {
            MainInventory.inventory.addMineral(Mineral.GEODE);
        }
    }
}