using UnityEngine;

namespace advent19 {
    public abstract class VisualUpdater : MonoBehaviour {
        private void Awake() {
            Events.updateVisuals.AddListener(updateVisual);
        }

        public abstract void updateVisual();
    }
}
