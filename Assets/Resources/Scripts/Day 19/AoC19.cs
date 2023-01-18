using System.Collections;
using System.Linq;
using UnityEngine;

namespace advent19 {
    public class AoC19 : MonoBehaviour {
        private void Start() {
            //StartCoroutine(partOne());
            //StartCoroutine(partTwo());
        }
        private IEnumerator partOne() {
            int[] geodeNumbers = new int[BlueprintList.blueprints.Count];
            for (int i = 0; i < BlueprintList.blueprints.Count; i++) {
                CurrentBlueprint.changeBlueprint(i);
                geodeNumbers[i] = findGeodeNumber() * (i + 1);
                print("Finished " + (i + 1));
                yield return null;
            }
            print(geodeNumbers.Sum());
        }
        private IEnumerator partTwo() {
            int originalTotal = Constants.TOTAL_TIME;
            Constants.TOTAL_TIME = 32;
            int blueprintsUsed = 3;
            int[] geodeNumbers = new int[blueprintsUsed];
            for (int i = 0; i < blueprintsUsed; i++) {
                CurrentBlueprint.changeBlueprint(i);
                geodeNumbers[i] = findGeodeNumber();
                print("Finished " + (i + 1));
                yield return null;
            }
            print(geodeNumbers.Aggregate((a, b) => a * b));
            Constants.TOTAL_TIME = originalTotal;
        }
        private int findGeodeNumber() {
            BestAtLevelRecord bestAtLevelRecord = new BestAtLevelRecord();
            State state = new State(bestAtLevelRecord);
            state.recurse();
            return bestAtLevelRecord.getFinalRecord();
        }
    }
}
