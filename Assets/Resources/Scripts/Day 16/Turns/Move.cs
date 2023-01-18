
namespace advent16 {
    public class Move : TurnAction {
        public void exe(Valve valve) {
            StateInformation.timeLeft -= StateInformation.distanceWouldMove();
            StateInformation.at = valve;
        }
        public bool isPossible(Valve valve) {
            return StateInformation.timeLeft >= StateInformation.distanceWouldMove();
        }
        public int turnsPassed() {
            return StateInformation.distanceWouldMove();
        }
    }
}
