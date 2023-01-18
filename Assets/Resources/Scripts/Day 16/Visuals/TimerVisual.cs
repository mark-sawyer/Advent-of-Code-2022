using TMPro;
using UnityEngine;

namespace advent16 {
    public class TimerVisual : VisualUpdater {
        [SerializeField] private TextMeshProUGUI textMesh;




        public override void updateVisual() {
            textMesh.text = StateInformation.timeLeft.ToString();
        }
    }
}
