using System;
using TMPro;
using UnityEngine;

namespace advent16 {
    public class ValveGridGenerator : MonoBehaviour {
        [SerializeField] private GameObject valveRowPrefab;
        [SerializeField] private GameObject valveColPrefab;
        [SerializeField] private GameObject distancePrefab;
        private void instantiateValves(Func<int, Vector3> newLocalPos, int increment, GameObject type, string cat) {
            GameObject newValve;
            Vector3 position;
            int currentAxisValue = increment;
            foreach (Valve valve in StateInformation.getValves()) {
                if (valve.flowRate == 0 && valve.name != Constants.STARTING_NAME) continue;
                newValve = Instantiate(type, transform);
                newValve.GetComponent<TextMeshProUGUI>().text = valve.name;
                newValve.name = valve.name + cat;
                position = newLocalPos(currentAxisValue);
                newValve.transform.localPosition = position;
                currentAxisValue += increment;
            }
        }
        private void instantiateDistances() {
            int xPos = Constants.X_OFFSET;
            GameObject newDistance;
            for (int row = 0; row < StateInformation.getValves().Count; row++) {
                if (shouldSkipValve(StateInformation.getValves()[row])) continue;
                for (int col = 0; col < StateInformation.getValves().Count; col++) {
                    if (shouldSkipValve(StateInformation.getValves()[col])) continue;
                    newDistance = Instantiate(distancePrefab, GameObject.Find(StateInformation.getValves()[row].name + "_row").transform);
                    newDistance.transform.localPosition = new Vector3(xPos, 0);
                    newDistance.GetComponent<TextMeshProUGUI>().text = StateInformation.getDistances().getDistanceString(row, col);
                    xPos += Constants.X_OFFSET;
                }
                xPos = Constants.X_OFFSET;
            }
        }
        private bool shouldSkipValve(Valve v) {
            return v.flowRate == 0 && v.name != Constants.STARTING_NAME;
        }




        private void Start() {
            instantiateValves((x) => new Vector3(0, x), Constants.Y_OFFSET, valveRowPrefab, "_row");
            instantiateValves((x) => new Vector3(x, 0), Constants.X_OFFSET, valveColPrefab, "_col");
            instantiateDistances();
            Events.updateVisuals.Invoke();
        }
    }
}
