
using System.Collections.Generic;

namespace advent19 {
    public static class TurnUndo {
        private static List<Robot> copyList(List<Robot> priorRobots) {
            List<Robot> copy = new List<Robot>();
            foreach (Robot robot in priorRobots) copy.Add(robot);
            return copy;
        }




        public static void exe(List<Robot> priorRobots, Inventory priorInventory) {
            Time.incrementTime();
            RobotList.robots = copyList(priorRobots);
            MainInventory.inventory = priorInventory.createCopy();
            TurnsToBuyableList.updateTurns();
            Events.updateVisuals.Invoke();
        }
    }
}
