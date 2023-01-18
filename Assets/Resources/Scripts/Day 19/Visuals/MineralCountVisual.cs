using TMPro;
using UnityEngine;

namespace advent19 {
    public class MineralCountVisual : VisualUpdater {
        [SerializeField] private Mineral mineral;
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private string countPrefix;

        public override void updateVisual() {
            textMesh.text = countPrefix + MainInventory.inventory.getMineralCount(mineral);
        }
    }
}
