using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;

namespace advent24 {

    public class AoC24 : MonoBehaviour {
        private int turnNum;
        private string[] input;
        private bool reachedDestinationOne;
        private bool reachedDestinationTwo;
        private bool reachedDestinationThree;
        [SerializeField] private GameObject token;
        [SerializeField] private GameObject wall;
        List<UnityEvent> adventEvents = new List<UnityEvent> {
            AdventEvents.blizzardMoves,
            AdventEvents.tokenMoves,
            AdventEvents.invalidPositionCheck
        };

        private void Start() {
            input = File.ReadAllLines("C:\\Documents\\R Files\\Advent of Code\\Inputs\\advent 24.txt");
            InputInterpreter.exe(input);
            Instantiate(wall, new Vector2(1, 1), Quaternion.identity);
            Instantiate(wall, new Vector2(WallBounds.rightBound - 1, WallBounds.bottomBound - 1), Quaternion.identity);
            GameObject firstToken = Instantiate(token, new Vector2(1, 0), Quaternion.identity);
            firstToken.GetComponent<Token>().initialise();
        }

        private void Update() {
            if (reachedDestinationThree) return;

            adventEvents[turnNum % 3].Invoke();
            turnNum++;
            if (reachedEndFirstTime()) {
                reachedDestinationOne = true;
                print(turnNum / 3);
                AdventEvents.destroyExceptEnd.Invoke();
            }
            else if (reachedStartAgain()) {
                reachedDestinationTwo = true;
                print(turnNum / 3);
                AdventEvents.destroyExceptStart.Invoke();
            }
            else if (reachedEndSecondTime()) {
                reachedDestinationThree = true;
                print(turnNum / 3);
                AdventEvents.destroyExceptEnd.Invoke();
            }
        }

        private bool reachedEndFirstTime() {
            return !reachedDestinationOne &&
                turnNum % 3 == 0 &&
                GameObject.Find("token (" + (WallBounds.rightBound - 1) + ", " + WallBounds.bottomBound + ")") != null;
        }

        private bool reachedStartAgain() {
            return reachedDestinationOne &&
                !reachedDestinationTwo &&
                turnNum % 3 == 0 &&
                GameObject.Find("token (" + 1 + ", " + 0 + ")") != null;
        }
        private bool reachedEndSecondTime() {
            return reachedDestinationOne &&
                reachedDestinationTwo &&
                !reachedDestinationThree &&
                turnNum % 3 == 0 &&
                GameObject.Find("token (" + (WallBounds.rightBound - 1) + ", " + WallBounds.bottomBound + ")") != null;
        }
    }
}
