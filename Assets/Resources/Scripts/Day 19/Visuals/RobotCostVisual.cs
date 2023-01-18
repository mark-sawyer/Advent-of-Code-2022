using TMPro;
using UnityEngine;

namespace advent19 {
    public class RobotCostVisual : VisualUpdater {
        [SerializeField] private Mineral mineral;
        [SerializeField] private TextMeshProUGUI textMesh;
        private void Start() {
            updateVisual();
        }




        public override void updateVisual() {
            Blueprint currentBlueprint = CurrentBlueprint.currentBlueprint;
            MineralCostGroup mineralCostGroup = currentBlueprint.mineralCostGroup;
            MineralCost mineralCost = mineralCostGroup.getMineralCost(mineral);
            textMesh.text = mineralCost.getCostString();
        }
    }
}
