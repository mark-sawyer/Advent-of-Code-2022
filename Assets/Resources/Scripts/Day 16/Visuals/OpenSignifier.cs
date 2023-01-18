using System;
using TMPro;
using UnityEngine;

namespace advent16 {
    public class OpenSignifier : VisualUpdater {
        private Valve associatedValve;
        private int childIndex;
        private void getAssociatedValues() {
            associatedValve = ValveGetter.exe(name.Substring(0, 2));
            childIndex = getChildIndex();
        }
        private int getChildIndex() {
            int tempIndex = 0;
            Transform valveGrid = GameObject.Find("valve grid").transform;
            Transform child;
            int children = valveGrid.childCount;
            for (int i = 0; i < children; i++) {
                child = valveGrid.transform.GetChild(i);
                if (child.name.Substring(3, 3) != "col") continue;
                if (child.name.Substring(0, 2) != associatedValve.name) {
                    tempIndex++;
                    continue;
                }
                else return tempIndex;
            }
            throw new Exception("Couldn't find child index.");
        }
        private void changeColour(Color col) {
            GetComponent<TextMeshProUGUI>().color = col;
            Transform valveGrid = GameObject.Find("valve grid").transform;
            Transform child;
            int children = valveGrid.childCount;
            for (int i = 0; i < children; i++) {
                child = valveGrid.GetChild(i);
                if (child.name.Substring(3, 3) == "row") {
                    child.GetChild(childIndex).GetComponent<TextMeshProUGUI>().color = col;
                }
            }
        }
        private Color currentColour() {
            return GetComponent<TextMeshProUGUI>().color;
        }




        public override void updateVisual() {
            if (associatedValve == null) getAssociatedValues();


            if (associatedValve.open && currentColour() == Color.white)
                changeColour(Color.red);
            else if (!associatedValve.open && currentColour() == Color.red)
                changeColour(Color.white);
        }
    }
}
