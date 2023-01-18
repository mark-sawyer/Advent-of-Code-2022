using UnityEngine;
using UnityEngine.UI;

namespace advent16 {
    public class ColHighlighter : VisualUpdater {
        [SerializeField] private Image highlight;
        private bool selected = false;
        private void changeHighlight(bool b) {
            highlight.enabled = b;
            selected = b;
        }




        public override void updateVisual() {
            if (StateInformation.target.name == transform.parent.name.Substring(0, 2)) changeHighlight(true);
            else if (selected) changeHighlight(false);
        }
    }
}
