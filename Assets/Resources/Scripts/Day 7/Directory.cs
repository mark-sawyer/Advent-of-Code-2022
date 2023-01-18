using System.Collections;
using System.Collections.Generic;

namespace advent7 {
    public class Directory {
        public string name;
        public Directory parent;
        public List<Directory> subdirectories = new List<Directory>();
        public List<int> files = new List<int>();
        public int sizeOfFiles;
        public int totalSize;

        public Directory(string name) { this.name = name; }

        public void addParent(Directory p) { parent = p; }

        public void findSizes() {
            foreach (Directory subdirectory in subdirectories)
                subdirectory.findSizes();

            foreach (int i in files)
                sizeOfFiles += i;

            totalSize = sizeOfFiles;
            foreach (Directory subdirectory in subdirectories)
                totalSize += subdirectory.totalSize;
        }

        public void addIfNotBiggerThan(List<int> sizes, int max) {
            foreach (Directory subdirectory in subdirectories) subdirectory.addIfNotBiggerThan(sizes, max);
            if (totalSize <= max) sizes.Add(totalSize);
        }

        public void addIfAtLeast(List<int> sizes, int min) {
            foreach (Directory subdirectory in subdirectories) subdirectory.addIfAtLeast(sizes, min);
            if (totalSize >= min) sizes.Add(totalSize);
        }
    }
}
