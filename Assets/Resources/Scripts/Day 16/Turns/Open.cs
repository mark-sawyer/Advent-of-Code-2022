
namespace advent16 {
    public class Open : TurnAction {
        public void exe(Valve valve) {
            StateInformation.onValves.Add(valve);
            valve.open = true;
            StateInformation.timeLeft -= 1;
        }
        public bool isPossible(Valve valve) {
            return valve == StateInformation.at &&
                !valve.open &&
                StateInformation.timeLeft >= 1;
        }
        public int turnsPassed() { return 1; }
    }
}
