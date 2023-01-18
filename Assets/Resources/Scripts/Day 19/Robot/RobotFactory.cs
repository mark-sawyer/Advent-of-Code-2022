
namespace advent19 {
    public static class RobotFactory {
        public static Robot manufacture(Mineral mineral) {
            Robot robot = null;
            switch (mineral) {
                case Mineral.ORE:
                    robot = new OreRobot();
                    break;
                case Mineral.CLAY:
                    robot = new ClayRobot();
                    break;
                case Mineral.OBSIDIAN:
                    robot = new ObsidianRobot();
                    break;
                case Mineral.GEODE:
                    robot = new GeodeRobot();
                    break;
            }
            return robot;
        }
    }
}
