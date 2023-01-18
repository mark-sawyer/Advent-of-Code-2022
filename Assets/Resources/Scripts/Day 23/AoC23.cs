using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace advent23 {
    public class AoC23 : MonoBehaviour {
        private string[] input;
        public Space[,] spaces { get; private set; }
        private List<Elf> elves;

        private void Start() {
            input = File.ReadAllLines("C:\\Documents\\R Files\\Advent of Code\\Inputs\\advent 23.txt");
            spaces = InputInterpreter.exe(input);
            elves = getElfList();
            placeElves();
            StartCoroutine(partTwoCoRoutine());
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                foreach (Elf elf in elves) elf.considerMoving();
                foreach (Elf elf in elves) elf.moveIfCan();
                foreach (Space space in spaces) space.resetConsideringElves();
            }
        }

        private void partOne() {
            for (int i = 0; i < 10; i++) {
                foreach (Elf elf in elves) elf.considerMoving();
                foreach (Elf elf in elves) elf.moveIfCan();
                foreach (Space space in spaces) space.resetConsideringElves();
            }

            int minRow = 9999999;
            int maxRow = -9999999; ;
            int minCol = 9999999; ;
            int maxCol = -9999999; ;
            int row;
            int col;
            foreach (Space space in spaces) {
                if (!space.hasElf) continue;
                row = space.row;
                col = space.col;

                if (row < minRow) minRow = row;
                if (row > maxRow) maxRow = row;
                if (col < minCol) minCol = col;
                if (col > maxCol) maxCol = col;
            }

            int width = maxCol - minCol + 1;
            int height = maxRow - minRow + 1;

            print(width * height - elves.Count);
        }

        private IEnumerator partTwoCoRoutine() {
            int round = 0;
            bool anElfMoved;
            do {
                round++;
                foreach (Elf elf in elves) elf.considerMoving();
                foreach (Elf elf in elves) elf.moveIfCan();
                foreach (Space space in spaces) space.resetConsideringElves();
                anElfMoved = this.anElfMoved();
                yield return null;
            } while (anElfMoved);

            print(round);
        }

        private bool anElfMoved() {
            bool elfMoved = false;
            foreach (Elf elf in elves) {
                if (elf.moved) {
                    elfMoved = true;
                    break;
                }
            }
            return elfMoved;
        }

        private void placeElves() {
            foreach (Elf e in elves) {
                e.setGameObject();
            }
        }

        private List<Elf> getElfList() {
            List<Elf> elves = new List<Elf>();
            foreach (Space space in spaces) {
                if (space.hasElf) elves.Add(space.elf);
            }
            return elves;
        }
    }
}
