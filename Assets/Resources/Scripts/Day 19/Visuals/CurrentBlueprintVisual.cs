using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace advent19 {
    public class CurrentBlueprintVisual : VisualUpdater {
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private string countPrefix;

        public override void updateVisual() {
            textMesh.text = countPrefix + (CurrentBlueprint.blueprintIndex + 1);
        }
    }
}
