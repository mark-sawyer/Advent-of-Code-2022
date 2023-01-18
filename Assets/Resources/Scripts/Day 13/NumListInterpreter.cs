
namespace advent13 {
    public static class NumListInterpreter {
        public static NumList interpretString(string definition) {
            NumList parent = null;
            NumList currentNumList = new NumList(parent);
            NumList newChild;

            int len = definition.Length;
            int stringIndex = 1;
            while (stringIndex < len - 1) {
                if (definition[stringIndex] == '[') {
                    newChild = new NumList(currentNumList);
                    currentNumList.childNumList.Add(newChild);
                    currentNumList = newChild;
                }
                else if (definition[stringIndex] == ']') {
                    currentNumList = currentNumList.parent;
                }
                else if (definition[stringIndex] != ',') {
                    int steps = stepsToNonNumber(stringIndex, definition);
                    string numString = definition.Substring(stringIndex, steps);
                    int num = int.Parse(numString);
                    newChild = new NumList(currentNumList, num);
                    currentNumList.childNumList.Add(newChild);
                    stringIndex += steps - 1;
                }

                stringIndex++;
            }

            return currentNumList;
        }

        private static int stepsToNonNumber(int currentIndex, string definition) {
            int steps = 1;
            while (
                definition[currentIndex + steps] != '[' &&
                definition[currentIndex + steps] != ']' &&
                definition[currentIndex + steps] != ','
            ) {
                steps++;
            }
            return steps;
        }
    }
}
