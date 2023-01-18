using TMPro;
using UnityEngine;

namespace advent16 {
    public class FlowRateVisual : MonoBehaviour {
        private void Start() {
            Transform parent = transform.parent;
            Valve valve = ValveGetter.exe(parent.name.Substring(0, 2));
            GetComponent<TextMeshProUGUI>().text = valve.flowRate.ToString();
        }
    }
}
