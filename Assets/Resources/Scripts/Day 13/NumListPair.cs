
namespace advent13 {
    public class NumListPair {
        public NumList numListOne;
        public NumList numListTwo;
        public bool correctOrder;
        private bool comparisonFinished;

        public NumListPair(string stringOne, string stringTwo) {
            numListOne = NumListInterpreter.interpretString(stringOne);
            numListTwo = NumListInterpreter.interpretString(stringTwo);
        }

        public NumListPair(NumList numListOne, NumList numListTwo) {
            this.numListOne = numListOne;
            this.numListTwo = numListTwo;
        }

        public void determineCorrectOrder() {
            compareNumLists(numListOne, numListTwo);
        }

        public void compareNumLists(NumList one, NumList two) {
            // Only called on NumLists in list mode.
            if (comparisonFinished) return;

            int index = 0;
            bool oneHasNextchild;
            bool twoHasNextchild;

            while (!comparisonFinished) {
                oneHasNextchild = index < one.childNumList.Count;
                twoHasNextchild = index < two.childNumList.Count;

                if (!oneHasNextchild && !twoHasNextchild) return;
                else if (oneHasNextchild && !twoHasNextchild) {
                    correctOrder = false;
                    comparisonFinished = true;
                    return;
                }
                else if (!oneHasNextchild && twoHasNextchild) {
                    correctOrder = true;
                    comparisonFinished = true;
                    return;
                }
                else if (oneHasNextchild && twoHasNextchild) {
                    NumList childOne = one.childNumList[index];
                    NumList childTwo = two.childNumList[index];

                    if (childOne.mode == Mode.LIST && childTwo.mode == Mode.LIST) compareNumLists(childOne, childTwo);
                    else if (childOne.mode == Mode.NUMBER && childTwo.mode == Mode.LIST) {
                        childOne.convertToListMode();
                        compareNumLists(childOne, childTwo);
                    }
                    else if (childOne.mode == Mode.LIST && childTwo.mode == Mode.NUMBER) {
                        childTwo.convertToListMode();
                        compareNumLists(childOne, childTwo);
                    }
                    else if (childOne.mode == Mode.NUMBER && childTwo.mode == Mode.NUMBER) {
                        if (childOne.num > childTwo.num) {
                            correctOrder = false;
                            comparisonFinished = true;
                            return;
                        }
                        else if (childOne.num < childTwo.num) {
                            correctOrder = true;
                            comparisonFinished = true;
                            return;
                        }
                    }
                }

                index++;
            }
        }
    }
}
