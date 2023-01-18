using TMPro;
using UnityEngine;

namespace advent16 {
    public class UserInput : MonoBehaviour {
        private void changeSelection(int increment) {
            int currentIndex = StateInformation.target.index;
            int newIndex = currentIndex;
            bool madeNewSelection = false;
            while (!madeNewSelection) {
                newIndex += increment;
                if (newIndex == -1) newIndex = StateInformation.getValves().Count - 1;
                else if (newIndex == StateInformation.getValves().Count) newIndex = 0;
                if (isVisualisedValve(StateInformation.getValves()[newIndex])) {
                    StateInformation.target = StateInformation.getValves()[newIndex];
                    madeNewSelection = true;
                }
            }
            Events.updateVisuals.Invoke();
        }
        private bool isVisualisedValve(Valve valve) {
            return valve.flowRate > 0 || valve.name == Constants.STARTING_NAME;
        }
        private void click() {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D ray = Physics2D.Raycast(clickPos, Vector2.zero);
            if (ray.collider != null) {
                string name = ray.collider.transform.GetChild(0).GetComponent<TextMeshPro>().text;
                Valve valve = ValveGetter.exe(name);
                StateInformation.target = valve;
                TurnProcess.exe(new Move());
                TurnProcess.exe(new Open());
            }
        }




        private void Update() {
            if (Input.GetKeyDown(KeyCode.DownArrow))
                changeSelection(-1);
            else if (Input.GetKeyDown(KeyCode.UpArrow))
                changeSelection(1);
            else if (Input.GetKeyDown(KeyCode.Space))
                TurnProcess.exe(new Move());
            else if (Input.GetKeyDown(KeyCode.Return))
                TurnProcess.exe(new Open());
            else if (Input.GetKeyDown(KeyCode.P))
                TurnProcess.exe(new Pass());
            else if (Input.GetKeyDown(KeyCode.R))
                StateInformation.reset();
            else if (Input.GetMouseButtonDown(0))
                click();
        }
    }
}
