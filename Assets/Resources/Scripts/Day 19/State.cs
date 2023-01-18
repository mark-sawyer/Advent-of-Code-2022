using System.Collections.Generic;

namespace advent19 {
    public class State {
        private BestAtLevelRecord bestAtLevelRecord;
        private int currentMinute;
        private State rootState;
        private List<TurnAction> possibleActions;
        private Inventory inventory;
        private List<Robot> robots;
        private void checkNewRecord() {
            if (bestAtLevelRecord.testNewRecord(MainInventory.inventory.getMineralCount(Mineral.GEODE), currentMinute - 1)) {
                bestAtLevelRecord.setNewRecord(MainInventory.inventory.getMineralCount(Mineral.GEODE), currentMinute - 1);
            }
        }
        private void recurseIfTimeLeft() {
            if (Time.timeLeft > 0) {
                State childState = new State(
                    currentMinute + 1,
                    rootState == null ? this : rootState,
                    bestAtLevelRecord
                );
                childState.recurse();
            }
        }




        public State(BestAtLevelRecord bestAtLevelRecord) {
            currentMinute = 1;
            this.bestAtLevelRecord = bestAtLevelRecord;
            robots = RobotList.copyList();
            inventory = MainInventory.inventory.createCopy();
            possibleActions = PossibleActionGetter.exe(bestAtLevelRecord, currentMinute);
        }
        public State(int currentMinute, State rootState, BestAtLevelRecord bestAtLevelRecord) {
            this.currentMinute = currentMinute;
            this.rootState = rootState;
            this.bestAtLevelRecord = bestAtLevelRecord;
            robots = RobotList.copyList();
            inventory = MainInventory.inventory.createCopy();
            possibleActions = PossibleActionGetter.exe(bestAtLevelRecord, currentMinute);
        }
        public void recurse() {
            foreach (TurnAction turnAction in possibleActions) {
                TurnProcedure.exe(turnAction);
                checkNewRecord();
                recurseIfTimeLeft();
                TurnUndo.exe(robots, inventory);
            }
        }
    }
}
