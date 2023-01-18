using TMPro;
using UnityEngine;

namespace advent19 {
    public class TimeLeftVisual : VisualUpdater {
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private string timeLeftPrefix;
        [SerializeField] private string currentMinutePrefix;




        private void Start() {
            textMesh.text = timeLeftPrefix + Time.timeLeft + "\n" +
                currentMinutePrefix + (Constants.TOTAL_TIME - Time.timeLeft + 1);
        }
        public override void updateVisual() {
            textMesh.text = timeLeftPrefix + Time.timeLeft + "\n" +
                currentMinutePrefix + (Constants.TOTAL_TIME - Time.timeLeft + 1);
        }
    }
}
