using UnityEngine;

namespace advent16 {
    public abstract class VisualUpdater : MonoBehaviour {
        private void Awake() {
            Events.updateVisuals.AddListener(updateVisual);
        }
        public abstract void updateVisual();
    }
}
