
namespace advent19 {
    public static class ResetProcedure {
        public static void exe() {
            MainInventory.inventory.resetInventory();
            RobotList.resetRobots();
            Time.resetTime();
            TurnsToBuyableList.updateTurns();
            Events.updateVisuals.Invoke();
        }
    }
}
