
using System;
using System.Collections.Generic;
using UnityEngine;

namespace advent23 {
    public class Elf {
        public Space currentSpace { get; private set; }
        private Space consideredSpace;
        private GameObject elfPrefab;
        private List<Direction> directions = new List<Direction>() {
            Direction.NORTH,
            Direction.SOUTH,
            Direction.WEST,
            Direction.EAST
        };
        public bool moved { get; private set; }

        public Elf(Space space) {
            currentSpace = space;
            elfPrefab = GameObject.Instantiate(
                Resources.Load<GameObject>("Prefabs/elf"),
                GameObject.Find("elves").transform
            );
        }

        public void setGameObject() {
            elfPrefab.transform.localPosition = new Vector2(currentSpace.col, -currentSpace.row);
        }

        public void considerMoving() {
            moved = false;

            if (!elfIsAdjacent()) {
                shuffleDirections();
                return;
            }

            Func<bool> elfInDirection;
            Action markDirection;
            for (int i = 0; i < 4; i++) {
                elfInDirection = getElfInDirectionFunction(directions[i]);
                if (!elfInDirection()) {
                    markDirection = getDirectionMarkedFunction(directions[i]);
                    markDirection();
                    break;
                }
            }

            shuffleDirections();
        }

        public void moveIfCan() {
            if (consideredSpace == null) return;

            if (consideredSpace.onlyOneElfConsidering()) {
                currentSpace.removeElf();
                currentSpace = consideredSpace;
                currentSpace.addElf(this);
                consideredSpace = null;
                setGameObject();
                moved = true;
            }
            else consideredSpace = null;
        }

        private bool elfIsAdjacent() {
            bool foundElf = false;
            Space checkedSpace;

            for (int i = -1; i < 2; i++) {
                for (int j = -1; j < 2; j++) {
                    checkedSpace = SpaceGetter.exe(currentSpace.row + i, currentSpace.col + j);
                    if (checkedSpace == currentSpace) continue;
                    if (checkedSpace.hasElf) {
                        foundElf = true;
                        goto end;
                    }
                }
            }
            end:
            return foundElf;
        }

        private void shuffleDirections() {
            Direction temp = directions[0];
            directions[0] = directions[1];
            directions[1] = directions[2];
            directions[2] = directions[3];
            directions[3] = temp;
        }


        private Func<bool> getElfInDirectionFunction(Direction d) {
            Func<bool> f = null;

            switch (d) {
                case Direction.NORTH:
                    f = elfNorth;
                    break;
                case Direction.EAST:
                    f = elfEast;
                    break;
                case Direction.SOUTH:
                    f = elfSouth;
                    break;
                case Direction.WEST:
                    f = elfWest;
                    break;
            }

            return f;
        }
        private Action getDirectionMarkedFunction(Direction d) {
            Action f = null;

            switch (d) {
                case Direction.NORTH:
                    f = markNorth;
                    break;
                case Direction.EAST:
                    f = markEast;
                    break;
                case Direction.SOUTH:
                    f = markSouth;
                    break;
                case Direction.WEST:
                    f = markWest;
                    break;
            }

            return f;
        }


        private bool elfNorth() {
            Space checkedSpace;
            bool foundElf = false;

            for (int i = -1; i < 2; i++) {
                checkedSpace = SpaceGetter.exe(currentSpace.row - 1, currentSpace.col + i);
                if (checkedSpace.hasElf) {
                    foundElf = true;
                    break;
                }
            }

            return foundElf;
        }
        private bool elfEast() {
            Space checkedSpace;
            bool foundElf = false;

            for (int i = -1; i < 2; i++) {
                checkedSpace = SpaceGetter.exe(currentSpace.row + i, currentSpace.col + 1);
                if (checkedSpace.hasElf) {
                    foundElf = true;
                    break;
                }
            }

            return foundElf;
        }
        private bool elfSouth() {
            Space checkedSpace;
            bool foundElf = false;

            for (int i = -1; i < 2; i++) {
                checkedSpace = SpaceGetter.exe(currentSpace.row + 1, currentSpace.col + i);
                if (checkedSpace.hasElf) {
                    foundElf = true;
                    break;
                }
            }

            return foundElf;
        }
        private bool elfWest() {
            Space checkedSpace;
            bool foundElf = false;

            for (int i = -1; i < 2; i++) {
                checkedSpace = SpaceGetter.exe(currentSpace.row + i, currentSpace.col - 1);
                if (checkedSpace.hasElf) {
                    foundElf = true;
                    break;
                }
            }

            return foundElf;
        }


        private void markNorth() {
            Space potentialNewSpace = SpaceGetter.exe(currentSpace.row - 1, currentSpace.col);
            mark(potentialNewSpace);
        }
        private void markEast() {
            Space potentialNewSpace = SpaceGetter.exe(currentSpace.row, currentSpace.col + 1);
            mark(potentialNewSpace);
        }
        private void markSouth() {
            Space potentialNewSpace = SpaceGetter.exe(currentSpace.row + 1, currentSpace.col);
            mark(potentialNewSpace);
        }
        private void markWest() {
            Space potentialNewSpace = SpaceGetter.exe(currentSpace.row, currentSpace.col - 1);
            mark(potentialNewSpace);
        }
        private void mark(Space potentialNewSpace) {
            potentialNewSpace.addConsideringElf(this);
            consideredSpace = potentialNewSpace;
        }
    }
}
