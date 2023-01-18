using System.Collections.Generic;

namespace advent19 {
    public class Blueprint {
        public MineralCostGroup mineralCostGroup { get; private set; }
        public int blueprintNum { get; private set; }
        public Blueprint(int blueprintNum, List<MineralCost> mineralCosts) {
            this.blueprintNum = blueprintNum;
            mineralCostGroup = new MineralCostGroup(mineralCosts);
        }
    }
}
