
namespace advent19 {
    public interface TurnAction {
        public void exe();
    }

    public class Pass : TurnAction {
        public void exe() { }
    }

    public class Buy : TurnAction {
        public Mineral mineral { get; private set; }




        public Buy(Mineral mineral) { this.mineral = mineral; }
        public void exe() {
            Blueprint blueprint = CurrentBlueprint.currentBlueprint;
            MineralCostGroup mineralCostGroup = blueprint.mineralCostGroup;
            MineralCost mineralCost = mineralCostGroup.getMineralCost(mineral);
            MainInventory.inventory.subtractRobotCost(mineralCost);
            Robot newRobot = RobotFactory.manufacture(mineral);
            RobotList.addRobot(newRobot);
        }
    }
}
