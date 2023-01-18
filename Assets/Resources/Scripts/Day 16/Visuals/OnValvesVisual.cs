using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace advent16 {
    public class OnValvesVisual : VisualUpdater {
        [SerializeField] private GameObject valveText;
        private void destroyChildren() {
            int children = transform.childCount;
            for (int i = 0; i < children; i++) {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        private void createChildren() {
            List<Valve> onValves = StateInformation.onValves;
            int yPos = 0;
            foreach (Valve valve in onValves) {
                instantiateTextUI(new Vector3(0, yPos), valve.name);
                instantiateTextUI(new Vector3(-100, yPos), valve.flowRate.ToString());
                yPos -= 50;
            }
        }
        private void instantiateTextUI(Vector3 localPos, string text) {
            GameObject newTextUI;
            newTextUI = Instantiate(valveText, transform);
            newTextUI.transform.localPosition = localPos;
            newTextUI.GetComponent<TextMeshProUGUI>().text = text;
        }




        public override void updateVisual() {
            destroyChildren();
            createChildren();
        }

    }
}
