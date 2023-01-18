using TMPro;
using UnityEngine;

namespace advent19 {
    public class TurnsToBuyableVisual : VisualUpdater {
        [SerializeField] private Mineral mineral;
        [SerializeField] private TextMeshProUGUI textMesh;
        private void Start() {
            updateVisual();
        }


        public override void updateVisual() {
            TurnsToBuyable turnsToBuyable = TurnsToBuyableList.getTurnsToBuyable(mineral);
            textMesh.text = turnsToBuyable.turnsString;
        }
    }
}
