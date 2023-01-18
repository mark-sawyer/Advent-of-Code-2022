
namespace advent19 {
    public static class Time {
        public static int timeLeft { get; private set; } = Constants.TOTAL_TIME;
        public static void decrementTime() {
            timeLeft--;
        }
        public static void incrementTime() {
            timeLeft++;
        }
        public static void resetTime() {
            timeLeft = Constants.TOTAL_TIME;
        }
    }
}
