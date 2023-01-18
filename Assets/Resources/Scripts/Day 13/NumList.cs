using System.Collections.Generic;

namespace advent13 {
    public class NumList {
        public NumList parent;
        public Mode mode;
        public List<NumList> childNumList;
        public int num;

        public NumList(NumList parent) {
            this.parent = parent;
            childNumList = new List<NumList>();
            mode = Mode.LIST;
        }

        public NumList(NumList parent, int num) {
            this.parent = parent;
            this.num = num;
            mode = Mode.NUMBER;
        }

        public void convertToListMode() {
            mode = Mode.LIST;
            childNumList = new List<NumList>();
            NumList child = new NumList(this, num);
            childNumList.Add(child);
        }
    }
}
