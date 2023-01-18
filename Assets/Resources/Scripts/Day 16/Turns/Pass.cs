
namespace advent16 {
    public class Pass : TurnAction {
        public void exe(Valve valve) {
            StateInformation.timeLeft -= 1;
        }
        public bool isPossible(Valve valve) {
            return StateInformation.timeLeft >= 1;
        }
        public int turnsPassed() { return 1; }
    }
}
