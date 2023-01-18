using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace advent7 {
    public class AoC7 : MonoBehaviour {
        // 1778099
        // 1623571

        private Directory slash = new Directory("/");
        private Directory currentDirectory;
        private string[] input;
        private List<int> sizesAtMostOneHundredThousand = new List<int>();
        private List<int> sizesAtMostOther = new List<int>();
        private int totalFileSystemSpace = 70000000;
        private int freeSpaceRequired = 30000000;

        private void Start() {
            input = File.ReadAllLines("C:\\Documents\\R Files\\Advent of Code\\Inputs\\advent 7.txt");
            currentDirectory = slash;
            followAllInstructions();
            slash.findSizes();
            partOne();
            partTwo();
        }

        private void partOne() {
            slash.addIfNotBiggerThan(sizesAtMostOneHundredThousand, 100000);
            int total = 0;
            foreach (int i in sizesAtMostOneHundredThousand) total += i;
            print(total);
        }

        private void partTwo() {
            int totalUsedSpace = slash.totalSize;
            int freeSpace = totalFileSystemSpace - totalUsedSpace;
            int extraSpaceNeeded = freeSpaceRequired - freeSpace;
            slash.addIfAtLeast(sizesAtMostOther, extraSpaceNeeded);
            sizesAtMostOther.Sort();
            print(sizesAtMostOther[0]);
        }

        private void followAllInstructions() {
            int inputLength = input.Length;
            for (int i = 1; i < inputLength; i++) {
                followSingleInstruction(input[i]);
            }
        }

        private void followSingleInstruction(string s) {
            if (s.Substring(0, 3) == "dir") addDirectory(s);
            else if (int.TryParse(s.Substring(0, 1), out _)) addSize(s);
            else if (s.Substring(0, 4) == "$ cd") changeDirectory(s);
        }

        private void addDirectory(string s) {
            string dirName = s.Substring(4);
            Directory newDir = new Directory(dirName);
            newDir.addParent(currentDirectory);
            currentDirectory.subdirectories.Add(newDir);
        }

        private void addSize(string s) {
            int spaceIndex = s.IndexOf(' ');
            string numString = s.Substring(0, spaceIndex);
            int num = int.Parse(numString);
            currentDirectory.files.Add(num);
        }

        private void changeDirectory(string s) {
            if (s == "$ cd ..") {
                currentDirectory = currentDirectory.parent;
                return;
            }

            string dirName = s.Substring(5);
            foreach (Directory subdirectory in currentDirectory.subdirectories) {
                if (subdirectory.name == dirName) {
                    currentDirectory = subdirectory;
                    return;
                }
            }
            throw new System.Exception("Directory didn't exist");
        }
    }
}