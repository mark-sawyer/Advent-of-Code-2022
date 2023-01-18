using TMPro;
using UnityEngine;

namespace advent16 {
    public class RowEmphasiser : VisualUpdater {
        private bool isBold = false;
        private void boldenDistances() {
            int children = transform.childCount;
            Transform child;
            TextMeshProUGUI textMesh;
            for (int i = 0; i < children; i++) {
                child = transform.GetChild(i);
                textMesh = child.GetComponent<TextMeshProUGUI>();
                textMesh.fontStyle = FontStyles.Bold;
                textMesh.fontSize = Constants.LARGE_DISTANCE_SIZE;
            }
            isBold = true;
        }
        private void unboldenDistances() {
            int children = transform.childCount;
            Transform child;
            TextMeshProUGUI textMesh;
            for (int i = 0; i < children; i++) {
                child = transform.GetChild(i);
                textMesh = child.GetComponent<TextMeshProUGUI>();
                textMesh.fontStyle = FontStyles.Normal;
                textMesh.fontSize = Constants.DEFAULT_DISTANCE_SIZE;
            }
            isBold = false;
        }




        public override void updateVisual() {
            if (name.Substring(0, 2) == StateInformation.at.name) boldenDistances();
            else if (isBold) unboldenDistances();
        }
    }
}
