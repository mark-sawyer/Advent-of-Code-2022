
namespace advent19 {
    public static class TurnProcedure {
        public static void exe(TurnAction turnAction) {
            updateData(turnAction);
            Events.updateVisuals.Invoke();
        }
        public static void updateData(TurnAction turnAction) {
            RobotList.mineRobots();
            turnAction.exe();
            Time.decrementTime();
            TurnsToBuyableList.updateTurns();
        }
    }
}
