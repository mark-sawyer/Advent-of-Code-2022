using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace advent16 {
    public class Node : VisualUpdater {
        private List<Transform> otherNodes;
        public Valve valve { get; private set; }


        private Color currentColour() {
            return GetComponent<SpriteRenderer>().color;
        }
        private void changeColour(Color col) {
            GetComponent<SpriteRenderer>().color = col;
        }



        public void setup(List<Transform> transforms, Valve valve) {
            this.valve = valve;
            otherNodes = new List<Transform>();
            foreach (Transform t in transforms) {
                if (t.GetChild(0).GetComponent<TextMeshPro>().text == valve.name) continue;
                otherNodes.Add(t);
            }
        }
        public override void updateVisual() {
            if (valve.open && currentColour() == Color.white)
                changeColour(Color.red);
            else if (!valve.open && currentColour() == Color.red)
                changeColour(Color.white);
        }
        private void Update() {
            Distances distances = StateInformation.getDistances();
            Vector3 totalDirection = new Vector3();
            Vector3 direction;
            Valve otherValve;
            float actualDistance;
            float desiredDistance;
            float difference;
            float sign;
            foreach (Transform t in otherNodes) {
                direction = t.localPosition - transform.localPosition;
                actualDistance = direction.magnitude;
                otherValve = t.GetComponent<Node>().valve;
                desiredDistance = distances.getDistance(valve.index, otherValve.index);
                difference = actualDistance - desiredDistance;
                sign = Mathf.Sign(difference);
                totalDirection += direction * sign * Mathf.Pow(difference, 2);
            }
            transform.localPosition += totalDirection * Constants.DISTANCE_SCALAR;
        }
    }
}
