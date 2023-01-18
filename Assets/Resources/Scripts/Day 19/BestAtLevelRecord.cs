
namespace advent19 {
    public class BestAtLevelRecord {
        private int[] records = new int[Constants.TOTAL_TIME];





        public bool testShouldStop(int geodes, int level) {
            int currentRecord = records[level];
            return geodes < currentRecord;
        }
        public bool testNewRecord(int geodes, int level) {
            int currentRecord = records[level];
            return geodes > currentRecord;
        }
        public void setNewRecord(int geodes, int level) {
            records[level] = geodes;
        }
        public int getFinalRecord() {
            return records[Constants.TOTAL_TIME - 1];
        }
    }
}
