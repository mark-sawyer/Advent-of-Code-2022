using UnityEngine;

namespace advent19 {
    public class KeyboardInput : MonoBehaviour {
        private void Update() {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                incrementCurrentBlueprint(1);
                ResetProcedure.exe();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                incrementCurrentBlueprint(-1);
                ResetProcedure.exe();
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift)) {
                BestAtLevelRecord bestAtLevelRecord = new BestAtLevelRecord();
                State state = new State(bestAtLevelRecord);
                state.recurse();
                print(bestAtLevelRecord.getFinalRecord());
            }
        }

        private void incrementCurrentBlueprint(int i) {
            int currentIndex = CurrentBlueprint.blueprintIndex;
            int totalBlueprints = BlueprintList.blueprints.Count;
            int newIndex = (currentIndex + i) % totalBlueprints;
            if (newIndex == -1) newIndex = totalBlueprints - 1;
            CurrentBlueprint.changeBlueprint(newIndex);
        }
    }
}
