using TMPro;

namespace advent16 {
    public class PointsVisual : VisualUpdater {
        public override void updateVisual() {
            GetComponent<TextMeshProUGUI>().text = StateInformation.points.ToString();
        }
    }
}
