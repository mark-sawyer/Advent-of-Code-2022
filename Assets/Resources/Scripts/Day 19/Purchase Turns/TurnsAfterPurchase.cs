
using System.Collections.Generic;

namespace advent19 {
    public class TurnsAfterPurchase {
        public int num { get; private set; }
        public TurnsAfterPurchase(Mineral typePurchased, Mineral typeCounted) {
            Inventory initialInventory = MainInventory.inventory.createCopy();
            List<Robot> initialRobots = RobotList.copyList();
            Buy buy = new Buy(typePurchased);
            TurnProcedure.updateData(buy);
            TurnsToBuyable turnsToBuyable = TurnsToBuyableList.getTurnsToBuyable(typeCounted);
            num = turnsToBuyable.willBeBuyable ? turnsToBuyable.turns : Constants.NOT_BUYABLE_FLAG;
            TurnUndo.exe(initialRobots, initialInventory);
        }
    }
}
