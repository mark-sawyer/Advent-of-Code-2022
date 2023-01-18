using System.Collections.Generic;
using System.Linq;

namespace advent19 {
    public static class RobotList {
        public static List<Robot> robots { get; set; } = new List<Robot>() { new OreRobot() };
        public static void addRobot(Robot robot) {
            robots.Add(robot);
        }
        public static void mineRobots() {
            foreach (Robot robot in robots) {
                robot.mine();
            }
        }
        public static int getRobotTypeCount(Mineral mineral) {
            return robots.Count(robot => robot.mineral == mineral);
        }
        public static void resetRobots() {
            robots.Clear();
            robots.Add(new OreRobot());
        }
        public static void removeRobot(Mineral mineral) {
            Robot robot;
            for (int i = 0; i < robots.Count; i++) {
                robot = robots[i];
                if (robot.mineral == mineral) {
                    robots.Remove(robot);
                    break;
                }
            }
        }
        public static List<Robot> copyList() {
            List<Robot> copy = new List<Robot>();
            foreach (Robot robot in robots) copy.Add(robot);
            return copy;
        }
    }
}
